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
    public partial class Form_Combobox : Form
    {
        AutoScale autoScale = new AutoScale();

        public Form_Combobox()
        {
            InitializeComponent();

            autoScale.AutoFont = true;
            autoScale.FontDependOn(comboBox1, label1);
            autoScale.SetContainer(this);
        }

        private void Form_Combobox_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
