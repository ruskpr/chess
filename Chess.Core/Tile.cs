using Core.Pieces;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.IO;

namespace Core
{
    public class Tile : IDisposable
    {
        #region Delegate Events
        public delegate void SendTileDelegate(Tile tile);
        public static event SendTileDelegate OnSelected;
        public static event SendTileDelegate SendTargetTile;
        #endregion

        #region Properties

        public Board Board { get; set; }
        public Piece? Piece { get; set; }
        public Point Location { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Selected { get; set; }
        public bool IsAValidSpace { get { return Piece == null; } }

        #endregion

        #region Fields
        private Color originalColor;
        #endregion

        #region Constructor
        public Tile(Board board, int x, int y, Piece? piece = null)
        {
            Board = board;
            X = x;
            Y = y;
            Selected = false;
            Piece = piece;


            //this.MouseDown += Tile_MouseDown;

            //board.Controls.Add(this);
        }
        #endregion
        #region Mouse down event
        //private void Tile_MouseDown(object? sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        foreach (Tile tile in Board._board) // reset all tiles to original color when new tile is clicked
        //            tile.UnSelectTile();

        //        if (IsAValidSpace) // move piece if it is marked as a valid space
        //            SendTargetTile.Invoke(this);

        //        SelectTile();

        //        //show moves of selected tile on click
        //        Board.ShowMovesOfSelectedTile(this);

        //    }
        //}
        #endregion
        #region Select / Unselect methods
        public void SelectTile()
        {
            Selected = true;
            OnSelected?.Invoke(this);
            BackColor = Game.ColorPackages[Board.ColorPack].Item3;
        }
        public void UnSelectTile()
        {
            Selected = false;
            BackColor = originalColor;

            Piece piece = this.Piece;
            if (piece is King)
            {
                King king = (King)piece;
                //if (king.inCheck)
                //    BackColor = Color.Red;
            }


            Image = null;
        }
        #endregion

        #region Create piece
        public void CreatePiece(char pieceLetter, int player)
        {
            // p r n b q k

            Piece.Player selectedPlayer = player == 1 ? Core.Piece.Player.Player_One : Core.Piece.Player.Player_Two;

            //only add piece if tile is empty
            if (Piece == null)
            {
                switch (pieceLetter)
                {
                    case 'p':
                        Piece = new Pawn(selectedPlayer, this); break;
                    case 'r':
                        Piece = new Rook(selectedPlayer, this); break;
                    case 'n':
                        Piece = new Knight(selectedPlayer, this); break;
                    case 'b':
                        Piece = new Bishop(selectedPlayer, this); break;
                    case 'q':
                        Piece = new Queen(selectedPlayer, this); break;
                    case 'k':
                        Piece = new King(selectedPlayer, this); break;
                    default:
                        throw new Exception("Invalid piece letter");
                }


            }

        }
        #endregion

        #region Remove piece
        public void DiscardPosition()
        {
            Piece = null;
        }
        #endregion

        #region tostring override

        public override string ToString()
        {
            return Piece == null ?
            $"Empty tile at x{X}, y{Y}" :
            $"{Piece} at x{X}, y{Y}";
        }

        #endregion

        #region dispose

        public new void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);

        }

        #endregion
    }
}
