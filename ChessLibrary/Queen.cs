using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Queen : Piece
    {
        public Queen(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? Assets.W_QueenImg : Assets.B_QueenImg;
        }

        #region Public methods
        public override List<Tile> GetValidMoves(Board board, Tile selectedTile)
        {
            List<Tile> validMoves = new List<Tile>();

            //straight line movement
            validMoves.AddRange(CastForwardMovement(board, selectedTile));
            validMoves.AddRange(CastBackwardMovement(board, selectedTile));
            validMoves.AddRange(CastLeftMovement(board, selectedTile));
            validMoves.AddRange(CastRightMovement(board, selectedTile));

            //diagnal movement
            validMoves.AddRange(CastDiagnalUpperRight(board, selectedTile));
            validMoves.AddRange(CastDiagnalUpperLeft(board, selectedTile));
            validMoves.AddRange(CastDiagnaLowerRight(board, selectedTile));
            validMoves.AddRange(CastDiagnaLowerLeft(board, selectedTile));
            //IgnoreKing(validMoves);

            return validMoves;
        }
        #endregion

        #region Private methods

        #region Forward Movement
        private List<Tile> CastForwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = currentY; i >= 0; i--) //cast movement upward
                    if (t.CoordinateY != i)
                    {
                        if (b.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a piece on same team stop casting direction
                                break;
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a piece on other team cast valid space on it and stop
                                validMoves.Add(b.Tiles[i, currentX]); break;
                        }

                        validMoves.Add(b.Tiles[i, currentX]); // add valid move if space is empty
                    }
            }
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = currentY; i >= 0; i--) //cast movement upward
                    if (t.CoordinateY != i)
                    {
                        if (b.Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a piece on same team stop casting direction
                                break;
                            if (b.Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a piece on other team cast valid space on it and stop
                                validMoves.Add(b.Tiles[i, currentX]); break;
                        }

                        validMoves.Add(b.Tiles[i, currentX]); // add valid move if space is empty
                    }
            }

            return validMoves; // return valid forward spaces
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

        #region Diagnal upper right
        private List<Tile> CastDiagnalUpperRight(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            //player 1
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = 1; i < 7; i++) // cast to the right end of the board
                    try
                    {
                        var location = b.Tiles[currentY - i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Player.Player_Two)
                        {
                            validMoves.Add(location); break;
                        }


                        // stop loop if there is friendly piece blocking the way
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b.Tiles[currentY + i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Player.Player_One)
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        #endregion
        #region Diagnal upper left
        private List<Tile> CastDiagnalUpperLeft(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            //player 1
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {  //int i = 1; i < 7; i++
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b.Tiles[currentY - i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Player.Player_Two)
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b.Tiles[currentY + i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Player.Player_One)
                        {
                            validMoves.Add(location);
                            break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        #endregion
        #region Diagnal lower right
        private List<Tile> CastDiagnaLowerRight(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            //player 1
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = 1; i < 7; i++)
                    try
                    {
                        var location = b.Tiles[currentY + i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Player.Player_Two)
                        {
                            validMoves.Add(location); break;
                        }


                        // stop loop if there is friendly piece blocking the way
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b.Tiles[currentY - i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Player.Player_One)
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        #endregion
        #region Diagnal lower left
        private List<Tile> CastDiagnaLowerLeft(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            //player 1
            if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
            {
                for (int i = 1; i < 7; i++)
                    try
                    {
                        var location = b.Tiles[currentY + i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Player.Player_Two)
                        {
                            validMoves.Add(location); break;
                        }

                        // stop loop if there is friendly piece blocking the way
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if (t.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b.Tiles[currentY - i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Player.Player_One)
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrentPiece != null &&
                            location.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        #endregion

        #endregion
    }
}
