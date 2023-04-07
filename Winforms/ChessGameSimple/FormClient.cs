using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.Core.UDP;
using System.Diagnostics;

namespace ChessGameSimple
{
    public partial class FormClient : Form
    {
        string _username;
        private UdpUser _client;
        

        public FormClient(string name, string ip, int port)
        {
            InitializeComponent();
            _username = name;
            _client = UdpUser.ConnectTo(_username, ip, port);
            _client.OnPacketRecieved += Client_OnPacketRecieved;
            _client.Listen();          
        }

        #region private

        #region packet handlers

        // will be called when a packet is recieved from the server
        private void Client_OnPacketRecieved(Packet packet)
        {
            HandlePacket(packet);
        }

        private void HandlePacket(Packet packet)
        {
            // TODO: update board
            switch (packet.Type)
            {
                case PacketType.Connect:
                    break;
                case PacketType.Disconnect:
                    throw new NotImplementedException();
                    break;
                case PacketType.Message:
                    this.Invoke(() => lstMessages.Items.Add($"{packet.SenderName}: {packet.Payload}"));

                    break;
                case PacketType.Move:
                    // TODO: update board on client side
                    throw new NotImplementedException();
                    break;
                case PacketType.GameStart:
                    break;
                case PacketType.GameEnd:
                    break;
                case PacketType.Error:
                    break;
                default:
                    break;
            }

        }

        #endregion

        #region packet type handler methods

        #endregion

        #endregion

        #region form code

        private void button1_Click(object sender, EventArgs e)
        {
            _client.Send(new Packet(_username, "hello world" , PacketType.Message));
        }

        #endregion

    }
}
