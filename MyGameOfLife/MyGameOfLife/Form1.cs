using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGameOfLife
{
    public partial class Form1 : Form
    {
        public Point size = new Point();
        public bool[,] alive, temp;
        public float spaceX, spaceY;
        public bool tor = true;
        public bool high = true;
        public Color linecolor = Color.Black;
        public Color pixelcolor = Color.Black;
        public Random ran = new Random();

        public Form1()
        {
            InitializeComponent();
            size.X = 100;
            size.Y = 100;
            alive = new bool[size.X,size.Y];
            temp = new bool[size.X,size.Y];
            timer1.Interval = 50;
            this.Text = "My Game Of Life";
        }

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            if(alive.GetUpperBound(0) != size.X - 1  || alive.GetUpperBound(1) != size.Y - 1)
            {
                ChangeSize();
            }
            spaceX = (float)graphicsPanel.Width / size.X;
            spaceY = (float)graphicsPanel.Height / size.Y;
            Pen p = new Pen(linecolor);
            SolidBrush b = new SolidBrush(pixelcolor);
            for (int i = 0; i <= size.X; i++)
            {
                if(i % 5 == 0 && high)
                {
                    p.Width = 3;
                }
                e.Graphics.DrawLine(p,i * spaceX,0,i * spaceX,graphicsPanel.Height);
                p.Width = 1;
            }
            for(int i = 0; i <= size.Y; i++)
            {
                if (i % 5 == 0 && high)
                {
                    p.Width = 3;
                }
                e.Graphics.DrawLine(p,0,i*spaceY,graphicsPanel.Width,i*spaceY);
                p.Width = 1;
            }
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    if (alive[i, j] == true)
                    {
                        e.Graphics.FillRectangle(b, i * spaceX, j * spaceY, spaceX, spaceY);
                    }
                }
            }
            p.Dispose();
        }

        //Changes wether a cell is alive or dead when clicked in the graphics panel
        private void graphicsPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                alive[(int)(e.X / spaceX), (int)(e.Y / spaceY)] = !alive[(int)(e.X / spaceX), (int)(e.Y / spaceY)];
                graphicsPanel.Invalidate();
            }
        }

        //Clears the whole board by setting everything to dead
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    alive[i, j] = false;
                }
            }
            graphicsPanel.Invalidate();
        }

        //Starts the game of life algorithm by enabling the timer
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        //pauses the timer
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        //moves one tick further into the algorithm
        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunLife();
        }

        //runs a single step through the program
        public void RunLife()
        {
            int nei = 0;
            temp = new bool[size.X,size.Y];
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    switch(alive[i,j])
                    {
                        case true:
                            if (tor)
                            {
                                nei = GetSurroundingTurodial(i, j);
                            }
                            else nei = GetSurrounding(i, j);
                            if (nei < 2 || nei > 3)
                                temp[i, j] = false;
                            else
                                temp[i, j] = true;
                            break;
                        case false:
                            if(tor)
                            {
                                nei = GetSurroundingTurodial(i, j);
                            }
                            else nei = GetSurrounding(i,j);
                            if (nei == 3)
                                temp[i, j] = true;
                            else
                                temp[i, j] = false;
                            break;
                    }
                }
            }
            graphicsPanel.Invalidate();
            alive = temp;
        }

        //When the timer is enabled this Runs the Life algorithm every tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            RunLife();
        }

        //gets the number of neighbors surrounding a specified pixel
        public int GetSurrounding(int x, int y)
        {
            int nei = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                if (i < 0 || i >= size.X)
                    continue;
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (j < 0 || j >= size.Y)
                        continue;
                    else if (alive[i, j] && !(i == x && j == y))
                    {
                        nei++;
                    }
                }
            }

            return nei;
        }

        //gets the number of neighbors surrounding a specified pixel and doesn't stop at edges, instead it searches the opposite side
        public int GetSurroundingTurodial(int x, int y)
        {
            int nei = 0;
            Point check = new Point();

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    check.X = i;
                    check.Y = j;
                    if(i < 0)
                    {
                        check.X = size.X - 1;
                    }
                    if(j < 0)
                    {
                        check.Y = size.Y - 1;
                    }
                    if(i >= size.X)
                    {
                        check.X = 0;
                    }
                    if(j >= size.Y)
                    {
                        check.Y = 0;
                    }
                    if (alive[check.X, check.Y] && !(i == x && j == y))
                    {
                        nei++;
                    }
                }
            }

            return nei;
        }

        //exits application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Randomly places alive cells thorughout the entire bool array
        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < alive.GetUpperBound(0); i++)
            {
                for(int j = 0; j < alive.GetUpperBound(1); j++)
                {
                    if (ran.Next() % 2 == 0)
                    {
                        alive[i, j] = true;
                    }
                    else alive[i, j] = false;
                }
            }
            graphicsPanel.Invalidate();
        }

        //if forms size changes so does the graphics panel
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            graphicsPanel.Width = Form1.ActiveForm.Width;
            graphicsPanel.Height = Form1.ActiveForm.Height;
            graphicsPanel.Height -= (25 + 28 + 27 + 41);
            graphicsPanel.Invalidate();
        }

        //if the grid size changes this function runs to resize the boolean arrays
        private void ChangeSize()
        {
            temp = alive;
            alive = new bool[size.X,size.Y];
            for(int i = 0; i < temp.GetUpperBound(0); i++)
            {
                if(i >= alive.GetUpperBound(0))
                    continue;
                for(int j = 0; j < temp.GetUpperBound(1); j++)
                {
                    if (j >= alive.GetUpperBound(1))
                        continue;
                    alive[i, j] = temp[i, j];
                }
            }
            temp = new bool[size.X, size.Y];
        }
    }
}
