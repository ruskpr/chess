using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public static class Format
    {
        public static void CenterBoard(Control control)
        {
            Control parent = control.Parent;
            //control.Height = parent.Height - 50;
            //control.Width = parent.Height - 50;
            control.Left = parent.Width / 2 - (control.Width / 2);
            control.Top = parent.Height / 2 - (control.Height / 2);
            control.Left -= control.Width / 4;
        }
        public static void CenterWithoutSizeChange(Control control)
        {
            Control parent = control.Parent;
            control.Left = parent.Width / 2 - (control.Width / 2);
            control.Top = parent.Height / 2 - (control.Height / 2);

        }
    }
}
