using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoScaleHelper;

namespace Demo._2_设定锚
{
    public partial class AnchorForm2 : Form
    {
        AutoScale autoScale = null;

        public AnchorForm2()
        {
            InitializeComponent();
            this.SetAnchorNoneExcept(button2);
            autoScale = new AutoScale(this);
        }
    }
}
