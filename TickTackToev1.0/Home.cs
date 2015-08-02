using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickTackToev1._0
{
    public partial class Home : MetroForm
    {
        private String playerName;
        private String otherPlayerName;
        private String plyerSymbol;
        private String serverOrClient;
        private Socket s;

        public Home()
        {
            InitializeComponent();
            serverOrClient = "single";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlayerOption playerOption = new PlayerOption(this);
            playerOption.Show();
        }

        public String PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }


        public String PlyerSymbol
        {
            get { return plyerSymbol; }
            set { plyerSymbol = value; }
        }

        public String ServerOrClient
        {
            get { return serverOrClient; }
            set { serverOrClient = value; }
        }

        public Socket S
        {
            get { return s; }
            set { s = value; }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {

            String mySymbol,otherPlayerSymbol;
            if (serverOrClient != "single")
            {
                if (plyerSymbol == "circle")
                {
                    mySymbol = "circle";
                    otherPlayerSymbol = "cross";
                }
                else
                {
                    mySymbol = "cross";
                    otherPlayerSymbol = "circle";
                }
                TickTackToe t = new TickTackToe(playerName, otherPlayerName, mySymbol, otherPlayerSymbol, serverOrClient, s);
                this.Hide();
                t.Show();
            }
            else {
                TickTackToe t = new TickTackToe(playerName, plyerSymbol);
                this.Hide();
                t.Show();
            }
            
        }

        public void getData()
        {
            if (serverOrClient == "Server")
            {
                string data = SynchronousSocketListener.getData(s);
                otherPlayerName = data.Substring(0,data.Length-4);

            }
            else
            {
                string data = SynchronousSocketClient.getData(s);
                otherPlayerName = data.Substring(0, data.Length - 4); 
            }
        }
    }
}
