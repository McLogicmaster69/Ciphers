using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Vigenere
{
    public partial class VigenereTools : Form
    {
        private float[] CharacterFrequency = new float[] { 0.082f, 0.015f, 0.028f, 0.043f, 0.127f, 0.022f, 0.020f, 0.061f, 0.070f, 0.002f, 0.008f, 0.040f, 0.024f, 0.067f, 0.075f, 0.019f, 0.001f, 0.060f, 0.063f, 0.091f, 0.028f, 0.010f, 0.024f, 0.002f, 0.020f, 0.001f };
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        private string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string mainText;
        private string normalText;
        public VigenereTools()
        {
            InitializeComponent();
        }
        public void SetupText(string input)
        {
            normalText = input;
            mainText = "";
            foreach(char c in input)
            {
                if (Capitals.Contains(c))
                    mainText += c;
            }
        }

        private void coincidencesBtn_Click(object sender, EventArgs e)
        {
            GetCoincidences();
        }
        private void patternsBtn_Click(object sender, EventArgs e)
        {
            GetPatterns();
        }
        private void resultsBtn_Click(object sender, EventArgs e)
        {
            GetResults();
        }
        private void bruteBtn_Click(object sender, EventArgs e)
        {
            BruteResults();
        }

        private void GetCoincidences()
        {
            int length = GetKeywordLength(mainText);
        }
        private int GetKeywordLength(string input)
        {
            int shifts = 30;
            if (input.Length < shifts)
            {
                shifts = input.Length;
            }

            Console.WriteLine(shifts);

            string[] shiftedText = new string[shifts];
            int[] totalCoincidences = new int[shifts];

            for (int i = 0; i < shifts; i++)
            {
                string shifted = "";
                for (int j = 0; j < input.Length; j++)
                {
                    int index = (j - i) - 1;
                    if (index < 0)
                        shifted += '#';
                    else
                        shifted += input[index];
                }
                shiftedText[i] = shifted;
            }

            for (int i = 0; i < shifts; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == shiftedText[i][j])
                        totalCoincidences[i]++;
                }
            }

            Coincidences coincidences = new Coincidences();
            coincidences.Setup(shiftedText, totalCoincidences);
            coincidences.Show();

            return 0;
        }

        private void GetPatterns()
        {
            List<string> checkedPat = new List<string>();
            List<string> foundPatterns = new List<string>();
            List<int> patternSpacing = new List<int>();
            for (int i = 0; i < mainText.Length - 3; i++)
            {
                string pat = mainText[i].ToString() + mainText[i + 1].ToString() + mainText[i + 2].ToString();
                if (!checkedPat.Contains(pat))
                {
                    checkedPat.Add(pat);
                    for (int j = i + 1; j < mainText.Length - 3; j++)
                    {
                        string secPat = mainText[j].ToString() + mainText[j + 1].ToString() + mainText[j + 2].ToString();
                        if(pat == secPat)
                        {
                            foundPatterns.Add(pat);
                            patternSpacing.Add(j);
                        }
                    }
                }
            }
            Patterns patternFrm = new Patterns();
            patternFrm.SetupPatterns(foundPatterns, patternSpacing);
            patternFrm.Show();
        }

        private void GetResults()
        {
            string[] textSubsets = new string[(int)suspectedKeyLength.Value];
            int currentSubset = 0;
            for (int i = 0; i < mainText.Length; i++)
            {
                textSubsets[currentSubset] += mainText[i];
                currentSubset++;
                if (currentSubset == (int)suspectedKeyLength.Value)
                    currentSubset = 0;
            }

            string[] ceaserSubsets = new string[(int)suspectedKeyLength.Value];
            for (int i = 0; i < (int)suspectedKeyLength.Value; i++)
            {
                ceaserSubsets[i] = TryCeaser(textSubsets[i]);
            }

            string compoundAnswer = "";
            currentSubset = 0;
            int currentIndex = 0;
            for (int i = 0; i < normalText.Length; i++)
            {
                if (Capitals.Contains(normalText[i]))
                {
                    compoundAnswer += ceaserSubsets[currentSubset][currentIndex];
                    currentSubset++;
                    if (currentSubset == (int)suspectedKeyLength.Value)
                    {
                        currentSubset = 0;
                        currentIndex++;
                    }
                }
                else
                {
                    compoundAnswer += normalText[i];
                }
            }
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(compoundAnswer);
            txtOut.Show();
        }
        private void BruteResults()
        {
            string[] textSubsets = new string[(int)suspectedKeyLength.Value];
            int currentSubset = 0;
            for (int i = 0; i < mainText.Length; i++)
            {
                textSubsets[currentSubset] += mainText[i];
                currentSubset++;
                if (currentSubset == (int)suspectedKeyLength.Value)
                    currentSubset = 0;
            }

            ProgressBarForm pbf = new ProgressBarForm();
            pbf.Show();

            int maxTime = (int)Math.Pow(26, (int)suspectedKeyLength.Value);
            float currentTime = 0;

            int maxStored = 20;
            string[] answersStored = new string[maxStored];
            float[] scoresStored = new float[maxStored];
            bool mustRecalculate = true;
            float highestValue = float.MinValue;
            int highestIndex = 0;

            for (int i = 0; i < maxStored; i++)
            {
                scoresStored[i] = float.MaxValue;
            }

            int[] indexs = new int[(int)suspectedKeyLength.Value];
            bool working = true;
            while (working)
            {
                string[] ceaserSubsets = new string[(int)suspectedKeyLength.Value];
                for (int i = 0; i < (int)suspectedKeyLength.Value; i++)
                {
                    ceaserSubsets[i] = Ceaser(textSubsets[i], indexs[i]);
                }

                string compoundAnswer = "";
                currentSubset = 0;
                int currentIndex = 0;
                for (int i = 0; i < mainText.Length; i++)
                {
                    compoundAnswer += ceaserSubsets[currentSubset][currentIndex];
                    currentSubset++;
                    if (currentSubset == (int)suspectedKeyLength.Value)
                    {
                        currentSubset = 0;
                        currentIndex++;
                    }
                }

                float[] freq = GetFrequencyProfile(compoundAnswer);
                float score = CalculateScore(freq);

                if (mustRecalculate)
                {
                    for (int i = 0; i < maxStored; i++)
                    {
                        if (scoresStored[i] > highestValue)
                        {
                            highestValue = scoresStored[i];
                            highestIndex = i;
                        }
                    }
                }
                if(score < highestValue)
                {
                    scoresStored[highestIndex] = score;
                    answersStored[highestIndex] = compoundAnswer;
                    mustRecalculate = true;
                }

                int workingIndex = 0;
                while (true)
                {
                    if(workingIndex == (int)suspectedKeyLength.Value)
                    {
                        working = false;
                        break;
                    }
                    indexs[workingIndex]++;
                    if (indexs[workingIndex] == 26)
                    {
                        indexs[workingIndex] = 0;
                        workingIndex++;
                    }
                    else
                        break;
                }
                currentTime++;
                pbf.loadingBar.Value = (int)Math.Floor((currentTime / maxTime) * 100);
                pbf.status.Text = $"{currentTime} / {maxTime.ToString()}";
                pbf.Invalidate();
                pbf.Refresh();
            }
            pbf.Close();
            foreach (string s in answersStored)
            {
                TextOutputFrm txtOut = new TextOutputFrm();
                txtOut.SetOutput(s);
                txtOut.Show();
            }
        }

        private string TryCeaser(string input)
        {
            float[] scores = new float[26];
            float[] freq = GetFrequencyProfile(input);
            float lowestScore = float.MaxValue;
            int lowestIndex = -1;
            for (int i = 0; i < 26; i++)
            {
                scores[i] = CalculateScore(freq, i);
                if(scores[i] < lowestScore)
                {
                    lowestScore = scores[i];
                    lowestIndex = i;
                }
            }
            return Ceaser(input, lowestIndex);
        }
        private string Ceaser(string input, int offset)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Characters.Contains(input[i].ToString().ToLower()))
                {
                    output += Characters[(Characters.IndexOf(input[i].ToString().ToLower()) - offset + 26) % 26];
                }
                else
                {
                    output += input[i];
                }
            }
            return output;
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
        private float CalculateScore(float[] freq, int offset)
        {
            float[] inp = new float[26];
            for (int i = offset, j = 0; i < offset + 26; i++, j++)
            {
                inp[j] = freq[i % 26];
            }
            return CalculateScore(inp);
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


        private void GetPatternsWrong()
        {
            List<string> foundPatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - 3; i++)
            {
                string pat = mainText[i].ToString() + mainText[i + 1].ToString() + mainText[i + 2].ToString();
                if (foundPatterns.Contains(pat))
                {
                    int index = foundPatterns.IndexOf(pat);
                    patternRepeats[index]++;
                }
                else
                {
                    foundPatterns.Add(pat);
                    patternRepeats.Add(1);
                }
            }
            Patterns patternFrm = new Patterns();
            patternFrm.SetupPatterns(foundPatterns, patternRepeats);
            patternFrm.Show();
        }
    }
}
