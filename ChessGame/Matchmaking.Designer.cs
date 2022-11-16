﻿namespace ChessGame
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
            this.SuspendLayout();
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.ItemHeight = 15;
            this.lstRooms.Location = new System.Drawing.Point(165, 12);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(283, 244);
            this.lstRooms.TabIndex = 0;
            // 
            // btnCreateNewRoom
            // 
            this.btnCreateNewRoom.Location = new System.Drawing.Point(165, 262);
            this.btnCreateNewRoom.Name = "btnCreateNewRoom";
            this.btnCreateNewRoom.Size = new System.Drawing.Size(146, 23);
            this.btnCreateNewRoom.TabIndex = 1;
            this.btnCreateNewRoom.Text = "Create New Room";
            this.btnCreateNewRoom.UseVisualStyleBackColor = true;
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.Location = new System.Drawing.Point(411, 365);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(194, 23);
            this.btnJoinRoom.TabIndex = 1;
            this.btnJoinRoom.Text = "Join Room";
            this.btnJoinRoom.UseVisualStyleBackColor = true;
            // 
            // Matchmaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 400);
            this.Controls.Add(this.btnJoinRoom);
            this.Controls.Add(this.btnCreateNewRoom);
            this.Controls.Add(this.lstRooms);
            this.Name = "Matchmaking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matchmaking";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lstRooms;
        private Button btnCreateNewRoom;
        private Button btnJoinRoom;
    }
}