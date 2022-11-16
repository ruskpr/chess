using ChessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class User
    {
        public string Username { get; set; }
        public int ChessRating { get; set; }
        public Bitmap? ProfilePic { get; set; }
        public User(string username)
        {
            DataLayer dl = new DataLayer();
            dl.PassUserInfo += Dl_PassUserInfo;
            dl.GetUserInfo(username);
            MessageBox.Show($"{Username}, {ChessRating}, {ProfilePic}");
        }
        public User()
        {
            Username = "Offline User";
            ChessRating = 0;
            ProfilePic = Assets.DefaultProfilePic;
        }

        private void Dl_PassUserInfo(string username, int chessRating, Bitmap profilePic)
        {
            Username = username;
            ChessRating = chessRating;
            ProfilePic = profilePic; 
        }
    }
}
