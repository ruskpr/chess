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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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

            lbTest2.Text = GameManager.Turn == GameManager.PlayerTurn.p1 ?
                $"TURN: Player 1" : $"TURN: Player 2";

            Tile.SendSelectedTile += Tile_SendCoordinate;

            int monitorHeight = Screen.PrimaryScreen.Bounds.Height;

            myBoard = new Board(this, (int)Math.Round(monitorHeight * 0.8));
            myBoard.ConstructBoard();
            myBoard.PieceMoved += MyBoard_PieceMoved;

            ResponsiveFormat();
        }
        #endregion
        #region Delegate methods
        private void Tile_SendCoordinate(Tile tile) => lbTest1.Text = tile.ToString();
        private void MyBoard_PieceMoved(Tile tileStart, Tile tileEnd)
        {
            // change turns when piece is moved
            if (GameManager.Turn == GameManager.PlayerTurn.p1)
                GameManager.Turn = GameManager.PlayerTurn.p2;
            else
                GameManager.Turn = GameManager.PlayerTurn.p1;

            lbTest2.Text = GameManager.Turn == GameManager.PlayerTurn.p1 ?
                $"TURN: Player 1" : $"TURN: Player 2";

            var movedpeice = tileEnd.CurrentPiece;
            lbTest4.Text = $"{movedpeice} moved from" + " " +
                $"{tileStart.CoordinateX}, {tileStart.CoordinateY}" + " " +
                $"to {tileEnd.CoordinateX}, {tileEnd.CoordinateY}";
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
