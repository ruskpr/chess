﻿namespace Core.Pieces
{
    public class Rook : Piece
    {
        #region Constructor
        public Rook(char player, Tile tile) : base(player, tile) { }
        #endregion
        #region Public Methods
        public override void GetValidMoves(Board board, Tile selectedTile)
        {
            CurrentValidMoves.Clear();

            CurrentValidMoves.AddRange(CastForwardMovement(board, selectedTile));
            CurrentValidMoves.AddRange(CastBackwardMovement(board, selectedTile));
            CurrentValidMoves.AddRange(CastLeftMovement(board, selectedTile));
            CurrentValidMoves.AddRange(CastRightMovement(board, selectedTile));
            IgnoreKing(CurrentValidMoves);
        }
        #endregion
        #region Private Methods 
        private List<Tile> CastForwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.X; // added for readability
            int currentY = t.Y;

            if ((int)t.CurrPiece.Player == 1)
            {
                for (int i = currentY; i >= 0; i--) //cast movement upward
                    if (t.Y != i)
                    {
                        if (b._tiles[i, currentX].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b._tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_One) // if its a piece on same team stop casting direction
                                break;
                            if (b._tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_Two) // if its a piece on other team cast valid space on it and stop
                                validMoves.Add(b._tiles[i, currentX]); break;
                        }

                        validMoves.Add(b._tiles[i, currentX]); // add valid move if space is empty
                    }
            }
            else if ((int)t.CurrPiece.Player == 2)
            {
                for (int i = currentY; i >= 0; i--) //cast movement upward
                    if (t.Y != i)
                    {
                        if (b._tiles[i, currentX].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b._tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_Two) // if its a piece on same team stop casting direction
                                break;
                            if (b._tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_One) // if its a piece on other team cast valid space on it and stop
                                validMoves.Add(b._tiles[i, currentX]); break;
                        }

                        validMoves.Add(b._tiles[i, currentX]); // add valid move if space is empty
                    }
            }

            return validMoves; // return valid forward spaces
        }
        private List<Tile> CastBackwardMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.X;
            int currentY = t.Y;

            if ((int)t.CurrPiece.Player == 1)
            {
                for (int i = currentY; i <= 7; i++) //cast movement downward
                {
                    if (t.Y != i) // skip add the valid location on same position of selected rook
                    {
                        if (b._tiles[i, currentX].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b._tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b._tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b._tiles[i, currentX]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b._tiles[i, currentX]); // add valid move if there is empty tile
                    }

                }
            }
            else if ((int)t.CurrPiece.Player == 2)
            {
                for (int i = currentY; i <= 7; i++) //cast movement downward
                {
                    if (t.Y != i) // skip add the valid location on same position of selected rook
                    {
                        if (b._tiles[i, currentX].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b._tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b._tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(b._tiles[i, currentX]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b._tiles[i, currentX]); // add valid move if there is empty tile
                    }
                }
            }

            return validMoves;
        }
        private List<Tile> CastLeftMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.X;
            int currentY = t.Y;

            if ((int)t.CurrPiece.Player == 1)
            {
                for (int i = currentX; i >= 0; i--) //cast movement left
                {
                    if (t.X != i) // skip add the valid location on same position of selected rook
                    {
                        if (b._tiles[currentY, i].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b._tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b._tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b._tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b._tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }
            else if ((int)t.CurrPiece.Player == 2)
            {
                for (int i = currentX; i >= 0; i--) //cast movement left
                {
                    if (t.X != i) // skip add the valid location on same position of selected rook
                    {
                        if (b._tiles[currentY, i].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b._tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b._tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(b._tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b._tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }

            return validMoves;
        }
        private List<Tile> CastRightMovement(Board b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.X;
            int currentY = t.Y;

            if ((int)t.CurrPiece.Player == 1)
            {
                for (int i = currentX; i <= 7; i++) //cast movement right
                {
                    if (t.X != i) // skip add the valid location on same position of selected rook
                    {
                        if (b._tiles[currentY, i].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b._tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b._tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b._tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b._tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }
            else if ((int)t.CurrPiece.Player == 2)
            {
                for (int i = currentX; i <= 7; i++) //cast movement right
                {
                    if (t.X != i) // skip add the valid location on same position of selected rook
                    {
                        if (b._tiles[currentY, i].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b._tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b._tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on other team
                            {
                                validMoves.Add(b._tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b._tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }

            return validMoves;
        }
        #endregion
    }
}