using DumbCodeYe.Ciphers.Substitution;
using DumbCodeYe.LetterPatterns.Bigrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.FourSquare
{
    public partial class FourSquareTools : Form
    {
        public const int HILL_CLIMB_ATTEMPTS = 1000;

        private readonly string _input;

        private readonly TextBox[][] _grid1;
        private readonly TextBox[][] _grid2;

        private SubstitutePatternAnalysis _bigramPatternsFrm = new SubstitutePatternAnalysis();
        private SubstitutePatternAnalysis _frequentBigramsFrm;

        public FourSquareTools(string input)
        {
            InitializeComponent();

            _input = input;
            mainTxt.Text = input;

            _grid1 = new TextBox[5][]
            {
                new TextBox[5] {Value211, Value212, Value213, Value214, Value215},
                new TextBox[5] {Value221, Value222, Value223, Value224, Value225},
                new TextBox[5] {Value231, Value232, Value233, Value234, Value235},
                new TextBox[5] {Value241, Value242, Value243, Value244, Value245},
                new TextBox[5] {Value251, Value252, Value253, Value254, Value255}
            };
            _grid2 = new TextBox[5][]
            {
                new TextBox[5] {Value311, Value312, Value313, Value314, Value315},
                new TextBox[5] {Value321, Value322, Value323, Value324, Value325},
                new TextBox[5] {Value331, Value332, Value333, Value334, Value335},
                new TextBox[5] {Value341, Value342, Value343, Value344, Value345},
                new TextBox[5] {Value351, Value352, Value353, Value354, Value355}
            };

            AnalyseBigrams();
            UnhighlightGrid();
            OpenBigramFrequencies();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            ApplyGrd();
        }

        private void OpenBigramFrequencies()
        {
            BigramsData.InitialiseFrequencySet();
            List<string> keys = new List<string>(BigramsData.FrequencyDataSet.Keys);
            List<long> values = new List<long>(BigramsData.FrequencyDataSet.Values);

            if (_frequentBigramsFrm == null)
                _frequentBigramsFrm = new SubstitutePatternAnalysis(OnFrequentBigramClicked);
            if (_frequentBigramsFrm.IsDisposed)
                _frequentBigramsFrm = new SubstitutePatternAnalysis();

            _frequentBigramsFrm.SetupPatterns(keys, values);
            _frequentBigramsFrm.Show();
        }
        private string ApplyGrd()
        {
            if (!ValidateGrid(_grid1, out char g1))
            {
                outputLbl.Text = $"Character {g1.ToString()} has been repeated in grid 1";
                return "";
            }
            if (!ValidateGrid(_grid2, out char g2))
            {
                outputLbl.Text = $"Character {g2.ToString()} has been repeated in grid 2";
                return "";
            }
            outputLbl.Text = "";

            string output = PureApply();
            AnalyseBigrams();
            UnhighlightGrid();
            return output;
        }
        private string PureApply()
        {
            string output = FourSquareCipher.Decipher(_input, _grid1, _grid2);
            mainTxt.Text = output;
            mainTxt.Refresh();
            return output;
        }

        private bool ValidateGrid(TextBox[][] grid, out char misinput)
        {
            List<char> letters = new List<char>("ABCDEFGHIKLMNOPQRSTUVWXYZ");
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (string.IsNullOrEmpty(grid[row][column].Text))
                        continue;
                    char c = grid[row][column].Text.ToString().ToUpper()[0];
                    if (GeneralConstants.CAPITALS.Contains(c) == true)
                    {
                        if (letters.Contains(c) == false)
                        {
                            misinput = c;
                            return false;
                        }
                        else
                            letters.Remove(c);
                    }
                }
            }
            misinput = ' ';
            return true;
        }

        private void bigramsBtn_Click(object sender, EventArgs e)
        {
            AnalyseBigrams();
            OpenBigramFrequencies();
            CheckExpectedLetterCount();
            CheckLetterCount();
        }

        private void AnalyseBigrams()
        {
            string input = FourSquareCipher.Decipher(_input, _grid1, _grid2);
            string mainText = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(input[i].ToString().ToLower()))
                    mainText += input[i];
            }

            List<string> foundPatterns = new List<string>();
            List<string> alternatePatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - 1; i += 2)
            {
                string pat = mainText.Substring(i, 2);
                if (foundPatterns.Contains(pat))
                {
                    int index = foundPatterns.IndexOf(pat);
                    patternRepeats[index]++;
                }
                else
                {
                    if (GeneralConstants.CHARACTERS.Contains(pat[0].ToString()) && GeneralConstants.CHARACTERS.Contains(pat[1].ToString()))
                        alternatePatterns.Add(FourSquareCipher.EncryptBigram(pat, _grid1, _grid2));
                    else
                        alternatePatterns.Add("");

                    foundPatterns.Add(pat);
                    patternRepeats.Add(1);
                }
            }

            List<string> sortedFoundPatterns = new List<string>();
            List<decimal> sortedPatternRepeats = new List<decimal>();
            int lengthOfList = foundPatterns.Count;
            for (int i = 0; i < lengthOfList; i++)
            {
                int highestRepeat = int.MinValue;
                int highestIndex = 0;
                for (int j = 0; j < foundPatterns.Count; j++)
                {
                    if (patternRepeats[j] > highestRepeat)
                    {
                        highestRepeat = patternRepeats[j];
                        highestIndex = j;
                    }
                }
                if (string.IsNullOrEmpty(alternatePatterns[highestIndex]))
                    sortedFoundPatterns.Add($"{foundPatterns[highestIndex]}");
                else
                    sortedFoundPatterns.Add($"{foundPatterns[highestIndex]} | {alternatePatterns[highestIndex]}");
                sortedPatternRepeats.Add(patternRepeats[highestIndex] / (_input.Length / 2m));
                foundPatterns.RemoveAt(highestIndex);
                alternatePatterns.RemoveAt(highestIndex);
                patternRepeats.RemoveAt(highestIndex);
            }

            if (_bigramPatternsFrm.IsDisposed)
                _bigramPatternsFrm = new SubstitutePatternAnalysis();

            _bigramPatternsFrm.SetupPatterns(sortedFoundPatterns, sortedPatternRepeats, true);
            _bigramPatternsFrm.Show();
        }

        private void outputBtn_Click(object sender, EventArgs e)
        {
            TextOutputFrm.CreateOutput(FourSquareCipher.Decipher(_input, _grid1, _grid2)).Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string text = ApplyGrd(); 
            string output = "";
            string searchBigram = bigram1Txt.Text + bigram2Txt.Text;
            for (int i = 0; i < text.Length - 1; i += 2)
            {
                string bigram = text.Substring(i, 2);
                if (bigram == searchBigram)
                    output += $" {bigram} ";
                else
                    output += bigram;
            }
            mainTxt.Text = output;
        }

        private void highlightBtn_Click(object sender, EventArgs e)
        {
            HighlightGrid();
        }

        private void HighlightGrid()
        {
            UnhighlightGrid();

            int r1 = 0;
            int r2 = 0;
            int c1 = 0;
            int c2 = 0;

            bool char1 = string.IsNullOrEmpty(bigram1Txt.Text) ?
                false
                : FourSquareCipher.CharacterInGrid(FourSquareCipher.CHARACTER_GRID, bigram1Txt.Text.ToLower(), out r1, out c1);
            bool char2 = string.IsNullOrEmpty(bigram2Txt.Text) ? 
                false
                : FourSquareCipher.CharacterInGrid(FourSquareCipher.CHARACTER_GRID, bigram2Txt.Text.ToLower(), out r2, out c2);

            if (char1 && char2)
            {
                _grid1[r1][c2].BackColor = Color.Yellow;
                _grid2[r2][c1].BackColor = Color.Yellow;
            }
            else if (char1)
            {
                for (int i = 0; i < 5; i++)
                {
                    _grid1[r1][i].BackColor = Color.Yellow;
                    _grid2[i][c1].BackColor = Color.Yellow;
                }
            }
            else if (char2)
            {
                for (int i = 0; i < 5; i++)
                {
                    _grid1[i][c2].BackColor = Color.Yellow;
                    _grid2[r2][i].BackColor = Color.Yellow;
                }
            }
        }

        private void UnhighlightGrid()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    _grid1[row][column].BackColor = Color.White;
                    _grid2[row][column].BackColor = Color.White;
                }
            }
        }

        private void OnFrequentBigramClicked(string pattern)
        {
            bigram1Txt.Text = pattern[0].ToString().ToLower();
            bigram2Txt.Text = pattern[1].ToString().ToLower();
            HighlightGrid();
        }

        private void frequencyBtn_Click(object sender, EventArgs e)
        {
            bool char1 = !string.IsNullOrEmpty(bigram1Txt.Text);
            bool char2 = !string.IsNullOrEmpty(bigram2Txt.Text);

            List<string> patterns;
            List<long> frequency;

            if (char1)
            {
                if (char2)
                {
                    SearchFrequencyList(bigram1Txt.Text.ToUpper() + bigram2Txt.Text.ToUpper(), out patterns, out frequency);
                }
                else
                {
                    SearchFrequencyListFirst(bigram1Txt.Text.ToUpper(), out patterns, out frequency);
                }
            }
            else
            {
                if (char2)
                {
                    SearchFrequencyListLast(bigram2Txt.Text.ToUpper(), out patterns, out frequency);
                }
                else
                {
                    patterns = new List<string>(BigramsData.FrequencyDataSet.Keys);
                    frequency = new List<long>(BigramsData.FrequencyDataSet.Values);
                }
            }

            if (_frequentBigramsFrm.IsDisposed)
                _frequentBigramsFrm = new SubstitutePatternAnalysis();

            _frequentBigramsFrm.SetupPatterns(patterns, frequency);
            _frequentBigramsFrm.Show();
        }

        private void SearchFrequencyList(string bigram, out List<string> patterns, out List<long> frequency)
        {
            patterns = new List<string>(new string[] {bigram});
            frequency = new List<long>(new long[] { BigramsData.GetFrequency(bigram.ToUpper())});
        }

        private void SearchFrequencyListFirst(string first, out List<string> patterns, out List<long> frequency)
        {
            patterns = new List<string>();
            frequency = new List<long>();

            for (int i = 0; i < BigramsData.FrequencyDataSet.Count; i++)
            {
                if(BigramsData.FrequencyDataSet.Keys[i][0].ToString().ToUpper() == first)
                {
                    patterns.Add(BigramsData.FrequencyDataSet.Keys[i]);
                    frequency.Add(BigramsData.FrequencyDataSet.Values[i]);
                }
            }
        }

        private void SearchFrequencyListLast(string last, out List<string> patterns, out List<long> frequency)
        {
            patterns = new List<string>();
            frequency = new List<long>();

            for (int i = 0; i < BigramsData.FrequencyDataSet.Count; i++)
            {
                if (BigramsData.FrequencyDataSet.Keys[i][1].ToString().ToUpper() == last)
                {
                    patterns.Add(BigramsData.FrequencyDataSet.Keys[i]);
                    frequency.Add(BigramsData.FrequencyDataSet.Values[i]);
                }
            }
        }

        private void textBtn_Click(object sender, EventArgs e)
        {
            bool char1 = !string.IsNullOrEmpty(bigram1Txt.Text);
            bool char2 = !string.IsNullOrEmpty(bigram2Txt.Text);

            if (char1)
            {
                if (char2)
                {
                    AnalyseBigramsWhole(bigram1Txt.Text.ToUpper() + bigram2Txt.Text.ToUpper());
                }
                else
                {
                    AnalyseBigramsFirst(bigram1Txt.Text.ToUpper());
                }
            }
            else
            {
                if (char2)
                {
                    AnalyseBigramsLast(bigram2Txt.Text.ToUpper());
                }
                else
                {
                    AnalyseBigrams();
                }
            }
        }

        private void AnalyseBigramsWhole(string bigram)
        {
            string mainText = "";
            for (int i = 0; i < _input.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(_input[i].ToString().ToLower()))
                    mainText += _input[i];
            }

            List<string> foundPatterns = new List<string>();
            List<string> alternatePatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - 1; i += 2)
            {
                string pat = mainText.Substring(i, 2);
                if (pat != bigram)
                    continue;
                if (foundPatterns.Contains(pat))
                {
                    int index = foundPatterns.IndexOf(pat);
                    patternRepeats[index]++;
                }
                else
                {
                    if (GeneralConstants.CHARACTERS.Contains(pat[0].ToString()) && GeneralConstants.CHARACTERS.Contains(pat[1].ToString()))
                        alternatePatterns.Add(FourSquareCipher.EncryptBigram(pat, _grid1, _grid2));
                    else
                        alternatePatterns.Add("");

                    foundPatterns.Add(pat);
                    patternRepeats.Add(1);
                }
            }

            List<string> sortedFoundPatterns = new List<string>();
            List<int> sortedPatternRepeats = new List<int>();
            int lengthOfList = foundPatterns.Count;
            for (int i = 0; i < lengthOfList; i++)
            {
                int highestRepeat = int.MinValue;
                int highestIndex = 0;
                for (int j = 0; j < foundPatterns.Count; j++)
                {
                    if (patternRepeats[j] > highestRepeat)
                    {
                        highestRepeat = patternRepeats[j];
                        highestIndex = j;
                    }
                }
                if (string.IsNullOrEmpty(alternatePatterns[highestIndex]))
                    sortedFoundPatterns.Add($"{foundPatterns[highestIndex]}");
                else
                    sortedFoundPatterns.Add($"{foundPatterns[highestIndex]} | {alternatePatterns[highestIndex]}");
                sortedPatternRepeats.Add(patternRepeats[highestIndex]);
                foundPatterns.RemoveAt(highestIndex);
                alternatePatterns.RemoveAt(highestIndex);
                patternRepeats.RemoveAt(highestIndex);
            }

            if (_bigramPatternsFrm.IsDisposed)
                _bigramPatternsFrm = new SubstitutePatternAnalysis();

            _bigramPatternsFrm.SetupPatterns(sortedFoundPatterns, sortedPatternRepeats);
            _bigramPatternsFrm.Show();
        }

        private void AnalyseBigramsFirst(string first)
        {
            string mainText = "";
            for (int i = 0; i < _input.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(_input[i].ToString().ToLower()))
                    mainText += _input[i];
            }

            List<string> foundPatterns = new List<string>();
            List<string> alternatePatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - 1; i += 2)
            {
                string pat = mainText.Substring(i, 2);
                if (pat[0].ToString() != first)
                    continue;
                if (foundPatterns.Contains(pat))
                {
                    int index = foundPatterns.IndexOf(pat);
                    patternRepeats[index]++;
                }
                else
                {
                    if (GeneralConstants.CHARACTERS.Contains(pat[0].ToString()) && GeneralConstants.CHARACTERS.Contains(pat[1].ToString()))
                        alternatePatterns.Add(FourSquareCipher.EncryptBigram(pat, _grid1, _grid2));
                    else
                        alternatePatterns.Add("");

                    foundPatterns.Add(pat);
                    patternRepeats.Add(1);
                }
            }

            List<string> sortedFoundPatterns = new List<string>();
            List<int> sortedPatternRepeats = new List<int>();
            int lengthOfList = foundPatterns.Count;
            for (int i = 0; i < lengthOfList; i++)
            {
                int highestRepeat = int.MinValue;
                int highestIndex = 0;
                for (int j = 0; j < foundPatterns.Count; j++)
                {
                    if (patternRepeats[j] > highestRepeat)
                    {
                        highestRepeat = patternRepeats[j];
                        highestIndex = j;
                    }
                }
                if (string.IsNullOrEmpty(alternatePatterns[highestIndex]))
                    sortedFoundPatterns.Add($"{foundPatterns[highestIndex]}");
                else
                    sortedFoundPatterns.Add($"{foundPatterns[highestIndex]} | {alternatePatterns[highestIndex]}");
                sortedPatternRepeats.Add(patternRepeats[highestIndex]);
                foundPatterns.RemoveAt(highestIndex);
                alternatePatterns.RemoveAt(highestIndex);
                patternRepeats.RemoveAt(highestIndex);
            }

            if (_bigramPatternsFrm.IsDisposed)
                _bigramPatternsFrm = new SubstitutePatternAnalysis();

            _bigramPatternsFrm.SetupPatterns(sortedFoundPatterns, sortedPatternRepeats);
            _bigramPatternsFrm.Show();
        }

        private void AnalyseBigramsLast(string last)
        {
            string mainText = "";
            for (int i = 0; i < _input.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(_input[i].ToString().ToLower()))
                    mainText += _input[i];
            }

            List<string> foundPatterns = new List<string>();
            List<string> alternatePatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - 1; i += 2)
            {
                string pat = mainText.Substring(i, 2);
                if (pat[1].ToString() != last)
                    continue;
                if (foundPatterns.Contains(pat))
                {
                    int index = foundPatterns.IndexOf(pat);
                    patternRepeats[index]++;
                }
                else
                {
                    if (GeneralConstants.CHARACTERS.Contains(pat[0].ToString()) && GeneralConstants.CHARACTERS.Contains(pat[1].ToString()))
                        alternatePatterns.Add(FourSquareCipher.EncryptBigram(pat, _grid1, _grid2));
                    else
                        alternatePatterns.Add("");

                    foundPatterns.Add(pat);
                    patternRepeats.Add(1);
                }
            }

            List<string> sortedFoundPatterns = new List<string>();
            List<int> sortedPatternRepeats = new List<int>();
            int lengthOfList = foundPatterns.Count;
            for (int i = 0; i < lengthOfList; i++)
            {
                int highestRepeat = int.MinValue;
                int highestIndex = 0;
                for (int j = 0; j < foundPatterns.Count; j++)
                {
                    if (patternRepeats[j] > highestRepeat)
                    {
                        highestRepeat = patternRepeats[j];
                        highestIndex = j;
                    }
                }
                if (string.IsNullOrEmpty(alternatePatterns[highestIndex]))
                    sortedFoundPatterns.Add($"{foundPatterns[highestIndex]}");
                else
                    sortedFoundPatterns.Add($"{foundPatterns[highestIndex]} | {alternatePatterns[highestIndex]}");
                sortedPatternRepeats.Add(patternRepeats[highestIndex]);
                foundPatterns.RemoveAt(highestIndex);
                alternatePatterns.RemoveAt(highestIndex);
                patternRepeats.RemoveAt(highestIndex);
            }

            if (_bigramPatternsFrm.IsDisposed)
                _bigramPatternsFrm = new SubstitutePatternAnalysis();

            _bigramPatternsFrm.SetupPatterns(sortedFoundPatterns, sortedPatternRepeats);
            _bigramPatternsFrm.Show();
        }

        private void CheckExpectedLetterCount()
        {
            decimal[] startLetter = new decimal[25];
            decimal[] endLetter = new decimal[25];

            LetterPatterns.Bigrams.DataSet freq = BigramsData.FrequencyDataSet;
            for (int i = 0; i < freq.Count; i++)
            {
                string bigram = freq.Keys[i].ToUpper();

                if (bigram[0] > 73)
                    startLetter[bigram[0] - 66] += freq.Values[i] * 1m / freq.GetValueTotal();
                else
                    startLetter[bigram[0] - 65] += freq.Values[i] * 1m / freq.GetValueTotal();

                if (bigram[1] > 73)
                    endLetter[bigram[1] - 66] += freq.Values[i] * 1m / freq.GetValueTotal();
                else
                    endLetter[bigram[1] - 65] += freq.Values[i] * 1m / freq.GetValueTotal();
            }

            List<string> characters = new List<string>();
            foreach (char c in "ABCDEFGHIKLMNOPQRSTUVWXYZ")
            {
                characters.Add(c.ToString());
            }

            SubstitutePatternAnalysis spaStart = new SubstitutePatternAnalysis();
            spaStart.SetupPatterns(characters, new List<decimal>(startLetter), true);
            spaStart.Text = "Expected start";
            spaStart.Show();

            SubstitutePatternAnalysis spaEnd = new SubstitutePatternAnalysis();
            spaEnd.SetupPatterns(characters, new List<decimal>(endLetter), true);
            spaEnd.Text = "Expected end";
            spaEnd.Show();
        }

        private void CheckLetterCount()
        {
            string mainText = "";
            for (int i = 0; i < _input.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(_input[i].ToString().ToLower()))
                    mainText += _input[i];
            }

            List<string> foundPatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - 1; i += 2)
            {
                string pat = mainText.Substring(i, 2);
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

            decimal[] startLetter = new decimal[25];
            decimal[] endLetter = new decimal[25]; 
            
            for (int i = 0; i < foundPatterns.Count; i++)
            {
                string bigram = foundPatterns[i].ToUpper();

                if (bigram[0] > 73)
                    startLetter[bigram[0] - 66] += patternRepeats[i] * 2m / mainText.Length;
                else
                    startLetter[bigram[0] - 65] += patternRepeats[i] * 2m / mainText.Length;

                if (bigram[1] > 73)
                    endLetter[bigram[1] - 66] += patternRepeats[i] * 2m / mainText.Length;
                else
                    endLetter[bigram[1] - 65] += patternRepeats[i] * 2m / mainText.Length;
            }

            List<string> characters = new List<string>();
            foreach (char c in "ABCDEFGHIKLMNOPQRSTUVWXYZ")
            {
                characters.Add(c.ToString());
            }

            SubstitutePatternAnalysis spaStart = new SubstitutePatternAnalysis();
            spaStart.SetupPatterns(characters, new List<decimal>(startLetter), true);
            spaStart.Text = "Actual start";
            spaStart.Show();

            SubstitutePatternAnalysis spaEnd = new SubstitutePatternAnalysis();
            spaEnd.SetupPatterns(characters, new List<decimal>(endLetter), true);
            spaEnd.Text = "Actual end";
            spaEnd.Show();
        }

        private decimal[,] GenerateTableLast(int row, int column, out decimal mean, out decimal standardDeviation)
        {
            decimal[,] table = new decimal[5, 5];
            decimal total = 0;

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    string bigram = FourSquareCipher.CHARACTER_GRID[r][column] + FourSquareCipher.CHARACTER_GRID[row][c];
                    decimal value = BigramsData.GetFrequency(bigram) * 1m / BigramsData.FrequencyDataSet.GetValueTotal();
                    total += value;
                    table[r, c] = value;
                }
            }

            mean = total / 25;
            decimal meanTotal = 0;
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    meanTotal += (table[r, c] - mean) * (table[r, c] - mean);
                }
            }
            standardDeviation = (decimal)Math.Sqrt((double)(meanTotal / 25));

            return table;
        }

        private decimal[,] GenerateTableFirst(int row, int column, out decimal mean, out decimal standardDeviation)
        {
            decimal[,] table = new decimal[5, 5];
            decimal total = 0;

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    string bigram = FourSquareCipher.CHARACTER_GRID[row][c] + FourSquareCipher.CHARACTER_GRID[r][column];
                    decimal value = BigramsData.GetFrequency(bigram) * 1m / BigramsData.FrequencyDataSet.GetValueTotal();
                    total += value;
                    table[r, c] = value;
                }
            }

            mean = total / 25;
            decimal meanTotal = 0;
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    meanTotal += (table[r, c] - mean) * (table[r, c] - mean);
                }
            }
            standardDeviation = (decimal)Math.Sqrt((double)(meanTotal / 25));

            return table;
        }

        private void expectedTableBtn_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    _grid1[r][c].Text = "";
                    _grid2[r][c].Text = "";
                }
            }

            CalculateTable(_grid1, ListOfBigramsFirst);
            CalculateTable(_grid2, ListOfBigramsLast);
        }

        private delegate List<decimal> BigramList(string b, out decimal m, out decimal s);

        private void CalculateTable(TextBox[][] grid, BigramList bigramList)
        {
            decimal[][][,] tables = new decimal[5][][,]
            {
                new decimal[5][,],
                new decimal[5][,],
                new decimal[5][,],
                new decimal[5][,],
                new decimal[5][,]
            };
            decimal[,] means = new decimal[5, 5];
            decimal[,] standardDeviations = new decimal[5, 5];

            List<RowColumnScore>[,] sortedTables = new List<RowColumnScore>[5, 5];

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    tables[r][c] = GenerateTableFirst(r, c, out decimal mean, out decimal standardDeviation);
                    means[r, c] = mean;
                    standardDeviations[r, c] = standardDeviation;

                    sortedTables[r, c] = new List<RowColumnScore>();

                    // SORT

                    for (int _r = 0; _r < 5; _r++)
                    {
                        for (int _c = 0; _c < 5; _c++)
                        {
                            decimal score = tables[r][c][_r, _c];

                            bool sorted = false;
                            for (int j = 0; j < sortedTables[r, c].Count; j++)
                            {
                                if (score > sortedTables[r, c][j].Score)
                                {
                                    sortedTables[r, c].Insert(j, new RowColumnScore(_r, _c, score));
                                    sorted = true;
                                    break;
                                }
                            }
                            if (!sorted)
                                sortedTables[r, c].Add(new RowColumnScore(_r, _c, score));
                        }
                    }

                }
            }

            int mostCertainIndex = -1;
            decimal mostCertainScore = decimal.MaxValue;

            List<RowColumnScore>[] scores = new List<RowColumnScore>[25];
            string characters = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < 25; i++)
            {
                List<decimal> probabilites = bigramList(characters[i].ToString(), out decimal m, out decimal s);

                scores[i] = new List<RowColumnScore>();
                decimal lowestScore = decimal.MaxValue;
                for (int r = 0; r < 5; r++)
                {
                    for (int c = 0; c < 5; c++)
                    {
                        // SCORE

                        decimal meanScore = Math.Abs(means[r, c] - m);
                        decimal standardScore = Math.Abs(standardDeviations[r, c] - s);
                        decimal score = meanScore + standardScore;

                        /*
                        List<RowColumnScore> expectedScores = sortedTables[r, c];
                        for (int j = 0; j < expectedScores.Count; j++)
                        {
                            score += Math.Abs(expectedScores[j].Score - probabilites[j]) * 0.01m;
                        }
                        */

                        // SORT

                        bool sorted = false;
                        for (int j = 0; j < scores[i].Count; j++)
                        {
                            if(score < scores[i][j].Score)
                            {
                                scores[i].Insert(j, new RowColumnScore(r, c, score));
                                sorted = true;
                                break;
                            }
                        }
                        if (!sorted)
                            scores[i].Add(new RowColumnScore(r, c, score));

                        if(score < lowestScore)
                        {
                            lowestScore = score;
                        }
                    }
                }

                if(lowestScore < mostCertainScore)
                {
                    mostCertainIndex = i;
                    mostCertainScore = lowestScore;
                }
            }

            List<int> completedIndexes = new List<int>();
            while(completedIndexes.Count < 25)
            {
                completedIndexes.Add(mostCertainIndex);
                int lowestRow = -1;
                int lowestColumn = -1;
                for (int i = 0; i < scores[mostCertainIndex].Count; i++)
                {
                    RowColumnScore rcs = scores[mostCertainIndex][i];
                    if(grid[rcs.Row][rcs.Column].Text == "")
                    {
                        lowestRow = rcs.Row;
                        lowestColumn = rcs.Column;
                        break;
                    }
                }

                if (lowestRow == -1)
                    break;

                grid[lowestRow][lowestColumn].Text = characters[mostCertainIndex].ToString();
                grid[lowestRow][lowestColumn].Refresh();

                mostCertainIndex = -1;
                decimal lowestScore = decimal.MaxValue;
                for (int i = 0; i < 25; i++)
                {
                    if (completedIndexes.Contains(i))
                        continue;
                    decimal lowestAvailableScore = decimal.MaxValue;
                    for (int j = 0; j < scores[i].Count; j++)
                    {
                        RowColumnScore rcs = scores[i][j];
                        if (grid[rcs.Row][rcs.Column].Text == "")
                        {
                            lowestAvailableScore = rcs.Score;
                            break;
                        }
                    }
                    if(lowestAvailableScore < lowestScore)
                    {
                        lowestScore = lowestAvailableScore;
                        mostCertainIndex = i;
                    }
                }

                if (mostCertainIndex == -1)
                    break;
            }

            return;
        }

        private List<decimal> ListOfBigramsFirst(string first, out decimal mean, out decimal standardDeviation)
        {
            string mainText = "";
            for (int i = 0; i < _input.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(_input[i].ToString().ToLower()))
                    mainText += _input[i];
            }

            List<string> foundPatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - 1; i += 2)
            {
                string pat = mainText.Substring(i, 2);
                if (pat[0].ToString().ToUpper() != first.ToUpper())
                    continue;
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

            while(patternRepeats.Count < 25)
            {
                patternRepeats.Add(0);
            }

            List<decimal> probabilities = new List<decimal>();
            decimal total = 0;
            for (int i = 0; i < patternRepeats.Count; i++)
            {
                decimal prob = patternRepeats[i] / (mainText.Length / 2m);
                total += prob;

                // SORT

                bool sorted = false;
                for (int j = 0; j < probabilities.Count; j++)
                {
                    if (prob > probabilities[j])
                    {
                        probabilities.Insert(j, prob);
                        sorted = true;
                        break;
                    }
                }
                if (!sorted)
                    probabilities.Add(prob);
            }
            mean = total / patternRepeats.Count;

            decimal meanTotal = 0;
            for (int i = 0; i < patternRepeats.Count; i++)
            {
                meanTotal += (probabilities[i] - mean) * (probabilities[i] - mean);
            }
            standardDeviation = (decimal)Math.Sqrt((double)(meanTotal / patternRepeats.Count));
            return probabilities;
        }

        private List<decimal> ListOfBigramsLast(string last, out decimal mean, out decimal standardDeviation)
        {
            string mainText = "";
            for (int i = 0; i < _input.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(_input[i].ToString().ToLower()))
                    mainText += _input[i];
            }

            List<string> foundPatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - 1; i += 2)
            {
                string pat = mainText.Substring(i, 2);
                if (pat[1].ToString().ToUpper() != last.ToUpper())
                    continue;
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

            while(patternRepeats.Count < 25)
            {
                patternRepeats.Add(0);
            }

            List<decimal> probabilities = new List<decimal>();
            decimal total = 0;
            for (int i = 0; i < 25; i++)
            {
                decimal prob = patternRepeats[i] / (mainText.Length / 2m);
                total += prob;

                // SORT

                bool sorted = false;
                for (int j = 0; j < probabilities.Count; j++)
                {
                    if (prob > probabilities[j])
                    {
                        probabilities.Insert(j, prob);
                        sorted = true;
                        break;
                    }
                }
                if (!sorted)
                    probabilities.Add(prob);
            }
            mean = total / 25;

            decimal meanTotal = 0;
            for (int i = 0; i < 25; i++)
            {
                meanTotal += (probabilities[i] - mean) * (probabilities[i] - mean);
            }
            standardDeviation = (decimal)Math.Sqrt((double)(meanTotal / 25));
            return probabilities;
        }
    }
}
