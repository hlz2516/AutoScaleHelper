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

namespace Demo._2_设定锚
{
    public partial class AnchorForm1 : Form
    {
        AutoScale autoScale = new AutoScale();
        public AnchorForm1()
        {
            InitializeComponent();
            autoScale.SetContainer(this);
        }

        private void AnchorForm1_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();
        }
    }
}
