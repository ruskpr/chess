namespace ChessClient;

partial class FormUDPClient
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
        btnSendMessage = new Button();
        lstMessages = new ListBox();
        panel1 = new Panel();
        tbMessage = new TextBox();
        pnlBoard = new Panel();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // btnSendMessage
        // 
        btnSendMessage.BackColor = Color.Silver;
        btnSendMessage.FlatAppearance.BorderSize = 0;
        btnSendMessage.FlatStyle = FlatStyle.Flat;
        btnSendMessage.ForeColor = Color.White;
        btnSendMessage.Location = new Point(310, 892);
        btnSendMessage.Margin = new Padding(6, 6, 6, 6);
        btnSendMessage.Name = "btnSendMessage";
        btnSendMessage.Size = new Size(139, 49);
        btnSendMessage.TabIndex = 0;
        btnSendMessage.Text = "Send";
        btnSendMessage.UseVisualStyleBackColor = false;
        btnSendMessage.Click += btnSendMessage_Click;
        // 
        // lstMessages
        // 
        lstMessages.FormattingEnabled = true;
        lstMessages.ItemHeight = 32;
        lstMessages.Location = new Point(6, 6);
        lstMessages.Margin = new Padding(6, 6, 6, 6);
        lstMessages.Name = "lstMessages";
        lstMessages.Size = new Size(440, 868);
        lstMessages.TabIndex = 1;
        // 
        // panel1
        // 
        panel1.Controls.Add(tbMessage);
        panel1.Controls.Add(btnSendMessage);
        panel1.Controls.Add(lstMessages);
        panel1.Dock = DockStyle.Right;
        panel1.Location = new Point(851, 0);
        panel1.Margin = new Padding(6, 6, 6, 6);
        panel1.Name = "panel1";
        panel1.Size = new Size(455, 951);
        panel1.TabIndex = 2;
        // 
        // tbMessage
        // 
        tbMessage.Location = new Point(6, 892);
        tbMessage.Margin = new Padding(6, 6, 6, 6);
        tbMessage.Name = "tbMessage";
        tbMessage.PlaceholderText = "message...";
        tbMessage.Size = new Size(290, 39);
        tbMessage.TabIndex = 2;
        // 
        // pnlBoard
        // 
        pnlBoard.Dock = DockStyle.Left;
        pnlBoard.Location = new Point(0, 0);
        pnlBoard.Margin = new Padding(6, 6, 6, 6);
        pnlBoard.Name = "pnlBoard";
        pnlBoard.Size = new Size(839, 951);
        pnlBoard.TabIndex = 3;
        // 
        // FormUDPClient
        // 
        AcceptButton = btnSendMessage;
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1306, 951);
        Controls.Add(pnlBoard);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        KeyPreview = true;
        Margin = new Padding(6, 6, 6, 6);
        MaximizeBox = false;
        Name = "FormUDPClient";
        StartPosition = FormStartPosition.Manual;
        Text = "Chess";
        FormClosing += FormUDPClient_FormClosing;
        KeyDown += FormClient_KeyDown;
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Button btnSendMessage;
    private ListBox lstMessages;
    private Panel panel1;
    private TextBox tbMessage;
    private Panel pnlBoard;
}