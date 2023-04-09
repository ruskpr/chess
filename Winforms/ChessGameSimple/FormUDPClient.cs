using Chess.Core.UDP;
using Chess.Core;
using Newtonsoft.Json;

namespace ChessGameSimple
{
    public partial class FormUDPClient : Form
    {
        string _username;
        private UdpUser _client;

        Button[,] _buttons = new Button[8, 8];

        Board _board;

        public FormUDPClient(string name, string ip, int port)
        {
            InitializeComponent();

            _username = name;
            this.Text = "Chess Game - " + _username;

            _client = UdpUser.ConnectTo(_username, ip, port);
            _client.OnPacketRecieved += Client_OnPacketRecieved;
            _client.Listen();
        }

        #region private

        // send a packet to notify the server an updated game state is needed
        private void SendUpdateGameRequest()
        {
            Packet p = new(_username, $"{_username} requested a game update", PacketType.GameUpdateRequest);
            _client.Send(p);
        }

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
                case PacketType.GameUpdateResponse:
                    UpdateBoard(packet);
                    break;
                case PacketType.Disconnect:
                    throw new NotImplementedException();
                    break;
                case PacketType.Message:
                    this.Invoke(() => lstMessages.Items.Add($"{packet.SenderName}: {packet.Payload}"));

                    break;
                case PacketType.Move:
                    SendUpdateGameRequest();
                    throw new NotImplementedException();
                case PacketType.GameStart:
                    SendUpdateGameRequest();
                    break;
                case PacketType.GameEnd:
                    break;
                case PacketType.Error:
                    break;
                default:
                    break;
            }

        }

        private void UpdateBoard(Packet packet)
        {
            // packet payload will be board as json
            // deserizalize packet payload
            _board = JsonConvert.DeserializeObject<Board>(packet.Payload, new JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            });

            this.Invoke(() =>
            {
                ChessUtils.CreateTiles(pnlBoard, _buttons, _board, pnlBoard.Width / 8, Color.Gainsboro, Color.Tan, OnTileClicked);
                ChessUtils.DrawSymbols(_buttons, _board);
            });
        }

        private void OnTileClicked(object? sender, EventArgs e)
        {
            // TODO: send a move packet to server
            throw new NotImplementedException();
        }

        #endregion

        #region form code

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (tbMessage.Text.Trim() != "")
                _client.Send(new Packet(_username, tbMessage.Text, PacketType.Message));

            tbMessage.Text = "";
        }

        private void FormClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode > Keys.A && e.KeyCode < Keys.Z)
                tbMessage.Focus();
        }

        #endregion


    }
}
