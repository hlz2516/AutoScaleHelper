using System.Drawing;
using System.Windows.Forms;

namespace AutoScaleHelper
{
    /// <summary>
    /// 设计器时期记录到的控件信息
    /// </summary>
    public class CtrlInfo
    {
        /// <summary>
        /// 各边的定位。如left表示该控件左侧到父容器的左边界的距离保持固定
        /// </summary>
        public AnchorStyles Anchors;
        /// <summary>
        /// (x:控件位置的x坐标,y:控件位置的y坐标,,width:控件宽度,height:控件高度)
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
        public NoScaleMode NoScale = NoScaleMode.None;
        /// <summary>
        /// 宽高比(宽(width)/高(height))
        /// </summary>
        public float AspectRatio = 0;
        /// <summary>
        /// 父容器的控件名称
        /// </summary>
        public string parentName;
    }
    /// <summary>
    /// 缩放模式
    /// </summary>
    public enum ScaleMode
    {
        /// <summary>
        /// 缩放时，控件的缩放大小只与其容器大小成比例，即控件的宽度按照其所在容器宽度的占比进行缩放，同理对于高度。
        /// 注意，该缩放模式对于TextScale无效。
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
    /// <summary>
    ///不缩放模式
    /// </summary>
    public enum NoScaleMode
    {
        /// <summary>
        /// 正常缩放
        /// </summary>
        None,
        /// <summary>
        /// 只缩放自身而不缩放其内部子控件
        /// </summary>
        Self,
        /// <summary>
        /// 只缩放其内部子控件而不缩放自身
        /// </summary>
        Inner,
        /// <summary>
        /// 只缩放字体
        /// </summary>
        Font
    }
}
