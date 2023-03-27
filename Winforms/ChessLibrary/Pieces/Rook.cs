namespace ChessLibrary.Pieces
{
    public class Rook : Piece
    {
        #region Constructor
        public Rook(Player player, Tile tile) : base(player, tile) =>
            Image = player == Player.Player_One ? Assets.W_RookImg : Assets.B_RookImg;
        #endregion
        #region Public Methods
        public override void GetValidMoves(Game board, Tile selectedTile)
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
        private List<Tile> CastForwardMovement(Game b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>(); // list that will be returned

            int currentX = t.CoordinateX; // added for readability
            int currentY = t.CoordinateY;

            if ((int)t.CurrPiece.CurrPlayer == 1)
            {
                for (int i = currentY; i >= 0; i--) //cast movement upward
                    if (t.CoordinateY != i)
                    {
                        if (b.Tiles[i, currentX].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_One) // if its a piece on same team stop casting direction
                                break;
                            if (b.Tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_Two) // if its a piece on other team cast valid space on it and stop
                                validMoves.Add(b.Tiles[i, currentX]); break;
                        }

                        validMoves.Add(b.Tiles[i, currentX]); // add valid move if space is empty
                    }
            }
            else if ((int)t.CurrPiece.CurrPlayer == 2)
            {
                for (int i = currentY; i >= 0; i--) //cast movement upward
                    if (t.CoordinateY != i)
                    {
                        if (b.Tiles[i, currentX].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_Two) // if its a piece on same team stop casting direction
                                break;
                            if (b.Tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_One) // if its a piece on other team cast valid space on it and stop
                                validMoves.Add(b.Tiles[i, currentX]); break;
                        }

                        validMoves.Add(b.Tiles[i, currentX]); // add valid move if space is empty
                    }
            }

            return validMoves; // return valid forward spaces
        }
        private List<Tile> CastBackwardMovement(Game b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.CoordinateX;
            int currentY = t.CoordinateY;

            if ((int)t.CurrPiece.CurrPlayer == 1)
            {
                for (int i = currentY; i <= 7; i++) //cast movement downward
                {
                    if (t.CoordinateY != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[i, currentX].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[i, currentX]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[i, currentX]); // add valid move if there is empty tile
                    }

                }
            }
            else if ((int)t.CurrPiece.CurrPlayer == 2)
            {
                for (int i = currentY; i <= 7; i++) //cast movement downward
                {
                    if (t.CoordinateY != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[i, currentX].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[i, currentX].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on other team
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
        private List<Tile> CastLeftMovement(Game b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.CoordinateX;
            int currentY = t.CoordinateY;

            if ((int)t.CurrPiece.CurrPlayer == 1)
            {
                for (int i = currentX; i >= 0; i--) //cast movement left
                {
                    if (t.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[currentY, i].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }
            else if ((int)t.CurrPiece.CurrPlayer == 2)
            {
                for (int i = currentX; i >= 0; i--) //cast movement left
                {
                    if (t.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[currentY, i].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on other team
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
        private List<Tile> CastRightMovement(Game b, Tile t)
        {
            List<Tile> validMoves = new List<Tile>();

            int currentX = t.CoordinateX;
            int currentY = t.CoordinateY;

            if ((int)t.CurrPiece.CurrPlayer == 1)
            {
                for (int i = currentX; i <= 7; i++) //cast movement right
                {
                    if (t.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[currentY, i].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on other team
                            {
                                validMoves.Add(b.Tiles[currentY, i]); // mark tile as valid
                                break; // break out of loop
                            }
                        }

                        validMoves.Add(b.Tiles[currentY, i]); // add valid move if there is empty tile
                    }
                }
            }
            else if ((int)t.CurrPiece.CurrPlayer == 2)
            {
                for (int i = currentX; i <= 7; i++) //cast movement right
                {
                    if (t.CoordinateX != i) // skip add the valid location on same position of selected rook
                    {
                        if (b.Tiles[currentY, i].CurrPiece != null) // if there is a piece occupying a tile...
                        {
                            if (b.Tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_Two) // if its a player on same team
                            {
                                break; // break out of loop
                            }
                            if (b.Tiles[currentY, i].CurrPiece.CurrPlayer == Player.Player_One) // if its a player on other team
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
    }
}
