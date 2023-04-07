using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.UDP
{
    

    public abstract class UdpBase
    {
        protected UdpClient Client;

        protected UdpBase()
        {
            Client = new UdpClient();
        }

        public async Task<Packet> Receive()
        {
            var result = await Client.ReceiveAsync();
            Packet p = Packet.Deserialize(Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length));            
            p.SenderEndpoint = result.RemoteEndPoint.Address + ":" + result.RemoteEndPoint.Port;
            return p;
        }
    }
}
