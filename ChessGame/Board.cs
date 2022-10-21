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
        #region Delegate to send and recieve tiles
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
            newTile.CurrentPiece.CurrentTile = oldTile.CurrentPiece.CurrentTile;
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

            Piece piece = selTile.CurrentPiece;

            //calculate values on type of piece that you selected
            switch (selTile.CurrentPiece)
            {
                case Pawn:
                    validMoves = piece.GetValidMoves(this, selTile);                
                    break;
                case Rook:
                    validMoves = piece.GetValidMoves(this, selTile);
                    break;
                case Knight:
                    validMoves = piece.GetValidMoves(this, selTile);
                    break;
                case Bishop:
                    validMoves = piece.GetValidMoves(this, selTile);
                    break;
                case Queen:
                    validMoves = piece.GetValidMoves(this, selTile);
                    break;
                case King:
                    validMoves = piece.GetValidMoves(this, selTile);
                    break;
            }

            foreach (Tile tile in validMoves) 
            {
                if (tile.CurrentPiece != null)
                    tile.Image = MyAssets.ValidKillImg; // if valid space contains enemy, display kill indicator
                else
                    tile.Image = MyAssets.ValidMoveImg; // if valid space is open open space display indicator

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
        public override string ToString() => "Chessboard";
        #endregion
    }
}
