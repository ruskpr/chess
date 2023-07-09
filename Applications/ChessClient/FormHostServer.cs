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

public partial class FormHostServer : Form
{

    public IPEndPoint EndpointAddress { get; set; }
    public string Username { get; set; }

    public FormHostServer()
    {
        InitializeComponent();
        this.Icon = new Icon("icon.ico");
    }

    private void btnStartAndJoin_Click(object sender, EventArgs e)
    {
        if (IPEndPoint.TryParse($"127.0.0.1:{tbPort.Text}", out IPEndPoint? ip))
        {
            EndpointAddress = ip;

            if (!string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                Username = tbUsername.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid username.");
            }
        }
        else
        {
            MessageBox.Show("Invalid port number.");
        }
    }
}
