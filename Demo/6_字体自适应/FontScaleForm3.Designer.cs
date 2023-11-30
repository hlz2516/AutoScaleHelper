namespace Demo._6_字体自适应
{
    partial class FontScaleForm3
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
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(67, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 84);
            this.button2.TabIndex = 2;
            this.button2.Text = "中文测试";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Yu Gothic UI", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(317, 70);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(531, 379);
            this.button7.TabIndex = 7;
            this.button7.Text = "EngTest";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // FontScaleForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 542);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button2);
            this.Name = "FontScaleForm3";
            this.Text = "FontScaleForm3";
            this.SizeChanged += new System.EventHandler(this.FontScaleForm3_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
    }
}