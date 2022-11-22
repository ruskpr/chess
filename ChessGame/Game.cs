using ChessLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ChessGame
{
    public partial class Game : Form
    {
        #region Fields
        //private Board? chessboard;
        public enum ConnectionType { Client, Server, Offline }
        public ConnectionType ConnType;


        TcpListener tcpListener;
        TcpClient tcpClient;
        private Timer timerConnChecker = new Timer();

        #endregion
        #region Properties
        //public Room CurrentRoom { get; set; }
        public Board? ChessBoard { get; set; }
        public Room CurrentRoom { get; set; }
        #endregion
        #region Constructors
        public Game(Room currRoom, ConnectionType connType)
        {
            InitializeComponent();

            // init connection
            ConnType = connType;
            InitializeConnection();

            CurrentRoom = currRoom;
            this.MinimumSize = new Size(1100, 800);
            this.SizeChanged += MainForm_SizeChanged;
            this.Resize += MainForm_Resize;

            int monitorHeight = Screen.PrimaryScreen.Bounds.Height;

            ChessBoard = new Board(this, CurrentRoom, (int)Math.Round(monitorHeight * 0.8));
            //myBoard = new Board(this, formHeight);

            ResponsiveLayout();
        }

        #endregion

        #region Init Connection
        private void InitializeConnection()
        {
            switch (ConnType)
            {
                case ConnectionType.Server:
                    // show your game on the matchmaking list
                    OpenRoomToOtherUsers();
                    break;
                case ConnectionType.Client:
                    //
                    break;
                case ConnectionType.Offline:
                    //
                    break;
                default:
                    break;
            }
        }

        private void OpenRoomToOtherUsers()
        {

        }
        void StartServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, 11000);
            tcpListener.Start();
            timerConnChecker.Enabled = true;

        }

        #endregion
        #region Responsive operations
        private void ResponsiveLayout() => ChessBoard.ResponsiveLayout();
        private void MainForm_SizeChanged(object? sender, EventArgs e) => ResponsiveLayout();
        private void MainForm_Resize(object? sender, EventArgs e) => ResponsiveLayout();
        #endregion

        private void Game_Load(object sender, EventArgs e)
        {
           
        }
    }
}
