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
        struct User
        {
            string Name;
            IPEndPoint Endpoint;
        }

        private IPEndPoint _listenOn;
        private User[] connectedUsers;

        
        public UdpListener(IPEndPoint endpoint)
        {
            _listenOn = endpoint;
            Client = new UdpClient(_listenOn);
        }

        #region private

        private void Reply(Packet packet, IPEndPoint endpoint)
        {
            string json = Packet.Serialize(packet);
            byte[] datagram = Encoding.ASCII.GetBytes(json);
            Client.Send(datagram, datagram.Length, endpoint);
        }

        private void ReplyAll(Packet packet, IEnumerable<IPEndPoint> endpoints)
        {
            string json = Packet.Serialize(packet);
            byte[] datagram = Encoding.ASCII.GetBytes(json);

            foreach (var ep in endpoints)
                Client.Send(datagram, datagram.Length, ep);
        }


        #endregion




        public void StartListening()
        {
            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () => {
                while (true)
                {
                    var packet = await this.Receive();
                    Console.WriteLine(packet.Payload);
                    Reply(packet, IPEndPoint.Parse(packet.SenderEndpoint));
                }
            });
        }
    }
}
