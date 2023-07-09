namespace ChessClient;

partial class FormHostServer
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
        label2 = new Label();
        label3 = new Label();
        btnStartAndJoin = new Button();
        tbUsername = new TextBox();
        tbPort = new TextBox();
        SuspendLayout();
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(52, 66);
        label2.Margin = new Padding(6, 0, 6, 0);
        label2.Name = "label2";
        label2.Size = new Size(119, 32);
        label2.TabIndex = 0;
        label2.Text = "username";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(52, 128);
        label3.Margin = new Padding(6, 0, 6, 0);
        label3.Name = "label3";
        label3.Size = new Size(132, 32);
        label3.TabIndex = 0;
        label3.Text = "Server port";
        // 
        // btnStartAndJoin
        // 
        btnStartAndJoin.BackColor = Color.DodgerBlue;
        btnStartAndJoin.FlatAppearance.BorderSize = 0;
        btnStartAndJoin.FlatStyle = FlatStyle.Flat;
        btnStartAndJoin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnStartAndJoin.ForeColor = Color.White;
        btnStartAndJoin.Location = new Point(102, 215);
        btnStartAndJoin.Margin = new Padding(6);
        btnStartAndJoin.Name = "btnStartAndJoin";
        btnStartAndJoin.Size = new Size(258, 49);
        btnStartAndJoin.TabIndex = 2;
        btnStartAndJoin.Text = "Start and Join Server";
        btnStartAndJoin.UseVisualStyleBackColor = false;
        btnStartAndJoin.Click += btnStartAndJoin_Click;
        // 
        // tbUsername
        // 
        tbUsername.Location = new Point(214, 60);
        tbUsername.Margin = new Padding(6);
        tbUsername.Name = "tbUsername";
        tbUsername.Size = new Size(182, 39);
        tbUsername.TabIndex = 0;
        // 
        // tbPort
        // 
        tbPort.Location = new Point(214, 122);
        tbPort.Margin = new Padding(6);
        tbPort.Name = "tbPort";
        tbPort.Size = new Size(182, 39);
        tbPort.TabIndex = 1;
        // 
        // FormHostServer
        // 
        AcceptButton = btnStartAndJoin;
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(459, 324);
        Controls.Add(tbPort);
        Controls.Add(tbUsername);
        Controls.Add(btnStartAndJoin);
        Controls.Add(label3);
        Controls.Add(label2);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Margin = new Padding(6);
        Name = "FormHostServer";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Host Server";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Label label2;
    private Label label3;
    private Button btnStartAndJoin;
    private TextBox tbUsername;
    private TextBox tbPort;
}