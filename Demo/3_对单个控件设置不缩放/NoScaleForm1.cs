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

namespace Demo._3_对单个控件设置不缩放
{
    public partial class NoScaleForm1 : Form
    {
        AutoScale autoScale = new AutoScale();

        public NoScaleForm1()
        {
            InitializeComponent();
            autoScale.AutoFont = true;
            autoScale.SetContainer(this);
            //设置Button1自身不缩放
            autoScale.SetControlNoScale(button1.Name, NoScaleMode.Self);
            //设置panel1里的控件不缩放，但panel1缩放
            autoScale.SetControlNoScale(panel1.Name, NoScaleMode.Inner);
        }

        private void NoScaleForm1_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
