using ChessLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
            tbLoginUsername.Text = "russ";
            tbLoginPassword.Text = "password";
        }


        #region Click events
        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (DataLayer dl = new DataLayer())
            {
                //
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
