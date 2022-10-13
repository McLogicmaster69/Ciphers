using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Substitution
{
    public partial class SubstitueTool : Form
    {
        private float[] CharacterFrequency = new float[] { 0.082f, 0.015f, 0.028f, 0.043f, 0.127f, 0.022f, 0.020f, 0.061f, 0.070f, 0.002f, 0.008f, 0.040f, 0.024f, 0.067f, 0.075f, 0.019f, 0.001f, 0.060f, 0.063f, 0.091f, 0.028f, 0.010f, 0.024f, 0.002f, 0.020f, 0.001f };
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        private string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Replacements ReplacementForm;
        private CrackOptions OptionsForm;
        private string OriginalText;
        public char[] replacements = new char[26];
        public Options Options = new Options();
        public SubstitueTool()
        {
            InitializeComponent();
        }

        private void crackBtn_Click(object sender, EventArgs e)
        {
            TrySubstitute();
        }

        private void TrySubstitute()
        {
            string input = mainTxt.Text;
            string filterInput = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Characters.Contains(input[i].ToString().ToLower()) || input[i] == ' ')
                {
                    filterInput += input[i];
                }
            }
            string[] words = filterInput.Split(' ');
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            List<string> wordsForFreq = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (wordFreq.ContainsKey(words[i]))
                    wordFreq[words[i]]++;
                else
                {
                    wordFreq.Add(words[i], 1);
                    wordsForFreq.Add(words[i]);
                }
            }
            int wordFreqCount = wordFreq.Count;
            Dictionary<string, int> sortedFreq = new Dictionary<string, int>();
            List<string> sortedWordsForFreq = new List<string>();
            for (int i = 0; i < wordFreqCount; i++)
            {
                int highestValue = int.MinValue;
                int indexOfHighest = -1;
                for (int j = 0; j < wordFreq.Count; j++)
                {
                    if (wordFreq[wordsForFreq[j]] > highestValue)
                    {
                        highestValue = wordFreq[wordsForFreq[j]];
                        indexOfHighest = j;
                    }
                }
                sortedFreq.Add(wordsForFreq[indexOfHighest], wordFreq[wordsForFreq[indexOfHighest]]);
                sortedWordsForFreq.Add(wordsForFreq[indexOfHighest]);
                wordFreq.Remove(wordsForFreq[indexOfHighest]);
                wordsForFreq.RemoveAt(indexOfHighest);
            }

            int predictLetters = Options.CommonLetters;
            List<char> sortedLetters = new List<char>();
            List<float> remainPercents = new List<float>();
            List<char> remainLetters = new List<char>();

            for (int i = 0; i < 26; i++)
            {
                remainPercents.Add(CharacterFrequency[i]);
                remainLetters.Add(Characters[i]);
            }
            for (int i = 0; i < predictLetters; i++)
            {
                float highestValue = float.MinValue;
                int highestIndex = -1;
                for (int j = 0; j < remainPercents.Count; j++)
                {
                    if (remainPercents[j] > highestValue)
                    {
                        highestValue = remainPercents[j];
                        highestIndex = j;
                    }
                }
                sortedLetters.Add(remainLetters[highestIndex]);
                remainLetters.RemoveAt(highestIndex);
                remainPercents.RemoveAt(highestIndex);
            }

            float[] FreqProfile = GetFrequencyProfile(input);

            List<float> freqProfileList = new List<float>();
            List<char> freqLetters = new List<char>();

            for (int i = 0; i < 26; i++)
            {
                freqProfileList.Add(FreqProfile[i]);
                freqLetters.Add(Capitals[i]);
            }

            for (int i = 0; i < predictLetters; i++)
            {
                float highestValue = float.MinValue;
                int highestIndex = -1;
                if (freqProfileList.Count == 0)
                    break;
                for (int j = 0; j < freqProfileList.Count; j++)
                {
                    if (freqProfileList[j] > highestValue)
                    {
                        highestValue = freqProfileList[j];
                        highestIndex = j;
                    }
                }
                replacements = ChangeReplacement(replacements, freqLetters[highestIndex], sortedLetters[i]);
                Console.WriteLine($"{freqLetters[highestIndex]} is meant to be {sortedLetters[i]}");
                freqProfileList.RemoveAt(highestIndex);
                freqLetters.RemoveAt(highestIndex);
            }

            for (int k = 0; k < Options.CommonWords.Length; k++)
            {
                for (int i = 0; i < Options.CommonWords[k].Length; i++)
                {
                    string replacedText = input;
                    for (int j = 0; j < 26; j++)
                    {
                        if (replacements[j] != '#')
                        {
                            replacedText = ReplaceLetter(replacedText, Capitals[i], replacements[i]);
                        }
                    }
                    sortedWordsForFreq = UpdateSortedList(sortedWordsForFreq, replacements);
                    for (int j = 0; j < sortedWordsForFreq.Count; j++)
                    {
                        string testWord = sortedWordsForFreq[j];
                        string testCommon = Options.CommonWords[k][i];
                        if (testWord.Length == testCommon.Length)
                        {
                            bool sharesLetter = false;
                            for (int l = 0; l < testWord.Length; l++)
                            {
                                int indexOfLetter = Capitals.IndexOf(testWord[l]);
                                if (indexOfLetter != -1)
                                {
                                    // IS A CAPITAL
                                    bool foundLower = false;
                                    for (int t = 0; t < 26; t++)
                                    {
                                        if (replacements[t] == testCommon[l])
                                        {
                                            foundLower = true;
                                            break;
                                        }
                                    }
                                    if (foundLower)
                                    {
                                        sharesLetter = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    // IS NOT CAPITAL
                                    if (testWord[l] != testCommon[l])
                                    {
                                        sharesLetter = false;
                                        break;
                                    }
                                    else
                                        sharesLetter = true;
                                }
                            }
                            if (sharesLetter)
                            {
                                for (int l = 0; l < testCommon.Length; l++)
                                {
                                    if (Capitals.Contains(testWord[l]))
                                    {
                                        replacements = ChangeReplacement(replacements, testWord[l], testCommon[l]);
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }

            string newText = input;
            for (int i = 0; i < 26; i++)
            {
                if (replacements[i] != '#')
                {
                    newText = ReplaceLetter(newText, Capitals[i], replacements[i]);
                }
            }
            mainTxt.Text = newText;
        }
        private char[] ChangeReplacement(char[] replacements, char letter, char newLetter)
        {
            char[] newChars = replacements;
            newChars[Capitals.IndexOf(letter)] = newLetter;
            return newChars;
        }
        private List<string> UpdateSortedList(List<string> list, char[] replacements)
        {
            List<string> ret = new List<string>();
            foreach (string word in list)
            {
                string newWord = "";
                for (int i = 0; i < word.Length; i++)
                {
                    int indexOfChar = Capitals.IndexOf(word[i]);
                    if (indexOfChar == -1)
                        newWord += word[i];
                    else
                    {
                        if (replacements[indexOfChar] == '#')
                            newWord += word[i];
                        else
                            newWord += replacements[indexOfChar];
                    }
                }
                ret.Add(newWord);
            }
            return ret;
        }
        private string ReplaceLetter(string text, char letter, char replace)
        {
            string final = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == letter)
                    final += replace;
                else
                    final += text[i];
            }
            return final;
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

        public void SetupText(string inputText)
        {
            mainTxt.Text = inputText;
            OriginalText = inputText;
        }

        private void freqBtn_Click(object sender, EventArgs e)
        {
            string input = mainTxt.Text;
            string filterInput = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Characters.Contains(input[i].ToString().ToLower()) || input[i] == ' ')
                {
                    filterInput += input[i];
                }
            }
            string[] words = filterInput.Split(' ');
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            List<string> wordsForFreq = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (wordFreq.ContainsKey(words[i]))
                    wordFreq[words[i]]++;
                else
                {
                    wordFreq.Add(words[i], 1);
                    wordsForFreq.Add(words[i]);
                }
            }
            int wordFreqCount = wordFreq.Count;
            Dictionary<string, int> sortedFreq = new Dictionary<string, int>();
            List<string> sortedWordsForFreq = new List<string>();
            for (int i = 0; i < wordFreqCount; i++)
            {
                int highestValue = int.MinValue;
                int indexOfHighest = -1;
                for (int j = 0; j < wordFreq.Count; j++)
                {
                    if (wordFreq[wordsForFreq[j]] > highestValue)
                    {
                        highestValue = wordFreq[wordsForFreq[j]];
                        indexOfHighest = j;
                    }
                }
                sortedFreq.Add(wordsForFreq[indexOfHighest], wordFreq[wordsForFreq[indexOfHighest]]);
                sortedWordsForFreq.Add(wordsForFreq[indexOfHighest]);
                wordFreq.Remove(wordsForFreq[indexOfHighest]);
                wordsForFreq.RemoveAt(indexOfHighest);
            }

            string freqText = "";
            for (int i = 0; i < sortedFreq.Count; i++)
            {
                freqText += $"Word \"{sortedWordsForFreq[i]}\" has frequency of {sortedFreq[sortedWordsForFreq[i]]}\n";
            }
            WordFrequencyFrm frequency = new WordFrequencyFrm();
            frequency.UpdateFreqLbl(freqText);
            frequency.Show();
        }

        private void SubstitueTool_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                replacements[i] = '#';
            }
            ReplacementForm = new Replacements(this);
            ReplacementForm.SetValues(replacements);
            OptionsForm = new CrackOptions();
            OptionsForm.SetupOptions(Options);
        }

        private void applyReplacementBtn_Click(object sender, EventArgs e)
        {
            string newText = mainTxt.Text;
            for (int i = 0; i < 26; i++)
            {
                if (replacements[i] != '#')
                {
                    newText = ReplaceLetter(newText, Capitals[i], replacements[i]);
                }
            }
            mainTxt.Text = newText;
        }

        private void openReplacementBtn_Click(object sender, EventArgs e)
        {
            if (ReplacementForm == null)
                ReplacementForm = new Replacements(this);
            ReplacementForm.SetValues(replacements);
            ReplacementForm.Show();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            mainTxt.Text = OriginalText;
        }

        private void crackOptionsBtn_Click(object sender, EventArgs e)
        {
            if (OptionsForm == null)
                OptionsForm = new CrackOptions();
            OptionsForm.SetupOptions(Options);
            OptionsForm.Show();
        }

        private void patermBtn_Click(object sender, EventArgs e)
        {
            SubsitutePatterns sp = new SubsitutePatterns();
            sp.Setup(this);
            sp.Show();
        }

        private void removeSpacesBtn_Click(object sender, EventArgs e)
        {
            string newText = "";
            for (int i = 0; i < mainTxt.Text.Length; i++)
            {
                if (mainTxt.Text[i] != ' ')
                    newText += mainTxt.Text[i];
            }
            mainTxt.Text = newText;
        }

        private void dictionaryBtn_Click(object sender, EventArgs e)
        {

        }

        private void bruteBtn_Click(object sender, EventArgs e)
        {
            Brute brute = new Brute();
            brute.Show();
            brute.BeginGrind(OriginalText, 10000);
        }

        private void smartBruteBtn_Click(object sender, EventArgs e)
        {
            SmartBrute brute = new SmartBrute();
            brute.Show();
            brute.BeginGrind(OriginalText, 2500);
        }

        private void wordDictionaryToolBtn_Click(object sender, EventArgs e)
        {
            WordDictionaryTool wdt = new WordDictionaryTool();
            wdt.Show();
        }
    }
}
