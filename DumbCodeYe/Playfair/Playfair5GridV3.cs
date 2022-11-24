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

namespace DumbCodeYe.Playfair
{
    public partial class Playfair5GridV3 : Form
    {
        private Random rand;
        private TextBox[,] Values;
        private float[] CharacterFrequency = new float[] { 0.082f, 0.015f, 0.028f, 0.043f, 0.127f, 0.022f, 0.020f, 0.061f, 0.070f, 0.002f, 0.008f, 0.040f, 0.024f, 0.067f, 0.075f, 0.019f, 0.001f, 0.060f, 0.063f, 0.091f, 0.028f, 0.010f, 0.024f, 0.002f, 0.020f, 0.001f };
        private string[] CommonWords = new string[] { "THE", "BE", "TO", "OF", "AND", "IN", "THAT", "HAVE", "IT", "FOR", "NOT", "ON", "WITH", "HE", "AS", "YOU", "DO", "AT", "THIS", "BUT", "HIS", "BY", "FROM", "THEY", "WE", "SAY", "HER" };
        private string[] PairFrequencyLetters = new string[] { "TH", "HE", "IN", "ER", "AN", "RE", "ES", "ON", "ST", "NT", "EN", "AT", "ED", "ND", "TO", "OR", "EA", "TI", "AR", "TE"};
        private float[] PairFrequencyScore = new float[] { 11.6f, 10.0f, 8.7f, 7.7f, 6.9f, 6.0f, 5.7f, 5.6f, 5.4f, 5.0f, 4.8f, 4.6f, 4.6f, 4.5f, 4.3f, 4.2f, 4.2f, 4.2f};
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        private string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public Playfair5GridV3()
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
            //startingTemp = inputText.Length / 12d;
            maxIterationTxt.Text = max.ToString();
            currentIterationTxt.Text = "1";
            char[][] bestKey = new char[5][] { new char[5], new char[5], new char[5], new char[5], new char[5] };
            double bestValue = double.MinValue;
            for (double temperature = 30; temperature > 0; temperature -= 0.5d)
            {
                for (int i = 0; i < max; i++)
                {
                    currentIterationTxt.Text = (i + 1).ToString();
                    char[][] CurrentGeneration = new char[5][];
                    if (i == 0)
                    {
                        CurrentGeneration = GetRandomGrid();
                    }
                    else
                    {
                        switch (rand.Next(0, 11))
                        {
                            case 0:
                                CurrentGeneration = SwapColumns(bestKey, rand.Next(0, 5), rand.Next(0, 5));
                                break;
                            case 1:
                                CurrentGeneration = SwapColumns(bestKey, rand.Next(0, 5), rand.Next(0, 5));
                                break;
                            case 2:
                                CurrentGeneration = SwapRows(bestKey, rand.Next(0, 5), rand.Next(0, 5));
                                break;
                            case 3:
                                CurrentGeneration = SwapRows(bestKey, rand.Next(0, 5), rand.Next(0, 5));
                                break;
                            case 4:
                                CurrentGeneration = MirrorColumns(bestKey);
                                break;
                            case 5:
                                CurrentGeneration = MirrorRows(bestKey);
                                break;
                            case 6:
                                CurrentGeneration = SwapPlaces(bestKey,
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)),
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)));
                                break;
                            case 7:
                                CurrentGeneration = SwapPlaces(bestKey,
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)),
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)));
                                break;
                            case 8:
                                CurrentGeneration = SwapPlaces(bestKey,
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)),
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)));
                                break;
                            case 9:
                                CurrentGeneration = SwapPlaces(bestKey,
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)),
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)));
                                break;
                            case 10:
                                CurrentGeneration = SwapPlaces(bestKey,
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)),
                                    new GridPosition(rand.Next(0, 5), rand.Next(0, 5)));
                                break;
                        }
                    }

                    //CurrentGeneration = new char[5][] { new char[5] { 'P', 'A', 'S', 'W', 'O' }, new char[5] { 'R', 'D', 'B', 'C', 'E' }, new char[5] { 'F', 'G', 'H', 'I', 'K' }, new char[5] { 'L', 'M', 'N', 'Q', 'T' }, new char[5] { 'U', 'V', 'X', 'Y', 'Z' } };
                    PlayfairGrid pg = new PlayfairGrid(5, GetKeyFromGrid(CurrentGeneration), resartLetters, horizontalMode, verticalMode);
                    string outputText = "";
                    SetGrid(CurrentGeneration);
                    for (int k = 0; k < inputText.Length; k += 2)
                    {
                        outputText += pg.Decrypt(inputText[k], inputText[k + 1]);
                    }
                    double score = ScoreText(outputText);

                    outputTxt.Text = outputText;
                    this.Invalidate();
                    this.Refresh();

                    if (score > bestValue) // IS THE BETTER SCORE
                    {
                        bestAnswetTxt.Text = outputText;
                        bestScoreTxt.Text = score.ToString();
                        bestKey = CurrentGeneration;
                        bestValue = score;
                    }
                    else // CALCULATE PROBABILITY OF CHANGING KEY
                    {
                        double df = score - bestValue;
                        double probability = Math.Pow(Math.E, df / temperature);
                        if (rand.NextDouble() < probability)
                        {
                            bestAnswetTxt.Text = outputText;
                            bestScoreTxt.Text = score.ToString();
                            bestKey = CurrentGeneration;
                            bestValue = score;
                        }
                    }
                }
            }
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

        private double ScoreText(string text)
        {
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
    }
}