using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Board : Panel
    {
        #region Properties
        //array of tiles
        public Tile[,] Tiles = new Tile[8, 8];
        Size tileSize;
        #endregion
        #region Constructor
        public Board(Form pntr, int size)
        {
            Size = new Size(size, size);
            tileSize = new Size(Width / 8, Width / 8);
            BackColor = Color.White;

            Tile.SendTile += Tile_SendTile;
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

        private void Tile_SendTile(Tile tile)
        {
            //MessageBox.Show(tile.ToString());
            CalcValidMoves(tile);
        }
        public void CalcValidMoves(Tile selectedTile)
        {
            List<Tile> validMoves = new List<Tile>();

            //clear valid move indicators on each selection
            foreach (Tile tile in Tiles)
                tile.Image = null;

            //calculate values on type of piece that you selectedd
            switch (selectedTile.CurrentPiece)
            {
                case Pawn:
                    if (selectedTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_One)
                    {
                        validMoves.Add(Tiles[selectedTile.CoordinateX - 1, selectedTile.CoordinateY]);
                        validMoves.Add(Tiles[selectedTile.CoordinateX - 2, selectedTile.CoordinateY]);
                        
                    }
                    else if (selectedTile.CurrentPiece.CurrentPlayer == Piece.Player.Player_Two)
                    {
                        validMoves.Add(Tiles[selectedTile.CoordinateX + 1, selectedTile.CoordinateY]);
                        validMoves.Add(Tiles[selectedTile.CoordinateX + 2, selectedTile.CoordinateY]);
                    }
                    break;
                case Rook:

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
        }
        
        #region Add tiles
        public void AddTiles()
        {
            int locX = 0;
            int locY = 0;
            Color tileColor;
            bool colorToggle = true;


            for (int i = 0; i < 8; i++) // column
            {
                colorToggle = !colorToggle;
                for (int j = 0; j < 8; j++) // row
                {
                    tileColor = colorToggle ? Color.MediumVioletRed : Color.DarkOrange;

                    Tile tile = new Tile(this, tileSize, new Point(locX, locY), i, j, tileColor);

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
        #region Add pieces
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
