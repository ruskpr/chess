using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Pawn : Piece
    {
        #region Constructor
        public Pawn(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? Assets.W_PawnImg : Assets.B_PawnImg;
            CompletedFirstMove = false;
        }
        #endregion
        #region Public Methods
        public override void GetValidMoves(Board board, Tile selTile)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(GetForwardMovement(board, selTile));
            CurrentValidMoves.AddRange(GetDiagnalMovement(board, selTile));

            IgnoreKing(CurrentValidMoves);
            //IgnoreFriendlies(CurrentValidMoves, (int)selTile.CurrentPiece.CurrentPlayer);
        }
        #endregion
        #region Private Methods
        private List<Tile> GetForwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            if ((int)t.CurrentPiece.CurrentPlayer == 1)
            {
                // allow 1 space forward if the tile is empty
                try
                {
                    if (b.Tiles[t.CoordinateY - 1, t.CoordinateX].CurrentPiece == null)
                        validMoves.Add(b.Tiles[t.CoordinateY - 1, t.CoordinateX]);
                }
                catch { }

                // allow pawn to move 2 spaces on its first move
                if (t.CurrentPiece.CompletedFirstMove == false && // condition: first move has not been completed
                    b.Tiles[t.CoordinateY - 2, t.CoordinateX].CurrentPiece == null && // condition: tile 2 steps ahead is empty
                    b.Tiles[t.CoordinateY - 1, t.CoordinateX].CurrentPiece == null // condition: tile 1 step ahead isnt taken
                    )
                    validMoves.Add(b.Tiles[t.CoordinateY - 2, t.CoordinateX]);
                        
                
            }
            else if ((int)t.CurrentPiece.CurrentPlayer == 2)
            {
                // allow 1 space forward if the tile is empty
                try
                {
                    if (b.Tiles[t.CoordinateY + 1, t.CoordinateX].CurrentPiece == null)
                        validMoves.Add(b.Tiles[t.CoordinateY + 1, t.CoordinateX]);
                }
                catch { }

                // allow pawn to move 2 spaces on its first move
                if (t.CurrentPiece.CompletedFirstMove == false && // condition: first move has not been completed
                    b.Tiles[t.CoordinateY + 2, t.CoordinateX].CurrentPiece == null && // condition: tile 2 steps ahead is empty
                    b.Tiles[t.CoordinateY + 1, t.CoordinateX].CurrentPiece == null // condition: tile 1 step ahead isnt taken
                    )
                    validMoves.Add(b.Tiles[t.CoordinateY + 2, t.CoordinateX]);
            }

            return validMoves;
        }
        private List<Tile> GetDiagnalMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            // player 1
            if ((int)t.CurrentPiece.CurrentPlayer == 1)
            {
                if (t.CoordinateY > 0)
                {
                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                        if (b.Tiles[t.CoordinateY - 1, t.CoordinateX - 1].CurrentPiece is Piece &&
                        (int)b.Tiles[t.CoordinateY - 1, t.CoordinateX - 1].CurrentPiece.CurrentPlayer == 2)
                            validMoves.Add(b.Tiles[t.CoordinateY - 1, t.CoordinateX - 1]);
                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // enemy at right diagnal -> valid kill
                        if (b.Tiles[t.CoordinateY - 1, t.CoordinateX + 1].CurrentPiece is Piece &&
                        (int)b.Tiles[t.CoordinateY - 1, t.CoordinateX + 1].CurrentPiece.CurrentPlayer == 2)
                            validMoves.Add(b.Tiles[t.CoordinateY - 1, t.CoordinateX + 1]);
                    }
                    catch { } // ignore exception 
                }
            }
            //player 2
            else if ((int)t.CurrentPiece.CurrentPlayer == 2)
            {
                if (t.CoordinateY < 7)
                {
                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                        if (b.Tiles[t.CoordinateY + 1, t.CoordinateX + 1].CurrentPiece is Piece &&
                        (int)b.Tiles[t.CoordinateY + 1, t.CoordinateX + 1].CurrentPiece.CurrentPlayer == 1)
                            validMoves.Add(b.Tiles[t.CoordinateY + 1, t.CoordinateX + 1]);
                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are right diagnal of pawn, allow them to kill
                        if (b.Tiles[t.CoordinateY + 1, t.CoordinateX - 1].CurrentPiece is Piece &&
                            (int)b.Tiles[t.CoordinateY + 1, t.CoordinateX - 1].CurrentPiece.CurrentPlayer == 1)
                            validMoves.Add(b.Tiles[t.CoordinateY + 1, t.CoordinateX - 1]);
                    }
                    catch { } // ignore exception 
                }
            }

            return validMoves;
        }
        #endregion
    }
}
