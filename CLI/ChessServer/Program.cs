using Chess.Core;
using Chess.Core.UDP;
using Newtonsoft.Json;
using System.Net;

namespace ChessServer
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    internal class Program
    {
        static UdpListener _server;
        static Board _board;

        static void Main(string[] args)
        {
            // configure console
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(60, 40);
            Console.CursorVisible = false;

            // init board
            _board = new Board(8, true);

            // set port from command args, or use default '32123'
            int port = args.Length == 1 ? Convert.ToInt32(args[0]) : 32123;

            //start a new server
            _server = new UdpListener(new IPEndPoint(IPAddress.Any, port), 2);
            _server.OnPacketRecieved += Server_OnPacketRecieved;
            _server.StartListening();
            Console.WriteLine($"started server on port {port}...");
            Console.ReadKey();
        }

        private static void Server_OnPacketRecieved(Packet packet)
        {
            Console.WriteLine($"Packet recieved: payload = {packet.Payload}");

            switch (packet.Type)
            {
                case PacketType.GameUpdateRequest:
                    string player = packet.Payload; 

                    var boardJson = JsonConvert.SerializeObject(_board, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        NullValueHandling = NullValueHandling.Ignore,
                    });

                    Packet gameStatePacket = new("SERVER", boardJson, PacketType.GameUpdateResponse);
                    _server.Reply(gameStatePacket, packet.SenderEndpointParsed);
                    break;

                case PacketType.Move:
                    var move = JsonConvert.DeserializeObject<Tuple<Tile, Tile>>(packet.Payload);
                    bool moveMade = _board.TryMakeMove(move.Item1, move.Item2);

                    if (moveMade) 
                        _server.ReplyAll(packet);
                    
                    break;

                default:
                    break;
            }
        }
    }
}