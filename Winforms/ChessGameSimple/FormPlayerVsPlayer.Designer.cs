namespace ChessGameSimple
{
    partial class FormPlayerVsPlayer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbTurn = new Label();
            lbSelected = new Label();
            SuspendLayout();
            // 
            // lbTurn
            // 
            lbTurn.AutoSize = true;
            lbTurn.Location = new Point(665, 9);
            lbTurn.Name = "lbTurn";
            lbTurn.Size = new Size(68, 15);
            lbTurn.TabIndex = 0;
            lbTurn.Text = "Turn: White";
            // 
            // lbSelected
            // 
            lbSelected.AutoSize = true;
            lbSelected.Location = new Point(665, 50);
            lbSelected.Name = "lbSelected";
            lbSelected.Size = new Size(54, 15);
            lbSelected.TabIndex = 0;
            lbSelected.Text = "Selected:";
            // 
            // FormLocalGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 708);
            Controls.Add(lbSelected);
            Controls.Add(lbTurn);
            Name = "FormLocalGame";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTurn;
        private Label lbSelected;
    }
}