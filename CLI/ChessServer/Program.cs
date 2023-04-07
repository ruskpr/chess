using Chess.Core.UDP;
using System.Net;

namespace ChessServer
{
    internal class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        static void Main(string[] args)
        {
            // configure console
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(100, 50);

            // set port from command args, or use default '32123'
            int port = args.Length == 1 ? Convert.ToInt32(args[0]) : 32123;

            //start a new server
            var server = new UdpListener(new IPEndPoint(IPAddress.Any, port));
            server.StartListening();
            Console.WriteLine("listening...");
            Console.ReadKey();
        }

    }
}