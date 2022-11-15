namespace ChessLibrary
{
    partial class LeftPanel
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
            this.lbTurn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstMoves
            // 
            this.lstMoves.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstMoves.FormattingEnabled = true;
            this.lstMoves.ItemHeight = 25;
            this.lstMoves.Location = new System.Drawing.Point(0, 375);
            this.lstMoves.Name = "lstMoves";
            this.lstMoves.Size = new System.Drawing.Size(391, 254);
            this.lstMoves.TabIndex = 0;
            // 
            // lbSelected
            // 
            this.lbSelected.AutoSize = true;
            this.lbSelected.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbSelected.ForeColor = System.Drawing.Color.Black;
            this.lbSelected.Location = new System.Drawing.Point(17, 40);
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.Size = new System.Drawing.Size(96, 30);
            this.lbSelected.TabIndex = 4;
            this.lbSelected.Text = "Selected:";
            // 
            // lbTurn
            // 
            this.lbTurn.AutoSize = true;
            this.lbTurn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTurn.ForeColor = System.Drawing.Color.Black;
            this.lbTurn.Location = new System.Drawing.Point(17, 82);
            this.lbTurn.Name = "lbTurn";
            this.lbTurn.Size = new System.Drawing.Size(60, 30);
            this.lbTurn.TabIndex = 4;
            this.lbTurn.Text = "Turn:";
            // 
            // LeftPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.Controls.Add(this.lbTurn);
            this.Controls.Add(this.lbSelected);
            this.Controls.Add(this.lstMoves);
            this.Name = "LeftPanel";
            this.Size = new System.Drawing.Size(394, 635);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstMoves;
        private Label lbSelected;
        private Label lbTurn;
    }
}
