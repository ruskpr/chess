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

        public FormClient(string ip, int port)
        {
            InitializeComponent();
            Thread.Sleep(500);
            _client = UdpUser.ConnectTo("127.0.0.1", 32123);
            _client.OnUserReceiveMessage += Client_OnPacketRecieved;
            //client.Listen();

            Task.Factory.StartNew(async () => {
                while (true)
                {
                    try
                    {
                        var received = await _client.Receive();
                        HandlePacket(received);
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
            this.Invoke(() => lstMessages.Items.Add(packet.Payload));
        }

        #region private

        private void button1_Click(object sender, EventArgs e)
        {
            _client.Send(new Packet("hello world", null));
        }

        #endregion

    }
}
