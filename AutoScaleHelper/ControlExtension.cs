using System.Windows.Forms;

namespace AutoScaleHelper
{
    public delegate void ControlScaleAction(Control ctrl, AutoScale autoScale);

    public static class ControlExtension
    {
        /// <summary>
        /// 设置该控件内的所有子控件的锚定位为空，包括该控件。
        /// </summary>
        /// <param name="ctrl"></param>
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
        /// <summary>
        /// 设置ListView的列头的缩放模式。
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="mode"></param>
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
        /// <summary>
        /// 给一个自定义控件挂载一个AutoScale实例（自动创建）
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="action"></param>
        public static void MountAutoScale(this UserControl ctrl, ControlScaleAction action)
        {
            AutoScale autoScale = new AutoScale();
            action?.Invoke(ctrl, autoScale);
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
    ///对 ListView列宽度的缩放模式的扩展（请优先考虑AutoResizeColumns方法，如果没有找到合适的，再来考虑使用该方法）
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
