﻿using Microsoft.VisualBasic.Devices;
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
            if (tile != null)
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


            if ((int)GameManager.Turn == 1) // player one's turn
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
            ResponsiveLayout();
            InitUserProfiles();
            UpdateText(null);
        }
        private void InitUserProfiles()
        {
            User pOne = parentBoard.CurrentRoom.PlayerOne;
            User pTwo = parentBoard.CurrentRoom.PlayerTwo;

            // profile pics
            pbP1Pic.Image = pOne.ProfilePic;
            pbP2Pic.Image = pTwo.ProfilePic;
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
        private void btnDeleteSave_Click(object sender, EventArgs e)
        {
            LocalDataSaver ds = new();

            ds.DeleteSave();
        }
        #endregion
        #region Responsive operations
        public void ResponsiveLayout()
        {
            // set location to left or right
            this.Location = new Point(parentBoard.Right, parentBoard.Top); this.Height = parentBoard.Height;
            this.Width = parentBoard.Width / 2;

            lstMoves.Width = this.Width;
            lstMoves.Height = this.Height / 3;
            //lstMoves.BackColor = Color.Black;
            lstMoves.ForeColor = Color.White;
            lstMoves.Location = new Point(0, this.Height - lstMoves.Height);

            pnlSelected.Location = new Point(0, lstMoves.Top - pnlSelected.Height);
        }

        #endregion
    }
}
