using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ChessGame
{
    public partial class MainForm : Form
    {

        private static Size tileSize;
        private Board board;
        public MainForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1100, 800);
            this.SizeChanged += MainForm_SizeChanged;
            this.Resize += MainForm_Resize;

            Tile.SendTile += Tile_SendCoordinate;

            board = new Board(this);
            board.Parent = pnlMiddleContent;
            Format.Center(board);
            ResponsiveFormat();
            ConstructBoard();

        }

        private void Tile_SendCoordinate(Tile tile)
        {
            lbTest1.Text = tile.ToString();
        }

        private void ConstructBoard()
        {
            AddTiles(board);
            AddPieces();
        }

        private void AddPieces()
        {
            //loop through each tile in 2d array (player 1 is white, player 2 is black)
            for (int i = 0; i < 8; i++) 
            {
                for (int j = 0; j < 8; j++)
                {

                    if (i == 1)
                        board.Tiles[i, j].CreatePiece("pawn", 2); // add player 2's pawns to 2nd row
                    if (i == 6)
                        board.Tiles[i, j].CreatePiece("pawn", 1); // add player 1's pawns to 7th row

                    // player 1's backrow
                    if (i == 7)
                    {
                        if (j == 0 || j == 7)
                            board.Tiles[i, j].CreatePiece("rook", 1); // add player 1's rooks
                        if (j == 1 || j == 6)
                            board.Tiles[i, j].CreatePiece("knight", 1); // add player 1's knights
                        if (j == 2 || j == 5)
                            board.Tiles[i, j].CreatePiece("bishop", 1); // add player 1's bishops
                        if (j == 3)
                            board.Tiles[i, j].CreatePiece("queen", 1); // add player 1's queen
                        if (j == 4)
                            board.Tiles[i, j].CreatePiece("king", 1); // add player 1's king
                    }

                    // player 2's backrow
                    if (i == 0)
                    {
                        if (j == 0 || j == 7)
                            board.Tiles[i, j].CreatePiece("rook", 2); // add player 2's rooks
                        if (j == 1 || j == 6)
                            board.Tiles[i, j].CreatePiece("knight", 2); // add player 2's knights
                        if (j == 2 || j == 5)
                            board.Tiles[i, j].CreatePiece("bishop", 2); // add player 2's bishops
                        if (j == 3)
                            board.Tiles[i, j].CreatePiece("queen", 2); // add player 2's queen
                        if (j == 4)
                            board.Tiles[i, j].CreatePiece("king", 2); // add player 2's king
                    }
                }
            }
        }

        void AddTiles(Control control)
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

                    Tile tile = new Tile(this, board, tileSize, new Point(locX, locY), i, j, tileColor);

                    board.Tiles[i, j] = tile;

                    locX += tileSize.Width;
                    colorToggle = !colorToggle;
                    control.Controls.Add(tile);
                }
                locX = 0;
                locY += tileSize.Height;
                board.BackColor = Color.White;
            }
        }
        private void MainForm_SizeChanged(object? sender, EventArgs e)
        {
            ResponsiveFormat();
        }
        private void MainForm_Resize(object? sender, EventArgs e)
        {
            ResponsiveFormat();
        }

        private void ResponsiveFormat()
        {
            Format.Center(pnlMiddleContent);
            Format.Center(board);
            pnlMiddleContent.Top = pnlMiddleContent.Top - 20;

            tileSize = new Size(board.Width / 8, board.Width / 8);
            //foreach (Tile tile in pnlBoard.Controls)
            //{
            //    tile.Size = tileSize;
            //}
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)// || this.WindowState == FormWindowState.Normal
            {
                //ResponsiveFormat();

            }
            base.OnSizeChanged(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TestForm testFrm = new TestForm();
            testFrm.Show();
        }


    }
}
