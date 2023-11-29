using DumbCodeYe.LetterPatterns.Bigrams;
using DumbCodeYe.LetterPatterns.Quadgrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Transposition
{
    public partial class GridOutput : Form
    {
        private List<char[]> mainGrid = new List<char[]>();
        private int Rows;
        private int Columns;
        private bool ShiftColumns;

        private TextOutputFrm LikelyPairsOutput = new TextOutputFrm();
        private int[] BestPair;
        private int[] BestShift;
        private int LowestIndex;

        private float totalCalc = 0;
        private int toCalc = 0;

        public GridOutput(char[,] grid, int rows, int columns, bool shiftColumns = false)
        {
            InitializeComponent();
            Setup(grid, rows, columns, shiftColumns);
        }

        private void Setup(char[,] grid, int rows, int columns, bool shiftColumns)
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
            ShiftColumns = shiftColumns;
            PrintGrid();
            CalculateBestPairs(false);

            if (shiftColumns)
            {
                shiftValueNum.Maximum = Rows - 1;
                shiftValueNum.Minimum = 1 - Rows;
                selectedColumnNum.Maximum = columns;
            }
            else
            {
                shiftBtn.Visible = false;
                selectedColumnNum.Visible = false;
                shiftValueNum.Visible = false;
            }

            columnNumbersTxt.Text = FormatColumnNumbers();
        }

        private string FormatColumnNumbers()
        {
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
            return topRow;
        }
        private void PrintGrid()
        {
            int topIndex = gridList.TopIndex;
            gridList.Items.Clear();
            if (ShiftColumns)
            {
                for (int row = 0; row < Rows; row++)
                {
                    string output = "";
                    if (row < 10)
                        output = $" {row}";
                    else
                        output = row.ToString();
                    for (int column = 0; column < Columns; column++)
                    {
                        output += " " + mainGrid[column][row].ToString() + " ";
                    }
                    gridList.Items.Add(output);
                }
            }
            else
            {
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
            gridList.TopIndex = topIndex;
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
            if (ShiftColumns)
            {
                int[] bestPair = new int[Columns];
                int[] bestShift = new int[Columns];
                long lowestScore = long.MaxValue;
                int lowestIndex = 0;
                for (int currentColumn = 0; currentColumn < Columns; currentColumn++)
                {
                    long[,] columnScores = new long[Columns, Rows];

                    // Iterate through each shift
                    for (int currentShift = 0; currentShift < Rows; currentShift++)
                    {
                        // Iterate through each row for the column
                        for (int currentRow = 0; currentRow < Rows; currentRow++)
                        {
                            // Compare it to other columns
                            for (int testColumn = 0; testColumn < Columns; testColumn++)
                            {
                                // Check not same column
                                if (testColumn == currentColumn)
                                    continue;

                                // Collect bigram
                                string bigram = mainGrid[currentColumn][(currentRow + currentShift) % Rows].ToString() + mainGrid[testColumn][currentRow].ToString();
                                // Add score of bigram
                                columnScores[testColumn, currentShift] += BigramsData.GetFrequency(bigram);
                            }
                        }
                    }

                    // Calculate the highest matching column and shift
                    int highestIndex = 0;
                    int highestShift = 0;
                    for (int shift = 0; shift < Rows; shift++)
                    {
                        for (int col = 0; col < Columns; col++)
                        {
                            if (columnScores[col, shift] > columnScores[highestIndex, highestShift])
                            {
                                highestIndex = col;
                                highestShift = shift;
                            }
                        }
                    }

                    // Change the best column
                    bestPair[currentColumn] = highestIndex;
                    bestShift[currentColumn] = highestShift;
                    // Check if lowest scoring match
                    if (columnScores[highestIndex, highestShift] < lowestScore)
                    {
                        lowestScore = columnScores[highestIndex, highestShift];
                        lowestIndex = currentColumn;
                    }
                }

                BestPair = bestPair;
                BestShift = bestShift;
                LowestIndex = lowestIndex;
            }
            else
            {
                int[] bestPair = new int[Columns];
                long lowestScore = long.MaxValue;
                int lowestIndex = 0;
                for (int currentColumn = 0; currentColumn < Columns; currentColumn++)
                {
                    long[] columnScores = new long[Columns];
                    // Iterate through each row for the column
                    for (int currentRow = 0; currentRow < Rows; currentRow++)
                    {
                        // Compare it to other columns
                        for (int testColumn = 0; testColumn < Columns; testColumn++)
                        {
                            // Check not same column
                            if (testColumn == currentColumn)
                                continue;

                            // Collect bigram
                            string bigram = mainGrid[currentColumn][currentRow].ToString() + mainGrid[testColumn][currentRow].ToString();
                            // Add score of bigram
                            columnScores[testColumn] += BigramsData.GetFrequency(bigram);
                        }
                    }

                    // Calculate the highest matching column
                    int highestIndex = 0;
                    for (int i = 1; i < Columns; i++)
                    {
                        if (columnScores[i] > columnScores[highestIndex])
                            highestIndex = i;
                    }

                    // Change the best column
                    bestPair[currentColumn] = highestIndex;
                    // Check if lowest scoring match
                    if (columnScores[highestIndex] < lowestScore)
                    {
                        lowestScore = columnScores[highestIndex];
                        lowestIndex = currentColumn;
                    }
                }

                BestPair = bestPair;
                LowestIndex = lowestIndex;
            }

            if (generate)
                GenerateBestPairOutput();
        }
        private void RecalculateBestPairs(int s1, int s2)
        {
            // Check if switch lowest index
            if (LowestIndex == s1)
                LowestIndex = s2;
            else if (LowestIndex == s2)
                LowestIndex = s1;

            // Switch best shift values
            if (ShiftColumns)
            {
                int shifttemp = BestShift[s1];
                BestShift[s1] = BestShift[s2];
                BestShift[s2] = shifttemp;
            }

            // Switch best pair values
            int temp = BestPair[s1];
            BestPair[s1] = BestPair[s2];
            BestPair[s2] = temp;

            // Switch any references to the included columns
            for (int col = 0; col < Columns; col++)
            {
                if (BestPair[col] == s1)
                    BestPair[col] = s2;
                else if (BestPair[col] == s2)
                    BestPair[col] = s1;
            }
            
        }
        private void RecalculateBestShift(int col, int shift)
        {
            BestShift[col] -= shift;
            if (BestShift[col] < 0)
                BestShift[col] += Rows;
            BestShift[col] %= Rows;
        }
        private void GenerateBestPairOutput()
        {
            string output = "";
            for (int i = 0; i < Columns; i++)
            {
                if (ShiftColumns)
                    output += $"Column {i + 1} has best match of column {BestPair[i] + 1} with shift {BestShift[i]}\r\n";
                else
                    output += $"Column {i + 1} has best match of column {BestPair[i] + 1}\r\n";
            }
            output += $"Most likly to be last column: {LowestIndex + 1}";

            if (LikelyPairsOutput.IsDisposed)
                LikelyPairsOutput = new TextOutputFrm();

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
            if (outputMethodBx.SelectedIndex == 1)
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

        private void shiftBtn_Click(object sender, EventArgs e)
        {
            Shift((int)shiftValueNum.Value, (int)selectedColumnNum.Value);
        }
        private void Shift(int s, int column, bool print = true)
        {
            char[] newColumn = new char[Rows];
            int shift = s;
            if (shift < 0)
                shift += Rows;
            for (int i = 0; i < Rows; i++)
            {
                newColumn[i] = mainGrid[column - 1][(i + shift) % Rows];
            }
            for (int i = 0; i < Rows; i++)
            {
                mainGrid[column - 1][i] = newColumn[i];
            }
            RecalculateBestShift(column - 1, shift);
            if (print)
            {
                PrintGrid();
                GenerateBestPairOutput();
            }
        }
        private void Shift(int s, int column, ref List<char[]> grid)
        {
            char[] newColumn = new char[Rows];
            int shift = s;
            if (shift < 0)
                shift += Rows;
            for (int i = 0; i < Rows; i++)
            {
                newColumn[i] = grid[column][(i + shift) % Rows];
            }
            for (int i = 0; i < Rows; i++)
            {
                grid[column][i] = newColumn[i];
            }
        }

        private void GridOutput_FormClosing(object sender, FormClosingEventArgs e)
        {
            LikelyPairsOutput.Close();
        }

        public bool AutoSolve(out string output, OutputMethod outputMessage = null)
        {
            outputMessage($"Attempting to solve grid with {Rows} rows and {Columns} columns");
            output = "";
            int lastColumn = -1;
            int[] pointers = new int[Columns];
            for (int i = 0; i < Columns; i++)
            {
                pointers[i] = -1;
            }

            outputMessage("Finding matches for columns");
            for (int i = 0; i < Columns; i++)
            {
                bool found = false;
                for (int j = 0; j < Columns; j++)
                {
                    if (i == j)
                        continue;
                    float score = CalculateColumnsBigramValue(i, j);
                    if(score >= BigramsData.EXPECTED_ENGLISH_AVERAGE)
                    {
                        if (found)
                        {
                            outputMessage($"Duplicate match found for column {i}");
                            outputMessage($"Unable to solve");
                            return false;
                        }
                        for (int k = 0; k < Columns; k++)
                        {
                            if (pointers[k] == j)
                            {
                                outputMessage($"Duplicate match found for column {i} and column {k}");
                                outputMessage($"Unable to solve");
                                return false;
                            }
                        }
                        outputMessage($"Found match for column {i}");
                        pointers[i] = j;
                        found = true;
                    }
                }

                if (!found)
                {
                    if (lastColumn != -1)
                    {
                        outputMessage($"Unable to find match for column {i}");
                        outputMessage($"Unable to solve");
                        return false;
                    }
                    outputMessage($"Column {i} is suspected to be the last column");
                    lastColumn = i;
                }
            }

            outputMessage($"All column matches found");
            outputMessage($"Attempting to order matches");

            int[] orderedColumns = new int[Columns];
            orderedColumns[Columns - 1] = lastColumn;

            outputMessage($"Putting column {lastColumn} in position {Columns - 1}");

            for (int i = Columns - 2; i >= 0; i--)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (orderedColumns[i + 1] == -1)
                    {
                        outputMessage($"Unable to find column for position {i + 1}");
                        return false;
                    }
                    if(pointers[j] == orderedColumns[i + 1])
                    {
                        outputMessage($"Putting column {j} in position {i}");
                        orderedColumns[i] = j;
                        break;
                    }    
                }
            }
            if (orderedColumns[0] == -1)
            {
                outputMessage($"Unable to find column for position 0");
                return false;
            }

            outputMessage("Matching columns have been ordered");
            outputMessage("Compiling message");

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    output += mainGrid[orderedColumns[j]][i];
                }
            }

            outputMessage($"Message compiled");
            return true;
        }

        private int CalculateColumnsBigramValue(int col1, int col2)
        {
            long total = 0;
            for (int i = 0; i < Rows; i++)
            {
                total += BigramsData.GetFrequency(mainGrid[col1][i].ToString() + mainGrid[col2][i].ToString());
            }
            return (int)Math.Floor(total / (double)Rows);
        }
    }
}
