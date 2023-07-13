using System.Drawing;
using System.Windows.Forms;

namespace AutoScaleHelper
{
    public class CtrlInfo
    {
        /// <summary>
        /// 各边的定位。如left表示该控件左侧到父容器的左边界的距离保持固定
        /// </summary>
        public AnchorStyles Anchors;
        /// <summary>
        /// (x,y,width,height)
        /// </summary>
        public Rectangle Rect;
        /// <summary>
        /// 字体
        /// </summary>
        public Font Font;
        /// <summary>
        /// 字号类型
        /// </summary>
        public FontSizeType FontSizeType;
        /// <summary>
        /// 是否启用缩放自适应
        /// </summary>
        public bool AutoScale = true;
        /// <summary>
        /// 宽高比(宽(width)/高(height))
        /// </summary>
        public float AspectRatio = 0;
    }

    public enum ScaleMode
    {
        /// <summary>
        /// 缩放时，控件的缩放大小只与其容器大小成比例，即控件的宽度按照其所在容器宽度的占比进行缩放，同理对于高度
        /// </summary>
        AdaptToContainer,
        /// <summary>
        /// 缩放时，控件仍保持自身的宽高比，缩放多少只取决于其容器的水平方向上的缩放比例
        /// </summary>
        MaintainSelfRatioH,
        /// <summary>
        /// 缩放时，控件仍保持自身的宽高比，缩放多少取决于其容器的垂直方向上的缩放比例
        /// </summary>
        MaintainSelfRatioV
    }
}
