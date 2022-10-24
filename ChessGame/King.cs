using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessGame.Piece;

namespace ChessGame
{
    public class King : Piece
    {
        public bool InCheck { get; set; }
        public King(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? MyAssets.W_KingImg : MyAssets.B_KingImg;
            InCheck = false;
        }
        public override List<Tile> GetValidMoves(Board board, Tile selectedTile)
        {
            List<Tile> validMoves = new List<Tile>();

            validMoves.AddRange(OneInEachDirection(board, selectedTile));
            IgnoreKing(validMoves);

            return validMoves;
        }

        private List<Tile> OneInEachDirection(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            var currPiece = t.CurrentPiece.CurrentPlayer;

            if (currPiece == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                try { validMoves.Add(b.Tiles[currentY - 1, currentX - 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY - 1, currentX]); } catch { }
                try { validMoves.Add(b.Tiles[currentY - 1, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX - 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY, currentX - 1]); } catch { }
            }
            else if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                try { validMoves.Add(b.Tiles[currentY - 1, currentX - 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY - 1, currentX]); } catch { }
                try { validMoves.Add(b.Tiles[currentY - 1, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX + 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX]); } catch { }
                try { validMoves.Add(b.Tiles[currentY + 1, currentX - 1]); } catch { }
                try { validMoves.Add(b.Tiles[currentY, currentX - 1]); } catch { }

            }
                return validMoves;
        }
        

    }
}
