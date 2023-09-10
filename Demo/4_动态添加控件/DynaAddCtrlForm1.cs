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

namespace Demo._4_动态添加控件
{
    public partial class DynaAddCtrlForm1 : Form
    {
        AutoScale autoScale = new AutoScale();
        Button button5 = new Button();
        Button button6 = new Button();

        public DynaAddCtrlForm1()
        {
            InitializeComponent();
            autoScale.SetContainer(this);
        }

        private void DynaAddCtrlForm1_SizeChanged(object sender, EventArgs e)
        {
            //this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            //this.ResumeLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            button5.Location = new System.Drawing.Point(584, 49);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(129, 44);
            button5.Text = "button5";
            button5.Anchor = AnchorStyles.None;
            button5.UseVisualStyleBackColor = true;

            this.Controls.Add(button5);
            autoScale.AddControl(button5);
            autoScale.UpdateControlsLayout();
           this.ResumeLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.RemoveControl(button5);
            this.Controls.Remove(button5);
            this.ResumeLayout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.button6.Location = new System.Drawing.Point(55, 70);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.Text = "button6";
            this.button6.Anchor = AnchorStyles.None;
            this.button6.UseVisualStyleBackColor = true;

            this.panel1.Controls.Add(this.button6);
            autoScale.AddControl(this.button6);
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.RemoveControl(this.button6);
            this.panel1.Controls.Remove(this.button6);
            this.ResumeLayout();
        }
    }
}
