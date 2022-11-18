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
        public string Username { get; set; }
        public int ChessRating { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int GamesPlayed { get; set; }
        public Bitmap? ProfilePic { get; set; }
        #region Constructors
        public User(string username)
        {
            DataLayer dl = new DataLayer();
            var info = dl.GetUserInfo(username); // get user info from database
            Username = info.Item1;
            ChessRating = info.Item2;
            Wins = info.Item3;
            Losses = info.Item4;
            GamesPlayed = info.Item5;
            ProfilePic = info.Item6;
            
            //MessageBox.Show($"{Username}, {ChessRating}, {ProfilePic}");
        }
        public User() // for offline user
        {
            Username = "Offline User";
            ChessRating = 0;
            ProfilePic = Assets.DefaultProfilePic;
        }
        #endregion
    }
}
