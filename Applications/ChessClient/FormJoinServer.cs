using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClient;

public partial class FormJoinServer : Form
{

    public IPEndPoint EndpointAddress { get; set; }
    public string Username { get; set; }
    public FormJoinServer()
    {
        InitializeComponent();
        this.Icon = new Icon("icon.ico");
    }

    private void btnJoin_Click(object sender, EventArgs e)
    {
        #region validation

        if (string.IsNullOrWhiteSpace(tbUsername.Text))
        {
            MessageBox.Show("Enter a username.");
            return;
        }

        if (string.IsNullOrWhiteSpace(tbIP.Text))
        {
            MessageBox.Show("Enter an IP address.");
            return;
        }

        if (string.IsNullOrWhiteSpace(tbPort.Text))
        {
            MessageBox.Show("Enter a port.");
            return;
        }

        if (tbUsername.Text.Length >= 30)
        {
            MessageBox.Show("username must be less that 30 characters.");
            return;
        }

        #endregion

        // handle loopback address if user inputs "localhost"
        if (tbIP.Text.Trim().ToLower() == "localhost") tbIP.Text = "127.0.0.1";
        if (IPEndPoint.TryParse($"{tbIP.Text}:{tbPort.Text}", out IPEndPoint ipEndpoint))
        {
            Username = tbUsername.Text;
            EndpointAddress = ipEndpoint;
            DialogResult = DialogResult.OK;
        }
        else
        {
            MessageBox.Show("Invalid server address, check you IP and port then try again.");
        }
    }
}
