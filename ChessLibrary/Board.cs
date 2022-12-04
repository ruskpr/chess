using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChessLibrary
{
    [Serializable]
    public class Board : Panel
    {
        #region Delegate definitions
        //event is called on main form constructor
        public delegate void PieceMovedDelegate();
        public event PieceMovedDelegate OnPieceMoved;

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
        #region Props
        public Tile SelTile { get; set; }
        public Form ParentForm { get; set; }
        public SidePanel SidePanel { get; set; }
        public int ColorPack { get; set; }
        public string Turn { get { return (int)GameManager.Turn == 1 ? "Player 1" : "Player 2"; } }
        public string LatestMove { get { return latestMove; } }
        public Room CurrentRoom { get; set; }
        #endregion
        #region Constructor / Finalizer
        public Board(Form form, Room? room = null)
        {
            this.ParentForm = form;
            this.CurrentRoom = CreateRoom();
            //this.Size = new Size(size, size);
            this.BackColor = Color.Transparent;
            //tileSize = new Size(Width / 8, Width / 8);
            ColorPack = 0;

            SelTile = null;
            Tile.OnSelected += Tile_OnSelected;
            Tile.SendTargetTile += Tile_SendTargetTile;

            // construct board and place on form
            ConstructBoard();
        }
        ~Board() => System.Diagnostics.Debug.WriteLine($"Chessboard was disposed");
        #endregion
        #region Create Room
        private Room CreateRoom()
        {
            Room room = new Room();

            LocalDataSaver ds = new();

            List<User> localUsers = ds.LoadPlayerData();

            room.PlayerOne = localUsers[0];
            room.PlayerTwo = localUsers[1];
            return room;
        }
        #endregion
        #region Construct Board method
        public void ConstructBoard()
        {
            AddTiles();
            AddPieces();

            // store all the moves of each piece when board is created
            foreach (Piece p in Piece.Pieces)
                p.GetValidMoves(this, p.CurrentTile);

            // add side panel
            SidePanel = new SidePanel(this);

            // set up event handlers and add board to parent form
            ParentForm.SizeChanged += ParentForm_SizeChanged;
            ParentForm.Resize += ParentForm_Resize;
            ParentForm.LocationChanged += ParentForm_LocationChanged;
            ParentForm.Controls.Add(this);
            ResponsiveLayout();
        }
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
                }
            }
        }
        #endregion
        #region Delegate to send and recieve tiles
        private void Tile_OnSelected(Tile tile) //recieve selected tile
        {
            SelTile = tile;
            //display valid moves for selected tile
            //GetValidMoves(SelectedTile);
        }
        private void Tile_SendTargetTile(Tile targetTile) // recieve target tile (the tiles new position)
        {  
            MovePiece(SelTile, targetTile);
        }
        #endregion
        #region Move Piece operations
        public void MovePiece(Tile oldTile, Tile newTile)
        {
            if (oldTile.CurrPiece != null)
            {
                if ((int)SelTile.CurrPiece.CurrPlayer == (int)GameManager.Turn)
                {
                    //check if opponent piece was captured
                    if (newTile.CurrPiece != null)
                    {
                        Piece capturedPiece = newTile.CurrPiece;

                        // remove from main list
                        Piece.Pieces.Remove(capturedPiece);

                        // if piece is captured place it in capturedPiece list
                        if ((int)capturedPiece.CurrPlayer == 1)
                            Piece.PlayerOne_CapturedPieces.Add(capturedPiece);
                        else
                            Piece.PlayerTwo_CapturedPieces.Add(capturedPiece);   
                    }

                    //set selected tiles to have the newly moved piece
                    newTile.CurrPiece = oldTile.CurrPiece;

                    //MessageBox.Show(newTile.CurrentPiece.CurrentTile.ToString());
                    newTile.CurrPiece.CurrentTile = newTile;
                    //update new tile
                    newTile.BackgroundImage = oldTile.BackgroundImage;
                    oldTile.BackgroundImage = null;

                    // push move into stack
                    MoveStack.Push(new Tuple<Piece, Tile, Tile>(newTile.CurrPiece, oldTile, newTile));

                    //remove oldtile (set images and child piece of tile to null)
                    oldTile.DiscardPosition();

                    // set bool
                    newTile.CurrPiece.CompletedFirstMove = true;

                    // check if recently moved piece is checking a king
                    newTile.CurrPiece.GetValidMoves(this, newTile);

                    // check if moved piece is checking the opposite king
                    CheckIfInCheck(newTile);

                    // hide indicators
                    foreach (Tile tile in Tiles)
                    {
                        tile.IsAValidSpace = false;
                        tile.Image = null;
                    }

                    // store latest move as string 
                    latestMove = $"{newTile.CurrPiece} moved from " +
                                $"{oldTile.CoordinateX}, {oldTile.CoordinateY} " +
                                $"to {newTile.CoordinateX}, {newTile.CoordinateY}";

                    // switch turn after a move
                    GameManager.SwapTurn();

                    //send delegate to side panel
                    OnPieceMoved.Invoke();
                }
            }       
        }
        #endregion
        #region show moves method
        public void ShowMovesOfSelectedTile(Tile selTile)
        {
            if (selTile.CurrPiece != null)
            {
                // generate moves on click
                selTile.CurrPiece.GetValidMoves(this, selTile);

                //only show moves if it is the players turn

                if ((int)SelTile.CurrPiece.CurrPlayer == (int)GameManager.Turn)
                {
                    // get list of moves for selected tile
                    List<Tile> currentTilesMoves = selTile.CurrPiece != null ?
                    selTile.CurrPiece.CurrentValidMoves : new List<Tile>();

                    //clear valid move indicators on all tiles
                    foreach (Tile tile in Tiles)
                    {
                        tile.IsAValidSpace = false;
                        tile.Image = null;
                    }

                    foreach (Tile tile in currentTilesMoves)
                    {
                        tile.IsAValidSpace = true;

                        tile.Image = tile.CurrPiece != null ?
                            Assets.ValidKillImg : Assets.ValidMoveImg;
                    }
                }
            }
        }
        #endregion
        #region Check if in king is in check method
        public void CheckIfInCheck(Tile mostRecentTile)
        {
            foreach (Tile move in mostRecentTile.CurrPiece.CurrentValidMoves)
            {
                if (move.CurrPiece is King && move.CurrPiece.CurrPlayer !=
                    mostRecentTile.CurrPiece.CurrPlayer )
                {
                    King checkedKing = (King)move.CurrPiece; // type cast to king
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
                locX = 0; // go to left side of board to iterate next row
                locY += tileSize.Height; // move one row down 
            }
        }
        #endregion
        #region ResetBoard
        public void ResetBoard()
        {
            MoveStack.Clear();
            SidePanel.Visible = false;
            SidePanel.Dispose();
            Piece.Pieces.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tiles[i, j].Location = new Point(-300, -300);
                    Tiles[i, j] = null;
                }
            }

            //Contruct new board after everything is reset
            ParentForm.Cursor = Cursors.WaitCursor;
            ConstructBoard();
            ParentForm.Cursor = Cursors.Default;

            GC.Collect();
        }
        #endregion
        #region Responsive layout
        public void ResponsiveLayout()
        {   
            if (ParentForm.Width < 500 )
            {
                SidePanel.Visible = false;
                this.Left = ParentForm.Width / 2 - (this.Width / 2) - 10;
                this.Size = new Size((int)Math.Round(ParentForm.Height * 0.85), (int)Math.Round(ParentForm.Height * 0.85));
                this.Top = 15;

            }
            else
            {
                this.Size = new Size(this.Height, (int)Math.Round(ParentForm.Height * 0.75));
                SidePanel.Visible = true;
                this.Left = ParentForm.Width / 2 - (this.Width / 2);
                this.Left -= this.Width / 4;
                this.Top = ParentForm.Height / 2 - (this.Height / 2);

            }



            tileSize = new Size(Width / 8, Width / 8);

            foreach (Tile t in Tiles)
                t.Size = tileSize;

            int x = 0;
            int y = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tiles[i, j].Location = new Point(x, y);
                    x += tileSize.Width;
                }
                x = 0;
                y += tileSize.Height;
            }

            if (ParentForm.Height < 200 && ParentForm.Width < 200)
                this.Location = new Point(0, 0);

            SidePanel.ResponsiveLayout();
        }
        #endregion
        #region Parent board events for responsive layout
        private void ParentForm_LocationChanged(object? sender, EventArgs e) => ResponsiveLayout();
        private void ParentForm_Resize(object? sender, EventArgs e) => ResponsiveLayout();
        private void ParentForm_SizeChanged(object? sender, EventArgs e) => ResponsiveLayout();

        #endregion        
    }
}
