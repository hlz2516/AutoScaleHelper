using AutoScaleHelper;
using System;
using System.Windows.Forms;

namespace Demo._7_常用控件测试
{
    public partial class Form_Panel : Form
    {
        AutoScale autoScale = new AutoScale();

        public Form_Panel()
        {
            InitializeComponent();
            //this.SetAnchorNone();
            autoScale.AutoFont = true;
            autoScale.SetContainer(this);
        }

        private void Form_Panel_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            this.ResumeLayout(true);
        }
    }
}
