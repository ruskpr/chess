using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public delegate void SendSelectionDelegate(Tile tile);
    
    public class Tile : PictureBox
    {
        public static event SendSelectionDelegate SendSelection;
        //public enum ContainingPiece
        //{
        //    None,
        //    Pawn,
        //    Rook,
        //    Bishop,
        //    Queen,
        //    King
        //}
        

        static Form mainForm;

        //array of tiles
        public static Tile[,] Tiles = new Tile[8, 8];

        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Piece ContainingPiece { get; set; }
        public bool Selected { get; set; }

        private Color originalColor;

        public Tile(Form pntr, Size size, Point boardlocation, int arrX,int arrY, Color color)
        {
            //mainForm = pntr;
            Image = null;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = color;
            originalColor = color;
            Size = size;
            Location = boardlocation;

            CoordinateX = arrX;
            CoordinateY = arrY;
            Selected = false;
            ContainingPiece = null;
            this.MouseDown += Tile_MouseDown;

            pntr.Controls.Add(this);
        }

        private void Tile_MouseDown(object? sender, MouseEventArgs e)
        {
            //MessageBox.Show(Coordinate[0,1].ToString());
            
            if (e.Button == MouseButtons.Left)
            {
                foreach (Tile tile in Tiles)
                {
                    tile.UnSelect();
                }

                Select();
            }

            //if (e.Button == MouseButtons.Right)
                //GetCoordinates();

        }

        public void Select()
        {
            SendSelection?.Invoke(this);
            Selected = true;
            BackColor = Color.Teal;
        }
        void UnSelect()
        {
            Selected = false;
            BackColor = originalColor;
        }

        public string GetCoordinates()
        {
            return $"{CoordinateX}, {CoordinateY}";

        }
    }
}
