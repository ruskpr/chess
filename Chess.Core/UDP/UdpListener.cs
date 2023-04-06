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
        private IPEndPoint _listenOn;

        public UdpListener() : this(new IPEndPoint(IPAddress.Any, 32123))
        {
        }

        public UdpListener(IPEndPoint endpoint)
        {
            _listenOn = endpoint;
            Client = new UdpClient(_listenOn);
        }

        public void Reply(Packet packet, IPEndPoint endpoint)
        {
            packet.Sender = endpoint;
            string json = JsonConvert.SerializeObject(packet);
            var datagram = Encoding.ASCII.GetBytes(json);
            Client.Send(datagram, datagram.Length, endpoint);
        }
        public void Reply(string message, IPEndPoint endpoint)
        {
            var datagram = Encoding.ASCII.GetBytes(message);
            Client.Send(datagram, datagram.Length, endpoint);
        }

        public void StartListening()
        {
            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () => {
                while (true)
                {
                    var received = await this.Receive();
                    Console.WriteLine(received.Payload);


                    Reply(received.Payload, received.Sender);
                    //server.Reply("copy " + received.Payload, received.Sender);
                }
            });
        }
    }
}
