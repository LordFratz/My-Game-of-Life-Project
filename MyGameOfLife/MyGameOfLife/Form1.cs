using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGameOfLife
{
    public partial class Form1 : Form
    {
        //universe values
        public Point size = new Point();
        public bool[,] alive, temp;
        public float spaceX, spaceY;
        public bool tor = Properties.Settings.Default.Toro;
        public bool high = Properties.Settings.Default.High;
        public Color linecolor = Properties.Settings.Default.GridColor;
        public Color pixelcolor = Properties.Settings.Default.PixelColor;
        public Random ran = new Random();
        public string filename = null;
        public ulong gen = 0;
        public ulong amtalive = 0;
        public int highamt;

        public Form1()
        {
            InitializeComponent();
            size.X = Properties.Settings.Default.Width;
            size.Y = Properties.Settings.Default.Height;
            highamt = Properties.Settings.Default.HighAmt;
            graphicsPanel.BackColor = Properties.Settings.Default.BackColor;
            alive = new bool[size.X,size.Y];
            temp = new bool[size.X,size.Y];
            timer1.Interval = Properties.Settings.Default.milliseconds;
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
            for (int i = 0; i <= size.X; i++)
            {
                if(i % highamt == 0 && high)
                {
                    p.Width = 3;
                }
                e.Graphics.DrawLine(p,i * spaceX,0,i * spaceX,graphicsPanel.Height);
                p.Width = 1;
            }
            for (int i = 0; i <= size.Y; i++)
            {
                if (i % highamt == 0 && high)
                {
                    p.Width = 3;
                }
                e.Graphics.DrawLine(p,0,i*spaceY,graphicsPanel.Width,i*spaceY);
                p.Width = 1;
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
            gen = 0;
            amtalive = 0;
            GenerationNum.Text = "" + gen;
            AliveNum.Text = "" + amtalive;
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
            amtalive = 0;
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
                            amtalive++;
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
            gen++;
            if(amtalive != 0)
            {
                GenerationNum.Text = "" + gen;
            }
            AliveNum.Text = "" + amtalive;
            millisecondsnum.Text = "" + timer1.Interval;
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
            this.Close();
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

        //opens the optons modal dialog box and changes the universe values depending on the settings that were changed
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 temp = new Form2(timer1.Interval, size.Y, size.X, highamt, graphicsPanel.BackColor, linecolor, pixelcolor, tor, high);
            temp.ShowDialog();
            timer1.Interval = temp.mill;
            size.Y = temp.rows;
            size.X = temp.columns;
            graphicsPanel.BackColor = temp.background;
            linecolor = temp.grid;
            pixelcolor = temp.Cells;
            tor = temp.tor;
            high = temp.high;
            highamt = temp.skip;
            graphicsPanel.Invalidate();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.BackColor = graphicsPanel.BackColor;
            Properties.Settings.Default.PixelColor = pixelcolor;
            Properties.Settings.Default.GridColor = linecolor;
            Properties.Settings.Default.Height = size.Y;
            Properties.Settings.Default.Width = size.X;
            Properties.Settings.Default.Toro = tor;
            Properties.Settings.Default.milliseconds = timer1.Interval;
            Properties.Settings.Default.High = high;
            Properties.Settings.Default.HighAmt = highamt;
            Properties.Settings.Default.Save();
        }

        //save to the current "open" file, IE is you opened or saved a file before pressing the button
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != null)
            {
                StreamWriter writer = new StreamWriter(filename);
                for (int i = 0; i < alive.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < alive.GetUpperBound(1); j++)
                    {
                        switch (alive[j, i])
                        {
                            case true:
                                writer.Write("O");
                                break;
                            case false:
                                writer.Write(".");
                                break;
                        }
                    }
                    writer.WriteLine();
                }
                writer.Close();
            }
        }

        //saves a new file with they users disered name
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Filter = ".Txt (*.txt)|*.txt";
            if (file.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(file.FileName);
                filename = file.FileName;
                for (int i = 0; i < alive.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < alive.GetUpperBound(1); j++)
                    {
                        switch (alive[i, j])
                        {
                            case true:
                                writer.Write("O");
                                break;
                            case false:
                                writer.Write(".");
                                break;
                        }
                    }
                    writer.WriteLine();
                }
                writer.Close();
            }
        }

        //Loads a file and displays it in application
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Filter = ".Txt (*.txt)|*.txt";
            if (file.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(file.FileName);
                filename = file.FileName;
                alive = new bool[size.X, size.Y];
                string tempp;
                int Y = 0;
                while(!reader.EndOfStream)
                {
                    if (Y >= alive.GetUpperBound(0))
                    {
                        break;
                    }
                    tempp = reader.ReadLine();
                    for(int i = 0; i < alive.GetUpperBound(1) && i < tempp.Length; i++)
                    {
                        switch(tempp[i])
                        {
                            case '.':
                                alive[Y, i] = false;
                                break;
                            case 'O':
                                alive[Y, i] = true;
                                break;
                        }
                    }
                    Y++;
                }
            }
            graphicsPanel.Invalidate();
        }

        //Imports a file of the user choosing by not deleting anything insede the universe
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        //changes interval of time when called
        private void ChangeTimer(int t)
        {
            timer1.Interval = t;
        }
    }
}
