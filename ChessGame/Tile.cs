using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Tile : PictureBox
    {
        static Form mainForm;
        
        public Tile(Form pntr, Size size, Point location, Color color)
        {
            mainForm = pntr;
            Image = null;
            BackColor = color;
            Size = size;
            Location = location;    

            mainForm.Controls.Add(this);
        }
    }
}
