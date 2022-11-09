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
            //kingThatIsChecked.CurrentTile.BackColor = Color.Red;
            // Check spaces that are occupied by enemy players
            List<Tile> tilesOccupiedByOpponent = new List<Tile>();
            foreach (Tile tile in CurrentTile.ParentBoard.Tiles)
            {
                // if the tiles pieces on the team opposite from the checked king...
                if (tile.CurrentPiece != null &&
                    tile.CurrentPiece.CurrentPlayer != kingThatIsChecked.CurrentPlayer)
                {
                    //tile.BackColor = Color.LightGoldenrodYellow;
                    // add all the moves of enemy tiles to one list
                    //tilesOccupiedByOpponent.AddRange(
                    //    tile.CurrentPiece.GetValidMoves(tile.ParentBoard, tile));
                }
            }

            if (true) // if king is checked and all spaces are occupied by opponent...
            {
                // MessageBox.Show("Checkmate!");
            }
        }
        #endregion
        #region Public methods
        public override void GetValidMoves(Board board, Tile selectedTile)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(OneInEachDirection(board, selectedTile));
            IgnoreKing(CurrentValidMoves); // inherited

            IgnoreOccupiedSpaces(CurrentValidMoves); // ignore all spaces where a piece sits
            IgnoreEnemyMoves(CurrentValidMoves);
        }
        #endregion
        #region Private methods
        private void Checkmate()
        {
            MessageBox.Show("Checkmate!");
        }
        private List<Tile> OneInEachDirection(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;
            var player = t.CurrentPiece.CurrentPlayer;

            // all moves (1 in each direction)
            try { validMoves.Add(b.Tiles[currentY - 1, currentX - 1]); } catch { }
            try { validMoves.Add(b.Tiles[currentY - 1, currentX]); } catch { }
            try { validMoves.Add(b.Tiles[currentY - 1, currentX + 1]); } catch { }
            try { validMoves.Add(b.Tiles[currentY, currentX + 1]); } catch { }
            try { validMoves.Add(b.Tiles[currentY + 1, currentX + 1]); } catch { }
            try { validMoves.Add(b.Tiles[currentY + 1, currentX]); } catch { }
            try { validMoves.Add(b.Tiles[currentY + 1, currentX - 1]); } catch { }
            try { validMoves.Add(b.Tiles[currentY, currentX - 1]); } catch { }

            return validMoves;
        }

        private void IgnoreOccupiedSpaces(List<Tile> validMoves)
        {
            foreach (Tile move in validMoves.ToList())
            {
                // remove moves where there are friendly pieces
                if (move.CurrentPiece != null)
                    if (move.CurrentPiece.CurrentPlayer == this.CurrentPlayer)
                        validMoves.Remove(move);
            }
        }
        private void IgnoreEnemyMoves(List<Tile> validMoves)
        {

        }
        #endregion
    }
}
