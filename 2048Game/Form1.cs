using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048Game
{
    public partial class Form1 : Form
    {

        enum GameSquares
        {
            blank = 0,
            square2 = 1,
            square4 = 2,
            square8 = 3,
            square16 = 4,
            square32 = 5,
            square64 = 6,
            square128 = 7,
            square256 = 8,
            square512 = 9,
            square1024 = 10,
            square2048 = 11
        };

        GameSquares[,] gameData;

        string[,] board;
        Size gridSize = new Size(4, 4);
        Size cellSize = new Size(75, 75);
        int imageIndex = 0;

        Bitmap squareGraphics = new Bitmap(typeof(Form1), "2048NumList.png");

        public Form1()
        {
            InitializeComponent();
        }

        private void createBoard()
        {
            for (int row = 0; row < gridSize.Height; row++)
            {
                for (int col = 0; col < gridSize.Width; col++)
                {
                    board[row, col] = "";
                    board[2, 2] = "s2";
                    //SetCell(row, col, (int)GameSquares.blank);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                squareGraphics = new Bitmap(typeof(Form1), "2048NumList.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with image");
            }
            imageIndex = 0;
            ClientSize = new Size(cellSize.Width * gridSize.Width, cellSize.Height * gridSize.Height + menuStrip1.Height);
            board = new string[gridSize.Height, gridSize.Width];
            createBoard();
            board[2, 2] = "s2";
       //     SetCell(2, 3, "s1");
        }
    
        private void SetCell(int x, int y, string number)
        {
            if (number.Equals("s2"))
            {
                gameData[x, y] = GameSquares.square2;
            }
            if (number.Equals("s4"))
            {
                gameData[x, y] = GameSquares.square4;
            }
            if (number.Equals("s8"))
            {
                gameData[x, y] = GameSquares.square8;
            }
            if (number.Equals("s16"))
            {
                gameData[x, y] = GameSquares.square16;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, menuStrip1.Height);
            Pen drawBoard = new Pen(Color.DarkGray, 1);

            for (int i = 0; i < gridSize.Width; i++)
            {
                e.Graphics.DrawLine(drawBoard, i * cellSize.Width, 0, i * cellSize.Width, ClientRectangle.Bottom);
            }

            for (int i = 0; i < gridSize.Height; i++)
            {
                e.Graphics.DrawLine(drawBoard, 0, i * cellSize.Height, ClientRectangle.Right, i * cellSize.Height);
            }

            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    Rectangle srcRect;
                    Rectangle destRect = new Rectangle(i * cellSize.Width, j * cellSize.Height, cellSize.Width, cellSize.Height);

                    if (board[i, j] == "s2")
                    {
                        Console.WriteLine("Square2");
                        imageIndex = 0;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s4")
                    {
                        
                    }
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createBoard();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
