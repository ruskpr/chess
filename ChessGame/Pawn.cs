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
        public Pawn(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? MyAssets.W_PawnImg : MyAssets.B_PawnImg;
            CompletedFirstMove = false;
        }

        public override List<Tile> GetValidMoves(Board board, Tile tile)
        {
            List<Tile> validMoves = new List<Tile>();

            if (tile.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                // allow pawn to move 2 spaces on its first move
                if (tile.CurrentPiece.CompletedFirstMove == false)
                    validMoves.Add(board.Tiles[tile.CoordinateY - 2, tile.CoordinateX]);

                // error check to not allow spaces outside of board index
                if (tile.CoordinateY > 0)
                {
                    // 1 space forward (only allows move if no pieces infront
                    if (board.Tiles[tile.CoordinateY - 1, tile.CoordinateX].CurrentPiece == null)
                        validMoves.Add(board.Tiles[tile.CoordinateY - 1, tile.CoordinateX]);

                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy peice AND they are left diagnal of pawn, allow them to kill
                        if (board.Tiles[tile.CoordinateY - 1, tile.CoordinateX - 1].CurrentPiece is Piece &&
                            board.Tiles[tile.CoordinateY - 1, tile.CoordinateX - 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                            validMoves.Add(board.Tiles[tile.CoordinateY - 1, tile.CoordinateX - 1]);

                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // enemy at right diagnal -> valid kill
                        if (board.Tiles[tile.CoordinateY - 1, tile.CoordinateX + 1].CurrentPiece is Piece &&
                            board.Tiles[tile.CoordinateY - 1, tile.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                            validMoves.Add(board.Tiles[tile.CoordinateY - 1, tile.CoordinateX + 1]);

                    }
                    catch { } // ignore exception 
                }
            }
            else if (tile.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                // allow pawn to move 2 spaces on its first move
                if (tile.CurrentPiece.CompletedFirstMove == false)
                    validMoves.Add(board.Tiles[tile.CoordinateY + 2, tile.CoordinateX]);

                // error check to not allow spaces outside of board index
                if (tile.CoordinateY < 7)
                {
                    // 1 space forward (only allows move if no pieces infront
                    if (board.Tiles[tile.CoordinateY + 1, tile.CoordinateX].CurrentPiece == null)
                        validMoves.Add(board.Tiles[tile.CoordinateY + 1, tile.CoordinateX]);

                    try // try catch to ignore out of board index
                    {
                        // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                        if (board.Tiles[tile.CoordinateY + 1, tile.CoordinateX + 1].CurrentPiece is Piece &&
                            board.Tiles[tile.CoordinateY + 1, tile.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                            validMoves.Add(board.Tiles[tile.CoordinateY + 1, tile.CoordinateX + 1]);

                    }
                    catch { } // ignore exception 

                    try // try catch to ignore out of board index
                    {
                        // enemy at right diagnal -> valid kill
                        if (board.Tiles[tile.CoordinateY + 1, tile.CoordinateX - 1].CurrentPiece is Piece &&
                            board.Tiles[tile.CoordinateY + 1, tile.CoordinateX - 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                            validMoves.Add(board.Tiles[tile.CoordinateY + 1, tile.CoordinateX - 1]);
                    }
                    catch { } // ignore exception 
                }
            }

            return validMoves;
        }
  
    }
}
