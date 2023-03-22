using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static ChessGame.Piece;

namespace Core.Pieces
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
        public King(char player, Tile tile) : base(player, tile)
        {

            Board.OnKingChecked += ParentBoard_OnKingChecked;
            CurrentTile.Board.OnPieceMoved += ParentBoard_PieceMoved;
        }
        #endregion
        private void UpdateSpaces(Board b, Tile t)
        {
            int currentX = t.X; // added for readability
            int currentY = t.Y;

            // all spaces
            try { allSpaces[0] = b._tiles[currentY - 1, currentX - 1]; } catch { }
            try { allSpaces[1] = b._tiles[currentY - 1, currentX]; } catch { }
            try { allSpaces[2] = b._tiles[currentY - 1, currentX + 1]; } catch { }
            try { allSpaces[3] = b._tiles[currentY, currentX + 1]; } catch { }
            try { allSpaces[4] = b._tiles[currentY + 1, currentX + 1]; } catch { }
            try { allSpaces[5] = b._tiles[currentY + 1, currentX]; } catch { }
            try { allSpaces[6] = b._tiles[currentY + 1, currentX - 1]; } catch { }
            try { allSpaces[7] = b._tiles[currentY, currentX - 1]; } catch { }
            try { allSpaces[8] = b._tiles[currentY, currentX]; } catch { }
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
            UpdateSpaces(CurrentTile.Board, CurrentTile);
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

            User playerOne = checkedKing.CurrentTile.Board.CurrentRoom.PlayerOne;
            User playerTwo = checkedKing.CurrentTile.Board.CurrentRoom.PlayerTwo;

            Player player = checkedKing.Player;
            string winningPlayer = player == Player.Player_One ? "player two" : "player one";
            MessageBox.Show($"{checkedKing} is in check!\n +10 for {winningPlayer}");

            if (winningPlayer.Contains("one"))
                playerOne.chess_rating += 10;
            else
                playerTwo.chess_rating += 10;

            LocalDataSaver ds = new();
            ds.SavePlayerData(playerOne, playerTwo);

            CurrentTile.Board.ResetBoard();
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

            int currentX = t.X; // added for readability
            int currentY = t.Y;

            UpdateSpaces(b, t);

            // all moves (1 in each direction)
            try { validMoves.Add(b._tiles[currentY - 1, currentX - 1]); } catch { }
            try { validMoves.Add(b._tiles[currentY - 1, currentX]); } catch { }
            try { validMoves.Add(b._tiles[currentY - 1, currentX + 1]); } catch { }
            try { validMoves.Add(b._tiles[currentY, currentX + 1]); } catch { }
            try { validMoves.Add(b._tiles[currentY + 1, currentX + 1]); } catch { }
            try { validMoves.Add(b._tiles[currentY + 1, currentX]); } catch { }
            try { validMoves.Add(b._tiles[currentY + 1, currentX - 1]); } catch { }
            try { validMoves.Add(b._tiles[currentY, currentX - 1]); } catch { }

            return validMoves;
        }
        private void IgnoreOccupiedSpaces(List<Tile> validMoves)
        {
            foreach (Tile move in validMoves.ToList())
            {
                // remove moves where there are friendly pieces
                if (move.CurrPiece != null)
                    if (move.CurrPiece.Player == Player)
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
