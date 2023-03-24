using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pieces
{
    public class Bishop : Piece
    {
        #region constructor
        public Bishop(char player) : base(player) { }       
        #endregion

        #region public

        public override void GetValidMoves(Board board, Tile origin)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(CastDiagnalUpperRight(board, origin));
            CurrentValidMoves.AddRange(CastDiagnalUpperLeft(board, origin));
            CurrentValidMoves.AddRange(CastDiagnaLowerRight(board, origin));
            CurrentValidMoves.AddRange(CastDiagnaLowerLeft(board, origin));
        }

        #endregion

        #region private 

        private List<Tile> CastDiagnalUpperRight(Board b, Tile tile)
        {
            List<Tile> validMoves = new List<Tile>(); 

            int currentX = tile.X;
            int currentY = tile.Y;

            // white
            if (tile.Piece.Player == 'w')
            {
                for (int i = 1; i < 7; i++) // cast to the right end of the board
                    try
                    {
                        var location = b._tiles[currentY - i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.Piece != null &&
                            (int)location.Piece.Player == 'b')
                        {
                            validMoves.Add(location); break;
                        }


                        // stop loop if there is friendly piece blocking the way
                        if (location.Piece != null &&
                            (int)location.Piece.Player == 'w')
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            // black
            else if ((int)tile.Piece.Player == 2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b._tiles[currentY + i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.Piece != null &&
                            (int)location.Piece.Player == 'w')
                        {
                            validMoves.Add(location); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.Piece != null &&
                            (int)location.Piece.Player == 'b')
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

            // white
            if (t.Piece.Player == 'w')
            {  //int i = 1; i < 7; i++
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var tmpTile = b._tiles[currentY - i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (tmpTile.Piece != null &&
                            (int)tmpTile.Piece.Player == 'b')
                        {
                            validMoves.Add(tmpTile); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (tmpTile.Piece != null &&
                            tmpTile.Piece.Player == 'w')
                            break;

                        validMoves.Add(tmpTile); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            // black
            else if (t.Piece.Player == 'b')
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var location = b._tiles[currentY + i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (location.Piece != null &&
                            location.Piece.Player == 'w')
                        {
                            validMoves.Add(location);
                            break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (location.Piece != null &&
                            location.Piece.Player == 'b')
                            break;

                        validMoves.Add(location); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        private List<Tile> CastDiagnaLowerRight(Board b, Tile tile)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = tile.X; // added for readability
            int currentY = tile.Y;

            // white
            if (tile.Piece.Player == 'w')
            {
                for (int i = 1; i < 7; i++)
                    try
                    {
                        var tmpTile = b._tiles[currentY + i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (tmpTile.Piece != null &&
                            (int)tmpTile.Piece.Player == 'b')
                        {
                            validMoves.Add(tmpTile); break;
                        }


                        // stop loop if there is friendly piece blocking the way
                        if (tmpTile.Piece != null &&
                            tmpTile.Piece.Player == 'w')
                            break;

                        validMoves.Add(tmpTile); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            //player 2
            else if ((int)tile.Piece.Player == 2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var tmpTile = b._tiles[currentY - i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (tmpTile.Piece != null &&
                            tmpTile.Piece.Player == 'w')
                        {
                            validMoves.Add(tmpTile); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (tmpTile.Piece != null &&
                            (int)tmpTile.Piece.Player == 'b')
                            break;

                        validMoves.Add(tmpTile); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        private List<Tile> CastDiagnaLowerLeft(Board b, Tile tile)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = tile.X; // added for readability
            int currentY = tile.Y;

            // white
            if (tile.Piece.Player == 'w')
            {
                for (int i = 1; i < 7; i++)
                    try
                    {
                        var tmpTile = b._tiles[currentY + i, currentX - i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (tmpTile.Piece != null &&
                            (int)tmpTile.Piece.Player == 'b')
                        {
                            validMoves.Add(tmpTile); break;
                        }

                        // stop loop if there is friendly piece blocking the way
                        if (tmpTile.Piece != null &&
                            tmpTile.Piece.Player == 'w')
                            break;

                        validMoves.Add(tmpTile); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }
            // black
            else if ((int)tile.Piece.Player == 2)
            {
                for (int i = 1; i < 7; i++) // cast to the left end of the board
                    try
                    {
                        var tmpTile = b._tiles[currentY - i, currentX + i]; // current location of iteration

                        // add valid move if there is enemy and stop loop
                        if (tmpTile.Piece != null &&
                            (int)tmpTile.Piece.Player == 'b')
                        {
                            validMoves.Add(tmpTile); break;
                        }

                        //stop loop if there is friendly piece blocking the way
                        if (tmpTile.Piece != null &&
                            (int)tmpTile.Piece.Player == 'b')
                            break;

                        validMoves.Add(tmpTile); // add to valid moves if loop in not broken out of
                    }
                    catch { }
            }

            return validMoves; // return valid forward spaces
        }
        #endregion
    }
}
