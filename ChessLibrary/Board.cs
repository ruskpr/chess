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

    public delegate void PieceMovedDelegate(Tile tileStart, Tile tileEnd);


    public class Board : Panel
    {
        #region Delegate definition
        //event is called on main form constructor
        public event PieceMovedDelegate PieceMoved;


        public delegate void OnKingCheckedDelegate(King kingThatIsChecked);
        public event OnKingCheckedDelegate OnKingChecked;
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
        public Form ParentForm { get; set; }
        #endregion
        #region Constructor
        public Board(Form pntr, int size)
        {
            this.ParentForm = pntr;
            this.Size = new Size(size, size);
            this.BackColor = Color.White;
            tileSize = new Size(Width / 8, Width / 8);

            // add side panels
            ParentForm.Controls.Add(new LeftPanel(this));

            SelectedTile = null;
            Tile.SendSelectedTile += Tile_SendSelectedTile;
            Tile.SendTargetTile += Tile_SendTargetTile;

            ConstructBoard();
            this.ParentForm.Controls.Add(this);

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
        }
        #endregion
        #region Delegate to send and recieve tiles
        private void Tile_SendSelectedTile(Tile tile) //recieve selected tile
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
                    //set selected tiles to have the newly moved piece
                    newTile.CurrentPiece = oldTile.CurrentPiece;

                    //MessageBox.Show(newTile.CurrentPiece.CurrentTile.ToString());
                    newTile.CurrentPiece.CurrentTile = newTile;
                    //update new tile
                    newTile.BackgroundImage = oldTile.BackgroundImage;
                    oldTile.BackgroundImage = null;

                    //remove oldtile
                    oldTile.RemovePiece();

                    // set bool
                    newTile.CurrentPiece.CompletedFirstMove = true;

                    //store new set of moves after being moved
                    //newTile.CurrentPiece.GetValidMoves(this, newTile);

                    //check if recently moved piece is checking a king
                    CheckIfInCheck(newTile);

                    // hide indicators
                    foreach (Tile tile in Tiles)
                    {
                        tile.IsAValidSpace = false;
                        tile.Image = null;
                    }

                    foreach (Piece piece in Piece.Pieces)
                    {
                        // generate opposing pieces' moves to see if the recent move is a valid kill for the enemy
                        if (newTile.CurrentPiece != null)
                            piece.GetValidMoves(this, piece.CurrentTile);

                        //if (piece.CurrentPlayer != newTile.CurrentPiece.CurrentPlayer)
                    }

                    GameManager.SwapTurns();
                    PieceMoved.Invoke(oldTile, newTile);
                    //send delegate to form
                }
            }       
        }
        #endregion
        #region show moves method
        public void ShowMovesOfSelectedTile(Tile selTile)
        {
            if (selTile.CurrentPiece != null)
            {
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
        public void CheckIfInCheck(Tile mostRecentTile)
        {
            var turn = GameManager.Turn; // current turn

            //mostRecentTile.CurrentPiece.GetValidMoves(this, mostRecentTile);

            foreach (Tile move in mostRecentTile.CurrentPiece.CurrentValidMoves)
            {
                if (move.CurrentPiece is King)
                {
                    move.BackColor = Color.Red;
                    King kingThatIsChecked = (King)move.CurrentPiece; // type cast to king
                    OnKingChecked.Invoke(kingThatIsChecked);
                }
            }
        }
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
                    tileColor = colorToggle ? GameManager.TileColorA : GameManager.TileColorB;

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
        #region Overrided ToString() method
        public override string ToString() => "Chessboard";
        #endregion
    }
}
