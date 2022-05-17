using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        int sent = 0;
        int[,] gameBoard = new int[4,4];
        int[,] bac = new int[4, 4];
        Label[,] labels = new Label[4,4];

        int startUp = 0;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            if (startUp == 0)
            {
                initializeGame();
                startUp = 1;
            }

            drawGrid();
        }

        public void initializeGame() {
            labels[0, 0] = this.label1;
            labels[0, 1] = this.label2;
            labels[0, 2] = this.label3;
            labels[0, 3] = this.label4;
            labels[1, 0] = this.label5;
            labels[1, 1] = this.label6;
            labels[1, 2] = this.label7;
            labels[1, 3] = this.label8;
            labels[2, 0] = this.label9;
            labels[2, 1] = this.label10;
            labels[2, 2] = this.label11;
            labels[2, 3] = this.label12;
            labels[3, 0] = this.label13;
            labels[3, 1] = this.label14;
            labels[3, 2] = this.label15;
            labels[3, 3] = this.label16;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    gameBoard[i, j] = 0;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    labels[i, j].Text = gameBoard[i, j].ToString();
            Random rnd = new Random();
            
            //To test Game
           // gameBoard[1, 2] = 2;
           // gameBoard[1, 3] = 8;
          //  gameBoard[3, 3] = 16;
           // gameBoard[0, 0] = 64;
            //gameBoard[3, 0] = 256;
            //gameBoard[3, 1] = 256;
           // gameBoard[3, 2] = 512;
            //gameBoard[3, 3] = 1024;
            
           
            gameBoard[rnd.Next(0,4), rnd.Next(0,4)] = 2; 
            gameBoard[rnd.Next(0,4), rnd.Next(0,4)] = 2;

        }

        public void drawGrid() {

            this.txtScore.Text = "Score: " + score;
       
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++) {
                    if (gameBoard[i, j] < 1)
                    {
                        labels[i, j].Text = "";
                        labels[i, j].BackColor = Color.White;
                    }
                    else if (gameBoard[i, j] <= 4)
                    {
                        labels[i,j].Text = gameBoard[i, j].ToString();
                        labels[i, j].BackColor = Color.Azure;

                    }
                    else if (gameBoard[i, j] <= 16)
                    {
                        labels[i, j].Text = gameBoard[i, j].ToString();
                        labels[i, j].BackColor = Color.Beige;

                    }
                    else if (gameBoard[i, j] <= 64)
                    {
                        labels[i, j].Text = gameBoard[i, j].ToString();
                        labels[i, j].BackColor = Color.AliceBlue;

                    }
                    else if (gameBoard[i, j] <= 256)
                    {
                        labels[i, j].Text = gameBoard[i, j].ToString();
                        labels[i, j].BackColor = Color.BlanchedAlmond;

                    }
                    else if (gameBoard[i, j] <= 512)
                    {
                        labels[i, j].Text = gameBoard[i, j].ToString();
                        labels[i, j].BackColor = Color.Coral;

                    }
                    else if (gameBoard[i, j] <= 1024)
                    {
                        labels[i, j].Text = gameBoard[i, j].ToString();
                        labels[i, j].BackColor = Color.Crimson;

                    }
                    else if (gameBoard[i, j] >= 2048)
                    {
                        labels[i, j].Text = gameBoard[i, j].ToString();
                        labels[i, j].BackColor = Color.Fuchsia;

                    }

                }


            if (canMove() == false)
                MessageBox.Show("Game over press the reset button to reset!");


            
            if (winner() && sent == 0) {
                MessageBox.Show("You Won! But you can keep playing!");
                sent = 1;
            }
                


        }

        public bool winner() {
            for (int i = 0; i < 4; i++)
                for (int a = 0; a < 4; a++)
                    if (gameBoard[i, a] == 2048)
                        return true;
            return false;        


        }
        public int canSpawn() {
            int n = 0;
            
            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 4; a++)
                {
                    if (gameBoard[i, a] != bac[i, a] && n == 0)
                        n = 1;
                   
                }
            }
            return n;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            for (int z = 0; z < 4; z++)
                for (int x = 0; x < 4; x++)
                    bac[z, x] = gameBoard[z, x];
            if (keyData == Keys.Left)
            {
                moveLeft();
                if(canSpawn() ==1)
                    spawn();
                drawGrid();
                
                return true;
            }
            if (keyData == Keys.Right)
            {
                moveRight();
                if (canSpawn() == 1)
                    spawn();
                drawGrid();
                return true;
            }
            if (keyData == Keys.Up)
            {
                moveUp();
                if (canSpawn() == 1)
                    spawn();
                drawGrid();
                return true;
            }
            if (keyData == Keys.Down)
            {
                moveDown();
                if (canSpawn() == 1)
                    spawn();
                drawGrid();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void spawn()
        { // spawns new value in random empty locations
            Random rnd = new Random();
            int t = rnd.Next(0, 4);
            int t1 = rnd.Next(0, 4);
            while (gameBoard[t, t1] != 0)
            {
                t = rnd.Next(0, 4);
                t1 = rnd.Next(0, 4);
            }
            int val = rnd.Next(0, 10) < 9 ? 2 : 4;
            gameBoard[t, t1] = val;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void resetGame() {
            for (int z = 0; z < 4; z++)
                for (int x = 0; x < 4; x++)
                    gameBoard[z, x] = 0;

            score = 0;
            Random rnd = new Random();
            gameBoard[rnd.Next(0, 4), rnd.Next(0, 4)] = 2;
            gameBoard[rnd.Next(0, 4), rnd.Next(0, 4)] = 2;

        }

        public void moveLeft() {
            //Nested for loop position helper
            int jr = 0;
            //Check if cells have been touched
            int c2 = 0;
            int c3 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (jr == 1 && gameBoard[i,jr - 1] == gameBoard[i,jr] && gameBoard[i,jr] != 0)
                    { //merge 2-3
                        gameBoard[i,jr - 1] += gameBoard[i,jr];
                        score += gameBoard[i,jr - 1];
                        gameBoard[i,jr] = 0;
                        c3 = 1;
                    }
                    else if (jr == 1 && gameBoard[i,jr - 1] == 0)
                    {// move if empty
                        gameBoard[i,jr - 1] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 2 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == 0)
                    { // move if spot 3 if empty
                        gameBoard[i,jr - 2] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 2 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == gameBoard[i,jr] && c3 == 0)
                    { // merge spot 1-3 if same
                        gameBoard[i,jr - 2] += gameBoard[i,jr];
                        score += gameBoard[i,jr - 2];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 2 && gameBoard[i,jr - 1] == gameBoard[i,jr] && gameBoard[i,jr] != 0)
                    {// merge 1-2
                        gameBoard[i,jr - 1] += gameBoard[i,jr];
                        score += gameBoard[i,jr - 1];
                        gameBoard[i,jr] = 0;
                        c2 = 1;
                    }
                    else if (jr == 2 && gameBoard[i,jr - 1] == 0)
                    {// move 1-2
                        gameBoard[i,jr - 1] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == 0 && gameBoard[i,jr - 3] == 0)
                    {// move to spot 3
                        gameBoard[i,jr - 3] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == 0 && gameBoard[i,jr - 3] == gameBoard[i,jr] && c3 == 0)
                    {// merge 0 - 3
                        gameBoard[i,jr - 3] += gameBoard[i,jr];
                        score += gameBoard[i,jr - 3];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == gameBoard[i,jr] && c2 == 0)
                    {//merge 0-2
                        gameBoard[i,jr - 2] += gameBoard[i,jr];
                        score += gameBoard[i,jr - 2];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == 0)
                    {// move spot 2
                        gameBoard[i,jr - 2] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == gameBoard[i,jr])
                    {//merge 0-1
                        gameBoard[i,jr - 1] += gameBoard[i,jr];
                        score += gameBoard[i,jr - 1];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0)
                    {
                        gameBoard[i,jr - 1] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    jr++;
                }
                c2 = 0;
                c3 = 0;
                jr = 0;
            }

        }


        public void moveRight()
        {
            int jr = 3;
            int c2 = 0;
            int c3 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 4; j > 0; j--)
                {

                    if (jr == 2 && gameBoard[i,jr + 1] == gameBoard[i,jr] && gameBoard[i,jr] != 0)
                    { //merge 2-3
                        gameBoard[i,jr + 1] += gameBoard[i,jr];
                        score += gameBoard[i,jr + 1];
                        gameBoard[i,jr] = 0;
                        c3 = 1;
                    }
                    else if (jr == 2 && gameBoard[i,jr + 1] == 0)
                    {// move if empty
                        gameBoard[i,jr + 1] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 1 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == 0)
                    { // move if spot 3 if empty
                        gameBoard[i,jr + 2] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 1 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == gameBoard[i,jr] && c3 == 0)
                    { // merge spot 1-3 if same
                        gameBoard[i,jr + 2] += gameBoard[i,jr];
                        score += gameBoard[i,jr + 2];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 1 && gameBoard[i,jr + 1] == gameBoard[i,jr] && gameBoard[i,jr] != 0)
                    {// merge 1-2
                        gameBoard[i,jr + 1] += gameBoard[i,jr];
                        score += gameBoard[i,jr + 1];
                        gameBoard[i,jr] = 0;
                        c2 = 1;
                    }
                    else if (jr == 1 && gameBoard[i,jr + 1] == 0)
                    {// move 1-2
                        gameBoard[i,jr + 1] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == 0 && gameBoard[i,jr + 3] == 0)
                    {// move to spot 3
                        gameBoard[i,jr + 3] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == 0 && gameBoard[i,jr + 3] == gameBoard[i,jr] && c3 == 0)
                    {// merge 0 - 3
                        gameBoard[i,jr + 3] += gameBoard[i,jr];
                        score += gameBoard[i,jr + 3];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == gameBoard[i,jr] && c2 == 0)
                    {//merge 0-2
                        gameBoard[i,jr + 2] += gameBoard[i,jr];
                        score += gameBoard[i,jr + 2];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == 0)
                    {// move spot 2
                        gameBoard[i,jr + 2] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == gameBoard[i,jr])
                    {//merge 0-1
                        gameBoard[i,jr + 1] += gameBoard[i,jr];
                        score += gameBoard[i,jr + 1];
                        gameBoard[i,jr] = 0;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0)
                    {
                        gameBoard[i,jr + 1] = gameBoard[i,jr];
                        gameBoard[i,jr] = 0;
                    }
                    jr--;
                }
                c2 = 0;
                c3 = 0;
                jr = 3;
            }
        }

        public void moveUp()
        {
            int jr = 0;
            int c2 = 0;
            int c3 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (jr == 1 && gameBoard[jr - 1,i] == gameBoard[jr,i] && gameBoard[jr,i] != 0)
                    { //merge 2-3
                        gameBoard[jr - 1,i] += gameBoard[jr,i];
                        score += gameBoard[jr - 1,i];
                        gameBoard[jr,i] = 0;
                        c3 = 1;
                    }
                    else if (jr == 1 && gameBoard[jr - 1,i] == 0)
                    {// move if empty
                        gameBoard[jr - 1,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 2 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == 0)
                    { // move if spot 3 if empty
                        gameBoard[jr - 2,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 2 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == gameBoard[jr,i] && c3 == 0)
                    { // merge spot 1-3 if same
                        gameBoard[jr - 2,i] += gameBoard[jr,i];
                        score += gameBoard[jr - 2,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 2 && gameBoard[jr - 1,i] == gameBoard[jr,i] && gameBoard[jr,i] != 0)
                    {// merge 1-2
                        gameBoard[jr - 1,i] += gameBoard[jr,i];
                        score += gameBoard[jr - 1,i];
                        gameBoard[jr,i] = 0;
                        c2 = 1;
                    }
                    else if (jr == 2 && gameBoard[jr - 1,i] == 0)
                    {// move 1-2
                        gameBoard[jr - 1,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == 0 && gameBoard[jr - 3,i] == 0)
                    {// move to spot 3
                        gameBoard[jr - 3,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == 0 && gameBoard[jr - 3,i] == gameBoard[jr,i] && c3 == 0)
                    {// merge 0 - 3
                        gameBoard[jr - 3,i] += gameBoard[jr,i];
                        score += gameBoard[jr - 3,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == gameBoard[jr,i] && c2 == 0)
                    {//merge 0-2
                        gameBoard[jr - 2,i] += gameBoard[jr,i];
                        score += gameBoard[jr - 2,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == 0)
                    {// move spot 2
                        gameBoard[jr - 2,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == gameBoard[jr,i])
                    {//merge 0-1
                        gameBoard[jr - 1,i] += gameBoard[jr,i];
                        score += gameBoard[jr - 1,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0)
                    {
                        gameBoard[jr - 1,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    jr++;
                }
                c2 = 0;
                c3 = 0;
                jr = 0;
            }
        }


        public void moveDown()
        {
            int jr = 3;
            int c2 = 0;
            int c3 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 4; j > 0; j--)
                {

                    if (jr == 2 && gameBoard[jr + 1,i] == gameBoard[jr,i] && gameBoard[jr,i] != 0)
                    { //merge 2-3
                        gameBoard[jr + 1,i] += gameBoard[jr,i];
                        score += gameBoard[jr + 1,i];
                        gameBoard[jr,i] = 0;
                        c3 = 1;
                    }
                    else if (jr == 2 && gameBoard[jr + 1,i] == 0)
                    {// move if empty
                        gameBoard[jr + 1,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 1 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == 0)
                    { // move if spot 3 if empty
                        gameBoard[jr + 2,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 1 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == gameBoard[jr,i] && c3 == 0)
                    { // merge spot 1-3 if same
                        gameBoard[jr + 2,i] += gameBoard[jr,i];
                        score += gameBoard[jr + 2,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 1 && gameBoard[jr + 1,i] == gameBoard[jr,i] && gameBoard[jr,i] != 0)
                    {// merge 1-2
                        gameBoard[jr + 1,i] += gameBoard[jr,i];
                        score += gameBoard[jr + 1,i];
                        gameBoard[jr,i] = 0;
                        c2 = 1;
                    }
                    else if (jr == 1 && gameBoard[jr + 1,i] == 0)
                    {// move 1-2
                        gameBoard[jr + 1,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == 0 && gameBoard[jr + 3,i] == 0)
                    {// move to spot 3
                        gameBoard[jr + 3,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == 0 && gameBoard[jr + 3,i] == gameBoard[jr,i] && c3 == 0)
                    {// merge 0 - 3
                        gameBoard[jr + 3,i] += gameBoard[jr,i];
                        score += gameBoard[jr + 3,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == gameBoard[jr,i] && c2 == 0)
                    {//merge 0-2
                        gameBoard[jr + 2,i] += gameBoard[jr,i];
                        score += gameBoard[jr + 2,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == 0)
                    {// move spot 2
                        gameBoard[jr + 2,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == gameBoard[jr,i])
                    {//merge 0-1
                        gameBoard[jr + 1,i] += gameBoard[jr,i];
                        score += gameBoard[jr + 1,i];
                        gameBoard[jr,i] = 0;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0)
                    {
                        gameBoard[jr + 1,i] = gameBoard[jr,i];
                        gameBoard[jr,i] = 0;
                    }
                    jr--;
                }
                c2 = 0;
                c3 = 0;
                jr = 3;
            }
        }

        // 
        public bool canMove()
        {
            int jr = 3;
            int c2 = 0;
            int c3 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 4; j > 0; j--)
                {

                    if (jr == 2 && gameBoard[i,jr + 1] == gameBoard[i,jr] && gameBoard[i,jr] != 0)
                    { //merge 2-3
                        return true;
                    }
                    else if (jr == 2 && gameBoard[i,jr + 1] == 0)
                    {// move if empty
                        return true;
                    }
                    else if (jr == 1 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == 0)
                    { // move if spot 3 if empty
                        return true;
                    }
                    else if (jr == 1 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == gameBoard[i,jr] && c3 == 0)
                    { // merge spot 1-3 if same
                        return true;
                    }
                    else if (jr == 1 && gameBoard[i,jr + 1] == gameBoard[i,jr] && gameBoard[i,jr] != 0)
                    {// merge 1-2
                        return true;
                    }
                    else if (jr == 1 && gameBoard[i,jr + 1] == 0)
                    {// move 1-2
                        return true;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == 0 && gameBoard[i,jr + 3] == 0)
                    {// move to spot 3
                        return true;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == 0 && gameBoard[i,jr + 3] == gameBoard[i,jr] && c3 == 0)
                    {// merge 0 - 3
                        return true;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == gameBoard[i,jr] && c2 == 0)
                    {//merge 0-2
                        return true;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0 && gameBoard[i,jr + 2] == 0)
                    {// move spot 2
                        return true;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == gameBoard[i,jr])
                    {//merge 0-1
                        return true;
                    }
                    else if (jr == 0 && gameBoard[i,jr + 1] == 0)
                    {
                        return true;
                    }
                    jr--;
                }
                c2 = 0;
                c3 = 0;
                jr = 3;
            }

            jr = 0;
            c2 = 0;
            c3 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (jr == 1 && gameBoard[i,jr - 1] == gameBoard[i,jr] && gameBoard[i,jr] != 0)
                    { //merge 2-3
                        return true;
                    }
                    else if (jr == 1 && gameBoard[i,jr - 1] == 0)
                    {// move if empty
                        return true;
                    }
                    else if (jr == 2 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == 0)
                    { // move if spot 3 if empty
                        return true;
                    }
                    else if (jr == 2 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == gameBoard[i,jr] && c3 == 0)
                    { // merge spot 1-3 if same
                        return true;
                    }
                    else if (jr == 2 && gameBoard[i,jr - 1] == gameBoard[i,jr] && gameBoard[i,jr] != 0)
                    {// merge 1-2
                        return true;
                    }
                    else if (jr == 2 && gameBoard[i,jr - 1] == 0)
                    {// move 1-2
                        return true;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == 0 && gameBoard[i,jr - 3] == 0)
                    {// move to spot 3
                        return true;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == 0 && gameBoard[i,jr - 3] == gameBoard[i,jr] && c3 == 0)
                    {// merge 0 - 3
                        return true;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == gameBoard[i,jr] && c2 == 0)
                    {//merge 0-2
                        return true;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0 && gameBoard[i,jr - 2] == 0)
                    {// move spot 2
                        return true;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == gameBoard[i,jr])
                    {//merge 0-1
                        return true;
                    }
                    else if (jr == 3 && gameBoard[i,jr - 1] == 0)
                    {
                        return true;
                    }
                    jr++;
                }
                c2 = 0;
                c3 = 0;
                jr = 0;
            }

            jr = 0;
            c2 = 0;
            c3 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if (jr == 1 && gameBoard[jr - 1,i] == gameBoard[jr,i] && gameBoard[jr,i] != 0)
                    { //merge 2-3
                        return true;
                    }
                    else if (jr == 1 && gameBoard[jr - 1,i] == 0)
                    {// move if empty
                        return true;
                    }
                    else if (jr == 2 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == 0)
                    { // move if spot 3 if empty
                        return true;
                    }
                    else if (jr == 2 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == gameBoard[jr,i] && c3 == 0)
                    { // merge spot 1-3 if same
                        return true;
                    }
                    else if (jr == 2 && gameBoard[jr - 1,i] == gameBoard[jr,i] && gameBoard[jr,i] != 0)
                    {// merge 1-2
                        return true;
                    }
                    else if (jr == 2 && gameBoard[jr - 1,i] == 0)
                    {// move 1-2
                        return true;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == 0 && gameBoard[jr - 3,i] == 0)
                    {// move to spot 3
                        return true;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == 0 && gameBoard[jr - 3,i] == gameBoard[jr,i] && c3 == 0)
                    {// merge 0 - 3
                        return true;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == gameBoard[jr,i] && c2 == 0)
                    {//merge 0-2
                        return true;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0 && gameBoard[jr - 2,i] == 0)
                    {// move spot 2
                        return true;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == gameBoard[jr,i])
                    {//merge 0-1
                        return true;
                    }
                    else if (jr == 3 && gameBoard[jr - 1,i] == 0)
                    {
                        return true;
                    }
                    jr++;
                }
                c2 = 0;
                c3 = 0;
                jr = 0;
            }

            jr = 3;
            c2 = 0;
            c3 = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 4; j > 0; j--)
                {

                    if (jr == 2 && gameBoard[jr + 1,i] == gameBoard[jr,i] && gameBoard[jr,i] != 0)
                    { //merge 2-3
                        return true;
                    }
                    else if (jr == 2 && gameBoard[jr + 1,i] == 0)
                    {// move if empty
                        return true;
                    }
                    else if (jr == 1 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == 0)
                    { // move if spot 3 if empty
                        return true;
                    }
                    else if (jr == 1 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == gameBoard[jr,i] && c3 == 0)
                    { // merge spot 1-3 if same
                        return true;
                    }
                    else if (jr == 1 && gameBoard[jr + 1,i] == gameBoard[jr,i] && gameBoard[jr,i] != 0)
                    {// merge 1-2
                        return true;
                    }
                    else if (jr == 1 && gameBoard[jr + 1,i] == 0)
                    {// move 1-2
                        return true;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == 0 && gameBoard[jr + 3,i] == 0)
                    {// move to spot 3
                        return true;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == 0 && gameBoard[jr + 3,i] == gameBoard[jr,i] && c3 == 0)
                    {// merge 0 - 3
                        return true;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == gameBoard[jr,i] && c2 == 0)
                    {//merge 0-2
                        return true;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0 && gameBoard[jr + 2,i] == 0)
                    {// move spot 2
                        return true;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == gameBoard[jr,i])
                    {//merge 0-1
                        return true;
                    }
                    else if (jr == 0 && gameBoard[jr + 1,i] == 0)
                    {
                        return true;
                    }

                    jr--;
                }
                c2 = 0;
                c3 = 0;
                jr = 3;
            }

            return false;
            
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            resetGame();
            drawGrid();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
