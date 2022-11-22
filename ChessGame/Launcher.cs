using ChessLibrary;
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
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
            tbLoginUsername.Text = "russ";
            tbLoginPassword.Text = "password";
        }


        #region Click events
        private void btnRegister_Click(object sender, EventArgs e)
        {
            DataLayer dl = new DataLayer();

            bool success = dl.RegisterUser(tbRegUsername.Text, tbRegPassword.Text);

            if (success)
            {
                MessageBox.Show("Success!");
                tbLoginUsername.Text = tbRegUsername.Text;
                tbLoginPassword.Text = tbRegPassword.Text;
                tbRegUsername.Clear();
                tbRegPassword.Clear();
            }
            else
                MessageBox.Show("Please try again.", "Failed to register user");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataLayer dl = new DataLayer();

            bool success = dl.LoginUser(tbLoginUsername.Text, tbLoginPassword.Text);

            if (success)
            {
                User user = dl.CreateUserObject(tbLoginUsername.Text);
                Matchmaking mm = new Matchmaking(user);
                mm.Show();
            }
            else
                MessageBox.Show("Username and/or password is incorrect.", "Failed to login");
        }
        #endregion

        private void btnPlayOffline_Click(object sender, EventArgs e)
        {
            //create a room with 2 default users
            Room room = new Room(new User(), new User());

            //
            Game game = new Game(room, Game.ConnectionType.Offline);
            game.Show();
        }
    }
}
