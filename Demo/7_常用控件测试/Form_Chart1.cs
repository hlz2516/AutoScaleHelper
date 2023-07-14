using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Demo._7_常用控件测试
{
    public partial class Form_Chart1 : Form
    {
        AutoScaleHelper.AutoScale autoScale;

        public Form_Chart1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                //动态添加Point
                DataPoint dataPoint = new DataPoint();
                dataPoint.YValues[0] = new Random().NextDouble();
                chart1.Series[0].Points.Add(dataPoint);
            }
            autoScale = new AutoScaleHelper.AutoScale(this);
        }

        private void Form_Chart1_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
