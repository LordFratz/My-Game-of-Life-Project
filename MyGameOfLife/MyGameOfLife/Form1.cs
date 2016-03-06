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

        public Form1()
        {
            InitializeComponent();
            size.X = 50;
            size.Y = 50;
            alive = new bool[size.X,size.Y];
            temp = new bool[size.X,size.Y];
            timer1.Interval = 50;
            this.Text = "My Game Of Life";
        }

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            spaceX = (float)graphicsPanel.Width / size.X;
            spaceY = (float)graphicsPanel.Height / size.Y;
            Pen p = new Pen(Color.Black);
            for (int i = 0; i <= size.X; i++)
            {
                e.Graphics.DrawLine(p,i * spaceX,0,i * spaceX,graphicsPanel.Height);
            }
            for(int i = 0; i <= size.Y; i++)
            {
                e.Graphics.DrawLine(p,0,i*spaceY,graphicsPanel.Width,i*spaceY);
            }
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    if (alive[i, j] == true)
                    {
                        e.Graphics.FillRectangle(Brushes.Black, i * spaceX, j * spaceY, spaceX, spaceY);
                    }
                }
            }
            p.Dispose();
        }

        private void graphicsPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                alive[(int)(e.X / spaceX), (int)(e.Y / spaceY)] = !alive[(int)(e.X / spaceX), (int)(e.Y / spaceY)];
                graphicsPanel.Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    alive[i, j] = false;
                }
            }
            size.X = 50;
            size.Y = 50;
            graphicsPanel.Invalidate();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

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
                            nei = GetSurrounding(i,j);
                            if (nei < 2 || nei > 3)
                                temp[i, j] = false;
                            else
                                temp[i, j] = true;
                            break;
                        case false:
                            nei = GetSurrounding(i,j);
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

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            graphicsPanel.Width = Form1.ActiveForm.Width;
            graphicsPanel.Height = Form1.ActiveForm.Height;
            graphicsPanel.Height -= (25 + 28 + 27 + 41);
            graphicsPanel.Invalidate();
        }
    }
}
