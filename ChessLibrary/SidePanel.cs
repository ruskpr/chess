using ChessLibrary.Pieces;
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
        private User playerOne;
        private User playerTwo;
        #endregion
        #region Constructor
        public SidePanel(Board board)
        {
            InitializeComponent();
            this.parentBoard = board;
            this.playerOne = board.CurrentRoom.PlayerOne;
            this.playerTwo = board.CurrentRoom.PlayerTwo;

            InitSidePanel();

            // events 
            parentBoard.OnPieceMoved += ParentBoard_PieceMoved;
            Tile.OnSelected += Tile_OnSelected;
        }
        #endregion
        #region Delegate events to update sidepanel
        private void Tile_OnSelected(Tile tile) => UpdateText(tile);
        private void ParentBoard_PieceMoved() => UpdateText(null);
        
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

            InitUserProfiles();
            UpdateText();
        }
        private void InitUserProfiles()
        {
            // profile pics
            pbP1Pic.Image = Utils.RoundImage(playerOne.ProfilePic);
            pbP2Pic.Image = Utils.RoundImage(playerTwo.ProfilePic);
            // usernames
            lbP1Username.Text = playerOne.username;
            lbP2Username.Text = playerTwo.username;
            // ratings
            lbP1Rating.Text = Convert.ToString(playerOne.chess_rating);
            lbP2Rating.Text = Convert.ToString(playerTwo.chess_rating);  
        }
        private void UpdateText(Tile? tile = null)
        {
            if (tile != null) // execute if tile is passed in parameter
            {
                lbSelected.Text = "Selected:";
                pbSelected.Image = tile.BackgroundImage;
                lbSelectedPos.Text = $"at: {tile.CoordinateX}, {tile.CoordinateY}";
            }
            else
            {
                lbSelected.Text = "";
                lbSelectedPos.Text = "";
                pbSelected.Image = null;
            }

            if ((int)GameManager.Turn == 1) // set color indicator of username if it is the user's turn
            {
                lbP1Username.BackColor = Color.SteelBlue;
                lbP2Username.BackColor = Color.Transparent;
            }
            else
            {
                lbP2Username.BackColor = Color.SteelBlue;
                lbP1Username.BackColor = Color.Transparent;
            }

            // display history of all moves
            lstMoves.Items.Clear();

            foreach (Tuple<Piece, Tile, Tile> move in parentBoard.MoveStack)
                lstMoves.Items.Add($"{move.Item1}: {move.Item2.CoordinateX},{move.Item2.CoordinateY} to " +
                    $"{move.Item3.CoordinateX},{move.Item3.CoordinateY}");
        }
        #endregion
        #region Button click events
        private void btnReset_Click(object sender, EventArgs e) => parentBoard.ResetBoard();
        private void btnDeleteSave_Click(object sender, EventArgs e)
        {
            LocalDataSaver ds = new(); 
            ds.DeleteSave();   
        }
        #endregion
        #region Responsive operations
        public void ResponsiveLayout()
        {
            // set location of side panel
            this.Location = new Point(parentBoard.Right, parentBoard.Top); 
            this.Height = parentBoard.Height;
            this.Width = parentBoard.Width / 2;

            // move stack list box
            lstMoves.Width = this.Width;
            lstMoves.Height = this.Height / 3;
            lstMoves.ForeColor = Color.White;
            lstMoves.Location = new Point(0, this.Height - lstMoves.Height);

            // set selected item panel location
            pnlSelected.Location = new Point(0, lstMoves.Top - pnlSelected.Height);
        }

        #endregion
    }
}
