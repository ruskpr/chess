using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.TCP
{
    public class Client
    {
        #region delegates / events

        public delegate void PacketRecieved(Packet packet);
        public event PacketRecieved OnPacketRecieved;


        #endregion

        #region fields

        private TcpClient _client;
        private string _ip;
        private string _username;
        private int _port;

        #endregion

        #region properties

        public bool IsConnected { get => _client.Connected; }

        #endregion

        #region constructors

        public Client(string username, string ip, int port)
        {
            _username = username;
            _client = new TcpClient();
            _ip = ip;
            _port = port;
        }
        #endregion

        #region public

        public async Task Start()
        {
            NetworkStream stream = _client.GetStream();
            byte[] buffer = new byte[1024];
            while (_client.Connected)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Packet packet = JsonConvert.DeserializeObject<Packet>(json);
                OnPacketRecieved?.Invoke(packet);
            }
        }

        public void JoinServer() 
        {
            // connect and send a message
            _client.Connect(_ip, _port);
            Packet packet = new Packet($"{_username} joined", MessageType.ClientConnected);
            SendMessage(packet);
        }

        public void LeaveServer()
        {
            // close connection to server
            _client.GetStream().Close();
            _client.Close();
            //_client.Dispose();
        }

        #endregion

        #region private

        private async void SendMessage(Packet message)
        {
            NetworkStream stream = _client.GetStream();
            string json = JsonConvert.SerializeObject(message);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            await stream.WriteAsync(buffer, 0, buffer.Length);
        }
        #endregion

    }
}
