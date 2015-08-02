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
    public partial class TickTackToe : MetroForm
    {
        private char[][] board;
        private char currentPlayerMark;
        private char mySymbol;
        private string serverOrClient;
        Socket socket;
        Thread t;
        PictureBox[,] picBoxes;
        private bool playforFirstTime;
        public TickTackToe(String me,String player,String meSymbol,String playerSymbol,string serverOrClient,Socket s)
        {
            InitializeComponent();
            board = new char[3][];
            for (int i = 0; i < 3; i++) {
                board[i] = new char[3];
            }
            initializeBoard();
            panel2.Visible = false;

            playerLabel.Text = player;
            if (playerSymbol == "circle")
            {
                playerBox.Image = Image.FromFile("circle_still.png");
                currentPlayerMark = 'x';
                mySymbol = 'x';
            }
            else {
                playerBox.Image = Image.FromFile("cross_still.png");
                currentPlayerMark = 'o';
                mySymbol = 'o';
            }
            meLabel.Text = me;
            if (meSymbol == "circle")
            {
                meBox.Image = Image.FromFile("circle_still.png");
            }
            else
            {
                meBox.Image = Image.FromFile("cross_still.png");
            }

            this.socket = s;
            this.serverOrClient = serverOrClient;

            t = new Thread(getData);
            t.Start();

            picBoxes = new PictureBox[3, 3]{ { pictureBox5, pictureBox4, pictureBox3 }, { pictureBox7, pictureBox6, pictureBox2 }, { pictureBox8, pictureBox9, pictureBox1 }};

            playforFirstTime = true;
            
        }

        public void getData() {
            if (serverOrClient == "Server")
            {
                string[] data = SynchronousSocketListener.getData(socket).Substring(0,3).Split(',');
                if (mySymbol == 'x')
                {
                    picBoxes[Int32.Parse(data[0]), Int32.Parse(data[1])].Image = Image.FromFile("round_1.gif");
                }
                else {
                    picBoxes[Int32.Parse(data[0]), Int32.Parse(data[1])].Image = Image.FromFile("cross_1.gif");
                }
                placeMarkRemote(Int32.Parse(data[0]), Int32.Parse(data[1]));
                checkWinner();
            }
            else
            {
                string[] data = SynchronousSocketClient.getData(socket).Substring(0, 3).Split(',');
                if (mySymbol == 'x')
                {
                    picBoxes[Int32.Parse(data[0]), Int32.Parse(data[1])].Image = Image.FromFile("round_1.gif");
                }
                else
                {
                    picBoxes[Int32.Parse(data[0]), Int32.Parse(data[1])].Image = Image.FromFile("cross_1.gif");
                }
                placeMarkRemote(Int32.Parse(data[0]), Int32.Parse(data[1]));
                checkWinner();
            }
        }

        // Set/Reset the board back to all empty values.
        public void initializeBoard()
        {

            // Loop through rows
            for (int i = 0; i < 3; i++)
            {

                // Loop through columns
                for (int j = 0; j < 3; j++)
                {
                    board[i][j] = '-';
                }
            }
        }

        // Print the current board (may be replaced by GUI implementation later)
        public void printBoard() {
        Console.WriteLine("-------------");

            for (int i = 0; i < 3; i++) {
                Console.WriteLine("| ");
                for (int j = 0; j < 3; j++) {
                   Console.WriteLine(board[i][j] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        // Loop through all cells of the board and if one is found to be empty (contains char '-') then return false.
        // Otherwise the board is full.
        public bool isBoardFull()
        {
            bool isFull = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == '-')
                    {
                        isFull = false;
                    }
                }
            }

            return isFull;
        }

        // Returns true if there is a win, false otherwise.
        // This calls our other win check functions to check the entire board.
        public bool checkForWin()
        {
            return (checkRowsForWin() || checkColumnsForWin() || checkDiagonalsForWin());
        }

        // Loop through rows and see if any are winners.
        private bool checkRowsForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (checkRowCol(board[i][0], board[i][1], board[i][2]) == true)
                {
                    return true;
                }
            }
            return false;
        }

        // Loop through columns and see if any are winners.
        private bool checkColumnsForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (checkRowCol(board[0][i], board[1][i], board[2][i]) == true)
                {
                    return true;
                }
            }
            return false;
        }

        // Check the two diagonals to see if either is a win. Return true if either wins.
        private bool checkDiagonalsForWin()
        {
            return ((checkRowCol(board[0][0], board[1][1], board[2][2]) == true) || (checkRowCol(board[0][2], board[1][1], board[2][0]) == true));
        }

        // Check to see if all three values are the same (and not empty) indicating a win.
        private bool checkRowCol(char c1, char c2, char c3)
        {
            return ((c1 != '-') && (c1 == c2) && (c2 == c3));
        }

        // Change player marks back and forth.
        public void changePlayer()
        {
            if (!playforFirstTime)
            {
                if (currentPlayerMark == 'x')
                {
                    currentPlayerMark = 'o';
                }
                else
                {
                    currentPlayerMark = 'x';
                }
            }
        }

        // Places a mark at the cell specified by row and col with the mark of the current player.
        public bool placeMark(int row, int col)
        {

            // Make sure that row and column are in bounds of the board.
            if ((row >= 0) && (row < 3))
            {
                if ((col >= 0) && (col < 3))
                {
                    if (board[row][col] == '-')
                    {
                        board[row][col] = currentPlayerMark;
                        if (serverOrClient == "Server")
                        {
                            SynchronousSocketListener.IsWantToSendData = true;
                            SynchronousSocketListener.SendData(socket, row.ToString() + "," + col.ToString());
                            t = new Thread(getData);
                            t.Start();
                        }
                        else
                        {
                            SynchronousSocketClient.IsWantToSendData = true;
                            SynchronousSocketClient.sendData(socket, row.ToString() + "," + col.ToString());
                            t = new Thread(getData);
                            t.Start();
                        }
                        return true;
                    }
                }
            }

           

            return false;
        }

        public bool placeMarkRemote(int row, int col)
        {

            // Make sure that row and column are in bounds of the board.
            if ((row >= 0) && (row < 3))
            {
                if ((col >= 0) && (col < 3))
                {
                    if (board[row][col] == '-')
                    {
                        board[row][col] = currentPlayerMark;
                        return true;
                    }
                }
            }

            return false;
        }

        public void checkWinner()
        {
            if (checkForWin())
            {
                 Console.WriteLine("We have a winner! Congrats!");
                 panel2.Visible = true;
            }
            else if (isBoardFull())
            {
                Console.WriteLine("Appears we have a draw!");
                panel2.Visible = true;
            }
            
            changePlayer();
        }

        public void setImage(PictureBox pb) {
        if (currentPlayerMark == 'x') {
            Image img = Image.FromFile("cross_1.gif");
            pb.Image = img;
            

        } else if (currentPlayerMark == 'o') {
            Image img = Image.FromFile("round_1.gif");
            pb.Image = img;
        }
    }
            
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox1.Image==null) {
                playforFirstTime = false;
                setImage(pictureBox1);
                placeMark(2, 2);
                checkWinner();
            }
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox5.Image == null)
            {
                playforFirstTime = false;
                setImage(pictureBox5);
                placeMark(0, 0);
                checkWinner();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox4.Image == null)
            {
                playforFirstTime = false;
                setImage(pictureBox4);
                placeMark(0, 1);
                checkWinner();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox3.Image == null)
            {
                playforFirstTime = false;
                setImage(pictureBox3);
                placeMark(0, 2);
                checkWinner();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox7.Image == null)
            {
                playforFirstTime = false;
                setImage(pictureBox7);
                placeMark(1, 0);
                checkWinner();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox6.Image == null)
            {
                playforFirstTime = false;
                setImage(pictureBox6);
                placeMark(1, 1);
                checkWinner();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox2.Image == null)
            {
                playforFirstTime = false;
                setImage(pictureBox2);
                placeMark(1, 2);
                checkWinner();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox8.Image == null)
            {
                playforFirstTime = false;
                setImage(pictureBox8);
                placeMark(2, 0);
                checkWinner();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (currentPlayerMark == mySymbol && pictureBox9.Image == null)
            {
                playforFirstTime = false;
                setImage(pictureBox9);
                placeMark(2, 1);
                checkWinner();
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        

    }
}
