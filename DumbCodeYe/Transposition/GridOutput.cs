using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Transposition
{
    public partial class GridOutput : Form
    {
        private List<char[]> mainGrid = new List<char[]>();
        private int Rows;
        private int Columns;

        public GridOutput()
        {
            InitializeComponent();
        }

        public void Setup(char[,] grid, int rows, int columns)
        {
            for (int column = 0; column < columns; column++)
            {
                char[] totalColumn = new char[rows];
                for (int row = 0; row < rows; row++)
                {
                    totalColumn[row] = grid[row, column];
                }
                mainGrid.Add(totalColumn);
            }
            swap1.Maximum = columns;
            swap2.Maximum = columns;
            Rows = rows;
            Columns = columns;
            PrintGrid();
        }

        private void PrintGrid()
        {
            gridList.Items.Clear();
            string topRow = "";
            for (int i = 0; i < Columns; i++)
            {
                string number = " " + (i + 1).ToString();
                topRow += number;
                for (int j = number.Length; j < 3; j++)
                {
                    topRow += " ";
                }
            }
            gridList.Items.Add(topRow);
            for (int row = 0; row < Rows; row++)
            {
                string output = "";
                for (int column = 0; column < Columns; column++)
                {
                    output += " " + mainGrid[column][row].ToString() + " ";
                }
                gridList.Items.Add(output);
            }
        }

        private void swapBtn_Click(object sender, EventArgs e)
        {
            if (swap1.Value != swap2.Value)
            {
                char[] temp = mainGrid[(int)swap1.Value - 1];
                mainGrid[(int)swap1.Value - 1] = mainGrid[(int)swap2.Value - 1];
                mainGrid[(int)swap2.Value - 1] = temp;
                PrintGrid();
            }
        }

        private void outputBtn_Click(object sender, EventArgs e)
        {
            string output = "";
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    output += mainGrid[column][row].ToString();
                }
            }
            TextOutputFrm TO = new TextOutputFrm();
            TO.SetOutput(output);
            TO.Show();
        }
    }
}
