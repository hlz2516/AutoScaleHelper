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

namespace Demo._7_常用控件测试
{
    public partial class Form_Textbox : Form
    {
        AutoScale autoScale = new AutoScale();
        public Form_Textbox()
        {
            InitializeComponent();
            autoScale.AutoFont = true;
            //textbox1的字体依赖于label1
            autoScale.FontDependOn(textBox1, label1);
            // textBox3, textBox4的字体依赖于label3
            autoScale.FontDependOn(label3, textBox3, textBox4);
            autoScale.FontDependOn(maskedTextBox1, label4);

            autoScale.SetContainer(this);
        }

        private void Form_Textbox_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();
        }

        /*
         * 网格布局里的label设置了anchor=right+top，autosize=false
         * textbox设置了anchor = left+top，注意，因为这里的left+top是有意义的，所以不能调用SetAnchorNone方法
         * textbox的TextAlign设置为Top+Right，并且设置margin的top为6
         */
    }
}
