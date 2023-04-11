namespace ChessGameSimple
{
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
            tbPort.Location = new Point(120, 70);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(100, 23);
            tbPort.TabIndex = 7;
            // 
            // tbIP
            // 
            tbIP.Location = new Point(120, 41);
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(100, 23);
            tbIP.TabIndex = 8;
            // 
            // btnJoin
            // 
            btnJoin.BackColor = Color.DimGray;
            btnJoin.FlatAppearance.BorderSize = 0;
            btnJoin.FlatStyle = FlatStyle.Flat;
            btnJoin.ForeColor = Color.White;
            btnJoin.Location = new Point(63, 108);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(139, 23);
            btnJoin.TabIndex = 6;
            btnJoin.Text = "Join Server";
            btnJoin.UseVisualStyleBackColor = false;
            btnJoin.Click += btnJoin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 73);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 4;
            label3.Text = "port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 44);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "IP address";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(120, 12);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(100, 23);
            tbUsername.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 16);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 9;
            label1.Text = "username";
            // 
            // FormJoinServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 156);
            Controls.Add(tbUsername);
            Controls.Add(label1);
            Controls.Add(tbPort);
            Controls.Add(tbIP);
            Controls.Add(btnJoin);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FormJoinServer";
            ShowIcon = false;
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
}