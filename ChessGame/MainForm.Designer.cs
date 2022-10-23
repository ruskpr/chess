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
            this.button1 = new System.Windows.Forms.Button();
            this.lbTest1 = new System.Windows.Forms.Label();
            this.lbTest2 = new System.Windows.Forms.Label();
            this.lbTest3 = new System.Windows.Forms.Label();
            this.lbTest4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1458, 918);
            this.Controls.Add(this.lbTest4);
            this.Controls.Add(this.lbTest3);
            this.Controls.Add(this.lbTest2);
            this.Controls.Add(this.lbTest1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button1;
        private Label lbTest1;
        private Label lbTest2;
        private Label lbTest3;
        private Label lbTest4;
    }
}