using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public delegate void SendTileDelegate(Tile tile);
    public delegate void CreateTestPieceDelegate(Tile tile);
    public class Tile : PictureBox
    {
        public static event SendTileDelegate SendTile;
        public static event CreateTestPieceDelegate CreateTestPiece;
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



        public Board ParentBoard { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Piece CurrentPiece { get; set; }
        public bool Selected { get; set; }
        public bool IsAValidSpace { get; set; }

        private Color originalColor;

        public Tile(Board board, Size size, Point boardlocation, int arrX,int arrY, Color color)
        {
            ParentBoard = board;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = color;
            originalColor = color;
            Size = size;
            Location = boardlocation;
            Image = null;
            BackgroundImage = null;
            CoordinateX = arrX;
            CoordinateY = arrY;
            Selected = false;
            IsAValidSpace = false;
            CurrentPiece = null;

            this.MouseDown += Tile_MouseDown;

            board.Controls.Add(this);
        }
        #region Mouse down event
        private void Tile_MouseDown(object? sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left)
            {
                if (IsAValidSpace) // move piece if it is marked as a valid space
                {
                    //ParentBoard.
                }
                
                foreach (Tile tile in ParentBoard.Tiles)
                    tile.UnSelect();


                Select();
            }

            if (TestForm.TestingMode == true)
                if (e.Button == MouseButtons.Right)
                {
                    Select();
                    CreateTestPiece.Invoke(this);
                }
                    

        }
        #endregion
        #region Select / Unselect methods
        public void Select()
        {
            SendTile?.Invoke(this);
            Selected = true;
            BackColor = Color.Teal;
        }
        void UnSelect()
        {
            Selected = false;
            BackColor = originalColor;
        }
        #endregion
        #region Create piece
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

                this.BackgroundImage = CurrentPiece?.Image;

            }

        }
        #endregion

        #region Tostring override
        public override string ToString()
        {
            if (CurrentPiece == null)
            {
                return $"Empty tile at {CoordinateX}, {CoordinateY}";
            }
            else
                return $"{CurrentPiece.ToString()} at {CoordinateX}, {CoordinateY}";

        }
        #endregion
    }
}
