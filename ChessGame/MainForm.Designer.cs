namespace ChessGame
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbTest1 = new System.Windows.Forms.Label();
            this.lbTest2 = new System.Windows.Forms.Label();
            this.lbTest3 = new System.Windows.Forms.Label();
            this.lbTest4 = new System.Windows.Forms.Label();
            this.lstMoves = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbTest1
            // 
            this.lbTest1.AutoSize = true;
            this.lbTest1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTest1.ForeColor = System.Drawing.Color.White;
            this.lbTest1.Location = new System.Drawing.Point(115, 115);
            this.lbTest1.Name = "lbTest1";
            this.lbTest1.Size = new System.Drawing.Size(68, 30);
            this.lbTest1.TabIndex = 3;
            this.lbTest1.Text = "label1";
            // 
            // lbTest2
            // 
            this.lbTest2.AutoSize = true;
            this.lbTest2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTest2.ForeColor = System.Drawing.Color.White;
            this.lbTest2.Location = new System.Drawing.Point(115, 162);
            this.lbTest2.Name = "lbTest2";
            this.lbTest2.Size = new System.Drawing.Size(68, 30);
            this.lbTest2.TabIndex = 3;
            this.lbTest2.Text = "label1";
            // 
            // lbTest3
            // 
            this.lbTest3.AutoSize = true;
            this.lbTest3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTest3.ForeColor = System.Drawing.Color.White;
            this.lbTest3.Location = new System.Drawing.Point(115, 216);
            this.lbTest3.Name = "lbTest3";
            this.lbTest3.Size = new System.Drawing.Size(68, 30);
            this.lbTest3.TabIndex = 3;
            this.lbTest3.Text = "label1";
            // 
            // lbTest4
            // 
            this.lbTest4.AutoSize = true;
            this.lbTest4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTest4.ForeColor = System.Drawing.Color.White;
            this.lbTest4.Location = new System.Drawing.Point(115, 270);
            this.lbTest4.Name = "lbTest4";
            this.lbTest4.Size = new System.Drawing.Size(68, 30);
            this.lbTest4.TabIndex = 3;
            this.lbTest4.Text = "label1";
            // 
            // lstMoves
            // 
            this.lstMoves.FormattingEnabled = true;
            this.lstMoves.ItemHeight = 15;
            this.lstMoves.Location = new System.Drawing.Point(39, 356);
            this.lstMoves.Name = "lstMoves";
            this.lstMoves.Size = new System.Drawing.Size(402, 319);
            this.lstMoves.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1458, 918);
            this.Controls.Add(this.lstMoves);
            this.Controls.Add(this.lbTest4);
            this.Controls.Add(this.lbTest3);
            this.Controls.Add(this.lbTest2);
            this.Controls.Add(this.lbTest1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lbTest1;
        private Label lbTest2;
        private Label lbTest3;
        private Label lbTest4;
        private ListBox lstMoves;
    }
}