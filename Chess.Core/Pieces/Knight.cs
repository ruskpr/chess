using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pieces
{
    public class Knight : Piece
    {
        #region constructor

        public Knight(char player) : base(player) { }

        #endregion

        #region public

        public override void GetValidMoves(Board board, Tile selTile)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(GetKnightMoves(board, selTile));

            //IgnoreKing(CurrentValidMoves);
            try
            {
                //IgnoreFriendlies(CurrentValidMoves, Player);
            }
            catch { }
        }

        #endregion

        #region private

        private List<Tile> GetKnightMoves(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            //upper right
            try { validMoves.Add(b._tiles[t.Column - 2, t.Row + 1]); } catch { }
            try { validMoves.Add(b._tiles[t.Column - 1, t.Row + 2]); } catch { }

            //upper left
            try { validMoves.Add(b._tiles[t.Column - 2, t.Row - 1]); } catch { }
            try { validMoves.Add(b._tiles[t.Column - 1, t.Row - 2]); } catch { }

            //lower right
            try { validMoves.Add(b._tiles[t.Column + 2, t.Row + 1]); } catch { }
            try { validMoves.Add(b._tiles[t.Column + 1, t.Row + 2]); } catch { }

            //lower left
            try { validMoves.Add(b._tiles[t.Column + 2, t.Row - 1]); } catch { }
            try { validMoves.Add(b._tiles[t.Column + 1, t.Row - 2]); } catch { }

            return validMoves;
        }

        #endregion
    }
}
