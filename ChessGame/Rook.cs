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

            validMoves.AddRange(CastForwardMovement(board,selTile));
            validMoves.AddRange(CastBackwardMovement(board, selTile));
            validMoves.AddRange(CastLeftMovement(board, selTile));
            validMoves.AddRange(CastRightMovement(board, selTile));

            return validMoves;
        }

        #region Private Methods
        #region Forward Movement
        private List<Tile> CastForwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.CoordinateX;
            int currentY = t.CoordinateY;

            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = currentY; i >= 0; i--) //cast movement upward
                {
                    if (t.CoordinateY != i)
                    {
                        if (b.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                            {
                                break;
                            }
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[i, currentX]);
                                break;
                            }
                        }

                        validMoves.Add(b.Tiles[i, currentX]);
                    }
                }
            }
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = currentY; i >= 0; i--) //cast movement upward
                {
                    if (t.CoordinateY != i)
                    {
                        if (b.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on same team
                            {
                                break;
                            }
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[i, currentX]);
                                break;
                            }
                        }

                        validMoves.Add(b.Tiles[i, currentX]);
                    }
                }
            }

            return validMoves;
        }
        #endregion
        #region Backward Movement
        private List<Tile> CastBackwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.CoordinateX;
            int currentY = t.CoordinateY;

            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = currentY; i <= 7; i++) //cast movement downward
                {
                    if (t.CoordinateY != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[i, currentX]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[i, currentX]); // add valid move if there is empty tile
                    }

                }
            }
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = currentY; i <= 7; i++) //cast movement downward
                {
                    if (t.CoordinateY != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[i, currentX]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[i, currentX]); // add valid move if there is empty tile
                    }
                }
            }

            return validMoves;
        }
        #endregion
        #region Left Movement
        private List<Tile> CastLeftMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.CoordinateX;
            int currentY = t.CoordinateY;

            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = currentX; i >= 0; i--) //cast movement left
                {
                    if (t.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = currentX; i >= 0; i--) //cast movement left
                {
                    if (t.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }

            return validMoves;
        }
        #endregion
        #region Right Movement
        private List<Tile> CastRightMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.CoordinateX;
            int currentY = t.CoordinateY;

            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = currentX; i <= 7; i++) //cast movement right
                {
                    if (t.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = currentX; i <= 7; i++) //cast movement right
                {
                    if (t.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }

            return validMoves;
        }
        #endregion
        #endregion
    }
}
