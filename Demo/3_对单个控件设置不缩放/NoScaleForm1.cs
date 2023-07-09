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
            autoScale.SetContainer(this);
        }

        private void NoScaleForm1_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
