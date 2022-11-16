using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Data.SqlClient;

namespace ChessLibrary
{
    public class DataLayer
    {
        public delegate void PassUserInfoDelegate(string username, int chessRating, Bitmap profilePic);
        public event PassUserInfoDelegate PassUserInfo;

        private string connString;
        public DataLayer()
        {
            connString = "server=tcp:russ-server.database.windows.net,1433;database=ChessDB;user id=russ;password=P@ssword!;encrypt=false;";
            //connString = ConfigurationManager.ConnectionStrings["remoteconnection"].ConnectionString;
        }
        #region Get user info
        public int GetChessRating(string username)
        {

            return 0;
        }
        public Bitmap GetProfilePic(string username)
        {
            return null;
        }
        public Bitmap ChangeProfilePic()
        {
            return null;
        }
        public void GetUserInfo()
        {
            string username = "";
            int chessRating = 0;
            Bitmap profilePic = null;

            PassUserInfo.Invoke(username, chessRating, profilePic);
        }
        #endregion

        #region Register/login user method
        public bool RegisterUser(string username, string password)
        {
            string qry = @"INSERT INTO Users VALUES (" +
                         @"@username, @password, '800', null, GETDATE())";

            // add parameters
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@username", username);
            parameters[1] = new SqlParameter("@password", password);

            return this.ExecuteNonQuery(qry, parameters);
        }
        public bool LoginUser(string username, string password)
        {
            try
            {
                string qry = @"SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";

                // add parameters
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@username", username);
                parameters[1] = new SqlParameter("@password", password);

                int count = (int)this.ExecuteScalar(qry, parameters);
                return count == 1;
            }
            catch { return false; }
        }
        #endregion
        #region Private methods (ExecuteNonQuery & ExecuteScalar)
        private bool ExecuteNonQuery(string qry, SqlParameter[]? parameters)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(qry, conn);

                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            catch { ret = false; }
            finally { conn.Close(); }

            return ret;
        }
        private object ExecuteScalar(string qry, SqlParameter[]? parameters)
        {

            object? ret = null;
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(qry, conn);

                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);

                ret = cmd.ExecuteScalar();
            }
            catch { return null; }
            finally { conn.Close(); }

            return ret;
        }
        #endregion
    }
}
