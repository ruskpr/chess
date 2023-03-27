using ChessLibrary;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    [Serializable]
    public class User
    {
        [NonSerialized] public Bitmap ProfilePic;

        public string username { get; set; }
        public int chess_rating { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int games_played { get; set; }

        public User(string username)
        {
            this.username = username;
            chess_rating = 0;
            ProfilePic = Assets.DefaultPic;
        }
    }
}
