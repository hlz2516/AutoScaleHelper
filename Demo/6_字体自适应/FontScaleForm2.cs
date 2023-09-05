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

namespace Demo._6_字体自适应
{
    public partial class FontScaleForm2 : Form
    {
        TextScale textScale = new TextScale();
        public FontScaleForm2()
        {
            InitializeComponent();
            textScale.SetContainer(tableLayoutPanel1);
            textScale.FontDependOn(label1, comboBox1);
        }

        private void tableLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.SuspendLayout();
            textScale.ScaleArea(tableLayoutPanel1);
            //textScale.ScaleSingle(label1,ScaleMode.MaintainSelfRatioH);
            tableLayoutPanel1.ResumeLayout(false);
        }
    }
}
