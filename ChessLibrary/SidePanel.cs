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
    public partial class SidePanel : UserControl
    {
        #region Fields
        private Board parentBoard;
        #endregion
        #region Constructor
        public SidePanel(Board board)
        {
            InitializeComponent();
            this.parentBoard = board;

            InitSidePanel();
            InitUserProfiles();
            UpdateText(null);

            // events 
            parentBoard.OnPieceMoved += ParentBoard_PieceMoved;
            Tile.OnSelected += Tile_OnSelected;
        }
        #endregion
        #region Delegate events and Update text method
        private void Tile_OnSelected(Tile tile) => UpdateText(tile);
        private void ParentBoard_PieceMoved() => UpdateText(null);
        private void UpdateText(Tile? tile)
        {
            lbSelected.Text = $"Selected: {tile}";

            lbTurn.Text = "Turn:" + " " + parentBoard.Turn;

            // display history of all moves
            lstMoves.Items.Clear();

            foreach (Tuple<Piece, Tile, Tile> move in parentBoard.MoveStack)
                lstMoves.Items.Add($"{move.Item1}: x{move.Item2.CoordinateX}, y{move.Item2.CoordinateY} -> " +
                    $"x{move.Item3.CoordinateX}, y{move.Item3.CoordinateY}");
        }
        #endregion
        #region Initialize sidepanel
        private void InitSidePanel()
        {
            // set location to left or right
            this.Location = new Point(parentBoard.Right, parentBoard.Top);


            this.Width = parentBoard.Width / 2;
            this.Height = parentBoard.Height;
            this.BackColor = Color.FromArgb(80, 80, 80);

            parentBoard.ParentForm.Controls.Add(this);
        }
        private void InitUserProfiles()
        {
            User pOne = parentBoard.CurrentRoom.PlayerOne;
            User pTwo = parentBoard.CurrentRoom.PlayerTwo;

            // profile pics
            pbP1Pic.Image = pOne.profile_pic;
            pbP2Pic.Image = pTwo.profile_pic;
            // usernames
            lbP1Username.Text = pOne.username;
            lbP2Username.Text = pTwo.username;
            // ratings
            lbP1Rating.Text = Convert.ToString(pOne.chess_rating);
            lbP2Rating.Text = Convert.ToString(pTwo.chess_rating);  
        }
        #endregion
        #region Button click events
        private void btnReset_Click(object sender, EventArgs e) => parentBoard.ResetBoard();
        #endregion
        #region Responsive operations
        public void ResponsiveLayout()
        {
            // set location to left or right
            this.Location = new Point(parentBoard.Right, parentBoard.Top); this.Height = parentBoard.Height;
            this.Width = parentBoard.Width / 2;

            lstMoves.Width = this.Width;
            lstMoves.Height = this.Height / 3;
            lstMoves.BackColor = Color.Black;
            lstMoves.ForeColor = Color.White;
            lstMoves.Location = new Point(0, this.Height - lstMoves.Height);
        }
        #endregion
    }
}
