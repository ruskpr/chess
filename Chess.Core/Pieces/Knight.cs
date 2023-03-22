using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pieces
{
    public class Knight : Piece
    {
        #region Constructor
        public Knight(char player, Tile tile) : base(player, tile) { }
        #endregion
        #region Public Methods
        public override void GetValidMoves(Board board, Tile selTile)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(GetKnightMoves(board, selTile));

            //IgnoreKing(CurrentValidMoves);
            try
            {
                IgnoreFriendlies(CurrentValidMoves, Player);
            }
            catch { }
        }
        #endregion
        #region Private Methods      
        private List<Tile> GetKnightMoves(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            //upper right
            try { validMoves.Add(b._tiles[t.Y - 2, t.X + 1]); } catch { }
            try { validMoves.Add(b._tiles[t.Y - 1, t.X + 2]); } catch { }

            //upper left
            try { validMoves.Add(b._tiles[t.Y - 2, t.X - 1]); } catch { }
            try { validMoves.Add(b._tiles[t.Y - 1, t.X - 2]); } catch { }

            //lower right
            try { validMoves.Add(b._tiles[t.Y + 2, t.X + 1]); } catch { }
            try { validMoves.Add(b._tiles[t.Y + 1, t.X + 2]); } catch { }

            //lower left
            try { validMoves.Add(b._tiles[t.Y + 2, t.X - 1]); } catch { }
            try { validMoves.Add(b._tiles[t.Y + 1, t.X - 2]); } catch { }

            return validMoves;
        }
        #endregion
    }
}
