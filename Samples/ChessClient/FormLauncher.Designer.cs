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
            label1 = new Label();
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
            btnPlayerVsPlayer.BackColor = Color.Silver;
            btnPlayerVsPlayer.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            btnPlayerVsPlayer.FlatAppearance.BorderSize = 0;
            btnPlayerVsPlayer.FlatStyle = FlatStyle.Flat;
            btnPlayerVsPlayer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnPlayerVsAI.BackColor = Color.Silver;
            btnPlayerVsAI.Enabled = false;
            btnPlayerVsAI.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            btnPlayerVsAI.FlatAppearance.BorderSize = 0;
            btnPlayerVsAI.FlatStyle = FlatStyle.Flat;
            btnPlayerVsAI.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnAIVsAI.BackColor = Color.Silver;
            btnAIVsAI.Enabled = false;
            btnAIVsAI.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            btnAIVsAI.FlatAppearance.BorderSize = 0;
            btnAIVsAI.FlatStyle = FlatStyle.Flat;
            btnAIVsAI.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnJoinServer.BackColor = Color.Silver;
            btnJoinServer.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            btnJoinServer.FlatAppearance.BorderSize = 0;
            btnJoinServer.FlatStyle = FlatStyle.Flat;
            btnJoinServer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            btnHostServer.BackColor = Color.Silver;
            btnHostServer.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            btnHostServer.FlatAppearance.BorderSize = 0;
            btnHostServer.FlatStyle = FlatStyle.Flat;
            btnHostServer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
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
            // label1
            // 
            label1.Font = new Font("Source Code Pro", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(118, 12);
            label1.Name = "label1";
            label1.Size = new Size(259, 100);
            label1.TabIndex = 2;
            label1.Text = "Chess";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormLauncher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(495, 315);
            Controls.Add(label1);
            Controls.Add(btnHostServer);
            Controls.Add(btnJoinServer);
            Controls.Add(btnAIVsAI);
            Controls.Add(btnPlayerVsAI);
            Controls.Add(btnPlayerVsPlayer);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormLauncher";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chess";
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
        private Label label1;
    }
}