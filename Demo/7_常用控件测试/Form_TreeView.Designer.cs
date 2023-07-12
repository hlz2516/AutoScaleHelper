namespace Demo._7_常用控件测试
{
    partial class Form_TreeView
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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点3", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点9", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点7", new System.Windows.Forms.TreeNode[] {
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("节点4", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(2, 3);
            this.treeView1.Name = "treeView1";
            treeNode11.Name = "节点5";
            treeNode11.Text = "节点5";
            treeNode12.Name = "节点1";
            treeNode12.Text = "节点1";
            treeNode13.Name = "节点0";
            treeNode13.Text = "节点0";
            treeNode14.Name = "节点6";
            treeNode14.Text = "节点6";
            treeNode15.Name = "节点3";
            treeNode15.Text = "节点3";
            treeNode16.Name = "节点10";
            treeNode16.Text = "节点10";
            treeNode17.Name = "节点9";
            treeNode17.Text = "节点9";
            treeNode18.Name = "节点7";
            treeNode18.Text = "节点7";
            treeNode19.Name = "节点8";
            treeNode19.Text = "节点8";
            treeNode20.Name = "节点4";
            treeNode20.Text = "节点4";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode15,
            treeNode20});
            this.treeView1.Size = new System.Drawing.Size(165, 237);
            this.treeView1.TabIndex = 0;
            // 
            // Form_TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 505);
            this.Controls.Add(this.treeView1);
            this.Name = "Form_TreeView";
            this.Text = "Form_TreeView";
            this.SizeChanged += new System.EventHandler(this.Form_TreeView_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}