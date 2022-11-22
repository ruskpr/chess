using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessLibrary;
using Timer = System.Windows.Forms.Timer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ChessGame
{
    public partial class Matchmaking : Form
    {
        private TCPIPLayer tcpLayer;
        private DataLayer dataLayer;
        private User loggedInUser;

        public Matchmaking(User user)
        {
            InitializeComponent();
            tcpLayer = new TCPIPLayer();
            loggedInUser = user;

            lbUsername.Text = $"Logged in as: {loggedInUser.username}";

            lbMyIP.Text = $"my IP: {tcpLayer.UserIPAddress}";
            lbPort.Text = $"listening port: {tcpLayer.Port}";
            lbNumUsers.Text = $"users connected: {tcpLayer.ClientList.Count}";
        }

        


        #region Button clicks
        private void btnCreateNewRoom_Click(object sender, EventArgs e)
        {
            //create a room 
            Room room = new Room(loggedInUser, loggedInUser);

            Game game = new Game(room, Game.ConnectionType.Server);
            game.Show();
            //StartServer();
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            string selectedRoom = (string)lstRooms.SelectedItem;

            Room room = new Room(loggedInUser, loggedInUser);

            Game game = new Game(room, Game.ConnectionType.Client);
            game.Show();
        }
        #endregion
        private void lstRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Matchmaking_Load(object sender, EventArgs e)
        {

        }
    }
}
