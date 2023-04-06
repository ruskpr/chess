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
        public IPEndPoint Sender { get; set; }
        public string Payload { get; set; }



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
