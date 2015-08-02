namespace TickTackToev1_0
{
    partial class Home
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
            this.highScore = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // highScore
            // 
            this.highScore.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.highScore.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.highScore.Location = new System.Drawing.Point(58, 129);
            this.highScore.Name = "highScore";
            this.highScore.Size = new System.Drawing.Size(137, 53);
            this.highScore.TabIndex = 0;
            this.highScore.Text = "High Scores";
            this.highScore.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.highScore.UseSelectable = true;
            this.highScore.Click += new System.EventHandler(this.highScore_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(310, 129);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(137, 55);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Player Options";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Enabled = false;
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(559, 129);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(137, 55);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "Play";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TickTackToev1_0.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(755, 253);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.highScore);
            this.Name = "Home";
            this.Text = "TicTacToe v1.0";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton highScore;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}