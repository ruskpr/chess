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
        #region Fields
        private bool inCheckedState = false;
        private bool[] spacesOccupied = new bool[9];
        private Tile[] allSpaces = new Tile[9];
        #endregion
        #region Properties
        public bool InCheckedState { get { return InCheckedState; } }
        #endregion
        #region Constructor
        public King(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? Assets.W_KingImg : Assets.B_KingImg;

            Board.OnKingChecked += ParentBoard_OnKingChecked;
            CurrentTile.ParentBoard.PieceMoved += ParentBoard_PieceMoved;
        }
        #endregion
        private void UpdateSpaces(Board b, Tile t)
        {
            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            // all spaces
            try { allSpaces[0] = b.Tiles[currentY - 1, currentX - 1]; } catch { }
            try { allSpaces[1] = b.Tiles[currentY - 1, currentX]; } catch { }
            try { allSpaces[2] = b.Tiles[currentY - 1, currentX + 1]; } catch { }
            try { allSpaces[3] = b.Tiles[currentY, currentX + 1]; } catch { }
            try { allSpaces[4] = b.Tiles[currentY + 1, currentX + 1]; } catch { }
            try { allSpaces[5] = b.Tiles[currentY + 1, currentX]; } catch { }
            try { allSpaces[6] = b.Tiles[currentY + 1, currentX - 1]; } catch { }
            try { allSpaces[7] = b.Tiles[currentY, currentX - 1]; } catch { }
            try { allSpaces[8] = b.Tiles[currentY, currentX]; } catch { }
        }
        private void CheckForOccupiedSpaces()
        {
            //for (int i = 0; i < allSpaces.Length; i++)
            //{
            //    if (allSpaces[i].CoordinateX == )
            //        for (int j = 0; j < length; j++)
            //        {
            //            // left off here
            //        }
            //}
        }
        private void ParentBoard_PieceMoved()
        {
            // update kings open spaces on every move
            UpdateSpaces(this.CurrentTile.ParentBoard, this.CurrentTile);
        }
        #region onKingChecked
        private void ParentBoard_OnKingChecked(King checkedKing)
        {
            // when king is check put that king in a state
            // where they can only make moves to escape from check
            if (checkedKing.inCheckedState == false)
                ExecuteCheckedState(checkedKing);


            // Check spaces that are occupied by enemy players
            List<Tile> tilesOccupiedByOpponent = new List<Tile>();

            //foreach (Piece piece in Piece.Pieces)
            //{
            //    // if the tiles are occupied add to list
            //    if (piece.CurrentPlayer != this.CurrentPlayer)
            //        foreach (Tile move in piece.CurrentValidMoves)
            //        {

            //        }
            //}

            if (true) // if king is checked and all spaces are occupied by opponent...
            {
                
            } 
        }
        private void ExecuteCheckedState(King checkedKing)
        {
            checkedKing.inCheckedState = true;
            checkedKing.CurrentTile.BackColor = Color.Red;
            MessageBox.Show("Checked!");
            //CurrentTile.ParentBoard.DeleteBoard();


            //show possible moves of the checked king

        }
        #endregion
        #region Get Moves
        public override void GetValidMoves(Board board, Tile selectedTile)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(OneInEachDirection(board, selectedTile));
            IgnoreKing(CurrentValidMoves); // inherited

            IgnoreOccupiedSpaces(CurrentValidMoves); // ignore all spaces where a piece sits
            IgnoreEnemyMoves(CurrentValidMoves);
        }   
        private List<Tile> OneInEachDirection(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            UpdateSpaces(b, t);

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
        private void Checkmate()
        {
            MessageBox.Show("Checkmate!");
        }
    }
}
