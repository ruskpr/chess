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
        #region Public methods
        public override List<Tile> GetValidMoves(Board board, Tile selectedTile)
        {
            List<Tile> validMoves = new List<Tile>();

            validMoves.AddRange(OneInEachDirection(board, selectedTile, selectedTile.CurrentPiece.CurrentPlayer));
            IgnoreKing(validMoves); // inherited
            IgnoreOccupiedSpaces(validMoves); // ignore all spaces where a piece sits

            return validMoves;
        }
        #endregion
        #region Private methods
        private List<Tile> OneInEachDirection(Board b, Tile t, Player player)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;
            var currPiece = t.CurrentPiece.CurrentPlayer;

            var turn = GameManager.Turn; // current turn

            if ((int)player == (int)turn) 
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

        private void IgnoreOccupiedSpaces(List<Tile> validMoves)
        {
            int numofMoves = validMoves.Count;
            for (int i = numofMoves; i >= 0; i--)
                try
                { // remove moves where there are friendly peices
                    if (validMoves[i].CurrentPiece is Piece)
                        validMoves.RemoveAt(i);
                }
                catch { }
        } 
        #endregion
    }
}
