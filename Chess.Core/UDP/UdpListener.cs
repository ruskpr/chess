using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            var datagram = Encoding.ASCII.GetBytes(Packet.Serialize(packet));
            Client.Send(datagram, datagram.Length, endpoint);
        }

    }
}
