using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Matchmaking : Form
    {

        public User LoggedInUser { get; set; }
        public Matchmaking(string user)
        {
            InitializeComponent();
            LoggedInUser = new User(user);
            lbUsername.Text = $"Logged in as: {LoggedInUser.Username}";

        }
        #region Button clicks
        private void btnCreateNewRoom_Click(object sender, EventArgs e)
        {

        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
