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

namespace ChessGameSimple
{
    public partial class FormClient : Form
    {
        string _clientName;
        private UdpUser client;

        public FormClient(string ip, int port)
        {
            InitializeComponent();
            Thread.Sleep(500);
            client = UdpUser.ConnectTo("172.18.31.108", 32123);
            client.OnUserReceiveMessage += Client_OnPacketRecieved;
            client.Listen();
            
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
            client.Send("hello world");
        }

        #endregion

    }
}
