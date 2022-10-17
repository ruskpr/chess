using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    static class Format
    {
        public static void Center(Control control)
        {
            Control parent = control.Parent;
            //control.Height = parent.Height - 50;
            //control.Width = parent.Height - 50;
            control.Left = parent.Width / 2 - (control.Width / 2);
            control.Top = parent.Height / 2 - (control.Height / 2);


        }
        public static void CenterWithoutSizeChange(Control control)
        {
            Control parent = control.Parent;
            control.Left = parent.Width / 2 - (control.Width / 2);
            control.Top = parent.Height / 2 - (control.Height / 2);

        }
    }
}
