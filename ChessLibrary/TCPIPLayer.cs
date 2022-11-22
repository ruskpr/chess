using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;
using System.Windows.Forms;

namespace ChessLibrary
{
    public class TCPIPLayer
    {
        TcpClient tcpClient;
        TcpListener tcpListener;

        public List<TcpClient> ClientList = new List<TcpClient>();
        public List<string> ConnectionList = new List<string>();

        const short LISTENING_PORT = 11001;

        //timers
        public static Timer timerCheckNewConn = new Timer();
        private static Timer timerCheckForMessage;


        #region Properties
        public string ErrorMessage { get; set; }
        public int MyProperty { get; set; }
        public string UserIPAddress { get; set; }
        public short Port { get; set; }
        #endregion
        #region constructors
        static TCPIPLayer()
        {
            timerCheckNewConn = new Timer();
            timerCheckNewConn.Interval = 500;
            timerCheckNewConn.Enabled = true;

            timerCheckForMessage = new Timer();
            timerCheckForMessage.Interval = 500;
            timerCheckForMessage.Enabled = true;

        }
        public TCPIPLayer()
        {
            UserIPAddress = GetLocalIPAddress();
            Port = LISTENING_PORT;

            timerCheckNewConn.Tick += timerCheckNewConn_Tick;
            timerCheckForMessage.Tick += TimerCheckForMessage_Tick;
        }
        #endregion

        

        // get connections
        public List<string> GetConnections()
        {
            List<string> connections = new List<string>();

            tcpListener = new TcpListener(IPAddress.Any, LISTENING_PORT);
            tcpListener.Start();
            timerCheckNewConn.Enabled = true;

            return connections;
        }

        // used to send your ip address to every users listbox in matchmaking window
        public void BroadcastMessage(string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(message);

            foreach (TcpClient curClient in ClientList)
            {
                if (curClient != null)
                {
                    NetworkStream clientStream = curClient.GetStream();
                    try
                    {
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

        }

        void StartServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, LISTENING_PORT);
            tcpListener.Start();
            timerCheckNewConn.Enabled = true;

            byte[] myWriteBuffer;

            myWriteBuffer = Encoding.ASCII.GetBytes($"chessroom, Port: {LISTENING_PORT}" + "\r\n");

            try
            {
                //tcpClient.Connect(UserIPAddress, LISTENING_PORT);
                tcpClient.GetStream().Write(myWriteBuffer, 0, myWriteBuffer.Length);
            }
            catch
            {
                throw;
            }

        }
        void StartConnection()
        {
            try
            {
                tcpClient = new TcpClient();
                //tcpClient.Connect(IPAddress.Parse(ipAddress), PORT);
            }
            catch
            {
                throw;
            }
        }
        private void CheckForIncomingData()
        {
            if (tcpClient.Client.Poll(0, SelectMode.SelectRead))  // only way to tell if connection has been terminated from other end
            {
                byte[] checkConn = new byte[1];
                if (tcpClient.Client.Receive(checkConn, SocketFlags.Peek) == 0)
                {
                    lbMessage.BackColor = Color.Red;
                }
            }

            if (tcpClient.Available > 0)             // see if there is new incoming data available
            {
                Byte[] InComing = new Byte[tcpClient.ReceiveBufferSize];
                tcpClient.GetStream().Read(InComing, 0, InComing.Length);
                string InComingString = Encoding.ASCII.GetString(InComing);
                lstRooms.Items.Add(InComingString);
                // txtIncoming.SelectionStart = txtIncoming.Text.Length;  // scroll to end of text
                //txtIncoming.ScrollToCaret();
            }
        }

        #region Timer tick events
        private void timerCheckNewConn_Tick(object? sender, EventArgs e)
        {
            if (tcpListener.Pending())
            {
                tcpClient = tcpListener.AcceptTcpClient();
            }
        }
        private void TimerCheckForMessage_Tick(object? sender, EventArgs e)
        {
            CheckForIncomingData();
            //lstRooms.Items.Clear();
            byte[] InComing = new byte[tcpClient.ReceiveBufferSize];

            if (tcpClient.Available > 0)             // see if there is new incoming data available
            {
                tcpClient.GetStream().Read(InComing, 0, InComing.Length);

                //lstRooms.Items.Add(Encoding.ASCII.GetString(InComing) + "\n");
            }

            if (tcpClient.Client.Poll(0, SelectMode.SelectRead))   // check if connection has been closed by client
            {
                tcpClient.Close();
                timerCheckForMessage.Enabled = false;
                timerCheckNewConn.Enabled = true;
                timerCheckForMessage.Enabled = false;

            }
        }
        #endregion

        #region static method (get IP address)
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        #endregion
    }
}
