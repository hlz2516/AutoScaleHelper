using AutoScaleHelper;
using System;
using System.Windows.Forms;

namespace Demo._7_常用控件测试
{
    public partial class Form_TagPage : Form
    {
        AutoScale autoScale = new AutoScale();

        public Form_TagPage()
        {
            InitializeComponent();
            autoScale.AutoFont = true;
            autoScale.FontDependOn(textBox1, label1);
            autoScale.SetContainer(this);
        }

        private void Form_TagPage_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
