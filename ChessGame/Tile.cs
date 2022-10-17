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
        static Bitmap whitePawnImg = new Bitmap("assets/pieces/pack1/BlackPawn.png");
        public Tile(Form pntr, Size size, Point location, Color color)
        {
            //mainForm = pntr;
            Image = null;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = color;
            Size = size;
            Location = location;
            this.Click += Tile_Click;

            pntr.Controls.Add(this);
        }

        private void Tile_Click(object? sender, EventArgs e)
        {
            Image = whitePawnImg;
        }
    }
}
