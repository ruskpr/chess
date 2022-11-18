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
        #region Constructors
        public User(string username)
        {
            DataLayer dl = new DataLayer();
            var info = dl.GetUserInfo(username); // 
            Username = info.Item1;
            ChessRating = info.Item2;
            ProfilePic = info.Item3;
            
            MessageBox.Show($"{Username}, {ChessRating}, {ProfilePic}");
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
