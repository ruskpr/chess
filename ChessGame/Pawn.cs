using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Pawn : Piece
    {
        #region Constructor
        public Pawn(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? MyAssets.W_PawnImg : MyAssets.B_PawnImg;
            CompletedFirstMove = false;
        }
        #endregion
        #region Public Methods
        public override List<Tile> GetValidMoves(Board board, Tile selectedTile)
        {
            List<Tile> validMoves = new List<Tile>();

            validMoves.AddRange(GetForwardMovement(board, selectedTile));
            validMoves.AddRange(GetDiagnalMovement(board, selectedTile));
            

            

            //////


            if (selectedTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                // allow pawn to move 2 spaces on its first move
                //if (selectedTile.CurrentPiece.CompletedFirstMove == false)
                //    validMoves.Add(board.Tiles[selectedTile.CoordinateY - 2, selectedTile.CoordinateX]);

                // error check to not allow spaces outside of board index
                if (selectedTile.CoordinateY > 0)
                {
                    //// 1 space forward (only allows move if no pieces infront
                    //if (board.Tiles[selectedTile.CoordinateY - 1, selectedTile.CoordinateX].CurrentPiece == null)
                    //    validMoves.Add(board.Tiles[selectedTile.CoordinateY - 1, selectedTile.CoordinateX]);

                    //try // try catch to ignore out of board index
                    //{
                    //    // if there is a enemy peice AND they are left diagnal of pawn, allow them to kill
                    //    if (board.Tiles[selectedTile.CoordinateY - 1, selectedTile.CoordinateX - 1].CurrentPiece is Piece &&
                    //        board.Tiles[selectedTile.CoordinateY - 1, selectedTile.CoordinateX - 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                    //        validMoves.Add(board.Tiles[selectedTile.CoordinateY - 1, selectedTile.CoordinateX - 1]);
                    //}
                    //catch { } // ignore exception 

                    //try // try catch to ignore out of board index
                    //{
                    //    // enemy at right diagnal -> valid kill
                    //    if (board.Tiles[selectedTile.CoordinateY - 1, selectedTile.CoordinateX + 1].CurrentPiece is Piece &&
                    //        board.Tiles[selectedTile.CoordinateY - 1, selectedTile.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                    //        validMoves.Add(board.Tiles[selectedTile.CoordinateY - 1, selectedTile.CoordinateX + 1]);
                    //}
                    //catch { } // ignore exception 
                }
            }
            else if (selectedTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                // allow pawn to move 2 spaces on its first move
                //if (selectedTile.CurrentPiece.CompletedFirstMove == false)
                //    validMoves.Add(board.Tiles[selectedTile.CoordinateY + 2, selectedTile.CoordinateX]);

                // error check to not allow spaces outside of board index
                if (selectedTile.CoordinateY < 7)
                {
                    // 1 space forward (only allows move if no pieces infront
                    //if (board.Tiles[selectedTile.CoordinateY + 1, selectedTile.CoordinateX].CurrentPiece == null)
                    //    validMoves.Add(board.Tiles[selectedTile.CoordinateY + 1, selectedTile.CoordinateX]);

                    //try // try catch to ignore out of board index
                    //{
                    //    // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                    //    if (board.Tiles[selectedTile.CoordinateY + 1, selectedTile.CoordinateX + 1].CurrentPiece is Piece &&
                    //        board.Tiles[selectedTile.CoordinateY + 1, selectedTile.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                    //        validMoves.Add(board.Tiles[selectedTile.CoordinateY + 1, selectedTile.CoordinateX + 1]);

                    //}
                    //catch { } // ignore exception 

                    //try // try catch to ignore out of board index
                    //{
                    //    // enemy at right diagnal -> valid kill
                    //    if (board.Tiles[selectedTile.CoordinateY + 1, selectedTile.CoordinateX - 1].CurrentPiece is Piece &&
                    //        board.Tiles[selectedTile.CoordinateY + 1, selectedTile.CoordinateX - 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                    //        validMoves.Add(board.Tiles[selectedTile.CoordinateY + 1, selectedTile.CoordinateX - 1]);
                    //}
                    //catch { } // ignore exception 
                }
            }

            return validMoves;
        }
        #endregion
        #region Private Methods
        private List<Tile> GetForwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                // allow pawn to move 2 spaces on its first move
                if (t.CurrentPiece.CompletedFirstMove == false)
                    validMoves.Add(b.Tiles[t.CoordinateY - 2, t.CoordinateX]);

                if (t.CoordinateY > 0)
                {
                    // 1 space forward (only allows move if no pieces infront
                    if (b.Tiles[t.CoordinateY - 1, t.CoordinateX].CurrentPiece == null)
                        validMoves.Add(b.Tiles[t.CoordinateY - 1, t.CoordinateX]);

                    
                       
                }
            }
            else if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                if (t.CurrentPiece.CompletedFirstMove == false)
                    validMoves.Add(b.Tiles[t.CoordinateY + 2, t.CoordinateX]);

                if (t.CoordinateY > 0)
                {
                    if (b.Tiles[t.CoordinateY + 1, t.CoordinateX].CurrentPiece == null)
                        validMoves.Add(b.Tiles[t.CoordinateY + 1, t.CoordinateX]);
                }
            }

            return validMoves;
        }

        private List<Tile> GetDiagnalMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                if (t.CoordinateY > 0)
                {
                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy peice AND they are left diagnal of pawn, allow them to kill
                        if (b.Tiles[t.CoordinateY - 1, t.CoordinateX - 1].CurrentPiece is Piece &&
                        b.Tiles[t.CoordinateY - 1, t.CoordinateX - 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                            validMoves.Add(b.Tiles[t.CoordinateY - 1, t.CoordinateX - 1]);
                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // enemy at right diagnal -> valid kill
                        if (b.Tiles[t.CoordinateY - 1, t.CoordinateX + 1].CurrentPiece is Piece &&
                        b.Tiles[t.CoordinateY - 1, t.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                            validMoves.Add(b.Tiles[t.CoordinateY - 1, t.CoordinateX + 1]);
                    }
                    catch { } // ignore exception 
                }
            }
            else if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                if (t.CoordinateY < 7)
                {
                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                        if (b.Tiles[t.CoordinateY + 1, t.CoordinateX + 1].CurrentPiece is Piece &&
                        b.Tiles[t.CoordinateY + 1, t.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                            validMoves.Add(b.Tiles[t.CoordinateY + 1, t.CoordinateX + 1]);

                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // enemy at right diagnal -> valid kill
                        if (b.Tiles[t.CoordinateY + 1, t.CoordinateX - 1].CurrentPiece is Piece &&
                            b.Tiles[t.CoordinateY + 1, t.CoordinateX - 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
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
