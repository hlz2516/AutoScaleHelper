using AutoScaleHelper;
using Demo._5_自定义控件的缩放;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo.一些测试
{
    public partial class TestForm1 : Form
    {
        AutoScale autoScale;

        public TestForm1()
        {
            InitializeComponent();
            autoScale = new AutoScale(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userCtrl = new UserControl1();
            userCtrl.Content = "测试";
            userCtrl.Icon = Properties.Resources.二哈;
            userCtrl.Size = new Size(100, 100);
            userCtrl.Location = new Point(100, 100);
            panel1.Controls.Add(userCtrl);
        }

        private void TestForm1_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
