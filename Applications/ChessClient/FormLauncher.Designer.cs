namespace ChessClient;

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
		chess960Checkbox = new CheckBox();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		SuspendLayout();
		// 
		// pictureBox1
		// 
		pictureBox1.BackgroundImage = Resources.WhiteRook;
		pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
		pictureBox1.InitialImage = null;
		pictureBox1.Location = new Point(17, 20);
		pictureBox1.Margin = new Padding(5, 5, 5, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new Size(143, 166);
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		// 
		// btnPlayerVsPlayer
		// 
		btnPlayerVsPlayer.BackColor = Color.DodgerBlue;
		btnPlayerVsPlayer.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
		btnPlayerVsPlayer.FlatAppearance.BorderSize = 0;
		btnPlayerVsPlayer.FlatStyle = FlatStyle.Flat;
		btnPlayerVsPlayer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
		btnPlayerVsPlayer.ForeColor = Color.White;
		btnPlayerVsPlayer.Location = new Point(266, 246);
		btnPlayerVsPlayer.Margin = new Padding(5, 5, 5, 5);
		btnPlayerVsPlayer.Name = "btnPlayerVsPlayer";
		btnPlayerVsPlayer.Size = new Size(176, 38);
		btnPlayerVsPlayer.TabIndex = 1;
		btnPlayerVsPlayer.Text = "Player vs Player";
		btnPlayerVsPlayer.UseVisualStyleBackColor = false;
		btnPlayerVsPlayer.Click += btnPlayerVsPlayer_Click;
		// 
		// btnPlayerVsAI
		// 
		btnPlayerVsAI.BackColor = Color.DodgerBlue;
		btnPlayerVsAI.Enabled = false;
		btnPlayerVsAI.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
		btnPlayerVsAI.FlatAppearance.BorderSize = 0;
		btnPlayerVsAI.FlatStyle = FlatStyle.Flat;
		btnPlayerVsAI.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
		btnPlayerVsAI.ForeColor = Color.White;
		btnPlayerVsAI.Location = new Point(266, 295);
		btnPlayerVsAI.Margin = new Padding(5, 5, 5, 5);
		btnPlayerVsAI.Name = "btnPlayerVsAI";
		btnPlayerVsAI.Size = new Size(176, 38);
		btnPlayerVsAI.TabIndex = 1;
		btnPlayerVsAI.Text = "Player vs AI";
		btnPlayerVsAI.UseVisualStyleBackColor = false;
		btnPlayerVsAI.Click += btnPlayerVsAI_Click;
		// 
		// btnAIVsAI
		// 
		btnAIVsAI.BackColor = Color.DodgerBlue;
		btnAIVsAI.Enabled = false;
		btnAIVsAI.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
		btnAIVsAI.FlatAppearance.BorderSize = 0;
		btnAIVsAI.FlatStyle = FlatStyle.Flat;
		btnAIVsAI.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
		btnAIVsAI.ForeColor = Color.White;
		btnAIVsAI.Location = new Point(266, 343);
		btnAIVsAI.Margin = new Padding(5, 5, 5, 5);
		btnAIVsAI.Name = "btnAIVsAI";
		btnAIVsAI.Size = new Size(176, 38);
		btnAIVsAI.TabIndex = 1;
		btnAIVsAI.Text = "AI vs AI";
		btnAIVsAI.UseVisualStyleBackColor = false;
		btnAIVsAI.Click += btnAIVsAI_Click;
		// 
		// btnJoinServer
		// 
		btnJoinServer.BackColor = Color.DodgerBlue;
		btnJoinServer.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
		btnJoinServer.FlatAppearance.BorderSize = 0;
		btnJoinServer.FlatStyle = FlatStyle.Flat;
		btnJoinServer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
		btnJoinServer.ForeColor = Color.White;
		btnJoinServer.Location = new Point(205, 459);
		btnJoinServer.Margin = new Padding(5, 5, 5, 5);
		btnJoinServer.Name = "btnJoinServer";
		btnJoinServer.Size = new Size(142, 38);
		btnJoinServer.TabIndex = 1;
		btnJoinServer.Text = "Join Server";
		btnJoinServer.UseVisualStyleBackColor = false;
		btnJoinServer.Click += btnJoinServer_Click;
		// 
		// btnHostServer
		// 
		btnHostServer.BackColor = Color.DodgerBlue;
		btnHostServer.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
		btnHostServer.FlatAppearance.BorderSize = 0;
		btnHostServer.FlatStyle = FlatStyle.Flat;
		btnHostServer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
		btnHostServer.ForeColor = Color.White;
		btnHostServer.Location = new Point(355, 459);
		btnHostServer.Margin = new Padding(5, 5, 5, 5);
		btnHostServer.Name = "btnHostServer";
		btnHostServer.Size = new Size(142, 38);
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
		pictureBox2.Location = new Point(547, 20);
		pictureBox2.Margin = new Padding(5, 5, 5, 5);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new Size(143, 166);
		pictureBox2.TabIndex = 0;
		pictureBox2.TabStop = false;
		// 
		// label1
		// 
		label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
		label1.Location = new Point(168, 20);
		label1.Margin = new Padding(5, 0, 5, 0);
		label1.Name = "label1";
		label1.Size = new Size(370, 166);
		label1.TabIndex = 2;
		label1.Text = "Chess";
		label1.TextAlign = ContentAlignment.MiddleCenter;
		// 
		// chess960Checkbox
		// 
		chess960Checkbox.AutoSize = true;
		chess960Checkbox.Location = new Point(26, 465);
		chess960Checkbox.Name = "chess960Checkbox";
		chess960Checkbox.Size = new Size(119, 29);
		chess960Checkbox.TabIndex = 3;
		chess960Checkbox.Text = "Chess 960";
		chess960Checkbox.UseVisualStyleBackColor = true;
		chess960Checkbox.CheckedChanged += checkBox1_CheckedChanged;
		// 
		// FormLauncher
		// 
		AutoScaleDimensions = new SizeF(10F, 25F);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.White;
		ClientSize = new Size(707, 525);
		Controls.Add(chess960Checkbox);
		Controls.Add(label1);
		Controls.Add(btnHostServer);
		Controls.Add(btnJoinServer);
		Controls.Add(btnAIVsAI);
		Controls.Add(btnPlayerVsAI);
		Controls.Add(btnPlayerVsPlayer);
		Controls.Add(pictureBox2);
		Controls.Add(pictureBox1);
		FormBorderStyle = FormBorderStyle.Fixed3D;
		Margin = new Padding(5, 5, 5, 5);
		MaximizeBox = false;
		Name = "FormLauncher";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Chess";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		ResumeLayout(false);
		PerformLayout();
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
	private CheckBox chess960Checkbox;
}