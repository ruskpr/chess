using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Chess.Core.UDP
{
    public class UdpListener : UdpBase
    {

        #region properties

        public int UsersConnected
        {
            get => _userConnections.Count;
        }

        public string IpAddress 
        { 
            get => _listenOn.Address.ToString();
        }

        #endregion

        private int _maxClientCount;

        private IPEndPoint _listenOn;

        private Dictionary<IPEndPoint, string> _userConnections = new Dictionary<IPEndPoint, string>();
        private List<Packet> _packetHistory = new List<Packet>();

        public UdpListener(IPEndPoint endpoint, int maxClientCount)
        {
            _maxClientCount = maxClientCount;
            _listenOn = endpoint;
            Client = new UdpClient(_listenOn);
        }

        #region public

        public void Reply(Packet packet, IPEndPoint endpoint)
        {
            string json = Packet.Serialize(packet);
            byte[] datagram = Encoding.ASCII.GetBytes(json);
            Client.Send(datagram, datagram.Length, endpoint);
        }

        public void ReplyAll(Packet packet)
        {
            string json = Packet.Serialize(packet);
            byte[] datagram = Encoding.ASCII.GetBytes(json);

            foreach (var endpoint in _userConnections.Keys)
                Client.Send(datagram, datagram.Length, endpoint);

            Console.WriteLine($"[Reply All] '{packet.Payload}'");
        }

        #endregion

        #region private

        private bool TryStoreUserConnection(string name, IPEndPoint clientEnpoint)
        {
            return _userConnections.TryAdd(clientEnpoint, name);
        }

        private void DisconnectUser(IPEndPoint clientEndpoint)
        {
            string user;
            _userConnections.Remove(clientEndpoint, out user);
            Console.WriteLine($"{user} was removed was disconnected by the server");

            // TODO: handle udp dispose
            throw new NotImplementedException();
        }

        private void HandleClientPacket(Packet packet)
        {
            _packetHistory.Add(packet);

            switch (packet.Type)
            {
                case PacketType.Connect:
                    #region if the packet is a new connection, store it and reply to all clients

                    bool isNewConnection = TryStoreUserConnection(packet.SenderName, packet.SenderEndpointParsed);

                    if (isNewConnection)
                    {
                        // update user with all previous packets
                        foreach (var p in _packetHistory)
                            Reply(p, packet.SenderEndpointParsed);

                        ReplyAll(packet);

                        // the server will start the game when the max number of clients is reached
                        if (UsersConnected == _maxClientCount)
                        {
                            Packet gameStartPacket = new("SERVER", "none", PacketType.GameStart);
                            ReplyAll(gameStartPacket);
                        }
                    }
                    else
                    {
                        DisconnectUser(packet.SenderEndpointParsed);
                    }

                    break;
                    #endregion

                case PacketType.Disconnect:
                    #region handle udp client properly when a user disconnects

                    throw new NotImplementedException();

                    #endregion

                case PacketType.Message:
                    #region send a text message to all users that are connected
                    ReplyAll(packet);

                    #endregion
                    break;
                default:
                    break;
            }
        }

        #endregion

        public void StartListening()
        {
            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () => {
                while (true)
                {
                    var packet = await this.Receive();
                    HandleClientPacket(packet);
                }
            });
        }

        
    }
}
