using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pieces
{
    public class Bishop : Piece
    {
        #region Constructor
        public Bishop(char player) : base(player) { }       
        #endregion

        #region Public Methods
        public override void GetValidMoves(Board board, Tile selectedTile)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(CastDiagnalUpperRight(board, selectedTile));
            CurrentValidMoves.AddRange(CastDiagnalUpperLeft(board, selectedTile));
            CurrentValidMoves.AddRange(CastDiagnaLowerRight(board, selectedTile));
            CurrentValidMoves.AddRange(CastDiagnaLowerLeft(board, selectedTile));
            IgnoreKing(CurrentValidMoves);
        }
        #endregion
        #region Private Methods
        private List<Tile> CastDiagnalUpperRight(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.X; // added for readability
            int currentY = t.Y;

            //player 1
            if ((int)t.CurrPiece.Player == 1)
            {
                for (int i = 1; i < 7; i++) // cast to the right end of the board
                    try
                    {
                        var location = b._tiles[currentY - i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                        {
                            validMoves.Add(location); break;
                        }


                        // stop loop if there is friendly piece blocking the way
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 1)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if ((int)t.CurrPiece.Player == 2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b._tiles[currentY + i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 1)
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        private List<Tile> CastDiagnalUpperLeft(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.X; // added for readability
            int currentY = t.Y;

            //player 1
            if ((int)t.CurrPiece.Player == 1)
            {  //int i = 1; i < 7; i++
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b._tiles[currentY - i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 1)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if ((int)t.CurrPiece.Player == 2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b._tiles[currentY + i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 1)
                        {
                            validMoves.Add(location);
                            break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        private List<Tile> CastDiagnaLowerRight(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.X; // added for readability
            int currentY = t.Y;

            //player 1
            if ((int)t.CurrPiece.Player == 1)
            {
                for (int i = 1; i < 7; i++)
                    try
                    {
                        var location = b._tiles[currentY + i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                        {
                            validMoves.Add(location); break;
                        }


                        // stop loop if there is friendly piece blocking the way
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 1)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if ((int)t.CurrPiece.Player == 2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b._tiles[currentY - i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 1)
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        private List<Tile> CastDiagnaLowerLeft(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.X; // added for readability
            int currentY = t.Y;

            //player 1
            if ((int)t.CurrPiece.Player == 1)
            {
                for (int i = 1; i < 7; i++)
                    try
                    {
                        var location = b._tiles[currentY + i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                        {
                            validMoves.Add(location); break;
                        }

                        // stop loop if there is friendly piece blocking the way
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 1)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if ((int)t.CurrPiece.Player == 2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b._tiles[currentY - i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.CurrPiece != null &&
                            (int)location.CurrPiece.CurrPlayer == 2)
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        #endregion
    }
}
