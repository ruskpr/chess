using Chess.Core.TCP;

namespace ChessServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(30000);
            server.OnPacketRecieved += Server_OnPacketRecieved;

            Task.Run(() => server.Start()); 
            
            Console.ReadLine();
        }

        private static void Server_OnPacketRecieved(Packet packet)
        {
            Console.WriteLine(packet.Payload);
        }
    }
}