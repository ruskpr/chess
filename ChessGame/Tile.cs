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
        public Piece CurrentPiece { get; set; }
        public bool Selected { get; set; }

        private Color originalColor;

        public Tile(Form pntr, Size size, Point boardlocation, int arrX,int arrY, Color color)
        {
            //mainForm = pntr;
            
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = color;
            originalColor = color;
            Size = size;
            Location = boardlocation;
            Image = null;
            CoordinateX = arrX;
            CoordinateY = arrY;
            Selected = false;
            CurrentPiece = null;
            

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

                if (CurrentPiece != null)
                {
                    
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


        public void CreatePiece(string piecename, int player)
        {
            // parse integer parameter to Player enum from Piece class
            Piece.Player selectedPlayer = player == 1 ? Piece.Player.Player_One : Piece.Player.Player_Two;

            //only add piece if tile is empty
            if (CurrentPiece == null)
            {
                switch (piecename)
                {
                    case "pawn":
                        CurrentPiece = new Pawn(selectedPlayer, this); break;
                    case "rook":
                        CurrentPiece = new Rook(selectedPlayer, this); break;
                    case "knight":
                        CurrentPiece = new Knight(selectedPlayer, this); break;
                    case "bishop":
                        CurrentPiece = new Bishop(selectedPlayer, this); break;
                    case "queen":
                        CurrentPiece = new Queen(selectedPlayer, this); break;
                    case "king":
                        CurrentPiece = new King(selectedPlayer, this); break;
                }

                this.Image = CurrentPiece.Image;
            }
            
        }

        public override string ToString()
        {
            if (CurrentPiece == null)
            {
                return $"Empty tile at {CoordinateX}, {CoordinateY}";
            }
            else
                return $"{CurrentPiece.ToString()} at {CoordinateX}, {CoordinateY}";

        }
    }
}
