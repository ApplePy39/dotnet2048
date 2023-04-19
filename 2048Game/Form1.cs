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

        Point[] listOfSquaresLocations = new Point[16]; 

        public Form1()
        {
            InitializeComponent();
        }

        private void createBoard()
        {
            int yVal;
            int xVal;

            Random firstNumberLocation = new Random();
            yVal = firstNumberLocation.Next(0, 4);
            xVal = firstNumberLocation.Next(0, 4);  

            Console.WriteLine(xVal+ " " + yVal);

            for (int row = 0; row < gridSize.Height; row++)
            {
                for (int col = 0; col < gridSize.Width; col++)
                {
                    board[row, col] = "";
                    board[xVal, yVal] = "s2";
                    listOfSquaresLocations.Append(new Point(xVal, yVal));
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
            if (number.Equals("s32"))
            {
                gameData[x, y] = GameSquares.square32;
            }
            if (number.Equals("s64"))
            {
                gameData[x, y] = GameSquares.square64;
            }
            if (number.Equals("s128"))
            {
                gameData[x, y] = GameSquares.square128;
            }
            if (number.Equals("s256"))
            {
                gameData[x, y] = GameSquares.square256;
            }
            if (number.Equals("s512"))
            {
                gameData[x, y] = GameSquares.square512;
            }
            if (number.Equals("s1024"))
            {
                gameData[x, y] = GameSquares.square1024;
            }
            if (number.Equals("s2048"))
            {
                gameData[x, y] = GameSquares.square2048;
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
                        Console.WriteLine("Square4");
                        imageIndex = 1;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s8")
                    {
                        Console.WriteLine("Square8");
                        imageIndex = 2;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s16")
                    {
                        Console.WriteLine("Square16");
                        imageIndex = 3;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s32")
                    {
                        Console.WriteLine("Square32");
                        imageIndex = 4;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s64")
                    {
                        Console.WriteLine("Square64");
                        imageIndex = 5;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s128")
                    {
                        Console.WriteLine("Square128");
                        imageIndex = 6;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s256")
                    {
                        Console.WriteLine("Square256");
                        imageIndex = 7;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s512")
                    {
                        Console.WriteLine("Square512");
                        imageIndex = 8;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s1024")
                    {
                        Console.WriteLine("Square1024");
                        imageIndex = 9;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }

                    else if (board[i, j] == "s2048")
                    {
                        Console.WriteLine("Square2048");
                        imageIndex = 10;
                        srcRect = new Rectangle(imageIndex * cellSize.Width, 0, cellSize.Width, cellSize.Height);
                        e.Graphics.DrawImage(squareGraphics, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    moveSquares(0, -1);
                    Console.WriteLine("Moved Up");
                    break;

                case Keys.S:
                    moveSquares(0, 1);
                    Console.WriteLine("Moved Down");
                    break;

                case Keys.A:
                    moveSquares(-1, 0);
                    Console.WriteLine("Moved Left");
                    break;

                case Keys.D:
                    moveSquares(1, 0);
                    Console.WriteLine("Moved Right");
                    break;


            }
        }

        private void moveSquares(int h, int v)
        {
            for (int i = 0; i < listOfSquaresLocations.Length; i++)
            {
             //   Console.WriteLine(listOfSquaresLocations[i].Y);
                listOfSquaresLocations[i].X = listOfSquaresLocations[i].X + h;
                listOfSquaresLocations[i].Y = listOfSquaresLocations[i].Y + v;
             //   Console.WriteLine(listOfSquaresLocations[i].Y);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // createBoard();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
