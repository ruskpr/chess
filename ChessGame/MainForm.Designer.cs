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
            this.pnlMiddleContent = new System.Windows.Forms.Panel();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlMiddleContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMiddleContent
            // 
            this.pnlMiddleContent.BackColor = System.Drawing.Color.White;
            this.pnlMiddleContent.Controls.Add(this.pnlBoard);
            this.pnlMiddleContent.Location = new System.Drawing.Point(324, 12);
            this.pnlMiddleContent.Name = "pnlMiddleContent";
            this.pnlMiddleContent.Size = new System.Drawing.Size(850, 850);
            this.pnlMiddleContent.TabIndex = 1;
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlBoard.Location = new System.Drawing.Point(16, 15);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(800, 800);
            this.pnlBoard.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1458, 918);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlMiddleContent);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMiddleContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnlMiddleContent;
        private Panel pnlBoard;
        private Button button1;
    }
}