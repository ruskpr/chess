using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessGame.Piece;

namespace ChessGame
{
    public class Rook : Piece
    {

        public Rook(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? MyAssets.W_RookImg : MyAssets.B_RookImg;
        }

        public override List<Tile> GetValidMoves(Board board, Tile selTile)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = selTile.CoordinateX;
            int currentY = selTile.CoordinateY;


            //player 1
            if (selTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                // UP and DOWN movement
                for (int i = currentY; i >= 0; i--) //cast movement upward
                {
                    if (selTile.CoordinateY != i)
                    {
                        if (board.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (board.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                            {
                                break;
                            }
                            if (board.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(board.Tiles[i, currentX]);
                                break;
                            }
                        }

                        validMoves.Add(board.Tiles[i, currentX]);
                    }
                }
                for (int i = currentY; i <= 7; i++) //cast movement downward
                {
                    if (selTile.CoordinateY != i) // skip add the valid location on same position of selected rook
                    {
                        if (board.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (board.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (board.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(board.Tiles[i, currentX]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(board.Tiles[i, currentX]); // add valid move if there is empty tile
                    }

                }

                // LEFT and RIGHT movement
                for (int i = currentX; i >= 0; i--) //cast movement left
                {
                    if (selTile.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (board.Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (board.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (board.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(board.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(board.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
                for (int i = currentX; i <= 7; i++) //cast movement right
                {
                    if (selTile.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (board.Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (board.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (board.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(board.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(board.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }
            //////////////////////
            //player 2
            if (selTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                // UP and DOWN movement
                for (int i = currentY; i >= 0; i--) //cast movement upward
                {
                    if (selTile.CoordinateY != i)
                    {
                        if (board.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (board.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on same team
                            {
                                break;
                            }
                            if (board.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(board.Tiles[i, currentX]);
                                break;
                            }
                        }

                        validMoves.Add(board.Tiles[i, currentX]);
                    }
                }
                for (int i = currentY; i <= 7; i++) //cast movement downward
                {
                    if (selTile.CoordinateY != i) // skip add the valid location on same position of selected rook
                    {
                        if (board.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (board.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (board.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(board.Tiles[i, currentX]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(board.Tiles[i, currentX]); // add valid move if there is empty tile
                    }

                }

                // LEFT and RIGHT movement
                for (int i = currentX; i >= 0; i--) //cast movement left
                {
                    if (selTile.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (board.Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (board.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (board.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(board.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(board.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
                for (int i = currentX; i <= 7; i++) //cast movement right
                {
                    if (selTile.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (board.Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (board.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (board.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(board.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(board.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }

            return validMoves;
        }//end


    }
}
