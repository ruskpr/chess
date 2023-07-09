using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClient;

public partial class FormLauncher : Form
{
    public FormLauncher()
    {
        InitializeComponent();
        this.Icon = new Icon("icon.ico");
    }

    private void btnPlayerVsPlayer_Click(object sender, EventArgs e)
    {
        FormPlayerVsPlayer frmPvP = new FormPlayerVsPlayer();
        frmPvP.Show();
    }

    private void btnPlayerVsAI_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Not implemented");
    }

    private void btnAIVsAI_Click(object sender, EventArgs e)
    {
        FormAIvsAI frmAi = new FormAIvsAI();
        frmAi.Show();
    }

    private void btnJoinServer_Click(object sender, EventArgs e)
    {
        using (FormJoinServer frmJoinServer = new FormJoinServer())
        {
            frmJoinServer.ShowDialog();
            if (frmJoinServer.DialogResult == DialogResult.OK)
            {

                FormUDPClient frmClient = new FormUDPClient(frmJoinServer.Username,
                                                frmJoinServer.EndpointAddress.Address.ToString(),
                                                frmJoinServer.EndpointAddress.Port);
                frmClient.Show();
            }
        }
    }

    private async void btnHostServer_Click(object sender, EventArgs e)
    {
        using (FormHostServer frmHostServer = new FormHostServer())
        {
            frmHostServer.ShowDialog();

            if (frmHostServer.DialogResult == DialogResult.OK)
            {
                var ipAddress = frmHostServer.EndpointAddress.Address.ToString();
                var port = frmHostServer.EndpointAddress.Port;
                var serverExecutablePath = Path.Combine(Environment.CurrentDirectory, "ChessServer.exe");

                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = serverExecutablePath;
                p.StartInfo.Arguments = $"{port}";
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.CreateNoWindow = false;
                p.Start();

                await Task.Delay(1000);

                FormUDPClient frmClient = new FormUDPClient(frmHostServer.Username, ipAddress, port);
                frmClient.Show();
            }

        }



    }
}
