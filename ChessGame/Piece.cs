using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Piece
    {
        public static List<Piece> pieceList = new List<Piece>();

        public bool CompletedFirstMove { get; set; }
        public Bitmap Image { get; set; }
        public Player CurrentPlayer { get; set; }

        public Tile CurrentTile { get; set; }
        public enum Player
        {
            None,
            Player_One,
            Player_Two
        }

        public Piece(Player player, Tile tile)
        {
            CurrentPlayer = player;
            CurrentTile = tile;
            this.Image = null;
            pieceList.Add(this);

        }
        #region Calc valid moves
        public virtual void CalcValidMoves()
        {

        }
        #endregion
        #region Move piece
        private void MovePiece(Tile oldPosition, Tile NewPosition)
        {

            oldPosition = CurrentTile;
        }
        #endregion

        public override string ToString()
        {
            return $"{CurrentPlayer.ToString().Replace("_"," ")}'s {GetType().Name}";
        }
    }
}
