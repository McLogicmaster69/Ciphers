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
    public partial class Playfair5Grid : Form
    {
        private Random rand;
        private TextBox[,] Values; 
        private float[] CharacterFrequency = new float[] { 0.082f, 0.015f, 0.028f, 0.043f, 0.127f, 0.022f, 0.020f, 0.061f, 0.070f, 0.002f, 0.008f, 0.040f, 0.024f, 0.067f, 0.075f, 0.019f, 0.001f, 0.060f, 0.063f, 0.091f, 0.028f, 0.010f, 0.024f, 0.002f, 0.020f, 0.001f };
        private string[] CommonWords = new string[] { "THE", "BE", "TO", "OF", "AND", "IN", "THAT", "HAVE", "IT", "FOR", "NOT", "ON", "WITH", "HE", "AS", "YOU", "DO", "AT", "THIS", "BUT", "HIS", "BY", "FROM", "THEY", "WE", "SAY", "HER"};
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        private string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Playfair5Grid()
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

        public void BeginGrind(string inputText, int max, int keyLength, bool resartLetters, MovementMode horizontalMode, MovementMode verticalMode) // YEAAAAAAH BRING ON THE GRIND
        {
            maxIterationTxt.Text = max.ToString();
            currentIterationTxt.Text = "1";
            string currentKey = GenerateKeyword(keyLength);
            float highestScore = float.MaxValue;
            string highestText = "";
            string highestKey = currentKey;
            for (int i = 0; i < max; i++)
            {
                currentIterationTxt.Text = (i + 1).ToString();
                keywordTxt.Text = currentKey;
                PlayfairGrid grid = new PlayfairGrid(5, currentKey, resartLetters, horizontalMode, verticalMode);
                SetGrid(grid.Grid);
                string outputText = "";
                for (int j = 0; j < inputText.Length; j += 2)
                {
                    outputText += grid.Decrypt(inputText[j], inputText[j + 1]);
                }
                float score = CalculateScore(GetFrequencyProfile(outputText)) - CalculateWordScore(outputText);
                if(score < highestScore)
                {
                    highestScore = score;
                    highestText = outputText;
                    highestKey = currentKey;
                    bestScoreTxt.Text = score.ToString();
                    bestAnswetTxt.Text = outputText;
                    bestKeyTxt.Text = currentKey;
                }
                outputTxt.Text = outputText;
                currentKey = AlterKeyword(highestKey);
                this.Invalidate();
                this.Refresh();
            }
        }
        private string GenerateKeyword(int length)
        {
            string currentKey = "";
            for (int i = 0; i < length; i++)
            {
                currentKey += GetRandomChar().ToString();
            }
            return currentKey;
        }
        private string AlterKeyword(string keyword)
        {
            List<int> remainValues = new List<int>();
            List<int> alterValues = new List<int>();
            for (int i = 0; i < keyword.Length; i++)
            {
                remainValues.Add(i);
            }
            for (int i = 0; i < keyword.Length; i++)
            {
                if (rand.Next(0, i + 1) == 0)
                {
                    int changeValue = remainValues[rand.Next(0, remainValues.Count)];
                    remainValues.Remove(changeValue);
                    alterValues.Add(changeValue);
                }
            }
            string newKeyword = "";
            for (int i = 0; i < keyword.Length; i++)
            {
                if (alterValues.Contains(i))
                    newKeyword += GetRandomChar();
                else
                    newKeyword += keyword[i];
            }
            return newKeyword;
        }
        private char GetRandomChar()
        {
            switch (rand.Next(0, 25))
            {
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';
                case 4:
                    return 'E';
                case 5:
                    return 'F';
                case 6:
                    return 'G';
                case 7:
                    return 'H';
                case 8:
                    return 'I';
                case 9:
                    return 'K';
                case 10:
                    return 'L';
                case 11:
                    return 'M';
                case 12:
                    return 'N';
                case 13:
                    return 'O';
                case 14:
                    return 'P';
                case 15:
                    return 'Q';
                case 16:
                    return 'R';
                case 17:
                    return 'S';
                case 18:
                    return 'T';
                case 19:
                    return 'U';
                case 20:
                    return 'V';
                case 21:
                    return 'W';
                case 22:
                    return 'X';
                case 23:
                    return 'Y';
                case 24:
                    return 'Z';
            }
            return ' ';
        }
        private void SetGrid(char[,] grid)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Values[row, column].Text = grid[row, column].ToString();
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
    }
}
