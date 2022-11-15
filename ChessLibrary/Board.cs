using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChessLibrary
{

    public delegate void PieceMovedDelegate();


    public class Board : Panel
    {
        #region Delegate definitions
        //event is called on main form constructor
        public event PieceMovedDelegate PieceMoved;


        public delegate void OnKingCheckedDelegate(King kingThatIsChecked);
        public static event OnKingCheckedDelegate OnKingChecked;
        #endregion
        #region Fields
        // 2d array of tiles
        public Tile[,] Tiles = new Tile[8, 8];
        public Stack<Tuple<Piece, Tile, Tile>> MoveStack = new Stack<Tuple<Piece, Tile, Tile>>();
        //size of the tiles (initialized in Board class constructor
        // used in AddTiles() method
        Size tileSize;

        private string latestMove = "";
        #endregion
        #region Properties
        public Tile SelectedTile { get; set; }
        public Form ParentForm { get; set; }
        public LeftPanel SidePanel { get; set; }
        public int ColorPack { get; set; }
        public string Turn { get { return (int)GameManager.Turn == 1 ? "Player 1" : "Player 2"; } }
        public string LatestMove { get { return latestMove; } }
        #endregion
        #region Constructor
        public Board(Form form, int size)
        {
            this.ParentForm = form;
            this.Size = new Size(size, size);
            this.BackColor = Color.White;
            tileSize = new Size(Width / 8, Width / 8);
            ColorPack = 0;

            SelectedTile = null;
            Tile.OnSelected += Tile_OnSelected;
            Tile.SendTargetTile += Tile_SendTargetTile;

            // construct board and place on form
            ConstructBoard();
            this.ParentForm.Controls.Add(this);

            ResponsiveLayout();

            // store all the moves of each piece when board is created
            foreach(Piece p in Piece.Pieces)
                p.GetValidMoves(this, p.CurrentTile);
        }
        #endregion
        #region Construct Board method
        public void ConstructBoard()
        {
            AddTiles();
            AddPieces();

            // add side panels
            SidePanel = new LeftPanel(this);
        }
        public void ResponsiveLayout()
        {
            Format.Center(this);
            SidePanel.ResponsiveLayout();
        }
        #endregion
        #region Delegate to send and recieve tiles
        private void Tile_OnSelected(Tile tile) //recieve selected tile
        {
            SelectedTile = tile;
            //display valid moves for selected tile
            //GetValidMoves(SelectedTile);
        }
        private void Tile_SendTargetTile(Tile tile) // recieve target tile (the tiles new position)
        {  
            MovePiece(SelectedTile, tile);
        }
        #endregion
        #region Move Piece method
        public void MovePiece(Tile oldTile, Tile newTile)
        {
            if (oldTile.CurrentPiece != null)
            {
                if ((int)SelectedTile.CurrentPiece.CurrentPlayer == (int)GameManager.Turn)
                {
                    //check if opponent piece was captured
                    if (newTile.CurrentPiece != null)
                    {
                        Piece capturedPiece = newTile.CurrentPiece;

                        // remove from main list
                        Piece.Pieces.Remove(capturedPiece);

                        // if piece is captured place it in capturedPiece list
                        if ((int)capturedPiece.CurrentPlayer == 1)
                            Piece.PlayerOne_CapturedPieces.Add(capturedPiece);
                        else
                            Piece.PlayerTwo_CapturedPieces.Add(capturedPiece);   
                    }

                    //set selected tiles to have the newly moved piece
                    newTile.CurrentPiece = oldTile.CurrentPiece;

                    //MessageBox.Show(newTile.CurrentPiece.CurrentTile.ToString());
                    newTile.CurrentPiece.CurrentTile = newTile;
                    //update new tile
                    newTile.BackgroundImage = oldTile.BackgroundImage;
                    oldTile.BackgroundImage = null;

                    // push move into stack
                    MoveStack.Push(new Tuple<Piece, Tile, Tile>(newTile.CurrentPiece, oldTile, newTile));

                    //remove oldtile (set images and child piece of tile to null)
                    oldTile.DiscardPosition();

                    // set bool
                    newTile.CurrentPiece.CompletedFirstMove = true;

                    // check if recently moved piece is checking a king
                    newTile.CurrentPiece.GetValidMoves(this, newTile);

                    // check if moved piece is checking the opposite king
                    CheckIfInCheck(newTile);

                    // hide indicators
                    foreach (Tile tile in Tiles)
                    {
                        tile.IsAValidSpace = false;
                        tile.Image = null;
                    }

                    // update opposing pieces' moves to see if the recent move is a valid move for the enemy
                    //foreach (Piece piece in Piece.Pieces)
                    //    if (piece.CurrentPlayer != newTile.CurrentPiece.CurrentPlayer)
                    //        piece.GetValidMoves(this, piece.CurrentTile);

                    // store latest move as string 
                    latestMove = $"{newTile.CurrentPiece} moved from " +
                                $"{oldTile.CoordinateX}, {oldTile.CoordinateY} " +
                                $"to {newTile.CoordinateX}, {newTile.CoordinateY}";

                    // switch turn after a move
                    GameManager.SwapTurns();

                    //send delegate to side panel
                    PieceMoved.Invoke();
                    
                }
            }       
        }
        #endregion
        #region show moves method
        public void ShowMovesOfSelectedTile(Tile selTile)
        {
            if (selTile.CurrentPiece != null)
            {
                // generate moves on click
                selTile.CurrentPiece.GetValidMoves(this, selTile);

                //only show moves if it is the players turn

                if ((int)SelectedTile.CurrentPiece.CurrentPlayer == (int)GameManager.Turn)
                {
                    // get list of moves for selected tile
                    List<Tile> currentTilesMoves = selTile.CurrentPiece != null ?
                    selTile.CurrentPiece.CurrentValidMoves : new List<Tile>();

                    //clear valid move indicators on all tiles
                    foreach (Tile tile in Tiles)
                    {
                        tile.IsAValidSpace = false;
                        tile.Image = null;
                    }

                    foreach (Tile tile in currentTilesMoves)
                    {
                        tile.IsAValidSpace = true;

                        tile.Image = tile.CurrentPiece != null ?
                            Assets.ValidKillImg : Assets.ValidMoveImg;
                    }
                }
            }
        }
        #endregion
        #region Check if in king is in check method
        public void CheckIfInCheck(Tile mostRecentTile)
        {
            foreach (Tile move in mostRecentTile.CurrentPiece.CurrentValidMoves)
            {
                if (move.CurrentPiece is King && move.CurrentPiece.CurrentPlayer !=
                    mostRecentTile.CurrentPiece.CurrentPlayer )
                {
                    King checkedKing = (King)move.CurrentPiece; // type cast to king
                    OnKingChecked.Invoke(checkedKing);
                    break;
                }
            }
        }
        #endregion
        #region Add tiles to board method
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
                    tileColor = colorToggle ?
                        GameManager.ColorPackages[ColorPack].Item1 :
                        GameManager.ColorPackages[ColorPack].Item2;

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
        #region Add game pieces to board method
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
        #region Reset board
        public void ResetBoard()
        {
            foreach (Piece p in Piece.Pieces)
            {
                p.Dispose();
            }
            foreach (Tile t in Tiles)
            {
                t.Dispose();
            }


            ConstructBoard();
        }
        #endregion
        #region Overrided ToString() method
        public override string ToString() => "Chessboard";
        #endregion
    }
}
