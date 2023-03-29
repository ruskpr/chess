using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.TCP
{
    public class Server
    {
        TcpListener _listener;

        Board _board;
        Player? _playerWhite;
        Player? _playerBlack;

        public Server()
        {


        }

        public void StartServer()
        {
            throw new NotImplementedException();
        }
        
    }
}
