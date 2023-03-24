namespace Core.Pieces
{
    public class Queen : Piece
    {
        #region constructor

        public Queen(char player) : base(player) { }

        #endregion

        #region public

        public override void GetValidMoves(Board board, Tile selectedTile)
        {
            CurrentValidMoves.Clear();

            //straight line movement
            CurrentValidMoves.AddRange(CastForwardMovement(board, selectedTile));
            CurrentValidMoves.AddRange(CastBackwardMovement(board, selectedTile));
            CurrentValidMoves.AddRange(CastLeftMovement(board, selectedTile));
            CurrentValidMoves.AddRange(CastRightMovement(board, selectedTile));

            //diagnal movement
            CurrentValidMoves.AddRange(CastDiagnalUpperRight(board, selectedTile));
            CurrentValidMoves.AddRange(CastDiagnalUpperLeft(board, selectedTile));
            CurrentValidMoves.AddRange(CastDiagnaLowerRight(board, selectedTile));
            CurrentValidMoves.AddRange(CastDiagnaLowerLeft(board, selectedTile));
            //IgnoreKing(validMoves);
        }

        #endregion

        internal override bool IsValidMove(int sourceColumn, int sourceRow, int destColumn, int destRow)
        {
            bool isDiagonalMove = this.IsDiagonalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isVerticalMove = this.IsVerticalMove(sourceColumn, sourceRow, destColumn, destRow);
            bool isHorizontalMove = this.IsHorizontalMove(sourceColumn, sourceRow, destColumn, destRow);

            return isDiagonalMove || isVerticalMove || isHorizontalMove;
        }

        #region private

        //#region straight line movement

        //private List<Tile> CastForwardMovement(Board b, Tile t)
        //{
        //    List<Tile> validMoves = new List<Tile>(); // list that will be returned

        //    int currentX = t.Row; // added for readability
        //    int currentY = t.Column;

        //    if ((int)t.Piece.Player == 1)
        //    {
        //        for (int i = currentY; i >= 0; i--) //cast movement upward
        //            if (t.Column != i)
        //            {
        //                if (b._tiles[i, currentX].Piece != null) // if there is a piece occupying a tile...
        //                {
        //                    if (b._tiles[i, currentX].Piece.CurrPlayer == Player.Player_One) // if its a piece on same team stop casting direction
        //                        break;
        //                    if (b._tiles[i, currentX].Piece.CurrPlayer == Player.Player_Two) // if its a piece on other team cast valid space on it and stop
        //                        validMoves.Add(b._tiles[i, currentX]); break;
        //                }

        //                validMoves.Add(b._tiles[i, currentX]); // add valid move if space is empty
        //            }
        //    }
        //    else if ((int)t.Piece.Player == 2)
        //    {
        //        for (int i = currentY; i >= 0; i--) //cast movement upward
        //            if (t.Column != i)
        //            {
        //                if (b._tiles[i, currentX].Piece != null) // if there is a piece occupying a tile...
        //                {
        //                    if (b._tiles[i, currentX].Piece.CurrPlayer == Player.Player_Two) // if its a piece on same team stop casting direction
        //                        break;
        //                    if (b._tiles[i, currentX].Piece.CurrPlayer == Player.Player_One) // if its a piece on other team cast valid space on it and stop
        //                        validMoves.Add(b._tiles[i, currentX]); break;
        //                }

        //                validMoves.Add(b._tiles[i, currentX]); // add valid move if space is empty
        //            }
        //    }

        //    return validMoves; // return valid forward spaces
        //}

        //private List<Tile> CastBackwardMovement(Board b, Tile t)
        //{
        //    List<Tile> validMoves = new List<Tile>();

        //    int currentX = t.Row;
        //    int currentY = t.Column;

        //    if ((int)t.Piece.Player == 1)
        //    {
        //        for (int i = currentY; i <= 7; i++) //cast movement downward
        //        {
        //            if (t.Column != i) // skip add the valid location on same position of selected rook
        //            {
        //                if (b._tiles[i, currentX].Piece != null) // if there is a piece occupying a tile...
        //                {
        //                    if (b._tiles[i, currentX].Piece.CurrPlayer == Player.Player_One) // if its a player on same team
        //                    {
        //                        break; // break out of loop
        //                    }
        //                    if (b._tiles[i, currentX].Piece.CurrPlayer == Player.Player_Two) // if its a player on other team
        //                    {
        //                        validMoves.Add(b._tiles[i, currentX]); // mark tile as valid
        //                        break; // break out of loop
        //                    }
        //                }

        //                validMoves.Add(b._tiles[i, currentX]); // add valid move if there is empty tile
        //            }

        //        }
        //    }
        //    else if ((int)t.Piece.Player == 2)
        //    {
        //        for (int i = currentY; i <= 7; i++) //cast movement downward
        //        {
        //            if (t.Column != i) // skip add the valid location on same position of selected rook
        //            {
        //                if (b._tiles[i, currentX].Piece != null) // if there is a piece occupying a tile...
        //                {
        //                    if (b._tiles[i, currentX].Piece.CurrPlayer == Player.Player_Two) // if its a player on same team
        //                    {
        //                        break; // break out of loop
        //                    }
        //                    if (b._tiles[i, currentX].Piece.CurrPlayer == Player.Player_One) // if its a player on other team
        //                    {
        //                        validMoves.Add(b._tiles[i, currentX]); // mark tile as valid
        //                        break; // break out of loop
        //                    }
        //                }

        //                validMoves.Add(b._tiles[i, currentX]); // add valid move if there is empty tile
        //            }
        //        }
        //    }

        //    return validMoves;
        //}

        //private List<Tile> CastLeftMovement(Board b, Tile t)
        //{
        //    List<Tile> validMoves = new List<Tile>();

        //    int currentX = t.Row;
        //    int currentY = t.Column;

        //    if ((int)t.Piece.Player == 1)
        //    {
        //        for (int i = currentX; i >= 0; i--) //cast movement left
        //        {
        //            if (t.Row != i) // skip add the valid location on same position of selected rook
        //            {
        //                if (b._tiles[currentY, i].Piece != null) // if there is a piece occupying a tile...
        //                {
        //                    if (b._tiles[currentY, i].Piece.CurrPlayer == Player.Player_One) // if its a player on same team
        //                    {
        //                        break; // break out of loop
        //                    }
        //                    if (b._tiles[currentY, i].Piece.CurrPlayer == Player.Player_Two) // if its a player on other team
        //                    {
        //                        validMoves.Add(b._tiles[currentY, i]); // mark tile as valid
        //                        break; // break out of loop
        //                    }
        //                }

        //                validMoves.Add(b._tiles[currentY, i]); // add valid move if there is empty tile
        //            }
        //        }
        //    }
        //    else if ((int)t.Piece.Player == 2)
        //    {
        //        for (int i = currentX; i >= 0; i--) //cast movement left
        //        {
        //            if (t.Row != i) // skip add the valid location on same position of selected rook
        //            {
        //                if (b._tiles[currentY, i].Piece != null) // if there is a piece occupying a tile...
        //                {
        //                    if (b._tiles[currentY, i].Piece.CurrPlayer == Player.Player_Two) // if its a player on same team
        //                    {
        //                        break; // break out of loop
        //                    }
        //                    if (b._tiles[currentY, i].Piece.CurrPlayer == Player.Player_One) // if its a player on other team
        //                    {
        //                        validMoves.Add(b._tiles[currentY, i]); // mark tile as valid
        //                        break; // break out of loop
        //                    }
        //                }

        //                validMoves.Add(b._tiles[currentY, i]); // add valid move if there is empty tile
        //            }
        //        }
        //    }

        //    return validMoves;
        //}

        //private List<Tile> CastRightMovement(Board b, Tile t)
        //{
        //    List<Tile> validMoves = new List<Tile>();

        //    int currentX = t.Row;
        //    int currentY = t.Column;

        //    if ((int)t.Piece.Player == 1)
        //    {
        //        for (int i = currentX; i <= 7; i++) //cast movement right
        //        {
        //            if (t.Row != i) // skip add the valid location on same position of selected rook
        //            {
        //                if (b._tiles[currentY, i].Piece != null) // if there is a piece occupying a tile...
        //                {
        //                    if (b._tiles[currentY, i].Piece.CurrPlayer == Player.Player_One) // if its a player on same team
        //                    {
        //                        break; // break out of loop
        //                    }
        //                    if (b._tiles[currentY, i].Piece.CurrPlayer == Player.Player_Two) // if its a player on other team
        //                    {
        //                        validMoves.Add(b._tiles[currentY, i]); // mark tile as valid
        //                        break; // break out of loop
        //                    }
        //                }

        //                validMoves.Add(b._tiles[currentY, i]); // add valid move if there is empty tile
        //            }
        //        }
        //    }
        //    else if ((int)t.Piece.Player == 2)
        //    {
        //        for (int i = currentX; i <= 7; i++) //cast movement right
        //        {
        //            if (t.Row != i) // skip add the valid location on same position of selected rook
        //            {
        //                if (b._tiles[currentY, i].Piece != null) // if there is a piece occupying a tile...
        //                {
        //                    if (b._tiles[currentY, i].Piece.CurrPlayer == Player.Player_Two) // if its a player on same team
        //                    {
        //                        break; // break out of loop
        //                    }
        //                    if (b._tiles[currentY, i].Piece.CurrPlayer == Player.Player_One) // if its a player on other team
        //                    {
        //                        validMoves.Add(b._tiles[currentY, i]); // mark tile as valid
        //                        break; // break out of loop
        //                    }
        //                }

        //                validMoves.Add(b._tiles[currentY, i]); // add valid move if there is empty tile
        //            }
        //        }
        //    }

        //    return validMoves;
        //}

        //#endregion

        //#region diagnal movement

        //private List<Tile> CastDiagnalUpperRight(Board b, Tile t)
        //{
        //    List<Tile> validMoves = new List<Tile>(); // list that will be returned

        //    int currentX = t.Row; // added for readability
        //    int currentY = t.Column;

        //    //player 1
        //    if ((int)t.Piece.Player == 1)
        //    {
        //        for (int i = 1; i < 7; i++) // cast to the right end of the board
        //            try
        //            {
        //                var location = b._tiles[currentY - i, currentX + i]; // current location of iteration

        //                // add valid move if there is enemy and stop loop
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_Two)
        //                {
        //                    validMoves.Add(location); break;
        //                }


        //                // stop loop if there is friendly piece blocking the way
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_One)
        //                    break;

        //                validMoves.Add(location); // add to valid moves if loop in not broken out of
        //            }
        //            catch { }
        //    }
        //    //player 2
        //    else if ((int)t.Piece.Player == 2)
        //    {
        //        for (int i = 1; i < 7; i++) // cast to the left end of the board
        //            try
        //            {
        //                var location = b._tiles[currentY + i, currentX - i]; // current location of iteration

        //                // add valid move if there is enemy and stop loop
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_One)
        //                {
        //                    validMoves.Add(location); break;
        //                }

        //                //stop loop if there is friendly piece blocking the way
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_Two)
        //                    break;

        //                validMoves.Add(location); // add to valid moves if loop in not broken out of
        //            }
        //            catch { }
        //    }

        //    return validMoves; // return valid forward spaces
        //}

        //private List<Tile> CastDiagnalUpperLeft(Board b, Tile t)
        //{
        //    List<Tile> validMoves = new List<Tile>(); // list that will be returned

        //    int currentX = t.Row; // added for readability
        //    int currentY = t.Column;

        //    //player 1
        //    if ((int)t.Piece.Player == 1)
        //    {  //int i = 1; i < 7; i++
        //        for (int i = 1; i < 7; i++) // cast to the left end of the board
        //            try
        //            {
        //                var location = b._tiles[currentY - i, currentX - i]; // current location of iteration

        //                // add valid move if there is enemy and stop loop
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_Two)
        //                {
        //                    validMoves.Add(location); break;
        //                }

        //                //stop loop if there is friendly piece blocking the way
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_One)
        //                    break;

        //                validMoves.Add(location); // add to valid moves if loop in not broken out of
        //            }
        //            catch { }
        //    }
        //    //player 2
        //    else if ((int)t.Piece.Player == 2)
        //    {
        //        for (int i = 1; i < 7; i++) // cast to the left end of the board
        //            try
        //            {
        //                var location = b._tiles[currentY + i, currentX + i]; // current location of iteration

        //                // add valid move if there is enemy and stop loop
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_One)
        //                {
        //                    validMoves.Add(location);
        //                    break;
        //                }

        //                //stop loop if there is friendly piece blocking the way
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_Two)
        //                    break;

        //                validMoves.Add(location); // add to valid moves if loop in not broken out of
        //            }
        //            catch { }
        //    }

        //    return validMoves; // return valid forward spaces
        //}

        //private List<Tile> CastDiagnaLowerRight(Board b, Tile t)
        //{
        //    List<Tile> validMoves = new List<Tile>(); // list that will be returned

        //    int currentX = t.Row; // added for readability
        //    int currentY = t.Column;

        //    //player 1
        //    if ((int)t.Piece.Player == 1)
        //    {
        //        for (int i = 1; i < 7; i++)
        //            try
        //            {
        //                var location = b._tiles[currentY + i, currentX + i]; // current location of iteration

        //                // add valid move if there is enemy and stop loop
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_Two)
        //                {
        //                    validMoves.Add(location); break;
        //                }


        //                // stop loop if there is friendly piece blocking the way
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_One)
        //                    break;

        //                validMoves.Add(location); // add to valid moves if loop in not broken out of
        //            }
        //            catch { }
        //    }
        //    //player 2
        //    else if ((int)t.Piece.Player == 2)
        //    {
        //        for (int i = 1; i < 7; i++) // cast to the left end of the board
        //            try
        //            {
        //                var location = b._tiles[currentY - i, currentX - i]; // current location of iteration

        //                // add valid move if there is enemy and stop loop
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_One)
        //                {
        //                    validMoves.Add(location); break;
        //                }

        //                //stop loop if there is friendly piece blocking the way
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_Two)
        //                    break;

        //                validMoves.Add(location); // add to valid moves if loop in not broken out of
        //            }
        //            catch { }
        //    }

        //    return validMoves; // return valid forward spaces
        //}

        //private List<Tile> CastDiagnaLowerLeft(Board b, Tile t)
        //{
        //    List<Tile> validMoves = new List<Tile>(); // list that will be returned

        //    int currentX = t.Row; // added for readability
        //    int currentY = t.Column;

        //    //player 1
        //    if ((int)t.Piece.Player == 1)
        //    {
        //        for (int i = 1; i < 7; i++)
        //            try
        //            {
        //                var location = b._tiles[currentY + i, currentX - i]; // current location of iteration

        //                // add valid move if there is enemy and stop loop
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_Two)
        //                {
        //                    validMoves.Add(location); break;
        //                }

        //                // stop loop if there is friendly piece blocking the way
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_One)
        //                    break;

        //                validMoves.Add(location); // add to valid moves if loop in not broken out of
        //            }
        //            catch { }
        //    }
        //    //player 2
        //    else if ((int)t.Piece.Player == 2)
        //    {
        //        for (int i = 1; i < 7; i++) // cast to the left end of the board
        //            try
        //            {
        //                var location = b._tiles[currentY - i, currentX + i]; // current location of iteration

        //                // add valid move if there is enemy and stop loop
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_One)
        //                {
        //                    validMoves.Add(location); break;
        //                }

        //                //stop loop if there is friendly piece blocking the way
        //                if (location.Piece != null &&
        //                    location.Piece.CurrPlayer == Player.Player_Two)
        //                    break;

        //                validMoves.Add(location); // add to valid moves if loop in not broken out of
        //            }
        //            catch { }
        //    }

        //    return validMoves; // return valid forward spaces
        //}


        //#endregion

        #endregion
    }
}
