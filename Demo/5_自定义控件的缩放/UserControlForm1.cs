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

namespace Demo._5_自定义控件的缩放
{
    public partial class UserControlForm1 : Form
    {
        AutoScale autoScale = new AutoScale();
        AutoScale autoScaleForUC = new AutoScale();

        public UserControlForm1()
        {
            InitializeComponent();
            autoScale.SetContainer(this);
            userControl11.SetAnchorNone();
            autoScaleForUC.SetContainer(userControl11);
        }

        private void UserControlForm1_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            autoScaleForUC.UpdateControlsLayout();
            this.ResumeLayout();
        }
    }
}
