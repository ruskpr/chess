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
        string _clientName;
        private UdpUser _client;
        

        public FormClient(string name, string ip, int port)
        {
            InitializeComponent();
            _clientName = name;
            _client = UdpUser.ConnectTo(ip, port);
            _client.OnUserReceiveMessage += Client_OnPacketRecieved;
            //client.Listen();

            Task.Factory.StartNew(async () => {
                while (true)
                {
                    try
                    {
                        var packet = await _client.Receive();
                        HandlePacket(packet);
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                }
            });

        }

        private void Client_OnPacketRecieved(Packet packet)
        {
            HandlePacket(packet);
        }

        private void HandlePacket(Packet packet)
        {
            // TODO: update board

            this.Invoke(() => lstMessages.Items.Add(packet.Payload));
        }

        #region form code

        private void button1_Click(object sender, EventArgs e)
        {
            _client.Send(new Packet(_clientName, "hello world", null));
        }

        #endregion

    }
}
