namespace ChessGameSimple
{
    partial class FormLauncher
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
            pictureBox1 = new PictureBox();
            btnPlayerVsPlayer = new Button();
            btnPlayerVsAI = new Button();
            btnAIVsAI = new Button();
            btnJoinServer = new Button();
            btnHostServer = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Resources.WhiteRook;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Resources.WhiteKnight;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnPlayerVsPlayer
            // 
            btnPlayerVsPlayer.BackColor = Color.DimGray;
            btnPlayerVsPlayer.FlatAppearance.BorderSize = 0;
            btnPlayerVsPlayer.FlatStyle = FlatStyle.Flat;
            btnPlayerVsPlayer.ForeColor = Color.White;
            btnPlayerVsPlayer.Location = new Point(198, 150);
            btnPlayerVsPlayer.Name = "btnPlayerVsPlayer";
            btnPlayerVsPlayer.Size = new Size(99, 23);
            btnPlayerVsPlayer.TabIndex = 1;
            btnPlayerVsPlayer.Text = "Player vs Player";
            btnPlayerVsPlayer.UseVisualStyleBackColor = false;
            btnPlayerVsPlayer.Click += btnPlayerVsPlayer_Click;
            // 
            // btnPlayerVsAI
            // 
            btnPlayerVsAI.BackColor = Color.DimGray;
            btnPlayerVsAI.FlatAppearance.BorderSize = 0;
            btnPlayerVsAI.FlatStyle = FlatStyle.Flat;
            btnPlayerVsAI.ForeColor = Color.White;
            btnPlayerVsAI.Location = new Point(198, 179);
            btnPlayerVsAI.Name = "btnPlayerVsAI";
            btnPlayerVsAI.Size = new Size(99, 23);
            btnPlayerVsAI.TabIndex = 1;
            btnPlayerVsAI.Text = "Player vs AI";
            btnPlayerVsAI.UseVisualStyleBackColor = false;
            btnPlayerVsAI.Click += btnPlayerVsAI_Click;
            // 
            // btnAIVsAI
            // 
            btnAIVsAI.BackColor = Color.DimGray;
            btnAIVsAI.FlatAppearance.BorderSize = 0;
            btnAIVsAI.FlatStyle = FlatStyle.Flat;
            btnAIVsAI.ForeColor = Color.White;
            btnAIVsAI.Location = new Point(198, 208);
            btnAIVsAI.Name = "btnAIVsAI";
            btnAIVsAI.Size = new Size(99, 23);
            btnAIVsAI.TabIndex = 1;
            btnAIVsAI.Text = "AI vs AI";
            btnAIVsAI.UseVisualStyleBackColor = false;
            btnAIVsAI.Click += btnAIVsAI_Click;
            // 
            // btnJoinServer
            // 
            btnJoinServer.BackColor = Color.DimGray;
            btnJoinServer.FlatAppearance.BorderSize = 0;
            btnJoinServer.FlatStyle = FlatStyle.Flat;
            btnJoinServer.ForeColor = Color.White;
            btnJoinServer.Location = new Point(144, 275);
            btnJoinServer.Name = "btnJoinServer";
            btnJoinServer.Size = new Size(99, 23);
            btnJoinServer.TabIndex = 1;
            btnJoinServer.Text = "Join Server";
            btnJoinServer.UseVisualStyleBackColor = false;
            btnJoinServer.Click += btnJoinServer_Click;
            // 
            // btnHostServer
            // 
            btnHostServer.BackColor = Color.DimGray;
            btnHostServer.FlatAppearance.BorderSize = 0;
            btnHostServer.FlatStyle = FlatStyle.Flat;
            btnHostServer.ForeColor = Color.White;
            btnHostServer.Location = new Point(249, 275);
            btnHostServer.Name = "btnHostServer";
            btnHostServer.Size = new Size(99, 23);
            btnHostServer.TabIndex = 1;
            btnHostServer.Text = "Host Server";
            btnHostServer.UseVisualStyleBackColor = false;
            btnHostServer.Click += btnHostServer_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Resources.BlackQueen;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(383, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 100);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // FormLauncher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 315);
            Controls.Add(btnHostServer);
            Controls.Add(btnJoinServer);
            Controls.Add(btnAIVsAI);
            Controls.Add(btnPlayerVsAI);
            Controls.Add(btnPlayerVsPlayer);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "FormLauncher";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Launcher";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnPlayerVsPlayer;
        private Button btnPlayerVsAI;
        private Button btnAIVsAI;
        private Button btnJoinServer;
        private Button btnHostServer;
        private PictureBox pictureBox2;
    }
}