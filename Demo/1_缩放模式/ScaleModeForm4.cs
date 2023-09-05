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
    public partial class ScaleModeForm4 : Form
    {
        AutoScale autoScale;
        public ScaleModeForm4()
        {
            InitializeComponent();
            panel1.SetAnchorNoneExcept(button2,button3);
            autoScale = new AutoScale(panel1);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout(false);
        }
    }
}
