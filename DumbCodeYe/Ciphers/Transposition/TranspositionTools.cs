using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Transposition
{
    public enum TranspositionType
    {
        BasicKeyword,
        RowColumnar
    }
    public partial class TranspositionTools : Form
    {
        string MainText = ""; 
        private string[] CommonWords = { "be", "to", "of", "in", "it", "on", "he", "as", "do", "at", "by", "we", "or", "an", "no", "the", "and", "for", "not", "you", "but", "his", "say", "her", "she", "one", "all", "yes", "one", "two", "six", "ten", "sad", "can", "that", "have", "with", "this", "from", "they", "will", "word", "what", "were", "when", "which", "would", "could", "these" };
        private ExpectedWords EW;

        int[] primaryFactors = { 2, 5, 10, 13 };
        int[] secondaryFactors = { 2, 5, 10, 13 };
        public TranspositionTools()
        {
            InitializeComponent();
            EW = new ExpectedWords();
        }
        public void Setup(string input)
        {
            foreach (char c in input)
            {
                if (GeneralConstants.CAPITALS.Contains(c))
                    MainText += c;
            }
        }

        private void expectedBtn_Click(object sender, EventArgs e)
        {
            EW.Show();
        }
        private void rowColumnBtn_Click(object sender, EventArgs e)
        {
            TryRowColumnTransposition();
        }
        private void rowColumnarBtn_Click(object sender, EventArgs e)
        {
            TryRowColumnarTransposition();
        }

        private void TryRowColumnTransposition()
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 1; i <= MainText.Length; i++)
            {
                if (MainText.Length % i == 0)
                {
                    rows.Add(i);
                    columns.Add(MainText.Length / i);
                }
            }

            int highestScore = int.MinValue;
            string highestText = "";
            for (int i = 0; i < rows.Count; i++)
            {
                string newText = RowColumnTransposition(MainText, rows[i], columns[i]);
                int score = CalculateTranspositionScore(newText);
                if (score > highestScore)
                {
                    highestScore = score;
                    highestText = newText;
                }
            }
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(highestText);
            txtOut.Show();
        }
        private string RowColumnTransposition(string text, int rows, int columns)
        {
            char[,] grid = new char[rows, columns];
            int currentIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    grid[row, column] = text[currentIndex];
                    currentIndex++;
                }
            }
            string newText = "";
            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    newText += grid[row, column].ToString().ToLower();
                }
            }
            return newText;
        }
        private int CalculateTranspositionScore(string text)
        {
            int score = 0;
            for (int i = 0; i < text.Length; i++)
            {
                foreach (string word in CommonWords)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (j + i >= text.Length)
                            break;
                        if (word[j] != text[i + j])
                            break;
                        if (j == word.Length - 1)
                            score++;
                    }
                }
            }
            return score;
        }

        private void TryRowColumnarTransposition()
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 1; i <= MainText.Length; i++)
            {
                if (MainText.Length % i == 0)
                {
                    columns.Add(i);
                    rows.Add(MainText.Length / i);
                }
            }

            string[] ExpectedWords = EW.expectedText.Text.Split('\n');

            int highestScore = int.MinValue;
            char[,] highestGrid = null;
            int highestRow = 0;
            int highestColumn = 0;
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i] > maxColumns.Value)
                    break;
                char[,] grid = new char[rows[i], columns[i]];
                int currentIndex = 0;
                for (int column = 0; column < columns[i]; column++)
                {
                    for (int row = 0; row < rows[i]; row++)
                    {
                        grid[row, column] = MainText[currentIndex];
                        currentIndex++;
                    }
                }

                int score = 0;
                foreach (string word in ExpectedWords)
                {
                    for (int row = 0; row < rows[i]; row++)
                    {
                        for (int column = 0; column < columns[i]; column++)
                        {
                            if(word.Contains(grid[row, column]))
                            {
                                List<char> remainingWord = new List<char>();
                                foreach(char c in word)
                                {
                                    remainingWord.Add(c);
                                }
                                for (int _column = column; _column < columns[i]; _column++)
                                {
                                    if (remainingWord.Contains(grid[row, _column]))
                                        remainingWord.Remove(grid[row, _column]);
                                }
                                if (remainingWord.Count == 0)
                                    score++;
                            }
                        }
                    }
                }
                if(score > highestScore)
                {
                    highestGrid = grid;
                    highestScore = score;
                    highestRow = rows[i];
                    highestColumn = columns[i];
                }
            }

            GridOutput GO = new GridOutput();
            GO.Setup(highestGrid, highestRow, highestColumn);
            GO.Show();
        }
        private char[,] CreateRowColumnar(string input, int columns)
        {
            int rows = input.Length / columns;
            char[,] grid = new char[rows, columns];
            int currentIndex = 0;
            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    grid[row, column] = MainText[currentIndex];
                    currentIndex++;
                }
            }
            return grid;
        }

        private void basicKeywordBtn_Click(object sender, EventArgs e)
        {
            int columns = (int)columnsNum.Value;
            int rows = (int)Math.Ceiling((decimal)MainText.Length / columns);
            char[,] grid = new char[rows, columns];
            int index = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    grid[r, c] = MainText[index];
                    index++;
                }
            }

            GridOutput GO = new GridOutput();
            GO.Setup(grid, rows, columns);
            GO.Show();
        }

        private char[,] CreateBasicKeyword(string input, int columns)
        {
            int rows = (int)Math.Ceiling((decimal)input.Length / columns);
            char[,] grid = new char[rows, columns];
            int index = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    grid[r, c] = MainText[index];
                    index++;
                }
            }
            return grid;
        }

        private void factorsBtn_Click(object sender, EventArgs e)
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 1; i <= MainText.Length; i++)
            {
                if (MainText.Length % i == 0)
                {
                    rows.Add(i);
                    columns.Add(MainText.Length / i);
                }
            }

            string factors = "";
            for (int i = 0; i < rows.Count; i++)
            {
                factors += $"{rows[i]}, {columns[i]}\r\n";
            }

            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(factors);
            tof.Show();
        }

        private void railfenceBtn_Click(object sender, EventArgs e)
        {
            int rails = (int)Math.Floor(railsNum.Value);
            char[,] grid = new char[rails, MainText.Length];
            int index = 0;
            int offset = 0;
            bool increasingOffset = true;
            int maxIncrease = (rails - 1) * 2;
            for (int r = 0; r < rails; r++)
            {
                int remainSpace = maxIncrease;
                for (int c = offset; c < MainText.Length;)
                {
                    grid[r, c] = MainText[index];
                    index++;
                    if (remainSpace < maxIncrease)
                    {
                        c += remainSpace;
                        remainSpace = maxIncrease;
                    }
                    else
                    {
                        c += maxIncrease - offset * 2;
                        remainSpace -= maxIncrease - offset * 2;
                        if (remainSpace == maxIncrease)
                            c += maxIncrease;
                        if (remainSpace == 0)
                            remainSpace = maxIncrease;
                    }
                }
                if (increasingOffset)
                {
                    offset++;
                    if (offset == rails - 1)
                        increasingOffset = false;
                }
                else
                {
                    offset--;
                    if (offset == 0)
                        increasingOffset = true;
                }
            }
            int rail = 0;
            bool increasingRail = true;
            string finalText = "";
            for (int i = 0; i < MainText.Length; i++)
            {
                finalText += grid[rail, i];
                if (increasingRail)
                {
                    rail++;
                    if (rail == rails - 1)
                        increasingRail = false;
                }
                else
                {
                    rail--;
                    if (rail == 0)
                        increasingRail = true;
                }
            }

            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(finalText);
            tof.Show();
        }

        private string CreateRailfence(string input, int rails)
        {
            char[,] grid = new char[rails, input.Length];
            int index = 0;
            int offset = 0;
            bool increasingOffset = true;
            int maxIncrease = (rails - 1) * 2;
            for (int r = 0; r < rails; r++)
            {
                int remainSpace = maxIncrease;
                for (int c = offset; c < input.Length;)
                {
                    grid[r, c] = input[index];
                    index++;
                    if (remainSpace < maxIncrease)
                    {
                        c += remainSpace;
                        remainSpace = maxIncrease;
                    }
                    else
                    {
                        c += maxIncrease - offset * 2;
                        remainSpace -= maxIncrease - offset * 2;
                        if (remainSpace == maxIncrease)
                            c += maxIncrease;
                        if (remainSpace == 0)
                            remainSpace = maxIncrease;
                    }
                }
                if (increasingOffset)
                {
                    offset++;
                    if (offset == rails - 1)
                        increasingOffset = false;
                }
                else
                {
                    offset--;
                    if (offset == 0)
                        increasingOffset = true;
                }
            }
            int rail = 0;
            bool increasingRail = true;
            string finalText = "";
            for (int i = 0; i < input.Length; i++)
            {
                finalText += grid[rail, i];
                if (increasingRail)
                {
                    rail++;
                    if (rail == rails - 1)
                        increasingRail = false;
                }
                else
                {
                    rail--;
                    if (rail == 0)
                        increasingRail = true;
                }
            }
            return finalText;
        }

        private void scytaleBtn_Click(object sender, EventArgs e)
        {
            int rails = (int)Math.Floor(railsNum.Value);
            char[,] grid = new char[rails, MainText.Length];
            int index = 0; 
            for (int r = 0; r < rails; r++)
            { 
                for (int c = r; c < MainText.Length; c += rails)
                {
                    grid[r, c] = MainText[index];
                    index++;
                }
            }

            int rail = 0;
            string finalText = "";
            for (int i = 0; i < MainText.Length; i++)
            {
                finalText += grid[rail, i];
                rail++;
                if (rail == rails)
                    rail = 0;
            }

            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(finalText);
            tof.Show();
        }
        private string CreateScylate(string input, int rails)
        {
            char[,] grid = new char[rails, input.Length];
            int index = 0;
            for (int r = 0; r < rails; r++)
            {
                for (int c = r; c < input.Length; c += rails)
                {
                    grid[r, c] = input[index];
                    index++;
                }
            }

            int rail = 0;
            string finalText = "";
            for (int i = 0; i < input.Length; i++)
            {
                finalText += grid[rail, i];
                rail++;
                if (rail == rails)
                    rail = 0;
            }
            return finalText;
        }

        private void getSubstringBtn_Click(object sender, EventArgs e)
        {
            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(MainText.Substring((int)substringIndexNum.Value, (int)substringLengthNum.Value));
            tof.Show();
        }

        private void applyTranspositionBtn_Click(object sender, EventArgs e)
        {
            List<string> splittedText = new List<string>();
            string outputString = "";
            for (int i = 0; i < MainText.Length / substringLengthNum.Value; i++)
            {
                splittedText.Add(MainText.Substring((int)substringLengthNum.Value * i, (int)substringLengthNum.Value));
                outputString += MainText.Substring((int)substringLengthNum.Value * i, (int)substringLengthNum.Value) + "\r\n";
            }
            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(outputString);
            tof.Show();
        }

        private void doubleBtn_Click(object sender, EventArgs e)
        {
            // FOR EACH CIPHER
            // TRANSPOSE WITH FIRST CIPHER
            // PERMUTATE EVERY KEYWORD
            // FOR EACH CIPHER
            // TRANSPOSE WITH SECOND CIPHER
            // CHECK IF POSSIBLE

            List<int> factors = new List<int>();
            foreach(string s in TestFactors.Text.Split(' '))
            {
                factors.Add(int.Parse(s));
            }

            primaryFactors = factors.ToArray();
            secondaryFactors = factors.ToArray();

            Thread[] CipherThreads = new Thread[]
            {
                new Thread(() => BasicKeywordPermutations()),
                new Thread(() => RowColumnarPermutations()),
                new Thread(() => ColumnarPermutations()),
                //new Thread(() => RailFencePermutations()),
                //new Thread(() => ScylatePermutations())
            };
            foreach(Thread t in CipherThreads)
            {
                t.Start();
            }
            foreach (Thread t in CipherThreads)
            {
                t.Join();
            }
        }
        private void BasicKeywordPermutations()
        {
            int currentTask = 0;
            int totalTasks = 0;
            ProgressBarForm PBF = new ProgressBarForm();
            PBF.Show();
            for (int i = 0; i < primaryFactors.Length; i++)
            {
                totalTasks += Factorial(primaryFactors[i]);
            }
            for (int pf = 0; pf < primaryFactors.Length; pf++)
            {
                char[,] pgrid = CreateBasicKeyword(MainText, primaryFactors[pf]);
                GridOutput pGO = new GridOutput();
                pGO.Setup(pgrid, MainText.Length / primaryFactors[pf], primaryFactors[pf]);
                List<string> permutations = pGO.GetAllPermutations();

                for (int i = 0; i < permutations.Count; i++)
                {
                    PBF.loadingBar.Value = (int)Math.Floor((float)currentTask * 100 / totalTasks);
                    PBF.status.Text = $"{currentTask} / {totalTasks}";
                    PBF.Invalidate();
                    PBF.Refresh();
                    currentTask++;

                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateBasicKeyword(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateRowColumnar(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }

                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateRailfence(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateScylate(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                }
            }
        }
        private void RowColumnarPermutations()
        {
            int currentTask = 0;
            int totalTasks = 0;
            ProgressBarForm PBF = new ProgressBarForm();
            PBF.Show();
            for (int i = 0; i < primaryFactors.Length; i++)
            {
                totalTasks += Factorial(primaryFactors[i]);
            }
            for (int pf = 0; pf < primaryFactors.Length; pf++)
            {
                char[,] pgrid = CreateRowColumnar(MainText, primaryFactors[pf]);
                GridOutput pGO = new GridOutput();
                pGO.Setup(pgrid, MainText.Length / primaryFactors[pf], primaryFactors[pf]);
                List<string> permutations = pGO.GetAllPermutations();

                for (int i = 0; i < permutations.Count; i++)
                {
                    PBF.loadingBar.Value = (int)Math.Floor((float)currentTask * 100 / totalTasks);
                    PBF.status.Text = $"{currentTask} / {totalTasks}";
                    PBF.Invalidate();
                    PBF.Refresh();
                    currentTask++;

                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateBasicKeyword(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateRowColumnar(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }

                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateRailfence(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateScylate(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                }
            }
        }
        private void ColumnarPermutations()
        {
            int currentTask = 0;
            int totalTasks = 0;
            ProgressBarForm PBF = new ProgressBarForm();
            PBF.Show();
            for (int i = 0; i < primaryFactors.Length; i++)
            {
                totalTasks += Factorial(primaryFactors[i]);
            }
            for (int pf = 0; pf < primaryFactors.Length; pf++)
            {
                char[,] pgrid = CreateRowColumnar(MainText, primaryFactors[pf]);
                GridOutput pGO = new GridOutput();
                pGO.Setup(pgrid, MainText.Length / primaryFactors[pf], primaryFactors[pf]);
                List<string> permutations = pGO.GetAllPermutations();

                for (int i = 0; i < permutations.Count; i++)
                {
                    PBF.loadingBar.Value = (int)Math.Floor((float)currentTask * 100 / totalTasks);
                    PBF.status.Text = $"{currentTask} / {totalTasks}";
                    PBF.Invalidate();
                    PBF.Refresh();
                    currentTask++;

                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateBasicKeyword(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateRowColumnar(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }

                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateRailfence(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateScylate(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                }
            }
        }
        private void RailFencePermutations()
        {
            int currentTask = 0;
            int totalTasks = 12;
            ProgressBarForm PBF = new ProgressBarForm();
            PBF.Show();
            for (int rail = 2; rail <= 12; rail++)
            {
                List<string> permutations = new List<string>() { CreateRailfence(MainText, rail) };
                for (int i = 0; i < permutations.Count; i++)
                {
                    PBF.loadingBar.Value = (int)Math.Floor((float)currentTask * 100 / totalTasks);
                    PBF.status.Text = $"{currentTask} / {totalTasks}";
                    PBF.Invalidate();
                    PBF.Refresh();
                    currentTask++;

                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateBasicKeyword(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateRowColumnar(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }

                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateRailfence(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateScylate(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                }
            }
        }
        private void ScylatePermutations()
        {
            int currentTask = 0;
            int totalTasks = 12;
            ProgressBarForm PBF = new ProgressBarForm();
            PBF.Show();
            for (int rail = 2; rail <= 12; rail++)
            {
                List<string> permutations = new List<string>() { CreateScylate(MainText, rail) };
                for (int i = 0; i < permutations.Count; i++)
                {
                    PBF.loadingBar.Value = (int)Math.Floor((float)currentTask * 100 / totalTasks);
                    PBF.status.Text = $"{currentTask} / {totalTasks}";
                    PBF.Invalidate();
                    PBF.Refresh();
                    currentTask++;

                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateBasicKeyword(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateRowColumnar(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        GridContainsText(sGO, sgrid, permutations, sf, i);
                    }

                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateRailfence(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateScylate(permutations[i], srail);
                        if (RailContainsText(output))
                        {
                            TextOutputFrm TOF = new TextOutputFrm();
                            TOF.SetOutput(output);
                            TOF.Show();
                        }
                    }
                }
            }
        }

        private void GridContainsText(GridOutput sGO, char[,] sgrid, List<string> permutations, int sf, int i)
        {
            string output = sGO.GetOutput();
            int charactersRead = 0;
            while (charactersRead <= 15)
            {
                charactersRead += secondaryFactors[sf];
            }
            //string testString = output.Substring(output.Length - charactersRead - 1);
            string testString = output.Substring(0, charactersRead);
            List<char> remainingChars = new List<char>(KnownText.Text);
            for (int j = 0; j < testString.Length; j++)
            {
                if (remainingChars.Contains(testString[j]))
                    remainingChars.Remove(testString[j]);
            }
            if (remainingChars.Count == 0)
            {
                GridOutput GO = new GridOutput();
                GO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                GO.Show();
            }
        }
        private bool RailContainsText(string text)
        {
            //string testString = text.Substring(text.Length - 16);
            string testString = text.Substring(0, 15);
            return testString == KnownText.Text;
        }

        public int Factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        private void reverseBtn_Click(object sender, EventArgs e)
        {
            string output = "";
            for(int i = MainText.Length - 1; i >= 0; i--)
            {
                output += MainText[i];
            }
            TextOutputFrm TOF = new TextOutputFrm();
            TOF.SetOutput(output);
            TOF.Show();
        }
        private string Reverse(string input)
        {
            string output = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }

        private void columnarBtn_Click(object sender, EventArgs e)
        {
            char[,] grid = CreateRowColumnar(MainText, (int)maxColumns.Value);
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / (int)maxColumns.Value, (int)maxColumns.Value, true);
            GO.Show();
        }
        private char[,] CreateColumnar(string input, int columns)
        {
            char[,] grid = CreateRowColumnar(MainText, (int)maxColumns.Value);
            return grid;
        }

        private void routeBtn_Click(object sender, EventArgs e)
        {
            TopLeftRoute();
            TopRightRoute();
            BottomRightRoute();
            BottomLeftRoute();
            TopLeftRouteReversed();
            TopRightRouteReversed();
            BottomRightRouteReversed();
            BottomLeftRouteReversed();
        }
        private void TopLeftRoute()
        {
            int columns = (int)maxColumns.Value;
            string reversed = Reverse(MainText);
            char[,] grid = new char[MainText.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = MainText.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < MainText.Length)
            {
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= MainText.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / columns, columns, true);
            GO.Show();
        }
        private void TopRightRoute()
        {
            int columns = (int)maxColumns.Value;
            string reversed = Reverse(MainText);
            char[,] grid = new char[MainText.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = MainText.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < MainText.Length)
            {
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= MainText.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / columns, columns, true);
            GO.Show();
        }
        private void BottomRightRoute()
        {
            int columns = (int)maxColumns.Value;
            string reversed = Reverse(MainText);
            char[,] grid = new char[MainText.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = MainText.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < MainText.Length)
            {
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= MainText.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / columns, columns, true);
            GO.Show();
        }
        private void BottomLeftRoute()
        {
            int columns = (int)maxColumns.Value;
            string reversed = Reverse(MainText);
            char[,] grid = new char[MainText.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = MainText.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < MainText.Length)
            {
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= MainText.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / columns, columns, true);
            GO.Show();
        }
        private void TopLeftRouteReversed()
        {
            int columns = (int)maxColumns.Value;
            string reversed = Reverse(MainText);
            char[,] grid = new char[MainText.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = MainText.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < MainText.Length)
            {
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, leftBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[lowerBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, rightBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[upperBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= MainText.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / columns, columns, true);
            GO.Show();
        }
        private void TopRightRouteReversed()
        {
            int columns = (int)maxColumns.Value;
            string reversed = Reverse(MainText);
            char[,] grid = new char[MainText.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = MainText.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < MainText.Length)
            {
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[upperBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, leftBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[lowerBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, rightBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= MainText.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / columns, columns, true);
            GO.Show();
        }
        private void BottomRightRouteReversed()
        {
            int columns = (int)maxColumns.Value;
            string reversed = Reverse(MainText);
            char[,] grid = new char[MainText.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = MainText.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < MainText.Length)
            {
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, rightBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[upperBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, leftBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[lowerBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= MainText.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / columns, columns, true);
            GO.Show();
        }
        private void BottomLeftRouteReversed()
        {
            int columns = (int)maxColumns.Value;
            string reversed = Reverse(MainText);
            char[,] grid = new char[MainText.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = MainText.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < MainText.Length)
            {
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[lowerBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, rightBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[upperBound, i] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, leftBound] = MainText[letterIndex];
                    letterIndex++;
                    if (letterIndex >= MainText.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= MainText.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / columns, columns, true);
            GO.Show();
        }

        private void xBtn_Click(object sender, EventArgs e)
        {
            int x = (int)substringIndexNum.Value;
            int y = (int)substringLengthNum.Value;
            string output = "";
            while (x < MainText.Length) 
            {
                output += MainText[x];
                x += y;
            }
            TextOutputFrm TOF = new TextOutputFrm();
            TOF.SetOutput(output);
            TOF.Show();
        }
        private void groupBtn_Click(object sender, EventArgs e)
        {
            int letterIndex = 0;
            int length = (int)substringIndexNum.Value;
            string output1 = "";
            string output2 = "";
            
            while(letterIndex < MainText.Length)
            {
                for (int i = 0; i < length; i++)
                {
                    output1 += MainText[letterIndex];
                    letterIndex++;
                }
                if (letterIndex >= MainText.Length)
                    break;
                for (int i = 0; i < length; i++)
                {
                    output2 += MainText[letterIndex];
                    letterIndex++;
                }
            }

            TextOutputFrm TOF1 = new TextOutputFrm();
            TOF1.SetOutput(output1);
            TOF1.Show();
            TextOutputFrm TOF2 = new TextOutputFrm();
            TOF2.SetOutput(output2);
            TOF2.Show();
        }
        private void changeOtherBtn_Click(object sender, EventArgs e)
        {
            ChangeOtherBackwards();
            ChangeOtherFowards();
        }
        private void ChangeOtherBackwards()
        {
            string output = "";
            for (int i = 0; i < MainText.Length; i += 2)
            {
                int first = CharToInt(MainText[i]);
                int second = CharToInt(MainText[MainText.Length - 2 - i]);
                int difference = second - first;
                if (difference <= 0)
                    difference += 26;
                output += MainText[i].ToString() + IntToChar(difference).ToString();
            }
            TextOutputFrm TOF = new TextOutputFrm();
            TOF.SetOutput(output);
            TOF.Show();
        }
        private void ChangeOtherFowards()
        {
            string output = "";
            for (int i = 0; i < MainText.Length; i += 2)
            {
                int first = CharToInt(MainText[i]);
                int second = CharToInt(MainText[MainText.Length - 2 - i]);
                int difference = second + first;
                if (difference >= 26)
                    difference -= 26;
                output += MainText[i].ToString() + IntToChar(difference).ToString();
            }
            TextOutputFrm TOF = new TextOutputFrm();
            TOF.SetOutput(output);
            TOF.Show();
        }
        public int CharToInt(char c)
        {
            switch (c)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
                case 'D':
                    return 4;
                case 'E':
                    return 5;
                case 'F':
                    return 6;
                case 'G':
                    return 7;
                case 'H':
                    return 8;
                case 'I':
                    return 9;
                case 'J':
                    return 10;
                case 'K':
                    return 11;
                case 'L':
                    return 12;
                case 'M':
                    return 13;
                case 'N':
                    return 14;
                case 'O':
                    return 15;
                case 'P':
                    return 16;
                case 'Q':
                    return 17;
                case 'R':
                    return 18;
                case 'S':
                    return 19;
                case 'T':
                    return 20;
                case 'U':
                    return 21;
                case 'V':
                    return 22;
                case 'W':
                    return 23;
                case 'X':
                    return 24;
                case 'Y':
                    return 25;
                case 'Z':
                    return 26;
            }
            return 0;
        }
        public char IntToChar(int num)
        {
            switch (num)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
                case 5:
                    return 'E';
                case 6:
                    return 'F';
                case 7:
                    return 'G';
                case 8:
                    return 'H';
                case 9:
                    return 'I';
                case 10:
                    return 'J';
                case 11:
                    return 'K';
                case 12:
                    return 'L';
                case 13:
                    return 'M';
                case 14:
                    return 'N';
                case 15:
                    return 'O';
                case 16:
                    return 'P';
                case 17:
                    return 'Q';
                case 18:
                    return 'R';
                case 19:
                    return 'S';
                case 20:
                    return 'T';
                case 21:
                    return 'U';
                case 22:
                    return 'V';
                case 23:
                    return 'W';
                case 24:
                    return 'X';
                case 25:
                    return 'Y';
                case 26:
                    return 'Z';
            }
            return '.';
        }
        private void crackDoubleToolsBtn_Click(object sender, EventArgs e)
        {
            CrackDoubleTools CDT = new CrackDoubleTools();
            CDT.Setup(MainText);
            CDT.Show();
        }

        private void cadneusBtn_Click(object sender, EventArgs e)
        {
            char[,] grid = CreateBasicKeyword(MainText, (int)maxColumns.Value);
            GridOutput GO = new GridOutput();
            GO.Setup(grid, MainText.Length / (int)maxColumns.Value, (int)maxColumns.Value, false, true);
            GO.Show();
        }
    }
}
