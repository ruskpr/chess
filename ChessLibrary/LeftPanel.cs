using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessLibrary
{
    public partial class LeftPanel : UserControl
    {
        public Board ParentBoard { get; set; }
        public LeftPanel(Board board)
        {
            InitializeComponent();
            ParentBoard = board;
            this.Width = ParentBoard.Width / 2;
            this.Height = ParentBoard.Height;
            this.BackColor = Color.AntiqueWhite;
            this.Location = new Point(0, this.Top);

            ParentBoard.ParentForm.Controls.Add(this);
            UpdateText(null);

            // delegate events
            ParentBoard.PieceMoved += ParentBoard_PieceMoved;
            Tile.OnSelected += Tile_OnSelected;
        }
        #region Delegate events
        private void Tile_OnSelected(Tile tile) => UpdateText(tile);
        private void ParentBoard_PieceMoved() => UpdateText(null);
        #endregion
        public void ResponsiveLayout()
        {
            this.Location = new Point(ParentBoard.Left-this.Width, ParentBoard.Top);
            this.Height = ParentBoard.Height;
            this.Width = ParentBoard.Width / 2;

            lstMoves.Width = this.Width;
            //lstMoves.Height = this.Height / 3;
            lstMoves.BackColor = Color.Black;
            lstMoves.ForeColor = Color.White;
            //lstMoves.Location = new Point(this.Left, 500);
        }

        private void UpdateText(Tile? tile)
        {
            lbSelected.Text = $"Selected: {tile}";

            lbTurn.Text = "Turn:" + " " + ParentBoard.Turn;

            // display history of all moves
            lstMoves.Items.Clear();

            foreach (Tuple<Piece, Tile, Tile> move in ParentBoard.MoveStack)
                lstMoves.Items.Add($"{move.Item1}: x{move.Item2.CoordinateX}, y{move.Item2.CoordinateY} -> " +
                    $"x{move.Item3.CoordinateX}, y{move.Item3.CoordinateY}");
        }
        #region Button click events
        private void btnReset_Click(object sender, EventArgs e)
        {
            ParentBoard.ResetBoard();
        }
        #endregion
    }
}
