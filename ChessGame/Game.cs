using ChessLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Game : Form
    {
        #region Fields
        //private Board? chessboard;
        #endregion
        #region Properties
        //public Room CurrentRoom { get; set; }
        public Board? ChessBoard { get; set; }
        #endregion
        #region Constructor
        public Game(Room room)
        {
            InitializeComponent();

            //CurrentRoom = room;
            this.MinimumSize = new Size(1100, 800);
            this.SizeChanged += MainForm_SizeChanged;
            this.Resize += MainForm_Resize;

            int monitorHeight = Screen.PrimaryScreen.Bounds.Height;

            ChessBoard = new Board(this, room, (int)Math.Round(monitorHeight * 0.8));
            //myBoard = new Board(this, formHeight);

            ResponsiveLayout();
        }
        #endregion
        #region Responsive operations
        private void ResponsiveLayout() => ChessBoard.ResponsiveLayout();
        private void MainForm_SizeChanged(object? sender, EventArgs e) => ResponsiveLayout();
        private void MainForm_Resize(object? sender, EventArgs e) => ResponsiveLayout();
        #endregion

        private void Game_Load(object sender, EventArgs e)
        {
           
        }
    }
}
