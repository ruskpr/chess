using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.TCP
{
    public enum MessageType
    {
        Broadcast,
        SingleMessage,
        ClientConnected,
        ClientDisconnected,
        ServerDisconnected,
        FileReceived,
        ServerOnlyMessage,
        FileRequest,
        FileList,
    }

    public class Packet
    {
        public MessageType MessageType { get; set; }
        public string Payload { get; set; }
        public string? Sender { get; set; }


        public Packet(string payload, MessageType messageType, string? sender = null)
        {
            Payload = payload;
            MessageType = messageType;
            Sender = sender;
        }

        public T JsonDeserialize<T>()
        {
            return JsonConvert.DeserializeObject<T>( Payload );
        }
    }
}
