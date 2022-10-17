using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Tile : PictureBox
    {
        public enum ContainingPiece
        {
            None,
            Pawn,
            Rook,
            Bishop,
            Queen,
            King
        }

        static Form mainForm;

        //array of tiles
        public static Tile[,] Tiles = new Tile[8, 8];

        public int[,] Coordinate { get; set; }
        public ContainingPiece Piece { get; set; }
        
        

        public Tile(Form pntr, Size size, Point boardlocation, int[,] arrloc, Color color)
        {
            //mainForm = pntr;
            Image = null;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = color;
            Size = size;
            Location = boardlocation;
            Coordinate = arrloc;
            Piece = ContainingPiece.None;
            this.MouseDown += Tile_MouseDown;

            pntr.Controls.Add(this);
        }

        private void Tile_MouseDown(object? sender, MouseEventArgs e)
        {
            //MessageBox.Show(Coordinate[0,1].ToString());
            if (e.Button == MouseButtons.Left)
                Image = MyAssets.B_KnightImg;
            if (e.Button == MouseButtons.Right)
                Image = MyAssets.W_KnightImg;
        }
    }
}
