using AutoScaleHelper;
using System;
using System.Windows.Forms;

namespace Demo._7_常用控件测试
{
    public partial class Form_CheckedListBox : Form
    {
        AutoScale autoScale = new AutoScale();

        public Form_CheckedListBox()
        {
            InitializeComponent();
            this.SetAnchorNone();
            //如果checkedlistbox的字体缩放不依赖于某个控件，仅靠AutoFont属性的字体缩放效果可能不是很好
            autoScale.FontDependOn(checkedListBox1, button1);
            autoScale.AutoFont = true;
            autoScale.SetContainer(this);
        }

        private void Form_CheckedListBox_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
