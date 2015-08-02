namespace TickTackToev1._0
{
    partial class PlayerOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerOption));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.playerName = new MetroFramework.Controls.MetroTextBox();
            this.crossBox = new System.Windows.Forms.PictureBox();
            this.roundBox = new System.Windows.Forms.PictureBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.crossBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(85, 122);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(58, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Name";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(85, 177);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(68, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Symbol";
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // playerName
            // 
            this.playerName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.playerName.Lines = new string[0];
            this.playerName.Location = new System.Drawing.Point(220, 122);
            this.playerName.MaxLength = 32767;
            this.playerName.Name = "playerName";
            this.playerName.PasswordChar = '\0';
            this.playerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.playerName.SelectedText = "";
            this.playerName.Size = new System.Drawing.Size(213, 23);
            this.playerName.TabIndex = 3;
            this.playerName.UseSelectable = true;
            // 
            // crossBox
            // 
            this.crossBox.Image = ((System.Drawing.Image)(resources.GetObject("crossBox.Image")));
            this.crossBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("crossBox.InitialImage")));
            this.crossBox.Location = new System.Drawing.Point(220, 177);
            this.crossBox.Name = "crossBox";
            this.crossBox.Size = new System.Drawing.Size(71, 74);
            this.crossBox.TabIndex = 4;
            this.crossBox.TabStop = false;
            this.crossBox.Click += new System.EventHandler(this.crossBox_Click);
            // 
            // roundBox
            // 
            this.roundBox.Image = ((System.Drawing.Image)(resources.GetObject("roundBox.Image")));
            this.roundBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("roundBox.InitialImage")));
            this.roundBox.Location = new System.Drawing.Point(357, 177);
            this.roundBox.Name = "roundBox";
            this.roundBox.Size = new System.Drawing.Size(76, 74);
            this.roundBox.TabIndex = 5;
            this.roundBox.TabStop = false;
            this.roundBox.Click += new System.EventHandler(this.roundBox_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(163, 353);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(201, 38);
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "Save";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroRadioButton1.Location = new System.Drawing.Point(15, 15);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(63, 19);
            this.metroRadioButton1.TabIndex = 7;
            this.metroRadioButton1.Text = "Server";
            this.metroRadioButton1.UseSelectable = true;
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Location = new System.Drawing.Point(159, 19);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(54, 15);
            this.metroRadioButton2.TabIndex = 8;
            this.metroRadioButton2.Text = "Client";
            this.metroRadioButton2.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroRadioButton2);
            this.groupBox1.Controls.Add(this.metroRadioButton1);
            this.groupBox1.Location = new System.Drawing.Point(220, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 46);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // PlayerOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.roundBox);
            this.Controls.Add(this.crossBox);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "PlayerOption";
            this.Text = "PlayerOption";
            ((System.ComponentModel.ISupportInitialize)(this.crossBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox playerName;
        private System.Windows.Forms.PictureBox crossBox;
        private System.Windows.Forms.PictureBox roundBox;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}