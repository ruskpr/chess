using Chess.Core.UDP;

namespace ChessServer
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //create a new server
            var server = new UdpListener();
            server.StartListening();
           
            Console.WriteLine("listening...");
            Console.ReadLine();
        }

    }
}