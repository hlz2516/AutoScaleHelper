using Demo._1_缩放模式;
using Demo._2_设定锚;
using Demo._3_对单个控件设置不缩放;
using Demo._4_动态添加控件;
using Demo._5_自定义控件的缩放;
using Demo._6_字体自适应;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
