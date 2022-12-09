using DumbCodeYe.Quadgrams;
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
        private bool ReadColumns;

        private float totalCalc = 0;
        private int toCalc = 0;

        public GridOutput()
        {
            InitializeComponent();
        }

        public void Setup(char[,] grid, int rows, int columns, bool readColumns = false)
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
            ReadColumns = readColumns;
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
            Swap((int)swap1.Value, (int)swap2.Value);
        }

        private void outputBtn_Click(object sender, EventArgs e)
        {
            string output = GetGridOutput(mainGrid);
            TextOutputFrm TO = new TextOutputFrm();
            TO.SetOutput(output);
            TO.Show();
        }
        public string GetOutput()
        {
            return GetGridOutput(mainGrid);
        }

        private void Swap(int c1, int c2)
        {
            if (c1 != c2)
            {
                char[] temp = mainGrid[c1 - 1];
                mainGrid[c1 - 1] = mainGrid[c2 - 1];
                mainGrid[c2 - 1] = temp;
                PrintGrid();
            }
        }
        private void Swap(int c1, int c2, ref List<char[]> grid)
        {
            if (c1 != c2)
            {
                char[] temp = grid[c1];
                grid[c1] = grid[c2];
                grid[c2] = temp;
            }
        }

        private void bruteBtn_Click(object sender, EventArgs e)
        {
            ProgressBarForm PBF = new ProgressBarForm();
            PBF.Show();
            totalCalc = 0;
            toCalc = Factorial(Columns);
            SwapIteration(0, new List<char[]>(mainGrid), out List<char[]> Best, out double Score, PBF);
            string output = GetGridOutput(Best);
            TextOutputFrm TO = new TextOutputFrm();
            TO.SetOutput(output);
            TO.Show();
            PBF.Close();
        }

        public List<string> GetAllPermutations()
        {
            List<string> permutations = new List<string>();
            PermutateList(ref permutations, 0, mainGrid);
            return permutations;
        }
        private void PermutateList(ref List<string> perms, int swapNumber, List<char[]> grid)
        {
            if(swapNumber == grid.Count - 1)
            {
                perms.Add(GetGridOutput(grid));
            }
            else
            {
                for(int i = swapNumber; i < grid.Count; i++)
                {
                    List<char[]> swapList = new List<char[]>(grid);
                    Swap(swapNumber, i, ref swapList);
                    PermutateList(ref perms, swapNumber + 1, swapList);
                }
            }
        }
        public string BruteIterations()
        {
            ProgressBarForm PBF = new ProgressBarForm();
            PBF.Show();
            totalCalc = 0;
            toCalc = Factorial(Columns);
            SwapIteration(0, new List<char[]>(mainGrid), out List<char[]> Best, out double Score, PBF);
            return GetGridOutput(Best);
        }


        private void SwapIteration(int swapNumber, List<char[]> grid, out List<char[]> bestGrid, out double bestScore, ProgressBarForm PBF)
        {
            if (swapNumber == grid.Count - 1)
            {
                bestGrid = grid;
                bestScore = ScoreGrid(grid);
                totalCalc++;
                PBF.status.Text = $"{totalCalc} / {toCalc}";
                PBF.loadingBar.Value = (int)Math.Floor((totalCalc * 100f) / toCalc);
                PBF.Invalidate();
                PBF.Refresh();
            }
            else
            {
                List<char[]> BestGrid = grid;
                double BestScore = double.MinValue;
                for (int i = swapNumber; i < grid.Count; i++)
                {
                    List<char[]> swapList = new List<char[]>(grid);
                    Swap(swapNumber, i, ref swapList);
                    SwapIteration(swapNumber + 1, swapList, out List<char[]> best, out double score, PBF);
                    if(score > BestScore)
                    {
                        BestGrid = best;
                        BestScore = score;
                    }
                }
                bestGrid = BestGrid;
                bestScore = BestScore;
            }
        }
        private string GetGridOutput(List<char[]> grid)
        {
            string text = "";
            if (ReadColumns)
            {
                for (int column = 0; column < Columns; column++)
                {
                    for (int row = 0; row < Rows; row++)
                    {
                        text += grid[column][row].ToString();
                    }
                }
            }
            else
            {
                for (int row = 0; row < Rows; row++)
                {
                    for (int column = 0; column < Columns; column++)
                    {
                        text += grid[column][row].ToString();
                    }
                }
            }
            return text;
        }
        private double ScoreGrid(List<char[]> grid)
        {
            string text = GetGridOutput(grid);
            double score = 0;
            for (int i = 0; i < text.Length - 4; i++)
            {
                if (i == 0)
                    score = QuadgramsData.GetLogProbability(text.Substring(i, 4));
                else
                    score += QuadgramsData.GetLogProbability(text.Substring(i, 4));
            }
            return score;
        }
        public int Factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }
    }
}
