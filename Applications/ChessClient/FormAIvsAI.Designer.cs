namespace ChessClient;

partial class FormAIvsAI
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
        btnStart = new Button();
        SuspendLayout();
        // 
        // btnStart
        // 
        btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnStart.Location = new Point(1339, 26);
        btnStart.Margin = new Padding(6, 6, 6, 6);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(139, 49);
        btnStart.TabIndex = 0;
        btnStart.Text = "Start";
        btnStart.UseVisualStyleBackColor = true;
        btnStart.Click += btnStart_Click;
        // 
        // FormAIvsAI
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(37, 37, 37);
        ClientSize = new Size(1501, 1412);
        Controls.Add(btnStart);
        Margin = new Padding(6, 6, 6, 6);
        Name = "FormAIvsAI";
        Text = "Chess";
        ResumeLayout(false);
    }

    #endregion

    private Button btnStart;
}