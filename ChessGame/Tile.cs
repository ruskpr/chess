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
        #region Delegate Events
        public static event SendTileDelegate SendSelectedTile;
        public static event SendTileDelegate SendTargetTile;
        public static event CreateTestPieceDelegate CreateTestPiece;
        #endregion
        #region Properties
        public Board ParentBoard { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Piece CurrentPiece { get; set; }
        public bool Selected { get; set; }
        public bool IsAValidSpace { get; set; }
        #endregion
        #region Fields
        private Color originalColor;
        #endregion
        #region Constructor
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
        #endregion
        #region Mouse down event
        private void Tile_MouseDown(object? sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left)
            {
                foreach (Tile tile in ParentBoard.Tiles) // reset all tiles to original color when new tile is clicked
                    tile.UnSelect();

                if (IsAValidSpace) // move piece if it is marked as a valid space
                    SendTargetTile.Invoke(this);

                Select();
            }
        }
        #endregion
        #region Select / Unselect methods
        public new void Select()
        {
            SendSelectedTile?.Invoke(this);
            Selected = true;
            BackColor = GameManager.SelectionColor;
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
        #region Remove piece
        public void RemovePiece()
        {
            CurrentPiece = null;
            Image = null;
            BackgroundImage = null;
        }
        #endregion
        #region Tostring override
        public override string ToString() =>
            CurrentPiece == null ? 
            $"Empty tile at {CoordinateX}, {CoordinateY}" :
            $"{CurrentPiece} at {CoordinateX}, {CoordinateY}";
        #endregion
    }
}
