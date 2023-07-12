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
    public partial class Form_Others : Form
    {
        AutoScale autoScale = new AutoScale();

        public Form_Others()
        {
            InitializeComponent();
            autoScale.AutoFont = true;
            autoScale.FontDependOn(label1, numericUpDown1, domainUpDown1,  dateTimePicker1);
            autoScale.SetContainer(panel1);
        }

        private void Form_Others_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();
        }
    }
}
