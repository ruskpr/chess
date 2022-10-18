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
        private Board myBoard;
        public MainForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1100, 800);
            this.SizeChanged += MainForm_SizeChanged;
            this.Resize += MainForm_Resize;

            Tile.SendTile += Tile_SendCoordinate;

            myBoard = new Board(this, 800);
            myBoard.ConstructBoard();
            
            ResponsiveFormat();
        }
        #region Initialize board

        #endregion
        #region Delegate target
        private void Tile_SendCoordinate(Tile tile)
        {
            lbTest1.Text = tile.ToString();
        }
        #endregion
        #region Form resize events
        private void MainForm_SizeChanged(object? sender, EventArgs e)
        {
            ResponsiveFormat();
        }
        private void MainForm_Resize(object? sender, EventArgs e)
        {
            ResponsiveFormat();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)// || this.WindowState == FormWindowState.Normal
            {
                //ResponsiveFormat();

            }
            base.OnSizeChanged(e);
        }
        #endregion
        #region Responsive format
        private void ResponsiveFormat()
        {
            Format.Center(myBoard);
        }
        #endregion
        #region Button clicks
        private void button1_Click_1(object sender, EventArgs e)
        {
            TestForm testFrm = new TestForm();
            testFrm.Show();
        }
        #endregion
    }
}
