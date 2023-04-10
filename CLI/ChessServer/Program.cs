using Chess.Core;
using Chess.Core.UDP;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;

namespace ChessServer
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    internal class Program
    {

        static UdpListener _server;
        static Game _game;
        static bool _gameOver = false;
        private static bool _gameStarted = false;
        private static Player _p1;
        private static Player _p2;

        static async Task Main(string[] args)
        {
            // configure console
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(60, 40);
            Console.CursorVisible = false;

            

            // set port from command args, or use default '32123'
            int port = args.Length == 1 ? Convert.ToInt32(args[0]) : 32123;

            //start a new server
            _server = new UdpListener(new IPEndPoint(IPAddress.Any, port), 2);
            _server.OnPacketRecieved += Server_OnPacketRecieved;
            _server.StartListening();
            
            Console.WriteLine($"SERVER STARTED...");
            Console.WriteLine($"clients can access it on {GetLocalIpAddress()}:{port}\n");

            Console.WriteLine("Waiting for players...");

            await WaitForPlayers();


            Console.WriteLine($"Game has started! {_p1.Name} (white) vs {_p2.Name} (black)");
            //while (!_gameOver)
            //{

            //}

            Console.ReadKey();
        }

        private static Task WaitForPlayers()
        {
            return Task.Factory.StartNew(() => {
                var board = new Board(8, true);

                while (!_gameStarted)
                {
                    // keep going until we have 2 players
                    if (_p1 is not null && _p2 is not null)
                    {
                        _game = new Game(board, _p1, _p2);
                        _gameStarted = true;
                        break;
                    }
                }

            });
        }

        #region game logic

        private void MakeMove(Tile from, Tile to)
        {
            // try to make the move
            if (_game.Board.TryMakeMove(_game.Board.GetTileByPiece(from.Piece), to))
            {
                _server.ReplyAll(new Packet("SERVER", "piece moved", PacketType.GameUpdateResponse));
            }
        }

        #endregion

        #region packet received event

        private static void Server_OnPacketRecieved(Packet packet)
        {
            switch (packet.Type)
            {
                case PacketType.Connect:
                    var username = packet.SenderName;

                    if (_p1 is null)
                    {
                        _p1 = new Player(username, 'w', PlayerType.OnlinePlayer);
                        _server.Reply(new Packet("SERVER", "You are player 1 (white)", PacketType.Message), packet.SenderEndpointParsed);
                    }
                    else if (_p2 is null)
                    {
                        _p2 = new Player(username, 'b', PlayerType.OnlinePlayer);
                        _server.Reply(new Packet("SERVER", "You are player 2 (black)", PacketType.Message), packet.SenderEndpointParsed);
                    }
                    else
                    {
                        _server.Reply(new Packet("SERVER", "Game is full", PacketType.Message), packet.SenderEndpointParsed);
                    }
                    break;

                case PacketType.GameUpdateRequest:

                    _server.Reply(UpdateGamePacket(), packet.SenderEndpointParsed);
                    break;

                case PacketType.Move:
                    
                    var move = JsonConvert.DeserializeObject<Tuple<Tile, Tile>>(packet.Payload, new JsonSerializerSettings
                    {
                        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    });

                    var from = _game.Board.GetTile(move.Item1.Row, move.Item1.Column);
                    var to = _game.Board.GetTile(move.Item2.Row, move.Item2.Column);

                    // try to make the move
                    if (_game.Board.TryMakeMove(from, to))
                    {
                        _game.SwapTurn();
                        _server.ReplyAll(UpdateGamePacket());
                    }

                    break;

                default:
                    break;
            }
        }


        private static Packet UpdateGamePacket()
        {
            var gameInfoJson = JsonConvert.SerializeObject(_game, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });

            return new("SERVER", gameInfoJson, PacketType.GameUpdateResponse);
        }
        #endregion

        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return _server.IpAddress;
        }

    }
}