using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGameSimple
{
    public partial class FormLauncher : Form
    {
        public FormLauncher()
        {
            InitializeComponent();
        }

        private void btnPlayerVsPlayer_Click(object sender, EventArgs e)
        {
            FormPlayerVsPlayer formLocalGame = new FormPlayerVsPlayer();
            formLocalGame.Show();
        }

        private void btnPlayerVsAI_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAIVsAI_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnJoinServer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnHostServer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
