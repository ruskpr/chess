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

        private Size tileSize;
        public MainForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1100, 800);
            this.SizeChanged += MainForm_SizeChanged;
            this.Resize += MainForm_Resize;

            
            

            Format.Center(pnlBoard);
            ResponsiveFormat();
            

        }
        Tile[,] tiles = new Tile[8, 8];
        private void ConstructBoard()
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
                    tileColor = colorToggle ? Color.Black : Color.White;
                    //Color color = j % 2 == 0 ? Color.Black : Color.White;
                    Tile tile = new Tile(this, tileSize, new Point(locX, locY), tileColor);
                    pnlBoard.Controls.Add(tile);
                    tiles[i, j] = tile;
                    locX += tileSize.Width;
                    //Thread.Sleep(100);
                    //this.pnlBoard.Refresh();
                    colorToggle = !colorToggle;
                }
                locX = 0;
                locY += tileSize.Height;
                pnlBoard.BackColor = Color.White;
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
            Format.Center(pnlBoard);
            pnlMiddleContent.Top = pnlMiddleContent.Top - 20;

            tileSize = new Size(pnlBoard.Width / 8, pnlBoard.Width / 8);
            foreach (Tile tile in pnlBoard.Controls)
            {
                tile.Size = tileSize;
            }
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
            ConstructBoard();
        }
    }
}
