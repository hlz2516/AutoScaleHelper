using AutoScaleHelper;
using System;
using System.Windows.Forms;

namespace Demo._5_自定义控件的缩放
{
    public partial class UserControlForm2 : Form
    {
        AutoScale autoScale = new AutoScale();

        public UserControlForm2()
        {
            InitializeComponent();
            this.SetAnchorNone();
            autoScale.SetContainer(this);
        }

        private void UserControlForm2_SizeChanged(object sender, EventArgs e)
        {
            autoScale.UpdateControlsLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1 userControl11 = new UserControl1();
            UserControl1 userControl12 = new UserControl1();
            UserControl1 userControl13 = new UserControl1();

            this.SuspendLayout();
            // 
            // userControl11
            // 
            userControl11.Content = "测试1";
            userControl11.Icon = global::Demo.Properties.Resources.二哈;
            userControl11.Location = new System.Drawing.Point(74, 180);
            userControl11.Name = "userControl11";
            userControl11.Size = new System.Drawing.Size(100, 115);
            userControl11.TabIndex = 1;
            userControl11.MountAutoScale((ctrl, scale) =>
            {
                ctrl.SetAnchorNone();
                scale.ScaleMode = ScaleMode.AdaptToContainer;
                scale.AutoFont = true;
                scale.SetContainer(ctrl);
                ctrl.SizeChanged += (s, eve) =>
                {
                    scale.UpdateControlsLayout();
                };
            });
            // 
            // userControl12
            // 
            userControl12.Content = "测试2";
            userControl12.Icon = global::Demo.Properties.Resources.二哈;
            userControl12.Location = new System.Drawing.Point(335, 180);
            userControl12.Name = "userControl12";
            userControl12.Size = new System.Drawing.Size(100, 115);
            userControl12.TabIndex = 2;
            userControl12.MountAutoScale((ctrl, scale) =>
            {
                ctrl.SetAnchorNone();
                scale.ScaleMode = ScaleMode.MaintainSelfRatioH;
                scale.AutoFont = true;
                scale.SetContainer(ctrl);
                ctrl.SizeChanged += (s, eve) =>
                {
                    scale.UpdateControlsLayout();
                };
            });
            // 
            // userControl13
            // 
            userControl13.Content = "测试3";
            userControl13.Icon = global::Demo.Properties.Resources.二哈;
            userControl13.Location = new System.Drawing.Point(580, 180);
            userControl13.Name = "userControl13";
            userControl13.Size = new System.Drawing.Size(100, 115);
            userControl13.TabIndex = 3;
            userControl13.MountAutoScale((ctrl, scale) =>
            {
                ctrl.SetAnchorNone();
                scale.ScaleMode = ScaleMode.MaintainSelfRatioV;
                scale.AutoFont = true;
                scale.SetContainer(ctrl);
                ctrl.SizeChanged += (s, eve) =>
                {
                    scale.UpdateControlsLayout();
                };
            });

            this.Controls.Add(userControl13);
            this.Controls.Add(userControl12);
            this.Controls.Add(userControl11);

            button1.Enabled = false;

            autoScale.AddControl(userControl11);
            autoScale.AddControl(userControl12);
            autoScale.AddControl(userControl13);
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();
        }
    }
}
