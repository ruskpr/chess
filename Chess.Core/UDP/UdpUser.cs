using System.Text;

namespace Chess.Core.UDP
{
    public class UdpUser : UdpBase
    {
        public delegate void PacketRecieved(Packet packet);
        public event PacketRecieved? OnUserReceiveMessage;

        private UdpUser() { }

        public static UdpUser ConnectTo(string hostname, int port)
        {
            var connection = new UdpUser();
            connection.Client.Connect(hostname, port);
            return connection;
        }

        public void Send(string message)
        {
            var datagram = Encoding.ASCII.GetBytes(message);
            Client.Send(datagram, datagram.Length);
        }

        public void Listen()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var Packet = await this.ReceivePacket();
                        Console.WriteLine(Packet.Payload);
                        OnUserReceiveMessage?.Invoke(Packet);
                        if (Packet.Payload.Contains("quit"))
                            break;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            });
        }

    }
}
