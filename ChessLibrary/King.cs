using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static ChessGame.Piece;

namespace ChessLibrary
{
    public class King : Piece
    {
        public bool InCheck { get; set; }
        public King(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? Assets.W_KingImg : Assets.B_KingImg;
            InCheck = false;
            CurrentTile.ParentBoard.OnKingChecked += ParentBoard_OnKingChecked;
        }
        #region Delegate
        private void ParentBoard_OnKingChecked(King kingThatIsChecked)
        {
            // when king is check put that king in a state
            // where they can only make moves to escape from check
            InCheck = true;
            kingThatIsChecked.CurrentTile.BackColor = Color.Red;
            // Check spaces that are occupied by enemy players
            List<Tile> tilesOccupiedByOpponent = new List<Tile>();
            foreach (Tile tile in CurrentTile.ParentBoard.Tiles)
            {
                // if the tiles pieces on the team opposite from the checked king...
                if (tile.CurrentPiece != null)
                {
                    if (tile.CurrentPiece.CurrentPlayer != kingThatIsChecked.CurrentPlayer)
                    {
                        tile.BackColor = Color.LightGoldenrodYellow;
                        // add all the moves of enemy tiles to one list
                        tilesOccupiedByOpponent.AddRange(
                            tile.CurrentPiece.GetValidMoves(tile.ParentBoard, tile));
                    }
                }
            }

            if (true) // if king is checked and all spaces are occupied by opponent...
            {
                // Checkmate();
            }
        }
        #endregion
        #region Public methods
        public override List<Tile> GetValidMoves(Board board, Tile selectedTile)
        {
            List<Tile> validMoves = new List<Tile>();
            
            validMoves.AddRange(OneInEachDirection(board, selectedTile, selectedTile.CurrentPiece.CurrentPlayer));
            IgnoreKing(validMoves); // inherited

            //IgnoreOccupiedSpaces(validMoves); // ignore all spaces where a piece sits

            return validMoves;
        }
        #endregion
        #region Private methods
        private void Checkmate()
        {
            MessageBox.Show("Checkmate!");
        }
        private List<Tile> OneInEachDirection(Board b, Tile t, Player player)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;
            var currPiece = t.CurrentPiece.CurrentPlayer;

            var turn = GameManager.Turn; // current turn

            if ((int)player == (int)turn) // if it is the pieces turn...
            {

                // all moves (1 in each direction)
                try { validMoves.Add(b.Tiles[currentY - 1, currentX - 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY - 1, currentX]); } catch { }
                try { validMoves.Add(b.Tiles[currentY - 1, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX - 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY, currentX - 1]); } catch { }
            }

            return validMoves;
        }

        private void IgnoreOccupiedSpaces(List<Tile> validMoves)
        {
            int numofMoves = validMoves.Count;
            for (int i = numofMoves; i >= 0; i--)
                try
                { // remove moves where there are friendly peices
                    if (validMoves[i].CurrentPiece != null)
                        validMoves.RemoveAt(i);
                }
                catch { }
        } 
        #endregion
    }
}
