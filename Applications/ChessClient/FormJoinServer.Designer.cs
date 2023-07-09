namespace ChessClient;

partial class FormJoinServer
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tbPort = new TextBox();
        tbIP = new TextBox();
        btnJoin = new Button();
        label3 = new Label();
        label2 = new Label();
        tbUsername = new TextBox();
        label1 = new Label();
        SuspendLayout();
        // 
        // tbPort
        // 
        tbPort.Location = new Point(223, 149);
        tbPort.Margin = new Padding(6);
        tbPort.Name = "tbPort";
        tbPort.Size = new Size(182, 39);
        tbPort.TabIndex = 2;
        // 
        // tbIP
        // 
        tbIP.Location = new Point(223, 87);
        tbIP.Margin = new Padding(6);
        tbIP.Name = "tbIP";
        tbIP.Size = new Size(182, 39);
        tbIP.TabIndex = 1;
        // 
        // btnJoin
        // 
        btnJoin.BackColor = Color.DodgerBlue;
        btnJoin.FlatAppearance.BorderSize = 0;
        btnJoin.FlatStyle = FlatStyle.Flat;
        btnJoin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnJoin.ForeColor = Color.White;
        btnJoin.Location = new Point(117, 230);
        btnJoin.Margin = new Padding(6);
        btnJoin.Name = "btnJoin";
        btnJoin.Size = new Size(258, 49);
        btnJoin.TabIndex = 3;
        btnJoin.Text = "Join Server";
        btnJoin.UseVisualStyleBackColor = false;
        btnJoin.Click += btnJoin_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(61, 156);
        label3.Margin = new Padding(6, 0, 6, 0);
        label3.Name = "label3";
        label3.Size = new Size(58, 32);
        label3.TabIndex = 4;
        label3.Text = "port";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(61, 94);
        label2.Margin = new Padding(6, 0, 6, 0);
        label2.Name = "label2";
        label2.Size = new Size(121, 32);
        label2.TabIndex = 5;
        label2.Text = "IP address";
        // 
        // tbUsername
        // 
        tbUsername.Location = new Point(223, 26);
        tbUsername.Margin = new Padding(6);
        tbUsername.Name = "tbUsername";
        tbUsername.Size = new Size(182, 39);
        tbUsername.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(61, 34);
        label1.Margin = new Padding(6, 0, 6, 0);
        label1.Name = "label1";
        label1.Size = new Size(119, 32);
        label1.TabIndex = 9;
        label1.Text = "username";
        // 
        // FormJoinServer
        // 
        AcceptButton = btnJoin;
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(466, 333);
        Controls.Add(tbUsername);
        Controls.Add(label1);
        Controls.Add(tbPort);
        Controls.Add(tbIP);
        Controls.Add(btnJoin);
        Controls.Add(label3);
        Controls.Add(label2);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Margin = new Padding(6);
        Name = "FormJoinServer";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Join Server";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox tbPort;
    private TextBox tbIP;
    private Button btnJoin;
    private Label label3;
    private Label label2;
    private TextBox tbUsername;
    private Label label1;
}