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

namespace Demo
{
    public partial class Form1 : Form
    {
        AutoScale autoScale = new AutoScale();

        public Form1()
        {
            InitializeComponent();
            this.SetAnchorNone();
            autoScale.AutoFont = true;
            autoScale.SetContainer(this);
            //autoScale.FontDependOn(comboBox1, label1);
            //autoScale.FontDependOn(textBox1, label1);
            autoScale.FontDependOn(label1, comboBox1, textBox1);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
