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
        public Bitmap ProfilePic { get; set; }
        public User(string username)
        {
            DataLayer dl = new DataLayer();
            Username = username;
            ChessRating = dl.GetChessRating(Username);
            ProfilePic = dl.GetProfilePic(Username);

        }        
    }
}
