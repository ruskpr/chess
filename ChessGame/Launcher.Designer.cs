namespace ChessGame
{
    partial class Launcher
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRegUsername = new System.Windows.Forms.TextBox();
            this.tbRegPassword = new System.Windows.Forms.TextBox();
            this.tbLoginUsername = new System.Windows.Forms.TextBox();
            this.tbLoginPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Login";
            // 
            // tbRegUsername
            // 
            this.tbRegUsername.Location = new System.Drawing.Point(114, 110);
            this.tbRegUsername.Name = "tbRegUsername";
            this.tbRegUsername.PlaceholderText = "username";
            this.tbRegUsername.Size = new System.Drawing.Size(158, 23);
            this.tbRegUsername.TabIndex = 1;
            // 
            // tbRegPassword
            // 
            this.tbRegPassword.Location = new System.Drawing.Point(114, 152);
            this.tbRegPassword.Name = "tbRegPassword";
            this.tbRegPassword.PlaceholderText = "password";
            this.tbRegPassword.Size = new System.Drawing.Size(158, 23);
            this.tbRegPassword.TabIndex = 1;
            this.tbRegPassword.UseSystemPasswordChar = true;
            // 
            // tbLoginUsername
            // 
            this.tbLoginUsername.Location = new System.Drawing.Point(507, 110);
            this.tbLoginUsername.Name = "tbLoginUsername";
            this.tbLoginUsername.PlaceholderText = "username";
            this.tbLoginUsername.Size = new System.Drawing.Size(158, 23);
            this.tbLoginUsername.TabIndex = 1;
            // 
            // tbLoginPassword
            // 
            this.tbLoginPassword.Location = new System.Drawing.Point(507, 152);
            this.tbLoginPassword.Name = "tbLoginPassword";
            this.tbLoginPassword.PlaceholderText = "password";
            this.tbLoginPassword.Size = new System.Drawing.Size(158, 23);
            this.tbLoginPassword.TabIndex = 1;
            this.tbLoginPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(153, 193);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(550, 193);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 266);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.tbLoginPassword);
            this.Controls.Add(this.tbRegPassword);
            this.Controls.Add(this.tbLoginUsername);
            this.Controls.Add(this.tbRegUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbRegUsername;
        private TextBox tbRegPassword;
        private TextBox tbLoginUsername;
        private TextBox tbLoginPassword;
        private Button btnRegister;
        private Button btnLogin;
    }
}