namespace ChessClient;

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
        lbTurn.ForeColor = Color.Black;
        lbTurn.Location = new Point(1279, 33);
        lbTurn.Margin = new Padding(6, 0, 6, 0);
        lbTurn.Name = "lbTurn";
        lbTurn.Size = new Size(138, 32);
        lbTurn.TabIndex = 0;
        lbTurn.Text = "Turn: White";
        // 
        // btnUndo
        // 
        btnUndo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnUndo.BackColor = Color.DodgerBlue;
        btnUndo.FlatAppearance.BorderSize = 0;
        btnUndo.FlatStyle = FlatStyle.Flat;
        btnUndo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnUndo.ForeColor = Color.White;
        btnUndo.Location = new Point(1278, 87);
        btnUndo.Margin = new Padding(6);
        btnUndo.Name = "btnUndo";
        btnUndo.Size = new Size(139, 49);
        btnUndo.TabIndex = 1;
        btnUndo.Text = "Undo";
        btnUndo.UseVisualStyleBackColor = false;
        btnUndo.Click += btnUndo_Click;
        // 
        // panel1
        // 
        panel1.Location = new Point(22, 19);
        panel1.Margin = new Padding(6);
        panel1.Name = "panel1";
        panel1.Size = new Size(1207, 1387);
        panel1.TabIndex = 2;
        // 
        // btnReset
        // 
        btnReset.BackColor = Color.DodgerBlue;
        btnReset.FlatAppearance.BorderSize = 0;
        btnReset.FlatStyle = FlatStyle.Flat;
        btnReset.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
        btnReset.ForeColor = Color.White;
        btnReset.Location = new Point(1278, 149);
        btnReset.Margin = new Padding(6);
        btnReset.Name = "btnReset";
        btnReset.Size = new Size(139, 49);
        btnReset.TabIndex = 3;
        btnReset.Text = "Reset";
        btnReset.UseVisualStyleBackColor = false;
        btnReset.Click += btnReset_Click;
        // 
        // FormPlayerVsPlayer
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1462, 1510);
        Controls.Add(btnReset);
        Controls.Add(panel1);
        Controls.Add(btnUndo);
        Controls.Add(lbTurn);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Margin = new Padding(6);
        MaximizeBox = false;
        Name = "FormPlayerVsPlayer";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Chess";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lbTurn;
    private Button btnUndo;
    private Panel panel1;
    private Button btnReset;
}