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
        public bool[,] alive;
        public float spaceX, spaceY;
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
            size.X = 50;
            size.Y = 50;
            alive = new bool[size.X,size.Y];
            timer.Interval = 20;
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
        }

        private void graphicsPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                alive[(int)(e.X / spaceX), (int)(e.Y / spaceY)] = !alive[(int)(e.X / spaceX), (int)(e.Y / spaceY)];
                graphicsPanel.Invalidate();
            }
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
