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
    }
}
