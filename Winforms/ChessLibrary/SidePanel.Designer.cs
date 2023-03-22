namespace ChessLibrary
{
    partial class SidePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstMoves = new System.Windows.Forms.ListBox();
            this.lbSelected = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.pbP2Pic = new System.Windows.Forms.PictureBox();
            this.lbP2Username = new System.Windows.Forms.Label();
            this.lbP2Rating = new System.Windows.Forms.Label();
            this.lbP1Username = new System.Windows.Forms.Label();
            this.lbP1Rating = new System.Windows.Forms.Label();
            this.pbP1Pic = new System.Windows.Forms.PictureBox();
            this.btnDeleteSave = new System.Windows.Forms.Button();
            this.pnlSelected = new System.Windows.Forms.Panel();
            this.pbSelected = new System.Windows.Forms.PictureBox();
            this.lbSelectedPos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbP2Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbP1Pic)).BeginInit();
            this.pnlSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMoves
            // 
            this.lstMoves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lstMoves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMoves.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstMoves.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstMoves.FormattingEnabled = true;
            this.lstMoves.ItemHeight = 20;
            this.lstMoves.Location = new System.Drawing.Point(0, 495);
            this.lstMoves.Name = "lstMoves";
            this.lstMoves.Size = new System.Drawing.Size(394, 140);
            this.lstMoves.TabIndex = 0;
            // 
            // lbSelected
            // 
            this.lbSelected.AutoSize = true;
            this.lbSelected.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbSelected.ForeColor = System.Drawing.Color.White;
            this.lbSelected.Location = new System.Drawing.Point(27, 18);
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.Size = new System.Drawing.Size(96, 30);
            this.lbSelected.TabIndex = 4;
            this.lbSelected.Text = "Selected:";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(251, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(143, 31);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pbP2Pic
            // 
            this.pbP2Pic.BackColor = System.Drawing.Color.Transparent;
            this.pbP2Pic.Location = new System.Drawing.Point(30, 117);
            this.pbP2Pic.Name = "pbP2Pic";
            this.pbP2Pic.Size = new System.Drawing.Size(50, 50);
            this.pbP2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbP2Pic.TabIndex = 6;
            this.pbP2Pic.TabStop = false;
            // 
            // lbP2Username
            // 
            this.lbP2Username.AutoSize = true;
            this.lbP2Username.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbP2Username.ForeColor = System.Drawing.Color.White;
            this.lbP2Username.Location = new System.Drawing.Point(86, 117);
            this.lbP2Username.Name = "lbP2Username";
            this.lbP2Username.Size = new System.Drawing.Size(86, 30);
            this.lbP2Username.TabIndex = 4;
            this.lbP2Username.Text = "Player 2";
            this.lbP2Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbP2Rating
            // 
            this.lbP2Rating.AutoSize = true;
            this.lbP2Rating.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbP2Rating.ForeColor = System.Drawing.Color.Gray;
            this.lbP2Rating.Location = new System.Drawing.Point(86, 150);
            this.lbP2Rating.Name = "lbP2Rating";
            this.lbP2Rating.Size = new System.Drawing.Size(42, 17);
            this.lbP2Rating.TabIndex = 4;
            this.lbP2Rating.Text = "rating";
            // 
            // lbP1Username
            // 
            this.lbP1Username.AutoSize = true;
            this.lbP1Username.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbP1Username.ForeColor = System.Drawing.Color.White;
            this.lbP1Username.Location = new System.Drawing.Point(86, 205);
            this.lbP1Username.Name = "lbP1Username";
            this.lbP1Username.Size = new System.Drawing.Size(86, 30);
            this.lbP1Username.TabIndex = 4;
            this.lbP1Username.Text = "Player 1";
            this.lbP1Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbP1Rating
            // 
            this.lbP1Rating.AutoSize = true;
            this.lbP1Rating.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbP1Rating.ForeColor = System.Drawing.Color.Gray;
            this.lbP1Rating.Location = new System.Drawing.Point(86, 238);
            this.lbP1Rating.Name = "lbP1Rating";
            this.lbP1Rating.Size = new System.Drawing.Size(42, 17);
            this.lbP1Rating.TabIndex = 4;
            this.lbP1Rating.Text = "rating";
            // 
            // pbP1Pic
            // 
            this.pbP1Pic.BackColor = System.Drawing.Color.Transparent;
            this.pbP1Pic.Location = new System.Drawing.Point(30, 205);
            this.pbP1Pic.Name = "pbP1Pic";
            this.pbP1Pic.Size = new System.Drawing.Size(50, 50);
            this.pbP1Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbP1Pic.TabIndex = 6;
            this.pbP1Pic.TabStop = false;
            // 
            // btnDeleteSave
            // 
            this.btnDeleteSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDeleteSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSave.FlatAppearance.BorderSize = 0;
            this.btnDeleteSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteSave.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSave.Location = new System.Drawing.Point(251, 37);
            this.btnDeleteSave.Name = "btnDeleteSave";
            this.btnDeleteSave.Size = new System.Drawing.Size(143, 31);
            this.btnDeleteSave.TabIndex = 5;
            this.btnDeleteSave.Text = "Delete Local Save ";
            this.btnDeleteSave.UseVisualStyleBackColor = false;
            this.btnDeleteSave.Click += new System.EventHandler(this.btnDeleteSave_Click);
            // 
            // pnlSelected
            // 
            this.pnlSelected.Controls.Add(this.pbSelected);
            this.pnlSelected.Controls.Add(this.lbSelectedPos);
            this.pnlSelected.Controls.Add(this.lbSelected);
            this.pnlSelected.Location = new System.Drawing.Point(3, 343);
            this.pnlSelected.Name = "pnlSelected";
            this.pnlSelected.Size = new System.Drawing.Size(378, 68);
            this.pnlSelected.TabIndex = 7;
            // 
            // pbSelected
            // 
            this.pbSelected.Location = new System.Drawing.Point(121, 4);
            this.pbSelected.Name = "pbSelected";
            this.pbSelected.Size = new System.Drawing.Size(50, 50);
            this.pbSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelected.TabIndex = 5;
            this.pbSelected.TabStop = false;
            // 
            // lbSelectedPos
            // 
            this.lbSelectedPos.AutoSize = true;
            this.lbSelectedPos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbSelectedPos.ForeColor = System.Drawing.Color.White;
            this.lbSelectedPos.Location = new System.Drawing.Point(176, 18);
            this.lbSelectedPos.Name = "lbSelectedPos";
            this.lbSelectedPos.Size = new System.Drawing.Size(100, 30);
            this.lbSelectedPos.TabIndex = 4;
            this.lbSelectedPos.Text = "at _______";
            // 
            // SidePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.pnlSelected);
            this.Controls.Add(this.pbP1Pic);
            this.Controls.Add(this.pbP2Pic);
            this.Controls.Add(this.btnDeleteSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lbP1Rating);
            this.Controls.Add(this.lbP1Username);
            this.Controls.Add(this.lbP2Rating);
            this.Controls.Add(this.lbP2Username);
            this.Controls.Add(this.lstMoves);
            this.Name = "SidePanel";
            this.Size = new System.Drawing.Size(394, 635);
            ((System.ComponentModel.ISupportInitialize)(this.pbP2Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbP1Pic)).EndInit();
            this.pnlSelected.ResumeLayout(false);
            this.pnlSelected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstMoves;
        private Label lbSelected;
        private Button btnReset;
        private PictureBox pbP2Pic;
        private Label lbP2Username;
        private Label lbP2Rating;
        private Label lbP1Username;
        private Label lbP1Rating;
        private PictureBox pbP1Pic;
        private Button btnDeleteSave;
        private Panel pnlSelected;
        private PictureBox pbSelected;
        private Label lbSelectedPos;
    }
}
