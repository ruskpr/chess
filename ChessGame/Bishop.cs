using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Bishop : Piece
    {
        #region Constructor
        public Bishop(Player player, Tile tile) : base(player, tile) =>
            this.Image = player == Player.Player_One ? MyAssets.W_BishopImg : MyAssets.B_BishopImg;
        #endregion
        #region Public Methods
        public override List<Tile> GetValidMoves(Board board, Tile selectedTile)
        {
            List<Tile> validMoves = new List<Tile>();

            validMoves.AddRange(CastDiagnalUpperRight(board, selectedTile));

            return validMoves;
        }
        #endregion
        #region Private Methods
        private List<Tile> CastDiagnalUpperRight(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = 0; i <= 7; i++)
                        try 
                        {
                            if (b.Tiles[currentY - i, currentX + i].CurrentPiece != null)// && b.Tiles[currentY - i, currentX + i].CurrentPiece.CurrentPlayer != Player.Player_One
                                validMoves.Add(b.Tiles[currentY - i, currentX + i]); 
                        } catch { }
            }


            return validMoves; // return valid forward spaces
        }
        #endregion
    }
}
