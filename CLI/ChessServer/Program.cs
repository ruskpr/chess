using Chess.Core.UDP;

namespace ChessServer
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //create a new server
            var server = new UdpListener();
            
            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () => {
                while (true)
                {
                    var received = await server.ReceivePacket();
                    Console.WriteLine("message recieved: " + received.Payload);
                    server.Reply(received, received.Sender);
                    if (received.Payload == "quit")
                        break;
                }
            });

            Console.WriteLine("listening...");
            Console.ReadLine();
        }

    }
}