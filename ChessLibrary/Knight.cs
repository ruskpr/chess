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

            //int currentTurn = (int)selTile.CurrentPiece.CurrentPlayer;

            if ((int)selTile.CurrentPiece.CurrentPlayer == (int)GameManager.Turn)
                CurrentValidMoves.AddRange(GetMoves(board, selTile));

            //if ((int)selTile.CurrentPiece.CurrentPlayer == 1 && (int)GameManager.Turn == 1)
            //    CurrentValidMoves.AddRange(GetPlayerOneMoves(board, selTile));

            //if ((int)selTile.CurrentPiece.CurrentPlayer == 2 && (int)GameManager.Turn == 2)
            //    CurrentValidMoves.AddRange(GetPlayerTwoMoves(board, selTile));

            //IgnoreKing(CurrentValidMoves);
        }
        #endregion
        #region Private Methods
        
        #region Player one movement
        private List<Tile> GetMoves(Board b, Tile t)
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

            // remove move if it contains a king or friendly player
            foreach (Tile move in validMoves.ToList())
                if (move.CurrentPiece is King || move.CurrentPiece != null &&
                (int)move.CurrentPiece.CurrentPlayer == (int)GameManager.Turn)
                    validMoves.Remove(move);

            return validMoves;
        }
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
