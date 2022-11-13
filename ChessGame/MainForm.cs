using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using ChessLibrary;

namespace ChessGame
{
    public partial class MainForm : Form
    {
        private Board? myBoard;
        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1100, 800);
            this.SizeChanged += MainForm_SizeChanged;
            this.Resize += MainForm_Resize;

            Tile.OnSelected += Tile_OnSelected;

            int monitorHeight = Screen.PrimaryScreen.Bounds.Height;

            myBoard = new Board(this, (int)Math.Round(monitorHeight * 0.8));
            
            myBoard.PieceMoved += MyBoard_PieceMoved;

            UpdateText(null);
            ResponsiveFormat();
        }
        #endregion
        #region Delegate methods
        private void Tile_OnSelected(Tile tile) => UpdateText(tile);
        private void MyBoard_PieceMoved() => UpdateText(null);
        private void UpdateText(Tile? tile)
        {
            lbTest1.Text = $"Selected: {tile}";

            lbTest2.Text = "Turn:" + " " + myBoard.Turn;

            // display latest move
            lbTest4.Text = myBoard.LatestMove;


            // display history of all moves
            lstMoves.Items.Clear();

            foreach (Tuple<Piece, Tile, Tile> move in myBoard.MoveStack)
                lstMoves.Items.Add($"{move.Item1}: x{move.Item2.CoordinateX}, y{move.Item2.CoordinateY} -> " +
                    $"x{move.Item3.CoordinateX}, y{move.Item3.CoordinateY}");
        }
        #endregion
        #region Responsive operations
        private void ResponsiveFormat() => Format.Center(myBoard);
        private void MainForm_SizeChanged(object? sender, EventArgs e) => ResponsiveFormat();
        private void MainForm_Resize(object? sender, EventArgs e) => ResponsiveFormat();
        #endregion
        #region Button clicks

        #endregion
    }
}
