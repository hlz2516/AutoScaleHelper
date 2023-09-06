using AutoScaleHelper;
using Demo._5_自定义控件的缩放;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo.一些测试
{
    public partial class TestForm1 : Form
    {
        AutoScale autoScale;

        public TestForm1()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                UpdateTableHeight();
            }
            autoScale = new AutoScale(this);
        }

        private void UpdateTableHeight()
        {
            int totalHeight = 0;
            foreach (RowStyle rowStyle in tableLayoutPanel1.RowStyles)
            {
                totalHeight += (int)rowStyle.Height;
            }
            tableLayoutPanel1.Height = totalHeight;
        }

        private void TestForm1_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }
    }
}
