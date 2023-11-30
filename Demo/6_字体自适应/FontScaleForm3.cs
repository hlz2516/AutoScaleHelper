using AutoScaleHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo._6_字体自适应
{
    public partial class FontScaleForm3 : Form
    {
        AutoScaleEx scaleEx = new AutoScaleEx();

        public FontScaleForm3()
        {
            InitializeComponent();
            //Console.WriteLine("中文字体大小:" + button2.Font.Size);
            //Console.WriteLine("英文字体大小:" + button7.Font.Size);
            this.SetAnchorNone();
            scaleEx.AutoFont = true;
            scaleEx.SetContainer(this);
        }

        private void FontScaleForm3_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            scaleEx.UpdateControlsLayout();
            this.ResumeLayout();
            //Console.WriteLine("中文字体大小:" + button2.Font.Size);
            //Console.WriteLine("英文字体大小:" + button7.Font.Size);
        }
    }

    public class AutoScaleEx : AutoScale
    {
        protected override void SetControlFontSize(Control curCtrl, CtrlInfo ctrlInfo)
        {
            //效果：字体高度随容器高度线性变化
            //根据设计器时期的字体大小与高度的比例计算得到当前字体大小
            float fontSize = ctrlInfo.Font.Size / ctrlInfo.Rect.Height * curCtrl.Height;
            curCtrl.Font = new Font(curCtrl.Font.Name, fontSize, curCtrl.Font.Style);
        }
    }
}
