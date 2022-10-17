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
        static Bitmap WhitePawnImg = new Bitmap("assets/pieces/pack1/WhitePawn.png");
        static Bitmap BlackRookImg = new Bitmap("assets/pieces/pack1/BlackRook.png");
        static Bitmap WhiteRookImg = new Bitmap("assets/pieces/pack1/WhiteRook.png");
        static Bitmap BlackKnightImg = new Bitmap("assets/pieces/pack1/BlackKnight.png");
        static Bitmap WhiteKnightImg = new Bitmap("assets/pieces/pack1/WhiteKnight.png");
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
                Image = WhiteKnightImg;
            if (e.Button == MouseButtons.Right)
                Image = BlackKnightImg;
        }
    }
}
