using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class Piece
    {
        #region Fields
        public static List<Piece> pieceList = new List<Piece>();

        public enum Player
        {
            Player_One,
            Player_Two
        }
        #endregion
        #region Properties
        public bool CompletedFirstMove { get; set; }
        public Bitmap Image { get; set; }
        public Player CurrentPlayer { get; set; }
        public Tile CurrentTile { get; set; }
        #endregion
        #region Constructor
        public Piece(Player player, Tile tile)
        {
            CurrentPlayer = player;
            CurrentTile = tile;
            this.Image = null;
            pieceList.Add(this);
        }
        #endregion
        #region Methods
        public abstract List<Tile> GetValidMoves(Board board, Tile selTile);

        protected void IgnoreKingMove(List<Tile> validMoves) 
        {
            for (int i = 0; i < validMoves.Count; i++)
                if (validMoves[i].CurrentPiece is King)
                    validMoves.RemoveAt(i);
        }
        public override string ToString() => $"{CurrentPlayer.ToString().Replace("_", " ")}'s {GetType().Name}";
        #endregion
    }
}
