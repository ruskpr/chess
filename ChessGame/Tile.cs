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

        static Bitmap BlackPawnImg = new Bitmap("assets/pieces/pack1/BlackPawn.png");
        static Bitmap whitePawnImg = new Bitmap("assets/pieces/pack1/WhitePawn.png");
        public Tile(Form pntr, Size size, Point location, Color color)
        {
            //mainForm = pntr;
            Image = null;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = color;
            Size = size;
            Location = location;
            this.MouseDown += Tile_MouseDown;

            pntr.Controls.Add(this);
        }

        private void Tile_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Image = whitePawnImg;
            if (e.Button == MouseButtons.Right)
                Image = BlackPawnImg;
        }
    }
}
