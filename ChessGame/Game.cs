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
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChessGame
{
    public partial class Game : Form
    {
        #region Fields
        public enum ConnectionType { Client, Server, Offline }
        public ConnectionType ConnType;

        TcpListener tcpListener;
        TcpClient tcpClient;

        private Timer timerConnChecker = new Timer();
        private Board board;
        private int boardSize;

        #endregion
        #region Properties
        public Room CurrentRoom { get; set; }
        #endregion
        #region Constructors
        public Game(Room currRoom, ConnectionType connType)
        {
            InitializeComponent();

            // init connection
            ConnType = connType;
            CurrentRoom = currRoom;
            InitializeConnection();

            // form event handlers
            //this.MinimumSize = new Size(100, 100);
            this.SizeChanged += Game_SizeChanged;
            this.Resize += Game_Resize;
            this.LocationChanged += Game_LocationChanged;

            //create board
            boardSize = (int)Math.Round(this.Height * 0.75);
            board = new Board(this, CurrentRoom, boardSize);
            Board.OnReset += board_OnReset;
            board.ResponsiveLayout();
        }
        #endregion
        #region Reset delegate event
        private void board_OnReset()
        {
            board = new Board(this, CurrentRoom, boardSize);
            board.ResponsiveLayout();
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
        #region Form events
        private void Game_SizeChanged(object? sender, EventArgs e) => board.ResponsiveLayout();
        private void Game_Resize(object? sender, EventArgs e) => board.ResponsiveLayout();
        private void Game_LocationChanged(object? sender, EventArgs e) => board.ResponsiveLayout();
        #endregion
    }
}
