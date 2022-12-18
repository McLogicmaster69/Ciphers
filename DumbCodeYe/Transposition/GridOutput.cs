using DumbCodeYe.Bigrams;
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

        private TextOutputFrm LikelyPairsOutput = new TextOutputFrm();
        private int[] BestPair;
        private int LowestIndex;

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
            CalculateBestPairs(false);
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
        public string GetOutput()
        {
            return GetGridOutput(mainGrid);
        }

        private void swapBtn_Click(object sender, EventArgs e)
        {
            Swap((int)swap1.Value, (int)swap2.Value);
        }
        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (swap1.Value == swap2.Value)
                return;
            int startValue = (int)swap1.Value;
            int endValue = (int)swap2.Value;
            if (startValue < endValue)
            {
                for (int i = startValue; i < endValue; i++)
                {
                    Swap(i, i + 1, false);
                }
            }
            else
            {
                for (int i = startValue; i > endValue; i--)
                {
                    Swap(i, i - 1, false);
                }
            }
            PrintGrid();
            GenerateBestPairOutput();
        }
        private void outputBtn_Click(object sender, EventArgs e)
        {
            string output = GetGridOutput(mainGrid);
            TextOutputFrm TO = new TextOutputFrm();
            TO.SetOutput(output);
            TO.Show();
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
        private void bestPairsBtn_Click(object sender, EventArgs e)
        {
            CalculateBestPairs();
        }

        private void CalculateBestPairs(bool generate = true)
        {
            int[] bestPair = new int[Columns];
            long lowestScore = long.MaxValue;
            int lowestIndex = 0;
            for (int currentColumn = 0; currentColumn < Columns; currentColumn++)
            {
                long[] columnScores = new long[Columns];
                for (int currentRow = 0; currentRow < Rows; currentRow++)
                {
                    for (int testColumn = 0; testColumn < Columns; testColumn++)
                    {
                        if (testColumn == currentColumn)
                            continue;
                        string bigram = mainGrid[currentColumn][currentRow].ToString() + mainGrid[testColumn][currentRow].ToString();
                        columnScores[testColumn] += BigramsData.GetFrequency(bigram);
                    }
                }
                int highestIndex = 0;
                for (int i = 1; i < Columns; i++)
                {
                    if (columnScores[i] > columnScores[highestIndex])
                        highestIndex = i;
                }
                bestPair[currentColumn] = highestIndex;
                if (columnScores[highestIndex] < lowestScore)
                {
                    lowestScore = columnScores[highestIndex];
                    lowestIndex = currentColumn;
                }
            }

            BestPair = bestPair;
            LowestIndex = lowestIndex;

            if(generate)
                GenerateBestPairOutput();
        }
        private void RecalculateBestPairs(int s1, int s2)
        {
            if (LowestIndex == s1)
                LowestIndex = s2;
            else if (LowestIndex == s2)
                LowestIndex = s1;

            int temp = BestPair[s1];
            BestPair[s1] = BestPair[s2];
            BestPair[s2] = temp;

            for (int col = 0; col < Columns; col++)
            {
                if (BestPair[col] == s1)
                    BestPair[col] = s2;
                else if (BestPair[col] == s2)
                    BestPair[col] = s1;
            }
        }
        private void GenerateBestPairOutput()
        {
            string output = "";
            for (int i = 0; i < Columns; i++)
            {
                output += $"Column {i + 1} has best match of column {BestPair[i] + 1}\r\n";
            }
            output += $"Most likly to be last column: {LowestIndex + 1}";
            LikelyPairsOutput.SetOutput(output);
            LikelyPairsOutput.Show();
        }
        public float GetAveragePointer()
        {
            int[] pointingTo = new int[Columns];
            for (int i = 0; i < Columns; i++)
            {
                if(i != LowestIndex)
                {
                    pointingTo[BestPair[i]]++;
                }
            }

            float totalValue = 0;
            int totalColumns = 0;
            for (int i = 0; i < Columns; i++)
            {
                if(pointingTo[i] != 0)
                {
                    totalValue += pointingTo[i];
                    totalColumns++;
                }
            }

            return totalValue / totalColumns; // BEST VALUE IS 1
        }

        private void Swap(int c1, int c2, bool print = true)
        {
            if (c1 != c2)
            {
                char[] temp = mainGrid[c1 - 1];
                mainGrid[c1 - 1] = mainGrid[c2 - 1];
                mainGrid[c2 - 1] = temp;
                RecalculateBestPairs(c1 - 1, c2 - 1);
                if (print)
                {
                    PrintGrid();
                    GenerateBestPairOutput();
                }
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
