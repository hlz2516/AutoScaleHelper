using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScaleHelper
{
    public static class ControlExtension
    {
        public static void SetAnchorNone(this Control ctrl)
        {
            if (ctrl.Anchor == (AnchorStyles.Left | AnchorStyles.Top))
            {
                ctrl.Anchor = AnchorStyles.None;
            }

            foreach (Control item in ctrl.Controls)
            {
                SetAnchorNone(item);
            }
        }

        public static void SetAutoSizeColumnsMode(this ListView lv,ListViewAutoSizeColumnsMode mode)
        {
            if (mode == ListViewAutoSizeColumnsMode.Fill)
            {
                ListviewFillWidth(lv);
                lv.SizeChanged += (s, e) =>
                {
                    ListviewFillWidth(lv);
                };
            }
            else if (mode == ListViewAutoSizeColumnsMode.Scale)
            {
               
            }
        }

        private static void ListviewFillWidth(ListView lv)
        {
            int colWidthSum = 0;
            foreach (ColumnHeader col in lv.Columns)
            {
                colWidthSum += col.Width;
            }

            foreach (ColumnHeader col in lv.Columns)
            {
                float rate = col.Width * 1.0f / colWidthSum;
                col.Width = (int)(rate * lv.ClientSize.Width);
            }
        }
    }

    /// <summary>
    /// ListView列宽度的缩放模式（本库扩展，请优先考虑AutoResizeColumns方法）
    /// </summary>
    public enum ListViewAutoSizeColumnsMode
    {
        /// <summary>
        /// 自适应容器宽度，其宽度缩放比例为原宽度比所有列宽度之和
        /// </summary>
        Fill,
        Scale
    }
}
