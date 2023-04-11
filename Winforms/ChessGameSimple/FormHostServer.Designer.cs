namespace ChessGameSimple
{
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
            label2.Location = new Point(28, 31);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 0;
            label2.Text = "username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 60);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 0;
            label3.Text = "Server port";
            // 
            // btnStartAndJoin
            // 
            btnStartAndJoin.BackColor = Color.DimGray;
            btnStartAndJoin.FlatAppearance.BorderSize = 0;
            btnStartAndJoin.FlatStyle = FlatStyle.Flat;
            btnStartAndJoin.ForeColor = Color.White;
            btnStartAndJoin.Location = new Point(53, 101);
            btnStartAndJoin.Name = "btnStartAndJoin";
            btnStartAndJoin.Size = new Size(139, 23);
            btnStartAndJoin.TabIndex = 2;
            btnStartAndJoin.Text = "Start and Join Server";
            btnStartAndJoin.UseVisualStyleBackColor = false;
            btnStartAndJoin.Click += btnStartAndJoin_Click;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(115, 28);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(100, 23);
            tbUsername.TabIndex = 3;
            // 
            // tbPort
            // 
            tbPort.Location = new Point(115, 57);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(100, 23);
            tbPort.TabIndex = 3;
            // 
            // FormHostServer
            // 
            AcceptButton = btnStartAndJoin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 152);
            Controls.Add(tbPort);
            Controls.Add(tbUsername);
            Controls.Add(btnStartAndJoin);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormHostServer";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Host Chess Server";
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
}