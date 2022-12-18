using DumbCodeYe.Bigrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Transposition
{
    public partial class CrackDoubleTools : Form
    {
        private string MainText = "";
        private string Mode = "FULL QUAD";
        private int[] primaryFactors = {  };
        private int[] secondaryFactors = {  };
        private List<string> CiphersToTest;
        private const long ExpectedBigramValue = 1700000000;
        public CrackDoubleTools()
        {
            InitializeComponent();
        }
        public void Setup(string text)
        {
            MainText = text;
        }

        private void doubleBtn_Click(object sender, EventArgs e)
        {
            List<int> factors = new List<int>();
            foreach (string s in TestFactors.Text.Split(' '))
            {
                try
                {
                    factors.Add(int.Parse(s));
                }
                catch
                {
                    return;
                }
            }
            if (factors.Count == 0)
                return;

            if (calculationList.CheckedItems.Count == 0)
                return;
            Mode = calculationList.CheckedItems[0].ToString();

            primaryFactors = factors.ToArray();
            secondaryFactors = factors.ToArray();

            List<Thread> CipherThreads = new List<Thread>();
            foreach (var s in firstPassList.CheckedItems)
            {
                switch (s.ToString())
                {
                    case "BASIC KEYWORD":
                        CipherThreads.Add(new Thread(() => BasicKeywordPermutations()));
                        break;
                    case "COLUMNAR":
                        CipherThreads.Add(new Thread(() => ColumnarPermutations()));
                        break;
                    case "ROW COLUMNAR":
                        CipherThreads.Add(new Thread(() => RowColumnarPermutations()));
                        break;
                    case "ROUTE":
                        CipherThreads.Add(new Thread(() => RoutePermutations()));
                        break;
                    case "RAILFENCE":
                        CipherThreads.Add(new Thread(() => RailFencePermutations()));
                        break;
                    case "SCYLATE":
                        CipherThreads.Add(new Thread(() => ScylatePermutations()));
                        break;
                    case "REVERSE":
                        CipherThreads.Add(new Thread(() => ReversePermutations()));
                        break;
                }
            }
            CiphersToTest = new List<string>();
            foreach (var s in secondPassList.CheckedItems)
            {
                CiphersToTest.Add(s.ToString());
            }
            foreach (Thread t in CipherThreads)
            {
                t.Start();
            }
            foreach (Thread t in CipherThreads)
            {
                t.Join();
            }
        }

        public int Factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }
        private void CreateOutput(string primary, string secondary)
        {
            string output = $"{primary}\n->\n{secondary}";
            File.Create($"output/{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}.txt").Close();
            File.WriteAllText($"output/{DateTime.Now.Day}-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}.txt", output);
        }

        //
        // Char edits
        //

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

        //
        // General string edits
        //

        private string Reverse(string input)
        {
            string output = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }

        //
        // ROUTES
        //

        private List<string> CreateRoute(string text, int columns)
        {
            List<string> output = new List<string>()
            {
                TopLeftRoute(text, columns),
                TopRightRoute(text, columns),
                BottomRightRoute(text, columns),
                BottomLeftRoute(text, columns),
                TopLeftRouteReversed(text, columns),
                TopRightRouteReversed(text, columns),
                BottomRightRouteReversed(text, columns),
                BottomLeftRouteReversed(text, columns)
            };
            return output;
        }
        private string TopLeftRoute(string text, int columns)
        {
            string reversed = Reverse(text);
            char[,] grid = new char[text.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = text.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < text.Length)
            {
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= text.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, text.Length / columns, columns, true);
            return GO.GetOutput();
        }
        private string TopRightRoute(string text, int columns)
        {
            string reversed = Reverse(text);
            char[,] grid = new char[text.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = text.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < text.Length)
            {
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= text.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, text.Length / columns, columns, true);
            return GO.GetOutput();
        }
        private string BottomRightRoute(string text, int columns)
        {
            string reversed = Reverse(text);
            char[,] grid = new char[text.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = text.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < text.Length)
            {
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= text.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, text.Length / columns, columns, true);
            return GO.GetOutput();
        }
        private string BottomLeftRoute(string text, int columns)
        {
            string reversed = Reverse(text);
            char[,] grid = new char[text.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = text.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < text.Length)
            {
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= text.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, text.Length / columns, columns, true);
            return GO.GetOutput();
        }
        private string TopLeftRouteReversed(string text, int columns)
        {
            string reversed = Reverse(text);
            char[,] grid = new char[text.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = text.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < text.Length)
            {
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, leftBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[lowerBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, rightBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[upperBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= text.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, text.Length / columns, columns, true);
            return GO.GetOutput();
        }
        private string TopRightRouteReversed(string text, int columns)
        {
            string reversed = Reverse(text);
            char[,] grid = new char[text.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = text.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < text.Length)
            {
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[upperBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, leftBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[lowerBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, rightBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= text.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, text.Length / columns, columns, true);
            return GO.GetOutput();
        }
        private string BottomRightRouteReversed(string text, int columns)
        {
            string reversed = Reverse(text);
            char[,] grid = new char[text.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = text.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < text.Length)
            {
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, rightBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[upperBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, leftBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[lowerBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= text.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, text.Length / columns, columns, true);
            return GO.GetOutput();
        }
        private string BottomLeftRouteReversed(string text, int columns)
        {
            string reversed = Reverse(text);
            char[,] grid = new char[text.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = text.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < text.Length)
            {
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[lowerBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, rightBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= text.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[upperBound, i] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= text.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, leftBound] = text[letterIndex];
                    letterIndex++;
                    if (letterIndex >= text.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= text.Length)
                    break;
            }
            GridOutput GO = new GridOutput();
            GO.Setup(grid, text.Length / columns, columns, true);
            return GO.GetOutput();
        }

        //
        // Create grids
        //

        private char[,] CreateColumnar(string input, int columns)
        {
            char[,] grid = CreateRowColumnar(MainText, columns);
            return grid;
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

        //
        // Permutations
        //

        private void SecondaryPermutations(List<string> permutations, ProgressBarForm PBF, int currentTask, int totalTasks, string outputMsg)
        {
            for (int i = 0; i < permutations.Count; i++)
            {
                PBF.loadingBar.Value = (int)Math.Floor((float)currentTask * 100 / totalTasks);
                PBF.status.Text = $"{currentTask} / {totalTasks}";
                PBF.Invalidate();
                PBF.Refresh();
                currentTask++;

                if (CiphersToTest.Contains("BASIC KEYWORD"))
                {
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateBasicKeyword(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        if(Mode == "KNOWN START" || Mode == "KNOWN END")
                            GridContainsText(sGO, sgrid, permutations, sf, i, outputMsg, $"BASIC KEYWORD WITH COLUMNS {secondaryFactors[sf]}");
                        else if(Mode == "VALID BIGRAMS")
                        {
                            if(sGO.GetAveragePointer() <= 1.05f)
                            {
                                CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"BASIC KEYWORD WITH COLUMNS {secondaryFactors[sf]}");
                                //GridOutput GO = new GridOutput();
                                //GO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                                //GO.Show();
                            }
                        }
                    }
                }
                if (CiphersToTest.Contains("COLUMNAR"))
                {
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateColumnar(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        if (Mode == "KNOWN START" || Mode == "KNOWN END")
                            GridContainsText(sGO, sgrid, permutations, sf, i, $"{outputMsg} OUTPUT: {permutations[i]}", $"COLUMNAR WITH COLUMNS {secondaryFactors[sf]}");
                        else if (Mode == "VALID BIGRAMS")
                        {
                            if (sGO.GetAveragePointer() <= 1.05f)
                            {
                                CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"COLUMNAR WITH COLUMNS {secondaryFactors[sf]}");
                            }
                        }
                    }
                }
                if (CiphersToTest.Contains("ROW COLUMNAR"))
                {
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        char[,] sgrid = CreateRowColumnar(permutations[i], secondaryFactors[sf]);
                        GridOutput sGO = new GridOutput();
                        sGO.Setup(sgrid, permutations[i].Length / secondaryFactors[sf], secondaryFactors[sf]);
                        if (Mode == "KNOWN START" || Mode == "KNOWN END")
                            GridContainsText(sGO, sgrid, permutations, sf, i, $"{outputMsg} OUTPUT: {permutations[i]}", $"BASIC KEYWORD WITH COLUMNS {secondaryFactors[sf]}");
                        else if (Mode == "VALID BIGRAMS")
                        {
                            if (sGO.GetAveragePointer() <= 1.05f)
                            {
                                CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"BASIC KEYWORD WITH COLUMNS {secondaryFactors[sf]}");
                            }
                        }
                    }
                }

                if (CiphersToTest.Contains("ROUTE"))
                {
                    for (int sf = 0; sf < secondaryFactors.Length; sf++)
                    {
                        List<string> routes = CreateRoute(permutations[i], secondaryFactors[sf]);
                        foreach(string s in routes)
                        {
                            if (Mode == "KNOWN START" || Mode == "KNOWN END")
                            {
                                if (RailContainsText(s))
                                {
                                    CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"ROUTE WITH COLUMNS {secondaryFactors[sf]}");
                                }
                            }
                            else if(Mode == "VALID BIGRAMS")
                            {
                                if(BigramsData.GetAverageValue(s) >= ExpectedBigramValue)
                                {
                                    CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"ROUTE WITH COLUMNS {secondaryFactors[sf]}");
                                }
                            }
                        }
                    }
                }

                if (CiphersToTest.Contains("RAILFENCE"))
                {
                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateRailfence(permutations[i], srail);
                        if (Mode == "KNOWN START" || Mode == "KNOWN END")
                        {
                            if (RailContainsText(output))
                            {
                                CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"RAILFENCE WITH RAILS {srail}");
                            }
                            else if (Mode == "VALID BIGRAMS")
                            {
                                if (BigramsData.GetAverageValue(output) >= ExpectedBigramValue)
                                {
                                    CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"RAILFENCE WITH RAILS {srail}");
                                }
                            }
                        }
                    }
                }
                if (CiphersToTest.Contains("SCYLATE"))
                {
                    for (int srail = 2; srail <= 12; srail++)
                    {
                        string output = CreateScylate(permutations[i], srail);
                        if (Mode == "KNOWN START" || Mode == "KNOWN END")
                        {
                            if (RailContainsText(output))
                            {
                                CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"SCYLATE WITH RAILS {srail}");
                            }
                        }
                        else if (Mode == "VALID BIGRAMS")
                        {
                            if (BigramsData.GetAverageValue(output) >= ExpectedBigramValue)
                            {
                                CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"SCYLATE WITH RAILS {srail}");
                            }
                        }
                    }
                }
                if (CiphersToTest.Contains("REVERSE"))
                {
                    string output = Reverse(permutations[i]); 
                    if (Mode == "KNOWN START" || Mode == "KNOWN END")
                    {
                        if (RailContainsText(output))
                        {
                            CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"REVERSE");
                        }
                    }
                    else if (Mode == "VALID BIGRAMS")
                    {
                        if (BigramsData.GetAverageValue(output) >= ExpectedBigramValue)
                        {
                            CreateOutput($"{outputMsg} OUTPUT: {permutations[i]}", $"REVERSE");
                        }
                    }
                }
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
                SecondaryPermutations(permutations, PBF, currentTask, totalTasks, $"BASIC KEYWORD WITH COLUMNS {primaryFactors[pf]}");
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
                SecondaryPermutations(permutations, PBF, currentTask, totalTasks, $"COLUMNAR WITH COLUMNS {primaryFactors[pf]}");
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
                SecondaryPermutations(permutations, PBF, currentTask, totalTasks, $"ROW COLUMNAR WITH COLUMNS {primaryFactors[pf]}");
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
                SecondaryPermutations(permutations, PBF, currentTask, totalTasks, $"RAILFENCE WITH RAILS {rail}");
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
                SecondaryPermutations(permutations, PBF, currentTask, totalTasks, $"SCYLATE WITH RAILS {rail}");
            }
        }
        private void RoutePermutations()
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
                List<string> permutations = CreateRoute(MainText, primaryFactors[pf]);
                SecondaryPermutations(permutations, PBF, currentTask, totalTasks, $"ROUTE WITH COLUMNS {primaryFactors[pf]}");
            }
        }
        private void ReversePermutations()
        {
            int currentTask = 0;
            int totalTasks = 1;
            ProgressBarForm PBF = new ProgressBarForm();
            PBF.Show();
            List<string> permutations = new List<string>() { Reverse(MainText) };
            SecondaryPermutations(permutations, PBF, currentTask, totalTasks, $"REVERSE");
        }

        //
        // Checks
        //


        private void GridContainsText(GridOutput sGO, char[,] sgrid, List<string> permutations, int sf, int i, string outputMsgPrimary, string outputMsgSecondary)
        {
            string output = sGO.GetOutput();
            int charactersRead = 0;
            while (charactersRead <= 15)
            {
                charactersRead += secondaryFactors[sf];
            }
            string testString = "";
            if(Mode == "KNOWN START")
                testString = output.Substring(0, charactersRead);
            else if(Mode == "KNOWN END")
                testString = output.Substring(output.Length - charactersRead - 1);
            List<char> remainingChars = new List<char>(KnownText.Text);
            for (int j = 0; j < testString.Length; j++)
            {
                if (remainingChars.Contains(testString[j]))
                    remainingChars.Remove(testString[j]);
            }
            if (remainingChars.Count == 0)
            {
                CreateOutput(outputMsgPrimary, outputMsgSecondary);
            }
        }
        private bool RailContainsText(string text)
        {
            string testString = "";
            if (Mode == "KNOWN START")
                testString = text.Substring(0, 15);
            else if(Mode == "KNOWN END") 
                testString = text.Substring(text.Length - 16);
            return testString == KnownText.Text;
        }
    }
}
