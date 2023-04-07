﻿using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Chess.Core.UDP
{
    public class UdpUser : UdpBase
    {        

        private UdpUser() { }

        public static UdpUser ConnectTo(string username, string hostname, int port)
        {
            var connection = new UdpUser();
            connection.Client.Connect(hostname, port);
            connection.Send(new Packet(username, $"{username} connected", PacketType.Connect));
            return connection;
        }

        public void Send(Packet packet)
        {
            var json = Packet.Serialize(packet);

            byte[] datagram = Encoding.ASCII.GetBytes(json);
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
                        var packet = await this.Receive();
                        //OnUserReceiveMessage?.Invoke(packet);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            });
        }

    }
}
