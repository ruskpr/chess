using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class Bishop : Piece
    {
        #region Constructor
        public Bishop(Player player, Tile tile) : base(player, tile) =>
            this.Image = player == Player.Player_One ? Assets.W_BishopImg : Assets.B_BishopImg;
        #endregion
        #region Public Methods
        public override List<Tile> GetValidMoves(Board board, Tile selectedTile)
        {
            List<Tile> validMoves = new List<Tile>();

            validMoves.AddRange(CastDiagnalUpperRight(board, selectedTile));
            validMoves.AddRange(CastDiagnalUpperLeft(board, selectedTile));
            validMoves.AddRange(CastDiagnaLowerRight(board, selectedTile));
            validMoves.AddRange(CastDiagnaLowerLeft(board, selectedTile));
            IgnoreKing(validMoves);

            return validMoves;
        }
        #endregion
        #region Private Methods

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
