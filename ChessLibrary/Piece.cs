using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static ChessGame.Piece;

namespace ChessLibrary
{
    public abstract class Piece
    {
        #region Fields
        public static List<Piece> Pieces = new List<Piece>();
        public static List<Piece> PlayerOne_CapturedPieces = new List<Piece>();
        public static List<Piece> PlayerTwo_CapturedPieces = new List<Piece>();

        public enum Player { Player_One = 1, Player_Two = 2 }
        #endregion
        #region Properties
        public bool CompletedFirstMove { get; set; }
        public Bitmap Image { get; set; }
        public Player CurrentPlayer { get; set; }
        public Tile CurrentTile { get; set; }
        public List<Tile> CurrentValidMoves { get; set; }
        #endregion
        #region Constructor
        public Piece(Player player, Tile tile)
        {
            CurrentPlayer = player;
            CurrentTile = tile;
            CurrentValidMoves = new List<Tile>();
            this.Image = null;
            Pieces.Add(this);
        }
        #endregion
        #region Methods
        public abstract void GetValidMoves(Board board, Tile selTile);
        protected void IgnoreKing(List<Tile> validMoves) 
        {
            //for (int i = 0; i < validMoves.Count; i++)
            //    if (validMoves[i].CurrentPiece is King)
            //        validMoves.RemoveAt(i);
        }
        protected void IgnoreFriendlies(List<Tile> moveList, Player currPlayer)
        {
            
            // remove move if it contains a king or friendly player
            foreach (Tile move in moveList.ToList())
                if (move.CurrentPiece != null)
                    if (move.CurrentPiece is King || (int)move.CurrentPiece.CurrentPlayer == (int)currPlayer)
                    {
                        moveList.Remove(move);
                        //MessageBox.Show($"ignored {move}");
                    }
        }

        public override string ToString() => $"{CurrentPlayer.ToString().Replace("_", " ")}'s {GetType().Name}";
        #endregion
    }
}
