using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Playfair
{
    public partial class Playfair5GridV2 : Form
    {
        private Random rand;
        private TextBox[,] Values;
        private float[] CharacterFrequency = new float[] { 0.082f, 0.015f, 0.028f, 0.043f, 0.127f, 0.022f, 0.020f, 0.061f, 0.070f, 0.002f, 0.008f, 0.040f, 0.024f, 0.067f, 0.075f, 0.019f, 0.001f, 0.060f, 0.063f, 0.091f, 0.028f, 0.010f, 0.024f, 0.002f, 0.020f, 0.001f };
        private string[] CommonWords = new string[] { "THE", "BE", "TO", "OF", "AND", "IN", "THAT", "HAVE", "IT", "FOR", "NOT", "ON", "WITH", "HE", "AS", "YOU", "DO", "AT", "THIS", "BUT", "HIS", "BY", "FROM", "THEY", "WE", "SAY", "HER" };
        private string[] PairFrequencyLetters = new string[] { "TH", "HE", "IN", "ER", "AN", "RE", "ES", "ON", "ST", "NT", "EN", "AT", "ED", "ND", "TO", "OR", "EA", "TI", "AR", "TE"};
        private float[] PairFrequencyScore = new float[] { 11.6f, 10.0f, 8.7f, 7.7f, 6.9f, 6.0f, 5.7f, 5.6f, 5.4f, 5.0f, 4.8f, 4.6f, 4.6f, 4.5f, 4.3f, 4.2f, 4.2f, 4.2f};
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        private string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public Playfair5GridV2()
        {
            InitializeComponent();
            rand = new Random();
            Values = new TextBox[5, 5]
            {
                {Value11, Value12, Value13, Value14, Value15},
                {Value21, Value22, Value23, Value24, Value25},
                {Value31, Value32, Value33, Value34, Value35},
                {Value41, Value42, Value43, Value44, Value45},
                {Value51, Value52, Value53, Value54, Value55}
            };
        }
        public void BeginGrind(string inputText, int max, bool resartLetters, MovementMode horizontalMode, MovementMode verticalMode)
        {
            maxIterationTxt.Text = max.ToString();
            currentIterationTxt.Text = "1";
            char[][] bestKey = new char[5][] { new char[5], new char[5], new char[5], new char[5], new char[5] };
            float bestValue = float.MaxValue;
            bool retestMirrors = true;
            for (int i = 0; i < max; i++)
            {
                currentIterationTxt.Text = (i + 1).ToString();
                List<char[][]> CurrentGeneration = new List<char[][]>();
                if (i == 0)
                {
                    CurrentGeneration = CreateNewGeneration(30);
                }
                else
                {
                    CurrentGeneration.Add(GetRandomGrid());
                    //CurrentGeneration.Add(SwapColumns(bestKey, rand.Next(0, 5), rand.Next(0, 5)));
                    //CurrentGeneration.Add(SwapRows(bestKey, rand.Next(0, 5), rand.Next(0, 5)));
                    if (retestMirrors)
                    {
                        CurrentGeneration.Add(MirrorColumns(bestKey));
                        CurrentGeneration.Add(MirrorRows(bestKey));
                        retestMirrors = false;
                    }
                    CurrentGeneration.Add(SwapPlaces(bestKey,
                        new GridPosition(rand.Next(0, 5), rand.Next(0, 5)),
                        new GridPosition(rand.Next(0, 5), rand.Next(0, 5))));
                }
                float highestScore = float.MaxValue;
                string highestText = "";
                int highestIndex = 0;
                for (int j = 0; j < CurrentGeneration.Count; j++)
                {
                    char[][] grid = CurrentGeneration[j];
                    PlayfairGrid pg = new PlayfairGrid(5, GetKeyFromGrid(grid), resartLetters, horizontalMode, verticalMode);
                    string outputText = "";
                    SetGrid(grid);
                    for (int k = 0; k < inputText.Length; k += 2)
                    {
                        outputText += pg.Decrypt(inputText[k], inputText[k + 1]);
                    }
                    float score = CalculateScore(GetFrequencyProfile(outputText)) - CalculateWordScore(outputText) - CalculatePairScore(outputText);
                    if (score < highestScore)
                    {
                        highestScore = score;
                        highestText = outputText;
                        highestIndex = j;
                    }
                    outputTxt.Text = outputText;
                    this.Invalidate();
                    this.Refresh();
                }
                if (highestScore < bestValue)
                {
                    bestAnswetTxt.Text = highestText;
                    bestScoreTxt.Text = highestScore.ToString();
                    bestKey = CurrentGeneration[highestIndex];
                    bestValue = highestScore;
                    retestMirrors = true;
                }
            }
        }
        private List<char[][]> CreateNewGeneration(int size)
        {
            List<char[][]> gen = new List<char[][]>();
            for (int i = 0; i < size; i++)
            {
                gen.Add(GetRandomGrid());
            }
            return gen;
        }
        private char[][] GetRandomGrid()
        {
            char[][] grid = new char[5][];
            for (int i = 0; i < 5; i++)
            {
                grid[i] = new char[5];
            }
            List<char> letters = new List<char>("ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray());
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    char randLetter = letters[rand.Next(0, letters.Count)];
                    grid[row][column] = randLetter;
                    letters.Remove(randLetter);
                }
            }
            return grid;
        }
        private char[][] SwapColumns(char[][] grid, int c1, int c2)
        {
            char[][] newGrid = grid;
            char[] temp = grid[c1];
            grid[c1] = grid[c2];
            grid[c2] = temp;
            return newGrid;
        }
        private char[][] SwapRows(char[][] grid, int r1, int r2)
        {
            char[][] newGrid = new char[5][] { new char[5], new char[5], new char[5], new char[5], new char[5]};
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (row == r1)
                        newGrid[row][column] = grid[r2][column];
                    else if (row == r2)
                        newGrid[row][column] = grid[r1][column];
                    else
                        newGrid[row][column] = grid[row][column];
                }
            }
            return newGrid;
        }
        private char[][] MirrorColumns(char[][] grid)
        {
            char[][] newGrid = SwapColumns(SwapColumns(grid, 0, 4), 1, 3);
            return newGrid;
        }
        private char[][] MirrorRows(char[][] grid)
        {
            char[][] newGrid = SwapRows(SwapColumns(grid, 0, 4), 1, 3);
            return newGrid;
        }
        private char[][] SwapPlaces(char[][] grid, GridPosition p1, GridPosition p2)
        {
            char[][] newGrid = grid;
            char temp = newGrid[p1.Row][p1.Column];
            newGrid[p1.Row][p1.Column] = newGrid[p2.Row][p2.Column];
            newGrid[p2.Row][p2.Column] = temp;
            return newGrid;
        }
        private string GetKeyFromGrid(char[][] grid)
        {
            string key = "";
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    key += grid[row][column].ToString();
                }
            }
            return key;
        }
        private void SetGrid(char[][] grid)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Values[row, column].Text = grid[row][column].ToString();
                }
            }
        }
        private float[] GetFrequencyProfile(string text)
        {
            float[] freq = new float[26];
            int[] freqChars = new int[26];
            float totalChars = 0f;
            for (int i = 0; i < text.Length; i++)
            {
                if (Characters.Contains(text[i].ToString().ToLower()))
                {
                    totalChars++;
                    switch (text[i].ToString().ToLower())
                    {
                        case "a":
                            freqChars[0]++;
                            break;
                        case "b":
                            freqChars[1]++;
                            break;
                        case "c":
                            freqChars[2]++;
                            break;
                        case "d":
                            freqChars[3]++;
                            break;
                        case "e":
                            freqChars[4]++;
                            break;
                        case "f":
                            freqChars[5]++;
                            break;
                        case "g":
                            freqChars[6]++;
                            break;
                        case "h":
                            freqChars[7]++;
                            break;
                        case "i":
                            freqChars[8]++;
                            break;
                        case "j":
                            freqChars[9]++;
                            break;
                        case "k":
                            freqChars[10]++;
                            break;
                        case "l":
                            freqChars[11]++;
                            break;
                        case "m":
                            freqChars[12]++;
                            break;
                        case "n":
                            freqChars[13]++;
                            break;
                        case "o":
                            freqChars[14]++;
                            break;
                        case "p":
                            freqChars[15]++;
                            break;
                        case "q":
                            freqChars[16]++;
                            break;
                        case "r":
                            freqChars[17]++;
                            break;
                        case "s":
                            freqChars[18]++;
                            break;
                        case "t":
                            freqChars[19]++;
                            break;
                        case "u":
                            freqChars[20]++;
                            break;
                        case "v":
                            freqChars[21]++;
                            break;
                        case "w":
                            freqChars[22]++;
                            break;
                        case "x":
                            freqChars[23]++;
                            break;
                        case "y":
                            freqChars[24]++;
                            break;
                        case "z":
                            freqChars[25]++;
                            break;
                    }
                }
            }
            for (int i = 0; i < 26; i++)
            {
                freq[i] = freqChars[i] / totalChars;
            }
            return freq;
        }
        private float CalculateScore(float[] freq)
        {
            float totalScore = 0;
            for (int i = 0; i < 26; i++)
            {
                totalScore += Math.Abs(CharacterFrequency[i] - freq[i]);
            }
            return (float)Math.Floor(totalScore * 1000);
        }
        private float CalculateWordScore(string text)
        {
            float score = 0;
            foreach (string word in CommonWords)
            {
                for (int i = 0; i < text.Length - word.Length; i++)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (word[j] != text[i + j])
                            break;
                        if (j == word.Length - 1)
                            score += 5;
                    }
                }
            }
            return score;
        }
        private float CalculatePairScore(string text)
        {
            float score = 0;
            for (int i = 0; i < PairFrequencyLetters.Length; i++)
            {
                for (int j = 0; j < text.Length - 1; j++)
                {
                    if (text[j] == PairFrequencyLetters[i][0] && text[j] == PairFrequencyLetters[i][1])
                        score += PairFrequencyScore[i];
                }
            }
            return score;
        }
    }
}