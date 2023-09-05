using Demo._1_缩放模式;
using Demo._2_设定锚;
using Demo._3_对单个控件设置不缩放;
using Demo._4_动态添加控件;
using Demo._5_自定义控件的缩放;
using Demo._6_字体自适应;
using Demo._7_常用控件测试;
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

            //Application.Run(new ScaleModeForm1());
            //Application.Run(new ScaleModeForm2());
            //Application.Run(new ScaleModeForm3());
            Application.Run(new ScaleModeForm4());
            //Application.Run(new AnchorForm1());
            //Application.Run(new NoScaleForm1());
            //Application.Run(new DynaAddCtrlForm1());
            //Application.Run(new DynaAddCtrlForm2());
            //Application.Run(new UserControlForm1());
            //Application.Run(new UserControlForm2());
            //Application.Run(new FontScaleForm1());
            //Application.Run(new Form_Button());
            //Application.Run(new Form_CheckedListBox());
            //Application.Run(new Form_Combobox());
            // Application.Run(new Form_DataGridView());
            //Application.Run(new Form_Groupbox());
            //Application.Run(new Form_Label());
            //Application.Run(new Form_ListBox());
            //Application.Run(new Form_ListView());
            //Application.Run(new Form_Panel());
            //Application.Run(new Form_PictureBox());
            //Application.Run(new Form_RadioAndCheck());
            //Application.Run(new Form_SplitContainer());
            //Application.Run(new Form_TagPage());
            //Application.Run(new Form_Textbox());
            //Application.Run(new Form_ToolStrip());
            //Application.Run(new Form_ToolstripContainer());
            //Application.Run(new Form_TreeView());
            //Application.Run(new Form_Others());
            //Application.Run(new Form_Chart1());
            //Application.Run(new Form1());
        }
    }
}
