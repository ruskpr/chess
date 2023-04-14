using System.Net.Sockets;
using System.Text;

namespace Chess.Core.UDP
{
   
    public abstract class UdpBase
    {
        public delegate void PacketRecieved(Packet packet);
        public event PacketRecieved? OnPacketRecieved;

        protected System.Net.Sockets.UdpClient Client;

        protected UdpBase()
        {
            Client = new System.Net.Sockets.UdpClient();
        }

        public async Task<Packet> Receive()
        {
            var result = await Client.ReceiveAsync();
            Packet p = Packet.Deserialize(Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length));            
            p.SenderEndpoint = result.RemoteEndPoint.Address + ":" + result.RemoteEndPoint.Port;
            OnPacketRecieved?.Invoke(p);
            return p;
        }
    }
}
