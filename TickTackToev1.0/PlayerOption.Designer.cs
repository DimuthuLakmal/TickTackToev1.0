namespace TickTackToev1_0
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
            this.serverRadio = new MetroFramework.Controls.MetroRadioButton();
            this.clientRadio = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.singlePlayerCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.crossBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(38, 90);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(59, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Name";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(38, 167);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(73, 25);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Symbol";
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // playerName
            // 
            this.playerName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.playerName.Lines = new string[0];
            this.playerName.Location = new System.Drawing.Point(215, 90);
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
            this.crossBox.Location = new System.Drawing.Point(215, 145);
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
            this.roundBox.Location = new System.Drawing.Point(352, 145);
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
            this.metroButton1.Location = new System.Drawing.Point(38, 387);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(384, 38);
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "Save";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // serverRadio
            // 
            this.serverRadio.AutoSize = true;
            this.serverRadio.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.serverRadio.Location = new System.Drawing.Point(23, 18);
            this.serverRadio.Name = "serverRadio";
            this.serverRadio.Size = new System.Drawing.Size(61, 15);
            this.serverRadio.TabIndex = 7;
            this.serverRadio.Text = "Server";
            this.serverRadio.UseSelectable = true;
            this.serverRadio.CheckedChanged += new System.EventHandler(this.serverRadio_CheckedChanged);
            // 
            // clientRadio
            // 
            this.clientRadio.AutoSize = true;
            this.clientRadio.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.clientRadio.Location = new System.Drawing.Point(126, 18);
            this.clientRadio.Name = "clientRadio";
            this.clientRadio.Size = new System.Drawing.Size(55, 15);
            this.clientRadio.TabIndex = 8;
            this.clientRadio.Text = "Client";
            this.clientRadio.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clientRadio);
            this.groupBox1.Controls.Add(this.serverRadio);
            this.groupBox1.Location = new System.Drawing.Point(215, 306);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 46);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(38, 316);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(104, 25);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Multi Player";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(38, 270);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(112, 25);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Single Player";
            // 
            // singlePlayerCheck
            // 
            this.singlePlayerCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.singlePlayerCheck.AutoSize = true;
            this.singlePlayerCheck.Location = new System.Drawing.Point(217, 276);
            this.singlePlayerCheck.Name = "singlePlayerCheck";
            this.singlePlayerCheck.Size = new System.Drawing.Size(15, 14);
            this.singlePlayerCheck.TabIndex = 12;
            this.singlePlayerCheck.UseVisualStyleBackColor = true;
            this.singlePlayerCheck.CheckedChanged += new System.EventHandler(this.singlePlayerCheck_CheckedChanged);
            // 
            // PlayerOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 493);
            this.Controls.Add(this.singlePlayerCheck);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.roundBox);
            this.Controls.Add(this.crossBox);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "PlayerOption";
            this.Text = "Player Options";
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
        private MetroFramework.Controls.MetroRadioButton serverRadio;
        private MetroFramework.Controls.MetroRadioButton clientRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.CheckBox singlePlayerCheck;
    }
}