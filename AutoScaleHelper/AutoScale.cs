using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AutoScaleHelper
{
    public delegate void ScaleEventHandler(Dictionary<string, CtrlInfo> designerInfos);

    public class AutoScale
    {
        /// <summary>
        /// 在缩放区域大小调整后发生。designerInfos记录了在界面设计器中缩放区域内的所有控件的信息，
        /// 比如location，size，font等，以控件的name作为键。
        /// </summary>
        public event ScaleEventHandler OnScale;

        private Dictionary<string, CtrlInfo> _ctrlInfos = new Dictionary<string, CtrlInfo>();
        private Dictionary<string, Size> ContainerDSizes = new Dictionary<string, Size>();
        private Dictionary<Control, List<Control>> groups =
            new Dictionary<Control, List<Control>>();
        private Control _container;
        /// <summary>
        /// 使缩放区域内的所有控件，其文本内容自适应其自身大小
        /// </summary>
        public bool AutoFont { get; set; }
        /// <summary>
        /// 缩放模式。默认AdaptToContainer。
        /// </summary>
        public ScaleMode ScaleMode { get; set; } = ScaleMode.AdaptToContainer;

        public AutoScale()
        {

        }
        /// <summary>
        /// 创建时设置缩放区域（容器）
        /// </summary>
        /// <param name="container">缩放区域（容器）</param>
        public AutoScale(Control container, bool autoFont = true)
        {
            this.AutoFont = autoFont;
            SetContainer(container);
        }
        /// <summary>
        /// 设置缩放区域（容器）。在SizeChanged事件中调用UpdateControlsLayout()时，
        /// 缩放区域内的所有非特殊控件均会自适应缩放。
        /// </summary>
        /// <param name="container">缩放区域（容器）</param>
        public void SetContainer(Control container)
        {
            if (container == null)
            {
                return;
            }

            _container = container;

            Queue<Control> queue = new Queue<Control>();
            queue.Enqueue(container);

            while (queue.Count > 0)
            {
                Control curCtrl = queue.Dequeue();

                foreach (Control ctrl in curCtrl.Controls)
                {
                    //对于特殊的控件，不加入队尾，这也意味着这些控件无法通过此实例进行自适应缩放
                    if (ctrl is Form || ctrl is ToolStrip)
                    {
                        continue;
                    }
                    //对于自定义控件，要记录该控件的ctrlinfo但其内部的子控件不做记录
                    //后者的判断是为了让自定义控件也可以应用此类进行自适应缩放
                    if (ctrl.Parent is UserControl && !(container is UserControl))
                    {
                        continue;
                    }
                    if (ctrl.Parent is DataGridView || ctrl.Parent is UpDownBase)
                    {
                        continue;
                    }

                    queue.Enqueue(ctrl);
                }

                //如果当前控件没有名字就取个名字
                if (string.IsNullOrEmpty(curCtrl.Name))
                {
                    curCtrl.Name = curCtrl.GetType().Name + Guid.NewGuid().ToString().Substring(0, 8);
                }

                if (curCtrl == _container)
                {
                    ContainerDSizes.Add(curCtrl.Name, curCtrl.ClientSize);
                    continue;
                }

                if (curCtrl is GroupBox || curCtrl is TabControl ||
                    curCtrl is Panel || curCtrl is ContainerControl)
                {
                    ContainerDSizes.Add(curCtrl.Name, curCtrl.ClientSize);
                }

                CtrlInfo ctrlInfo = new CtrlInfo();
                ctrlInfo.Anchors = curCtrl.Anchor;

                ctrlInfo.Rect = new Rectangle
                {
                    X = curCtrl.Location.X,
                    Y = curCtrl.Location.Y,
                    Width = curCtrl.Size.Width,
                    Height = curCtrl.Size.Height,
                };
                ctrlInfo.AspectRatio = curCtrl.Width * 1.0f / curCtrl.Height;
                ctrlInfo.Font = curCtrl.Font;
                FontInfos.GetFontInfo(curCtrl.Font.Name);
                ctrlInfo.FontSizeType = FontInfo.GetFontSizeType(curCtrl.Font.Size);
                ctrlInfo.parentName = curCtrl.Parent.Name;
                //if (curCtrl.Tag != null)
                //{
                //    ctrlInfo.AutoScale = !curCtrl.Tag.ToString().Contains("NoScale");
                //}

                _ctrlInfos[curCtrl.Name] = ctrlInfo;
            }
        }
        /// <summary>
        /// 对缩放区域的所有控件进行缩放，包括位置，大小，字体等属性的调整。
        /// </summary>
        public void UpdateControlsLayout()
        {
            Queue<Control> queue = new Queue<Control>();
            queue.Enqueue(_container);

            while (queue.Count > 0)
            {
                Control curCtrl = queue.Dequeue();

                foreach (Control ctrl in curCtrl.Controls)
                {
                    if (ctrl is Form || ctrl is ToolStrip)
                    {
                        continue;
                    }
                    if (ctrl.Parent is UserControl && !(_container is UserControl))
                    {
                        continue;
                    }
                    if (ctrl.Parent is DataGridView || ctrl.Parent is UpDownBase)
                    {
                        continue;
                    }

                    queue.Enqueue(ctrl);
                }
                //如果当前控件是传入的容器，则不缩放
                if (curCtrl == _container)
                {
                    continue;
                }

                if (_ctrlInfos.ContainsKey(curCtrl.Name))
                {
                    var ctrlInfo = _ctrlInfos[curCtrl.Name];
                    if (ctrlInfo.NoScale == NoScaleMode.Self)
                    {
                        continue;
                    }
                    else if (ctrlInfo.NoScale == NoScaleMode.Inner)
                    {
                        foreach (var ctrlInfoPair in _ctrlInfos)
                        {
                            //如果子控件的父容器名与当前控件的控件名相等
                            if (curCtrl.Name == ctrlInfoPair.Value.parentName)
                            {
                                //将子控件设置为自身不缩放
                                ctrlInfoPair.Value.NoScale = NoScaleMode.Self;
                            }
                        }
                    }

                    var parentSize = ContainerDSizes[curCtrl.Parent.Name];
                    //获取设计时与当前容器的(水平和垂直)缩放比例
                    float ratioH = curCtrl.Parent.ClientSize.Width * 1.0f / parentSize.Width;
                    float ratioV = curCtrl.Parent.ClientSize.Height * 1.0f / parentSize.Height;
                    int scaledWidth = ctrlInfo.Rect.Width;
                    int scaledHeight = ctrlInfo.Rect.Height;
                    //根据缩放模式算出控件缩放后的宽度和高度
                    if (ScaleMode == ScaleMode.MaintainSelfRatioH)
                    {
                        //该模式取水平方向缩放比例
                        ratioV = ratioH;
                    }
                    else if (ScaleMode == ScaleMode.MaintainSelfRatioV)
                    {
                        //该模式取垂直方向缩放比例
                        ratioH = ratioV;
                    }

                    scaledWidth = (int)(scaledWidth * ratioH);
                    scaledHeight = (int)(scaledHeight * ratioV);
                    curCtrl.Size = new Size(scaledWidth, scaledHeight);

                    //根据定位点情况决定如何缩放
                    var anchorL = ctrlInfo.Anchors & AnchorStyles.Left;
                    var anchorR = ctrlInfo.Anchors & AnchorStyles.Right;
                    var anchorT = ctrlInfo.Anchors & AnchorStyles.Top;
                    var anchorB = ctrlInfo.Anchors & AnchorStyles.Bottom;
                    //对于水平方向的定位
                    if (anchorL == AnchorStyles.None && anchorR == AnchorStyles.None)
                    {
                        //如果没有水平方向上的定位，则将位置X按照水平方向缩放比进行缩放定位
                        curCtrl.Location = new Point((int)(ctrlInfo.Rect.X * ratioH), curCtrl.Location.Y);
                    }
                    else if (anchorL == AnchorStyles.Left && anchorR == AnchorStyles.None)
                    {
                        //如果只有左定位，左边位置固定
                        curCtrl.Location = new Point(ctrlInfo.Rect.X, curCtrl.Location.Y);
                    }
                    else if (anchorR == AnchorStyles.Right && anchorL == AnchorStyles.None)
                    {
                        //如果只有右定位，用容器原工作区宽度减去控件原X和控件原宽度得到原右侧距离，
                        //用缩放后的容器后的宽度减去控件的宽度再减去原右侧距离，得到X
                        int right = parentSize.Width - ctrlInfo.Rect.X - ctrlInfo.Rect.Width;
                        //int scaledRight = (int)(right * ratioH);
                        int scaledX = curCtrl.Parent.ClientSize.Width - right - scaledWidth;
                        curCtrl.Location = new Point(scaledX, curCtrl.Location.Y);
                    }
                    else
                    {
                        //如果左右定位均有，根据左侧原距离和右侧原距离计算控件宽度
                        //int scaledLeft = (int)(ctrlInfo.Rect.X * ratioH);
                        int right = parentSize.Width - ctrlInfo.Rect.X - ctrlInfo.Rect.Width;
                        //int scaledRight = (int)(right * ratioH);
                        scaledWidth = curCtrl.Parent.ClientSize.Width - ctrlInfo.Rect.X - right;
                        if (ScaleMode == ScaleMode.MaintainSelfRatioH ||
                            ScaleMode == ScaleMode.MaintainSelfRatioV)
                        {
                            scaledHeight = (int)(scaledWidth / ctrlInfo.AspectRatio);
                        }

                        curCtrl.Size = new Size(scaledWidth, scaledHeight);
                        curCtrl.Location = new Point(ctrlInfo.Rect.X, curCtrl.Location.Y);
                    }

                    //对于垂直方向的定位
                    if (anchorT == AnchorStyles.None && anchorB == AnchorStyles.None)
                    {
                        //如果没有垂直方向上的定位，则将位置X按照垂直方向缩放比进行缩放定位
                        curCtrl.Location = new Point(curCtrl.Location.X, (int)(ctrlInfo.Rect.Y * ratioV));
                    }
                    else if (anchorT == AnchorStyles.Top && anchorB == AnchorStyles.None)
                    {
                        //如果只有顶定位，顶部位置固定
                        curCtrl.Location = new Point(curCtrl.Location.X, ctrlInfo.Rect.Y);
                    }
                    else if (anchorB == AnchorStyles.Bottom && anchorT == AnchorStyles.None)
                    {
                        //如果只有底定位，用容器原工作区高度减去控件原Y和控件原高度得到原底部距离，
                        //用缩放后的容器后的高度减去控件的高度再减去原底部距离，得到Y
                        int bottom = parentSize.Height - ctrlInfo.Rect.Y - ctrlInfo.Rect.Height;
                        //int scaledBottom = (int)(bottom * ratioV);
                        int scaledY = curCtrl.Parent.ClientSize.Height - bottom - scaledHeight;
                        curCtrl.Location = new Point(curCtrl.Location.X, scaledY);
                    }
                    else
                    {
                        //如果顶底定位均有，根据顶部原距离和底部原距离计算控件高度
                        //int scaledTop = (int)(ctrlInfo.Rect.Y * ratioV);
                        int bottom = parentSize.Height - ctrlInfo.Rect.Y - ctrlInfo.Rect.Height;
                        //int scaledBottom = (int)(bottom * ratioV);
                        scaledHeight = curCtrl.Parent.ClientSize.Height - ctrlInfo.Rect.Y - bottom;
                        if (ScaleMode == ScaleMode.MaintainSelfRatioH ||
                            ScaleMode == ScaleMode.MaintainSelfRatioV)
                        {
                            scaledWidth = (int)(scaledHeight * ctrlInfo.AspectRatio);
                        }

                        curCtrl.Size = new Size(scaledWidth, scaledHeight);
                        curCtrl.Location = new Point(curCtrl.Location.X, ctrlInfo.Rect.Y);
                    }

                    if (AutoFont)
                    {
                        //如果是仅内部控件不缩放或者字体不缩放，不改变当前控件的字体大小
                        if (ctrlInfo.NoScale == NoScaleMode.Inner || ctrlInfo.NoScale == NoScaleMode.Font)
                        {
                            continue;
                        }
                        //根据原字体行高与控件高度的比例计算缩放后的字体行高
                        int fontHeight = (int)(ctrlInfo.Font.Height * 1.0f / ctrlInfo.Rect.Height * curCtrl.Height);
                        FontInfo fontInfo = FontInfos.GetFontInfo(ctrlInfo.Font.Name);
                        float fontSize = fontInfo.GetFloorFontSizeByHeight(fontHeight, ctrlInfo.FontSizeType);
                        curCtrl.Font = new Font(ctrlInfo.Font.Name, fontSize);
                    }
                }
            }

            //针对设置了字体依赖的控件特殊处理
            foreach (var g in groups)
            {
                foreach (var item in g.Value)
                {
                    item.Font = g.Key.Font.Clone() as Font;
                }
            }

            OnScale?.Invoke(_ctrlInfos);
        }
        /// <summary>
        /// 在缩放区域内动态添加一个控件，使得该控件在缩放区域大小改变时，也能具有缩放自适应的功能。
        /// </summary>
        /// <param name="ctrl">要动态添加的控件</param>
        /// <param name="noScaleMode">不缩放模式</param>
        public void AddControl(Control ctrl, NoScaleMode noScaleMode = NoScaleMode.None)
        {
            if (ctrl.Parent != null)
            {
                var ctrlInfo = new CtrlInfo();
                ctrlInfo.Anchors = ctrl.Anchor;
                ctrlInfo.Rect = new Rectangle
                {
                    X = ctrl.Location.X,
                    Y = ctrl.Location.Y,
                    Width = ctrl.Width,
                    Height = ctrl.Height
                };
                ctrlInfo.AspectRatio = ctrl.Width * 1.0f / ctrl.Height;
                ctrlInfo.NoScale = noScaleMode;

                if (!_ctrlInfos.ContainsKey(ctrl.Name))
                {
                    _ctrlInfos.Add(ctrl.Name, ctrlInfo);
                }
            }
        }
        /// <summary>
        /// 在缩放区域内动态删除一个已具有缩放自适应功能的控件，
        /// 使得该控件在缩放区域大小改变时，不再具有缩放自适应的功能。
        /// </summary>
        /// <param name="ctrl">要动态删除的控件</param>
        public void RemoveControl(Control ctrl)
        {
            if (_ctrlInfos.ContainsKey(ctrl.Name))
            {
                _ctrlInfos.Remove(ctrl.Name);
            }
        }
        /// <summary>
        /// 指定一个控件的字体依赖于另一个目标控件，目标控件必须在缩放区域内才有效。
        /// 只有在每次容器大小发生变化时才发生更新字体操作。
        /// </summary>
        /// <param name="ctrl">需要依赖的控件</param>
        /// <param name="target">目标控件</param>
        public void FontDependOn(Control ctrl, Control target)
        {
            if (!groups.ContainsKey(target))
            {
                List<Control> g = new List<Control>();
                g.Add(ctrl);
                groups.Add(target, g);
            }
            else
            {
                var ctrls = groups[target];
                ctrls.Add(ctrl);
            }
        }

        /// <summary>
        /// 指定多个控件的字体依赖于另一个目标控件，目标控件必须在缩放区域内才有效。
        /// </summary>
        /// <param name="target">目标控件</param>
        /// <param name="ctrls">需要依赖的一组控件</param>
        public void FontDependOn(Control target, params Control[] ctrls)
        {
            if (!groups.ContainsKey(target))
            {
                List<Control> g = new List<Control>();
                g.AddRange(ctrls);
                groups.Add(target, g);
            }
            else
            {
                var _ctrls = groups[target];
                _ctrls.AddRange(ctrls);
            }
        }

        public void RelieveFontDependency(Control ctrl,Control target)
        {
            if (groups.ContainsKey(target))
            {
                var ctrls = groups[target];
                if (ctrls.Contains(ctrl))
                {
                    ctrls.Remove(ctrl);
                }
            }
        }

        public void RelieveFontDependency(Control target)
        {
            if (groups.ContainsKey(target))
            {
                groups.Remove(target);
            }
        }

        public void SetControlNoScale(string ctrlName, NoScaleMode noScale)
        {
            if (_ctrlInfos.ContainsKey(ctrlName))
            {
                var ctrlInfo = _ctrlInfos[ctrlName];
                ctrlInfo.NoScale = noScale;
            }
        }
    }
}
