namespace ChessGame
{
    partial class TestForm
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
            this.lbTest4 = new System.Windows.Forms.Label();
            this.lbTest3 = new System.Windows.Forms.Label();
            this.lbTest2 = new System.Windows.Forms.Label();
            this.lbTest1 = new System.Windows.Forms.Label();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.btnP1 = new System.Windows.Forms.Button();
            this.btnP2 = new System.Windows.Forms.Button();
            this.cbPiece = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbTest4
            // 
            this.lbTest4.AutoSize = true;
            this.lbTest4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTest4.ForeColor = System.Drawing.Color.White;
            this.lbTest4.Location = new System.Drawing.Point(100, 284);
            this.lbTest4.Name = "lbTest4";
            this.lbTest4.Size = new System.Drawing.Size(68, 30);
            this.lbTest4.TabIndex = 5;
            this.lbTest4.Text = "label1";
            // 
            // lbTest3
            // 
            this.lbTest3.AutoSize = true;
            this.lbTest3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTest3.ForeColor = System.Drawing.Color.White;
            this.lbTest3.Location = new System.Drawing.Point(100, 230);
            this.lbTest3.Name = "lbTest3";
            this.lbTest3.Size = new System.Drawing.Size(68, 30);
            this.lbTest3.TabIndex = 6;
            this.lbTest3.Text = "label1";
            // 
            // lbTest2
            // 
            this.lbTest2.AutoSize = true;
            this.lbTest2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTest2.ForeColor = System.Drawing.Color.White;
            this.lbTest2.Location = new System.Drawing.Point(100, 176);
            this.lbTest2.Name = "lbTest2";
            this.lbTest2.Size = new System.Drawing.Size(68, 30);
            this.lbTest2.TabIndex = 7;
            this.lbTest2.Text = "label1";
            // 
            // lbTest1
            // 
            this.lbTest1.AutoSize = true;
            this.lbTest1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTest1.ForeColor = System.Drawing.Color.White;
            this.lbTest1.Location = new System.Drawing.Point(100, 129);
            this.lbTest1.Name = "lbTest1";
            this.lbTest1.Size = new System.Drawing.Size(68, 30);
            this.lbTest1.TabIndex = 8;
            this.lbTest1.Text = "label1";
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(93, 82);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(75, 23);
            this.btnTest1.TabIndex = 4;
            this.btnTest1.Text = "button1";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // btnP1
            // 
            this.btnP1.Location = new System.Drawing.Point(47, 414);
            this.btnP1.Name = "btnP1";
            this.btnP1.Size = new System.Drawing.Size(75, 23);
            this.btnP1.TabIndex = 9;
            this.btnP1.Text = "White";
            this.btnP1.UseVisualStyleBackColor = true;
            this.btnP1.Click += new System.EventHandler(this.btnP1_Click);
            // 
            // btnP2
            // 
            this.btnP2.Location = new System.Drawing.Point(161, 414);
            this.btnP2.Name = "btnP2";
            this.btnP2.Size = new System.Drawing.Size(75, 23);
            this.btnP2.TabIndex = 9;
            this.btnP2.Text = "Black";
            this.btnP2.UseVisualStyleBackColor = true;
            this.btnP2.Click += new System.EventHandler(this.btnP2_Click);
            // 
            // cbPiece
            // 
            this.cbPiece.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPiece.FormattingEnabled = true;
            this.cbPiece.Items.AddRange(new object[] {
            "pawn",
            "rook",
            "knight",
            "bishop",
            "queen",
            "king"});
            this.cbPiece.Location = new System.Drawing.Point(63, 373);
            this.cbPiece.Name = "cbPiece";
            this.cbPiece.Size = new System.Drawing.Size(159, 23);
            this.cbPiece.TabIndex = 10;
            this.cbPiece.SelectedIndexChanged += new System.EventHandler(this.cbPiece_SelectedIndexChanged);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1458, 918);
            this.Controls.Add(this.cbPiece);
            this.Controls.Add(this.btnP2);
            this.Controls.Add(this.btnP1);
            this.Controls.Add(this.lbTest4);
            this.Controls.Add(this.lbTest3);
            this.Controls.Add(this.lbTest2);
            this.Controls.Add(this.lbTest1);
            this.Controls.Add(this.btnTest1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbTest4;
        private Label lbTest3;
        private Label lbTest2;
        private Label lbTest1;
        private Button btnTest1;
        private Button btnP1;
        private Button btnP2;
        private ComboBox cbPiece;
    }
}