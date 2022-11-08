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
        public override void GetValidMoves(Board board, Tile selectedTile)
        {
            CurrentValidMoves.Clear();

            if (selectedTile.CurrentPiece.CurrentPlayer == Player.Player_One &&
            GameManager.Turn == GameManager.PlayerTurn.p1)
                CurrentValidMoves.AddRange(GetPlayerOneMoves(board, selectedTile));

            if (selectedTile.CurrentPiece.CurrentPlayer == Player.Player_Two &&
            GameManager.Turn == GameManager.PlayerTurn.p2)
                CurrentValidMoves.AddRange(GetPlayerTwoMoves(board, selectedTile));

            IgnoreKing(CurrentValidMoves);
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// 
        /// 2 private methods, one for each player
        /// 
        /// </summary>
        /// <param name="t"> refers to the selected parameter when public method is called in board class </param>
        /// <param name="b"> refers to the board that the selected tile belongs to </param>
        /// <returns></returns>
        #region Player one movement
        private List<Tile> GetPlayerOneMoves(Board b, Tile t)
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


            foreach (Tile tile in validMoves.ToList())
                if (tile.CurrentPiece is King || tile.CurrentPiece != null &&
                tile.CurrentPiece.CurrentPlayer == Player.Player_One)
                    validMoves.Remove(tile);

            return validMoves;
        }
        #endregion
        #region Player two movement
        private List<Tile> GetPlayerTwoMoves(Board b, Tile t)
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


            foreach (Tile tile in validMoves.ToList())
                if (tile.CurrentPiece is King || tile.CurrentPiece != null &&
                tile.CurrentPiece.CurrentPlayer == Player.Player_Two)
                    validMoves.Remove(tile);

            return validMoves;
        }
        #endregion
        #endregion
    }
}
