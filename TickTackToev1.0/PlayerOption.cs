using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickTackToev1._0
{
    
    public partial class PlayerOption : MetroForm
    {
        private bool isCrossSelected;
        private bool isRoundSelected;
        private Home home;
        
        public PlayerOption(Home home)
        {
            this.home = home;
            InitializeComponent();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }



        private void crossBox_Click(object sender, EventArgs e)
        {
            if (isCrossSelected)
            {
                crossBox.Image = Image.FromFile("cross_still.png");
                isCrossSelected = false;
            }
            else {
                roundBox.Image = Image.FromFile("circle_still.png");
                crossBox.Image = Image.FromFile("cross_still_blue.png");
                isCrossSelected = true;
                isRoundSelected = false;
            }
            
        }

        private void roundBox_Click(object sender, EventArgs e)
        {
            if (isRoundSelected)
            {
                roundBox.Image = Image.FromFile("circle_still.png");
                isRoundSelected = false;
            }
            else
            {
                crossBox.Image = Image.FromFile("cross_still.png");
                roundBox.Image = Image.FromFile("circle_still_blue.png");
                isCrossSelected = false;
                isRoundSelected = true;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!singlePlayerCheck.Checked)
            {
                var buttons = groupBox1.Controls.OfType<RadioButton>()
                                          .FirstOrDefault(r => r.Checked);
                home.ServerOrClient = buttons.Text.ToString();
                home.PlayerName = playerName.Text.ToString();
                if (isRoundSelected)
                {
                    home.PlyerSymbol = "circle";
                }
                if (isCrossSelected)
                {
                    home.PlyerSymbol = "cross";
                }
                Thread t = new Thread(startServices);
                t.Start();
            }
            else {
                home.PlayerName = playerName.Text.ToString();
                if (isRoundSelected)
                {
                    home.PlyerSymbol = "circle";
                }
                if (isCrossSelected)
                {
                    home.PlyerSymbol = "cross";
                }
            }
            this.Close();
            home.Show();
        }

        public void startServices() {

            if (home.ServerOrClient == "Server")
            {
                home.S = SynchronousSocketListener.StartListening();
                Thread t = new Thread(home.getData);
                t.Start();
                SynchronousSocketListener.SendData(home.S, playerName.Text.ToString());
                
            }
            else
            {
                home.S = SynchronousSocketClient.StartClient();
                Thread t = new Thread(home.getData);
                t.Start();
                SynchronousSocketClient.sendData(home.S, playerName.Text.ToString());
            }
            
        }

        private void singlePlayerCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (singlePlayerCheck.Checked)
            {
                groupBox1.Enabled = false;
            }
            else {
                groupBox1.Enabled = true;
            }
        }

        private void serverRadio_CheckedChanged(object sender, EventArgs e)
        {
            
        }


    }
}
