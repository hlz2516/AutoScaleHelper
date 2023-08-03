using AutoScaleHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo._4_动态添加控件
{
    public partial class DynaAddCtrlForm2 : Form
    {
        AutoScale autoScale = new AutoScale();

        public DynaAddCtrlForm2()
        {
            InitializeComponent();
            foreach (Control item in this.panel1.Controls)
            {
                item.SetAnchorNone();
            }
            autoScale.SetContainer(this.panel1);
            autoScale.FontDependOn(textBox2, label2);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;

            var textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(292, 125);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(139, 21);
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Font = label1.Font.Clone() as Font;
            textBox1.Text = "测试一";
            this.panel1.Controls.Add(textBox1);
            autoScale.AddControl(textBox1);
            autoScale.FontDependOn(textBox1, label1);

            autoScale.UpdateControlsLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;

            var txt1 = panel1.Controls["textBox1"];
            panel1.Controls.Remove(txt1);
            autoScale.RemoveControl(txt1);
            autoScale.RelieveFontDependency(txt1, label1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;

            panel1.Controls.Remove(label2);
            autoScale.RemoveControl(label2);
            autoScale.RelieveFontDependency(label2);
        }
    }
}
