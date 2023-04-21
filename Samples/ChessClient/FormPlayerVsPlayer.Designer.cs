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
            btnUndo = new Button();
            panel1 = new Panel();
            btnReset = new Button();
            SuspendLayout();
            // 
            // lbTurn
            // 
            lbTurn.AutoSize = true;
            lbTurn.Location = new Point(691, 13);
            lbTurn.Name = "lbTurn";
            lbTurn.Size = new Size(68, 15);
            lbTurn.TabIndex = 0;
            lbTurn.Text = "Turn: White";
            // 
            // btnUndo
            // 
            btnUndo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUndo.Location = new Point(688, 41);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(75, 23);
            btnUndo.TabIndex = 1;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(650, 650);
            panel1.TabIndex = 2;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(688, 70);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // FormPlayerVsPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 708);
            Controls.Add(btnReset);
            Controls.Add(panel1);
            Controls.Add(btnUndo);
            Controls.Add(lbTurn);
            Name = "FormPlayerVsPlayer";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTurn;
        private Button btnUndo;
        private Panel panel1;
        private Button btnReset;
    }
}