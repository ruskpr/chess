using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Knight : Piece
    {
        #region Constructor
        public Knight(Player player, Tile tile) : base(player, tile) =>
            this.Image = player == Player.Player_One ? Assets.W_KnightImg : Assets.B_KnightImg;
        #endregion
        #region Public Methods
        public override void GetValidMoves(Board board, Tile selTile)
        {
            CurrentValidMoves.Clear();
            
            CurrentValidMoves.AddRange(GetKnightMoves(board, selTile));

            //IgnoreKing(CurrentValidMoves);
            try
            {
                IgnoreFriendlies(CurrentValidMoves, CurrentPlayer);
            }
            catch { }
        }
        #endregion
        #region Private Methods      
        private List<Tile> GetKnightMoves(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            //upper right
            try { validMoves.Add(b.Tiles[t.CoordinateY - 2, t.CoordinateX + 1]); } catch { }
            try { validMoves.Add(b.Tiles[t.CoordinateY - 1, t.CoordinateX + 2]); } catch { }

            //upper left
            try { validMoves.Add(b.Tiles[t.CoordinateY - 2, t.CoordinateX - 1]); } catch { }
            try { validMoves.Add(b.Tiles[t.CoordinateY - 1, t.CoordinateX - 2]); } catch { }

            //lower right
            try { validMoves.Add(b.Tiles[t.CoordinateY + 2, t.CoordinateX + 1]); } catch { }
            try { validMoves.Add(b.Tiles[t.CoordinateY + 1, t.CoordinateX + 2]); } catch { }

            //lower left
            try { validMoves.Add(b.Tiles[t.CoordinateY + 2, t.CoordinateX - 1]); } catch { }
            try { validMoves.Add(b.Tiles[t.CoordinateY + 1, t.CoordinateX - 2]); } catch { }

            return validMoves;
        }
        #endregion
    }
}
