namespace Demo._5_自定义控件的缩放
{
    partial class UserControlForm2
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "动态添加三个usercontrol";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 400);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(795, 73);
            this.label2.TabIndex = 2;
            this.label2.Tag = "NoScale";
            this.label2.Text = "注意点：\r\n1. 此例演示如何动态添加自定义控件并且该自定义控件类内部没有做缩放自适应处理的情况。\r\n我们希望不破坏该自定义控件类里的代码，又能做到给该类的实例添" +
    "加缩放功能，因此采用了挂载这一方法，详情请看代码。\r\n如果自定义控件类里已经做了大小自适应，那么不需要挂载。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // UserControlForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "UserControlForm2";
            this.Text = "UserControlForm2";
            this.SizeChanged += new System.EventHandler(this.UserControlForm2_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}