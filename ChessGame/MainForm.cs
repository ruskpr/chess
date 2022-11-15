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
        private Board myBoard;
        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1100, 800);
            this.SizeChanged += MainForm_SizeChanged;
            this.Resize += MainForm_Resize;

            int monitorHeight = Screen.PrimaryScreen.Bounds.Height;

            myBoard = new Board(this, (int)Math.Round(monitorHeight * 0.8));

            ResponsiveLayout();
        }
        #endregion
        #region Responsive operations
        private void ResponsiveLayout() => myBoard.ResponsiveLayout();
        private void MainForm_SizeChanged(object? sender, EventArgs e) => ResponsiveLayout();
        private void MainForm_Resize(object? sender, EventArgs e) => ResponsiveLayout();
        #endregion
    }
}
