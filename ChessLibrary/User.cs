using ChessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class User
    {
        public string username { get; set; }
        public int chess_rating { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int games_played { get; set; }
        public Bitmap? profile_pic { get; set; }
        public DateTime account_created { get; set; } 

        #region Constructors
        public User(string username)
        {

        }
        public User() // for offline user
        {
            username = "Offline User";
            chess_rating = 0;
            profile_pic = Assets.DefaultProfilePic;
        }
        #endregion
    }
}
