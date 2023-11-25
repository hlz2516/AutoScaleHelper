using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AutoScaleHelper
{
    /// <summary>
    /// 文本缩放自适应类。用于对某一区域或某一控件的文本进行缩放。
    /// </summary>
    public class TextScale
    {
        private Control _container;
        private Dictionary<string, CtrlInfo> _ctrlInfos = new Dictionary<string, CtrlInfo>();
        private Dictionary<Control, List<Control>> groups =
            new Dictionary<Control, List<Control>>();

        public TextScale()
        {

        }
        /// <summary>
        /// 构造时设置缩放文本区域
        /// </summary>
        /// <param name="container"></param>
        public TextScale(Control container)
        {
            SetContainer(container);
        }
        /// <summary>
        /// 设置容器。当该容器大小改变时，可控制其内部控件的字体大小自适应。
        /// </summary>
        /// <param name="container"></param>
        public void SetContainer(Control container)
        {
            //记录container所有子控件的宽高和字体信息
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
                    continue;
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
                ctrlInfo.Font = curCtrl.Font;
                FontInfos.GetFontInfo(curCtrl.Font.Name);
                ctrlInfo.FontSizeType = FontInfo.GetFontSizeType(curCtrl.Font.Size);
                ctrlInfo.parentName = curCtrl.Parent.Name;

                _ctrlInfos[curCtrl.Name] = ctrlInfo;
            }
        }
        /// <summary>
        /// 缩放（在该容器内部的）单个控件的文本字体大小
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="scaleMode"></param>
        public void ScaleSingle(Control ctrl,ScaleMode scaleMode = ScaleMode.MaintainSelfRatioV)
        {
            if (_ctrlInfos.ContainsKey(ctrl.Name))
            {
                var ctrlInfo = _ctrlInfos[ctrl.Name];
                if (scaleMode == ScaleMode.MaintainSelfRatioV)
                {
                    //根据原字体行高与控件高度的比例计算缩放后的字体行高
                    int fontHeight = (int)(ctrlInfo.Font.Height * 1.0f / ctrlInfo.Rect.Height * ctrl.Height);
                    FontInfo fontInfo = FontInfos.GetFontInfo(ctrlInfo.Font.Name);
                    float fontSize = fontInfo.GetFloorFontSizeByHeight(fontHeight, ctrlInfo.FontSizeType);
                    ctrl.Font = new Font(ctrl.Font.Name, fontSize,ctrl.Font.Style);
                }
                else if (scaleMode == ScaleMode.MaintainSelfRatioH)
                {
                    //将设计器中的控件宽度缩放比例作为字体的行高缩放比例
                    float rate = ctrl.Width * 1.0f / ctrlInfo.Rect.Width;
                    FontInfo fontInfo = FontInfos.GetFontInfo(ctrlInfo.Font.Name);
                    float fontSize = fontInfo.GetFloorFontSizeByHeight((int)(rate * ctrlInfo.Font.Height), ctrlInfo.FontSizeType);
                    ctrl.Font = new Font(ctrl.Font.Name, fontSize,ctrl.Font.Style);
                }

                //针对设置了字体依赖的控件特殊处理
                if (groups.ContainsKey(ctrl))
                {
                    var values = groups[ctrl];
                    foreach (var item in values)
                    {
                        //item.Font = ctrl.Font.Clone() as Font;
                        item.Font = new Font(item.Font.FontFamily, ctrl.Font.Size, item.Font.Style);
                    }
                }
            }
        }
        /// <summary>
        /// 缩放容器内的所有子控件的字体大小
        /// </summary>
        /// <param name="area"></param>
        /// <param name="scaleMode"></param>
        public void ScaleArea(Control area, ScaleMode scaleMode = ScaleMode.MaintainSelfRatioV)
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
                //如果当前控件是传入的容器，则直接缩放字体
                if (curCtrl == _container)
                {
                    ScaleSingle(curCtrl,scaleMode);
                    continue;
                }

                if (_ctrlInfos.ContainsKey(curCtrl.Name))
                {
                    ScaleSingle(curCtrl, scaleMode);
                }
            }
        }
        /// <summary>
        /// 指定多个控件的字体依赖于另一个目标控件，目标控件必须在容器内才有效。
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
        /// <summary>
        /// 解除一个控件对目标控件的字体依赖。
        /// </summary>
        /// <param name="ctrl">依赖控件</param>
        /// <param name="target">目标控件</param>
        public void RelieveFontDependency(Control ctrl, Control target)
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
        /// <summary>
        /// 删除所有与该目标控件相关的字体依赖。
        /// </summary>
        /// <param name="target">目标控件</param>
        public void RelieveFontDependency(Control target)
        {
            if (groups.ContainsKey(target))
            {
                groups.Remove(target);
            }
        }
    }
}
