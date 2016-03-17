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
    public partial class Form2 : Form
    {
        public int mill, rows, columns, skip;
        public Color background, grid, Cells;
        public bool tor, high;

        public Form2(int m, int r, int c, int s, Color b, Color g, Color ce, bool t, bool h)
        {
            InitializeComponent();
            MillisecondsUpDown.Value = m;
            mill = m;
            RowsUpDown.Value = r;
            rows = r;
            ColumnsUpDown.Value = c;
            columns = c;
            SkipUpDown.Value = s;
            skip = s;
            BackgroundButton.BackColor = b;
            background = b;
            GridButton.BackColor = g;
            grid = g;
            CellsButton.BackColor = ce;
            Cells = ce;
            if (t)
                TorodialRadioButton.Checked = true;
            else FiniteRadioButton.Checked = true;
                tor = t;
            if (h)
                comboBox1.SelectedIndex = 0;
            else comboBox1.SelectedIndex = 1;
            high = h;
        }

        private void BackgroundButton_Click(object sender, EventArgs e)
        {
            ColorDialog pick = new ColorDialog();
            pick.Color = BackgroundButton.BackColor;
            if(pick.ShowDialog() == DialogResult.OK)
            {
                BackgroundButton.BackColor = pick.Color;
            }
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            ColorDialog pick = new ColorDialog();
            pick.Color = GridButton.BackColor;
            if (pick.ShowDialog() == DialogResult.OK)
            {
                GridButton.BackColor = pick.Color;
            }
        }

        private void CellsButton_Click(object sender, EventArgs e)
        {
            ColorDialog pick = new ColorDialog();
            pick.Color = CellsButton.BackColor;
            if (pick.ShowDialog() == DialogResult.OK)
            {
                CellsButton.BackColor = pick.Color;
            }
        }
        //just closes and doesn't change anything
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //sets all the values to the selected one in the dialog box before closing
        private void OKButton_Click(object sender, EventArgs e)
        {
            mill = (int)MillisecondsUpDown.Value;
            rows = (int)RowsUpDown.Value;
            columns = (int)ColumnsUpDown.Value;
            background = BackgroundButton.BackColor;
            grid = GridButton.BackColor;
            Cells = CellsButton.BackColor;
            if (TorodialRadioButton.Checked)
            {
                tor = true;
            }
            else tor = false;
            if (comboBox1.SelectedIndex == 0)
            {
                high = true;
            }
            else high = false;
            skip = (int)SkipUpDown.Value;
            this.Close();
        }
    }
}
