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

namespace Demo._1_缩放模式
{
    public partial class ScaleModeForm1 : Form
    {
        AutoScale autoScale = new AutoScale();

        public ScaleModeForm1()
        {
            InitializeComponent();
            autoScale.SetContainer(this);
        }

        private void ScaleModeForm1_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();
        }
    }
}
