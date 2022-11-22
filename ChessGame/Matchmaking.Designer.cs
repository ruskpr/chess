namespace ChessGame
{
    partial class Matchmaking
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
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.btnCreateNewRoom = new System.Windows.Forms.Button();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbMyIP = new System.Windows.Forms.Label();
            this.lbNumUsers = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.ItemHeight = 15;
            this.lstRooms.Location = new System.Drawing.Point(168, 40);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(283, 244);
            this.lstRooms.TabIndex = 0;
            this.lstRooms.SelectedIndexChanged += new System.EventHandler(this.lstRooms_SelectedIndexChanged);
            // 
            // btnCreateNewRoom
            // 
            this.btnCreateNewRoom.Location = new System.Drawing.Point(168, 290);
            this.btnCreateNewRoom.Name = "btnCreateNewRoom";
            this.btnCreateNewRoom.Size = new System.Drawing.Size(146, 23);
            this.btnCreateNewRoom.TabIndex = 1;
            this.btnCreateNewRoom.Text = "Create New Room";
            this.btnCreateNewRoom.UseVisualStyleBackColor = true;
            this.btnCreateNewRoom.Click += new System.EventHandler(this.btnCreateNewRoom_Click);
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.Location = new System.Drawing.Point(411, 365);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(194, 23);
            this.btnJoinRoom.TabIndex = 1;
            this.btnJoinRoom.Text = "Join Room";
            this.btnJoinRoom.UseVisualStyleBackColor = true;
            this.btnJoinRoom.Click += new System.EventHandler(this.btnJoinRoom_Click);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(17, 12);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(77, 15);
            this.lbUsername.TabIndex = 2;
            this.lbUsername.Text = "Logged in as:";
            // 
            // lbMyIP
            // 
            this.lbMyIP.AutoSize = true;
            this.lbMyIP.Location = new System.Drawing.Point(60, 331);
            this.lbMyIP.Name = "lbMyIP";
            this.lbMyIP.Size = new System.Drawing.Size(38, 15);
            this.lbMyIP.TabIndex = 3;
            this.lbMyIP.Text = "label1";
            // 
            // lbNumUsers
            // 
            this.lbNumUsers.AutoSize = true;
            this.lbNumUsers.Location = new System.Drawing.Point(60, 373);
            this.lbNumUsers.Name = "lbNumUsers";
            this.lbNumUsers.Size = new System.Drawing.Size(38, 15);
            this.lbNumUsers.TabIndex = 3;
            this.lbNumUsers.Text = "label1";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(60, 352);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(38, 15);
            this.lbPort.TabIndex = 3;
            this.lbPort.Text = "label1";
            // 
            // Matchmaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 400);
            this.Controls.Add(this.lbNumUsers);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbMyIP);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.btnJoinRoom);
            this.Controls.Add(this.btnCreateNewRoom);
            this.Controls.Add(this.lstRooms);
            this.Name = "Matchmaking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matchmaking";
            this.Load += new System.EventHandler(this.Matchmaking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstRooms;
        private Button btnCreateNewRoom;
        private Button btnJoinRoom;
        private Label lbUsername;
        private Label lbMyIP;
        private Label lbNumUsers;
        private Label lbPort;
    }
}