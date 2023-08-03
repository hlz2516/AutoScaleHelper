﻿using AutoScaleHelper;
using System;
using System.Windows.Forms;

namespace Demo._7_常用控件测试
{
    public partial class Form_Panel : Form
    {
        AutoScale autoScale = new AutoScale();

        public Form_Panel()
        {
            InitializeComponent();
            //this.SetAnchorNone();
            autoScale.AutoFont = true;
            autoScale.SetContainer(this);
        }

        private void Form_Panel_SizeChanged(object sender, EventArgs e)
        {
            //凡是布局控件，均要挂起布局
            this.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();

            autoScale.UpdateControlsLayout();
            //逐一恢复布局
            this.tableLayoutPanel2.ResumeLayout();
            this.panel3.ResumeLayout();
            this.flowLayoutPanel2.ResumeLayout();
            this.tableLayoutPanel1.ResumeLayout();
            this.flowLayoutPanel1.ResumeLayout();
            this.panel2.ResumeLayout();
            this.panel1.ResumeLayout();
            this.ResumeLayout();
        }
    }
}
