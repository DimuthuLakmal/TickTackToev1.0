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
        private Socket socket;
        private Thread t;
        private PictureBox[,] picBoxes;
        private bool playforFirstTime;
        private string singleOrMulti;

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
            Console.WriteLine("Name : " +player);
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
            singleOrMulti = "Multi";
            
        }

        public TickTackToe(String playerName, String playerSymbol)
        {
            InitializeComponent();
            board = new char[3][];
            for (int i = 0; i < 3; i++)
            {
                board[i] = new char[3];
            }
            initializeBoard();
            panel2.Visible = false;

            meLabel.Text = playerName;
            if (playerSymbol == "circle")
            {
                meBox.Image = Image.FromFile("circle_still.png");
                currentPlayerMark = 'x';
                mySymbol = 'x';
            }
            else
            {
                meBox.Image = Image.FromFile("cross_still.png");
                currentPlayerMark = 'o';
                mySymbol = 'o';
            }
            playerLabel.Text = "";
            singleOrMulti = "Single";
            
        }

        public void getData() {
            if (serverOrClient == "Server")
            {
                string rawData = SynchronousSocketListener.getData(socket);
                if (rawData == "We have a winner! Congrats!<EOF>" || rawData == "Appears we have a draw!<EOF>")
                {
                    Console.WriteLine(rawData);
                }
                else if(rawData!="<EOF>")
                {
                    string[] data = rawData.Substring(0, 3).Split(',');
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
            else
            {
                string rawData = SynchronousSocketClient.getData(socket);
                if (rawData == "We have a winner! Congrats!<EOF>" || rawData == "Appears we have a draw!<EOF>")
                {
                    Console.WriteLine(rawData);
                }
                else if (rawData != "<EOF>")
                {
                    string[] data = rawData.Substring(0, 3).Split(',');
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
            String finalResult = "";
            if (checkForWin())
            {
                 finalResult = "We have a winner! Congrats!";
                 Console.WriteLine("We have a winner! Congrats!");
                 //panel2.Visible = true;
            }
            else if (isBoardFull())
            {
                finalResult = "Appears we have a draw!";
                Console.WriteLine("Appears we have a draw!");
                //panel2.Visible = true;
            }

            if (serverOrClient == "Server")
            {
                SynchronousSocketListener.IsWantToSendData = true;
                SynchronousSocketListener.SendData(socket, finalResult);
                t = new Thread(getData);
                t.Start();
            }
            else
            {
                SynchronousSocketClient.IsWantToSendData = true;
                SynchronousSocketClient.sendData(socket, finalResult);
                t = new Thread(getData);
                t.Start();
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
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox1.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox1);
                    placeMark(2, 2);
                    checkWinner();
                }
            }
            else {
                makeMove(8);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox5.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox5);
                    placeMark(0, 0);
                    checkWinner();
                }
            }
            else
            {
                makeMove(0);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox4.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox4);
                    placeMark(0, 1);
                    checkWinner();
                }
            }
            else {
                makeMove(1);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox3.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox3);
                    placeMark(0, 2);
                    checkWinner();
                }
            }
            else {
                makeMove(2);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox7.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox7);
                    placeMark(1, 0);
                    checkWinner();
                }
            }
            else {
                makeMove(3);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox6.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox6);
                    placeMark(1, 1);
                    checkWinner();
                }
            }
            else {
                makeMove(4);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox2.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox2);
                    placeMark(1, 2);
                    checkWinner();
                }
            }
            else {
                makeMove(5);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox8.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox8);
                    placeMark(2, 0);
                    checkWinner();
                }
            }
            else {
                makeMove(6);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (singleOrMulti == "Multi")
            {
                if (currentPlayerMark == mySymbol && pictureBox9.Image == null)
                {
                    playforFirstTime = false;
                    setImage(pictureBox9);
                    placeMark(2, 1);
                    checkWinner();
                }
            }
            else {
                makeMove(7);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        //----------------------------------Single Player MiniMax Algorithm------------------------------------------------------

        //gameXO is the game
        static String[] gameXO = new String[9];
        //_sdepth is used to control the depth
        static int sdepth;

        public PictureBox getPictureBox(int i)
        {
            switch(i){
                case 0: return pictureBox5;
                case 1: return pictureBox4;
                case 2: return pictureBox3;
                case 3: return pictureBox7;
                case 4: return pictureBox6;
                case 5: return pictureBox2;
                case 6: return pictureBox8;
                case 7: return pictureBox9;
                case 8: return pictureBox1;
                default: return null;
            }
        }

        public int makeMove(int index)
        {	/*Step to do in this method
         *1- update gameXO. put X in the gameXO[index]
         *2- test if game is finished (draw or X win)
         *3- call MinMax algorithm and return the score and return the best position for O
         *4- update gameXO. put O in its position
         *5- test if game is finished (draw or O win)
         */
            //return -1 to know that player X wins
            //return -2 to know that the game is draw
            //1

            gameXO[index] = "X";
            //2
            if (gameOver(gameXO))
            {
                return -1;
            }
            if (drawGame(gameXO))
            {
                return -2;
            }

            //3
            ResultMM res = MinMax(gameXO, "MAX", 0, 0);
            int i = res.getIntrus();
            // code for show the image or whatever in the design
            setImage(getPictureBox(i));

            //4
            gameXO[i] = "O";

            //5
            // return i+20 to know that o wins (i used this method for programming issues)
            // retrun i-30 to know that the game is draw (i used this method for programming issues)
            if (gameOver(gameXO))
            {
                return i + 20;
            }
            if (drawGame(gameXO))
            {
                return i - 30;
            }

            return i;

        }

        public ResultMM MinMax(String[] demo, String level, int fils, int depth)
        {/*MinMax algorithm
         * 1- generate successor
         * 2- if no successor or game is finished return score 
         * 3- if there is successor
         * 	a) apply MinMax for each successor
         *	b) after recursive call, i return the good score
         */

            //1---------------

            List<String[]> children = genere_succ(demo, level);
            //2------------------
            if (children == null && sdepth != -1)
            {
                sdepth = -1;
                depth = depth + 1;
            }

            if (children == null || gameOver(demo))
            {
                return new ResultMM(demo, getScore(demo), depth);
            }
            else
            {//3------------------
                if (sdepth > children.Count())
                {
                    sdepth = children.Count();
                    depth = depth + 1;
                }

                List<ResultMM> listScore = new List<ResultMM>();
                //pass into each child
                for (int i = 0; i < children.Count(); i++)
                {//3 a)---------------
                    listScore.Add(MinMax(children.ElementAt(i), inverse(level), 1, depth + 1));
                }
                //3 b)----------------
                ResultMM res = getResult(listScore, level);
                if (fils == 1)
                {
                    res.updateMatrix(demo);
                }

                return res;
            }
        }

        public ResultMM getResult(List<ResultMM> listScore, String level)
        {//this method is used to get the appropriate score
            //if level is MAX, i search for the higher score in the nearer depth
            //if level is MIN, i search for the lowest score in the nearer depth
            ResultMM result = listScore.ElementAt(0);
            if (level.Equals("MAX"))
            {
                for (int i = 1; i < listScore.Count(); i++)
                {
                    if ((listScore.ElementAt(i).getScore() > result.getScore())
                            || (listScore.ElementAt(i).getScore() == result.getScore() && listScore.ElementAt(i).depth < result.depth))
                    {
                        result = listScore.ElementAt(i);
                    }
                }
            }
            else
            {
                for (int i = 1; i < listScore.Count(); i++)
                {
                    if ((listScore.ElementAt(i).getScore() < result.getScore())
                            || (listScore.ElementAt(i).getScore() == result.getScore() && listScore.ElementAt(i).depth < result.depth))
                    {
                        result = listScore.ElementAt(i);
                    }
                }
            }
            return result;
        }

        public List<String[]> genere_succ(String[] demo, String level)
        {//generate successor
            //if level is MAX, generate successor with o ( o in lowerCase)
            //if level is MIN, generate successor with x ( x in lowerCase)
            //if demo has no successor, return null
            List<String[]> succ = new List<String[]>();
            for (int i = 0; i < demo.Length; i++)
            {
                if (demo[i].Equals(" "))
                {
                    String[] child = new String[9];
                    for (int j = 0; j < 9; j++)
                    {
                        child[j] = demo[j];
                    }

                    if (level.Equals("MAX"))
                    {
                        child[i] = "o";
                    }
                    else
                    {
                        child[i] = "x";
                    }
                    succ.Add(child);
                }
            }
            return (succ.Count() == 0) ? null : succ;
        }

        public String inverse(String level)
        { //inverse level from MIN to MAX
            return (level.Equals("MIN")) ? "MAX" : "MIN";
        }

        public int getScore(String[] demo)
        { //return  the score:
            //if X win return -1;
            //if O win return 1;
            //else return 0, this mean draw
            if ((demo[0].Equals("x") && demo[1].Equals("x") && demo[2].Equals("x")) || (demo[3].Equals("x") && demo[4].Equals("x") && demo[5].Equals("x"))
                    || (demo[6].Equals("x") && demo[7].Equals("x") && demo[8].Equals("x")) || (demo[0].Equals("x") && demo[3].Equals("x") && demo[6].Equals("x"))
                    || (demo[1].Equals("x") && demo[4].Equals("x") && demo[7].Equals("x")) || (demo[2].Equals("x") && demo[5].Equals("x") && demo[8].Equals("x"))
                    || (demo[0].Equals("x") && demo[4].Equals("x") && demo[8].Equals("x")) || (demo[2].Equals("x") && demo[4].Equals("x") && demo[6].Equals("x")))
            {
                return -1;
            }

            if ((demo[0].Equals("o") && demo[1].Equals("o") && demo[2].Equals("o")) || (demo[3].Equals("o") && demo[4].Equals("o") && demo[5].Equals("o"))
                    || (demo[6].Equals("o") && demo[7].Equals("o") && demo[8].Equals("o")) || (demo[0].Equals("o") && demo[3].Equals("o") && demo[6].Equals("o"))
                    || (demo[1].Equals("o") && demo[4].Equals("o") && demo[7].Equals("o")) || (demo[2].Equals("o") && demo[5].Equals("o") && demo[8].Equals("o"))
                    || (demo[0].Equals("o") && demo[4].Equals("o") && demo[8].Equals("o")) || (demo[2].Equals("o") && demo[4].Equals("o") && demo[6].Equals("o")))
            {
                return 1;
            }

            return 0;
        }

        public bool gameOver(String[] demo)
        {//if the score of the game is 0 then return false. this mean we have a winner
            return (getScore(demo) != 0) ? true : false;
        }

        public bool drawGame(String[] demo)
        {
            //test if the game is draw.
            //if demo is full, this mean that game is draw
            //if demo still has empty square, this mean that the game isn't finished
            for (int i = 0; i < 9; i++)
            {
                if (demo[i].Equals(" "))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class ResultMM
    {
        public String[] matrix;
        public int score;
        public int depth;

        public ResultMM(String[] matrix, int score, int depth)
        {
            this.matrix = matrix;
            this.score = score;
            this.depth = depth;
        }

        public void updateMatrix(String[] matrix)
        {
            this.matrix = matrix;
        }

        public int getScore()
        {
            return score;
        }
        public int getIntrus()
        {
            for (int i = 0; i < 9; i++)
                if (matrix[i].Equals("o"))
                    return i;
            return -1;
        }
    }
}