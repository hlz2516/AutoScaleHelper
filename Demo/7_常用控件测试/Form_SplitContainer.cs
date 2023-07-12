using AutoScaleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo._7_常用控件测试
{
    public partial class Form_SplitContainer : Form
    {
        AutoScale autoScaleForPnl1 = new AutoScale();
        AutoScale autoScaleForPnl2 = new AutoScale();
        AutoScale autoScale = new AutoScale();  //这个缩放辅助在只存在splitcontainer的窗体中加了也没用，这里只是为了演示加了不会报错

        public Form_SplitContainer()
        {
            InitializeComponent();
            autoScaleForPnl1.AutoFont = true;
            autoScaleForPnl1.SetContainer(splitContainer1.Panel1);
            autoScaleForPnl2.AutoFont = true;
            autoScaleForPnl2.SetContainer(splitContainer1.Panel2);
            autoScale.AutoFont = true;
            autoScale.SetContainer(this);
        }

        private void Form_SplitContainer_SizeChanged(object sender, EventArgs e)
        {
            this.splitContainer1.SuspendLayout();
            autoScaleForPnl1.UpdateControlsLayout();
            autoScaleForPnl2.UpdateControlsLayout();
            autoScale.UpdateControlsLayout();
            this.splitContainer1.ResumeLayout();
        }
    }
}
