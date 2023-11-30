using AutoScaleHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo._6_字体自适应
{
    public partial class FontScaleForm4 : Form
    {
        TextScaleEx scaleEx = new TextScaleEx();
        public FontScaleForm4()
        {
            InitializeComponent();
            scaleEx.SetContainer(tableLayoutPanel1);
        }

        private void tableLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.SuspendLayout();
            scaleEx.ScaleArea(tableLayoutPanel1);
            tableLayoutPanel1.ResumeLayout(false);
        }
    }

    public class TextScaleEx : TextScale
    {
        protected override void SetControlFontSize(Control curCtrl, CtrlInfo ctrlInfo)
        {
            //效果：字体高度随容器宽度线性变化
            //根据设计器时期的字体大小与其容器宽度的比例计算得到当前字体大小
            float fontSize = ctrlInfo.Font.Size / ctrlInfo.Rect.Width * curCtrl.Width;
            curCtrl.Font = new Font(curCtrl.Font.Name, fontSize, curCtrl.Font.Style);
        }
    }
}
