namespace Demo._5_自定义控件的缩放
{
    partial class UserControlForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControl11 = new Demo._5_自定义控件的缩放.UserControl1();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userControl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControl11.Content = "二哈";
            this.userControl11.Icon = global::Demo.Properties.Resources.二哈;
            this.userControl11.Location = new System.Drawing.Point(338, 157);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(100, 115);
            this.userControl11.TabIndex = 0;
            // 
            // UserControlForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userControl11);
            this.Name = "UserControlForm1";
            this.Text = "UserControlForm1";
            this.SizeChanged += new System.EventHandler(this.UserControlForm1_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 userControl11;
    }
}