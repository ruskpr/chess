using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{

    public delegate void PieceMovedDelegate(Tile tileStart, Tile tileEnd);
    public class Board : Panel
    {
        #region Delegate definition
        //event is called on main form constructor
        public event PieceMovedDelegate PieceMoved;
        #endregion
        #region Fields
        // 2d array of tiles
        public Tile[,] Tiles = new Tile[8, 8];

        //size of the tiles (initialized in Board class constructor
        // used in AddTiles() method
        Size tileSize;
        #endregion
        #region Properties
        public Tile SelectedTile { get; set; }
        #endregion
        #region Constructor
        public Board(Form pntr, int size)
        {
            Size = new Size(size, size);
            tileSize = new Size(Width / 8, Width / 8);
            BackColor = Color.White;

            SelectedTile = null;
            Tile.SendSelectedTile += Tile_SendSelectedTile;
            Tile.SendTargetTile += Tile_SendTargetTile;
            pntr.Controls.Add(this);
        }

        
        #endregion
        #region Construct Board
        public void ConstructBoard()
        {
            AddTiles();
            AddPieces();
        }
        #endregion
        #region Delegate to recieve tiles
        private void Tile_SendSelectedTile(Tile tile) //recieve selected tile
        {
            SelectedTile = tile;
            //display valid moves for selected tile
            GetValidMoves(SelectedTile);
        }
        private void Tile_SendTargetTile(Tile tile) // recieve target tile (the tile the user clicks to move their piece
        {
            
            MovePiece(SelectedTile, tile);
            tile.CurrentPiece.CompletedFirstMove = true;
        }
        #endregion
        #region Move Piece method
        public void MovePiece(Tile oldTile, Tile newTile)
        {
            newTile.CurrentPiece = oldTile.CurrentPiece;

            //update new tile
            newTile.BackgroundImage = oldTile.BackgroundImage;
            oldTile.BackgroundImage = null;

            //remove oldtile
            oldTile.RemovePiece();

            //send delegate 
            PieceMoved.Invoke(oldTile, newTile);
        }
        #endregion
        #region Get valid moves method
        public List<Tile> GetValidMoves(Tile selTile)
        {
            List<Tile> validMoves = new List<Tile>();

            //clear valid move indicators on each selection
            foreach (Tile tile in Tiles)
            {
                tile.IsAValidSpace = false;
                tile.Image = null;
            }
             
            //calculate values on type of piece that you selectedd
            switch (selTile.CurrentPiece)
            {
                #region Pawn movement
                case Pawn:
                    if (selTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
                    {
                        // allow pawn to move 2 spaces on its first move
                        if (selTile.CurrentPiece.CompletedFirstMove == false)
                            validMoves.Add(Tiles[selTile.CoordinateY - 2, selTile.CoordinateX]);

                        // error check to not allow spaces outside of board index
                        if (selTile.CoordinateY > 0)
                        {
                            // 1 space forward (only allows move if no pieces infront
                            if (Tiles[selTile.CoordinateY - 1, selTile.CoordinateX].CurrentPiece == null)
                                validMoves.Add(Tiles[selTile.CoordinateY - 1, selTile.CoordinateX]);

                            try // try catch to ignore out of board index
                            {
                                // if there is a enemy peice AND they are left diagnal of pawn, allow them to kill
                                if (Tiles[selTile.CoordinateY - 1, selTile.CoordinateX - 1].CurrentPiece is Piece &&
                                    Tiles[selTile.CoordinateY - 1, selTile.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                                    validMoves.Add(Tiles[selTile.CoordinateY - 1, selTile.CoordinateX - 1]);

                            } catch { } // ignore exception 

                            try // try catch to ignore out of board index
                            {
                                // enemy at right diagnal -> valid kill
                                if (Tiles[selTile.CoordinateY - 1, selTile.CoordinateX + 1].CurrentPiece is Piece &&
                                    Tiles[selTile.CoordinateY - 1, selTile.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                                    validMoves.Add(Tiles[selTile.CoordinateY - 1, selTile.CoordinateX + 1]);

                            } catch { } // ignore exception 
                        }
                    }
                    else if (selTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two && GameManager.Turn == GameManager.PlayerTurn.p2)
                    {
                        // allow pawn to move 2 spaces on its first move
                        if (selTile.CurrentPiece.CompletedFirstMove == false)
                            validMoves.Add(Tiles[selTile.CoordinateY + 2, selTile.CoordinateX]);

                        // error check to not allow spaces outside of board index
                        if (selTile.CoordinateY < 7)
                        {
                            // 1 space forward (only allows move if no pieces infront
                            if (Tiles[selTile.CoordinateY + 1, selTile.CoordinateX].CurrentPiece == null)
                                validMoves.Add(Tiles[selTile.CoordinateY + 1, selTile.CoordinateX]);

                            try // try catch to ignore out of board index
                            {
                                // if there is a enemy piece AND they are left diagnal of pawn, allow them to kill
                                if (Tiles[selTile.CoordinateY + 1, selTile.CoordinateX + 1].CurrentPiece is Piece &&
                                    Tiles[selTile.CoordinateY + 1, selTile.CoordinateX + 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                                    validMoves.Add(Tiles[selTile.CoordinateY + 1, selTile.CoordinateX + 1]);

                            }
                            catch { } // ignore exception 

                            try // try catch to ignore out of board index
                            {
                                // enemy at right diagnal -> valid kill
                                if (Tiles[selTile.CoordinateY + 1, selTile.CoordinateX - 1].CurrentPiece is Piece &&
                                    Tiles[selTile.CoordinateY + 1, selTile.CoordinateX - 1].CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                                    validMoves.Add(Tiles[selTile.CoordinateY + 1, selTile.CoordinateX - 1]);
                            }
                            catch { } // ignore exception 
                        }
                    }
                    break;
                #endregion
                case Rook:

                    int currentX = selTile.CoordinateX;
                    int currentY = selTile.CoordinateY;

                    if (selTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_One && GameManager.Turn == GameManager.PlayerTurn.p1)
                    {
                    // UP and DONW movement
                        for (int i = currentY; i >= 0; i--) //cast movement upward
                        {
                            if (selTile.CoordinateY != i )
                            {
                                if (Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                                {
                                    if (Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                                    {
                                        break;
                                    }
                                    if (Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                                    {
                                        validMoves.Add(Tiles[i, currentX]);
                                        break;
                                    }
                                }

                                validMoves.Add(Tiles[i, currentX]);
                            }
                        }
                        for (int i = currentY; i <= 7; i++) //cast movement downward
                        {
                            if (selTile.CoordinateY != i) // skip add the valid location on same position of selected rook
                            {
                                if (Tiles[i, currentX].CurrentPiece != null) // if there is a piece occupying a tile...
                                {
                                    if (Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                                    {
                                        break; // break out of loop
                                    }
                                    if (Tiles[i, currentX].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                                    {
                                        validMoves.Add(Tiles[i, currentX]); // mark tile as valid
                                        break; // break out of loop
                                    }
                                }

                                validMoves.Add(Tiles[i, currentX]); // add valid move if there is empty tile
                            }

                        }

                        // LEFT and RIGHT movement
                        for (int i = currentX; i >= 0; i--) //cast movement left
                        {
                            if (selTile.CoordinateX != i) // skip add the valid location on same position of selected rook
                            {
                                if (Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                                {
                                    if (Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                                    {
                                        break; // break out of loop
                                    }
                                    if (Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                                    {
                                        validMoves.Add(Tiles[currentY, i]); // mark tile as valid
                                        break; // break out of loop
                                    }
                                }

                                validMoves.Add(Tiles[currentY, i]); // add valid move if there is empty tile
                            }
                        }
                        for (int i = currentX; i <= 7; i++) //cast movement right
                        {
                            if (selTile.CoordinateX != i) // skip add the valid location on same position of selected rook
                            {
                                if (Tiles[currentY, i].CurrentPiece != null) // if there is a piece occupying a tile...
                                {
                                    if (Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_One) // if its a player on same team
                                    {
                                        break; // break out of loop
                                    }
                                    if (Tiles[currentY, i].CurrentPiece.CurrentPlayer == Piece.Player.Player_Two) // if its a player on other team
                                    {
                                        validMoves.Add(Tiles[currentY, i]); // mark tile as valid
                                        break; // break out of loop
                                    }
                                }

                                validMoves.Add(Tiles[currentY, i]); // add valid move if there is empty tile
                            }
                        }
                    } 



                    //validMoves.Add(Tiles[currentY - 2, currentX]);
                    //validMoves.Add(Tiles[currentY - 3, currentX]);
                    //validMoves.Add(Tiles[currentY - 4, currentX]);
                    //validMoves.Add(Tiles[currentY - 5, currentX]);


                    //cast movement downward


                    break;
                case Knight:

                    break;
                case Bishop:

                    break;
                case Queen:

                    break;
                case King:

                    break;
            }

            foreach (Tile tile in validMoves)
            {
                if (tile.CurrentPiece != null)
                    tile.Image = MyAssets.ValidKillImg;
                else
                    tile.Image = MyAssets.ValidMoveImg;

                tile.IsAValidSpace = true;
            }
            return validMoves;
        }
        #endregion
        #region Add tiles method
        public void AddTiles()
        {
            int locX = 0;
            int locY = 0;
            Color tileColor;
            bool colorToggle = true;


            for (int i = 0; i < 8; i++) // column Y
            {
                colorToggle = !colorToggle;
                for (int j = 0; j < 8; j++) // row X
                {
                    tileColor = colorToggle ? Color.MediumVioletRed : Color.DarkOrange;

                    Tile tile = new Tile(this, tileSize, new Point(locX, locY), j, i, tileColor);

                    Tiles[i, j] = tile;

                    locX += tileSize.Width;
                    colorToggle = !colorToggle;
                    this.Controls.Add(tile);
                }
                locX = 0;
                locY += tileSize.Height;
                BackColor = Color.White;
            }
        }
        #endregion
        #region Add pieces method
        public void AddPieces()
        {
            //loop through each tile in 2d array (player 1 is white, player 2 is black)
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (i == 1)
                        Tiles[i, j].CreatePiece("pawn", 2); // add player 2's pawns to 2nd row
                    if (i == 6)
                        Tiles[i, j].CreatePiece("pawn", 1); // add player 1's pawns to 7th row

                    // player 1's backrow
                    if (i == 7)
                    {
                        if (j == 0 || j == 7)
                            Tiles[i, j].CreatePiece("rook", 1); // add player 1's rooks
                        if (j == 1 || j == 6)
                            Tiles[i, j].CreatePiece("knight", 1); // add player 1's knights
                        if (j == 2 || j == 5)
                            Tiles[i, j].CreatePiece("bishop", 1); // add player 1's bishops
                        if (j == 3)
                            Tiles[i, j].CreatePiece("queen", 1); // add player 1's queen
                        if (j == 4)
                            Tiles[i, j].CreatePiece("king", 1); // add player 1's king
                    }

                    // player 2's backrow
                    if (i == 0)
                    {
                        if (j == 0 || j == 7)
                            Tiles[i, j].CreatePiece("rook", 2); // add player 2's rooks
                        if (j == 1 || j == 6)
                            Tiles[i, j].CreatePiece("knight", 2); // add player 2's knights
                        if (j == 2 || j == 5)
                            Tiles[i, j].CreatePiece("bishop", 2); // add player 2's bishops
                        if (j == 3)
                            Tiles[i, j].CreatePiece("queen", 2); // add player 2's queen
                        if (j == 4)
                            Tiles[i, j].CreatePiece("king", 2); // add player 2's king
                    }

                    //test
                    //if (i == 5 || i == 6)
                        //Tiles[i, j].Image = MyAssets.ValidSpaceImg;
                }
            }
        }
        #endregion  
        #region Overrided ToString() method
        public override string ToString()
        {
            return "Chessboard";
        }
        #endregion
    }
}
