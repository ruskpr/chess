using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.TCP
{
    public class Server
    {
        #region delegates / events

        public delegate void PacketRecieved(Packet packet);
        public event PacketRecieved OnPacketRecieved;

        #endregion

        #region get only properties

        public bool IsRunning { get => _running; }
        public int Port { get => _port; }
        public List<TcpClient> Clients { get => _clients; }

        #endregion

        #region fields

        TcpListener _listener;
        private int _port;
        private bool _running;
        private List<TcpClient> _clients = new List<TcpClient>();

        Board _board;
        Player? _playerWhite;
        Player? _playerBlack;

        #endregion

        public Server(int port)
        {
            _port = port;
            _listener = new TcpListener(IPAddress.Any, port);

        }

        public async Task Start()
        {
            _listener.Start();
            _running = true;

            while (_running)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();

                _clients.Add(client);

                Task.Run(() => HandleClient(client));
            }
        }

        public void Stop()
        {
            _running = false;
            _listener.Stop();
        }   

        public async Task HandleClient(TcpClient client)
        {
            if (_listener.Pending())
            {
                client = _listener.AcceptTcpClient();
                _clients.Add(client);
            }
        }

    }
}
