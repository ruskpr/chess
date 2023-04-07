using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.UDP
{
    public class Packet
    {
        public string Payload { get; set; }
        public string SenderName { get; set; }
        public string? SenderEndpoint { get; set; }

        public Packet(string senderName, string payload, IPEndPoint senderIP)
        {
            Payload = payload;
            SenderName = senderName;

            if (senderIP != null)
                SenderEndpoint = senderIP.Address + ":" + senderIP.Port;
        }

        #region public static

        public static string Serialize(Packet packet)
        {
            return JsonConvert.SerializeObject(packet);
        }   

        public static Packet Deserialize(string packetJson)
        {
            return JsonConvert.DeserializeObject<Packet>(packetJson);
        }

        #endregion
    }
}
