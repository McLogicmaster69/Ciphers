using DumbCodeYe.BasicWordLib;
using DumbCodeYe.Bigrams;
using DumbCodeYe.Hill;
using DumbCodeYe.Playfair;
using DumbCodeYe.Polybius;
using DumbCodeYe.Quadgrams;
using DumbCodeYe.Substitution;
using DumbCodeYe.Transposition;
using DumbCodeYe.TwoSquare;
using DumbCodeYe.WordFreq;
using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe
{
    public partial class mainFrm : Form
    {
        private float[] CharacterFrequency = new float[] { 0.082f, 0.015f, 0.028f, 0.043f, 0.127f, 0.022f, 0.020f, 0.061f, 0.070f, 0.002f, 0.008f, 0.040f, 0.024f, 0.067f, 0.075f, 0.019f, 0.001f, 0.060f, 0.063f, 0.091f, 0.028f, 0.010f, 0.024f, 0.002f, 0.020f, 0.001f};
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        private string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const int SpaceIterations = 400;

        private WordDictionary dict = new WordDictionary();
        private Spelling speller = new Spelling();

        ///
        /// START METHODS
        ///

        public mainFrm()
        {
            InitializeComponent();
        }
        private void mainFrm_Load(object sender, EventArgs e)
        {
            InitDropouts();
            dict.Initialize();
            speller.Dictionary = dict;
        }

        ///
        /// BUTTON METHODS
        ///

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void upperBtn_Click(object sender, EventArgs e)
        {
            ToUpper();
            RollingTheRick.Roll();
            textInput.Text = textInput.Text.ToUpper();
        }
        private void ceaserBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            TryCeaser();
        }
        private void substituteBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            OpenSubstituteTool();
        }
        private void vigenereBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            OpenVigenereTool();
        }
        private void polybiusBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            OpenPolybiusTool();
        }
        private void transpositionBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            OpenTransposition();
        }
        private void morseBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            GetMorseCode();
        }
        private void binaryBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            GetBinary();
        }
        private void playfairBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            OpenPlayfairTools();
        }
        private void lettersBtn_Click(object sender, EventArgs e)
        {
            JustLetters();
        }
        private void btnBacon_Click(object sender, EventArgs e)
        {
            BaconCipher();
        }
        private void btnHill_Click(object sender, EventArgs e)
        {
            HillCipher();
        }
        private void twoSquareBtn_Click(object sender, EventArgs e)
        {
            TwoSquareCipher();
        }
        private void addSpacesBtn_Click(object sender, EventArgs e)
        {
            Spaces();
        }
        private void initBigramsBtn_Click(object sender, EventArgs e)
        {
            InitBigramsFrm ibw = new InitBigramsFrm();
            ibw.Show();
        }
        private void initWordFreqBtn_Click(object sender, EventArgs e)
        {
            InitWordFreq iqf = new InitWordFreq();
            iqf.Show();
        }
        private void initDictionaryBtn_Click(object sender, EventArgs e)
        {
            InitBasicWord ibw = new InitBasicWord();
            ibw.Show();
        }
        private void initQuadBtn_Click(object sender, EventArgs e)
        {
            InitQuadgramsFrm iqf = new InitQuadgramsFrm();
            iqf.Show();
        }

        /// 
        /// ACTION METHODS
        /// 

        private void JustLetters()
        {
            // Check each character if it is either upper or lowercase of the english alphabet
            RollingTheRick.Roll();
            string outputText = "";
            foreach (char c in textInput.Text)
            {
                if (Capitals.Contains(c.ToString().ToUpper()))
                    outputText += c;
            }
            textInput.Text = outputText;
        }
        private void ToUpper()
        {
            textInput.Text = textInput.Text.ToUpper();
        }

        ///
        /// CEASER
        ///

        private void TryCeaser()
        {
            // Check frequency analysis for patterns
            float[] scores = new float[26];
            float[] freq = GetFrequencyProfile(textInput.Text);
            string freqText = "";
            for (int i = 0; i < 26; i++)
            {
                // Calculate frequency score for letter offset and output results
                scores[i] = CalculateScore(freq, i);
                freqText += $"offset {i} gives score {scores[i]}\n";
                // If score if low enough, apply ceaser to given offset
                if (scores[i] < 400)
                {
                    Ceaser(textInput.Text, i);
                }
            }
            // Give output
            FrequencyFrm frequency = new FrequencyFrm();
            frequency.UpdateFreqLabel(freqText);
            frequency.Show();
        }
        private void Ceaser(string input, int offset)
        {
            // Apply ceaser with offset
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                // Check if valid character
                if (Characters.Contains(input[i].ToString().ToLower()))
                {
                    // Offset the character
                    output += Characters[(Characters.IndexOf(input[i].ToString().ToLower()) - offset + 26) % 26];
                }
                else
                {
                    // Include the unknown character
                    output += input[i];
                }
            }
            // Output
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(output);
            txtOut.Show();
        }

        ///
        /// TRANSPOSITION
        ///

        private void OpenTransposition()
        {
            TranspositionTools TT = new TranspositionTools();
            TT.Setup(textInput.Text);
            TT.Show();
        }

        ///
        /// SUBSTITUTE
        ///

        private void OpenSubstituteTool()
        {
            SubstitueTool st = new SubstitueTool();
            st.SetupText(textInput.Text);
            st.Show();
        }

        ///
        /// VIGENERE
        ///

        private void OpenVigenereTool()
        {
            VigenereTools vt = new VigenereTools();
            vt.SetupText(textInput.Text);
            vt.Show();
        }

        ///
        /// POLYBIUS
        ///

        private void OpenPolybiusTool()
        {
            PolybiusTools pt = new PolybiusTools();
            pt.SetupText(textInput.Text);
            pt.Show();
        }

        ///
        /// MORSE
        ///

        private void GetMorseCode()
        {
            string finalText = "";
            // Split code into characters
            foreach (string code in textInput.Text.Split(' '))
            {
                // Get character for each morse character
                finalText += GetMorseCharacter(code);
            }
            // Output
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(finalText);
            txtOut.Show();
        }
        private string GetMorseCharacter(string morse) // A = DOT , D = DASH
        {
            // Check according to A as . and D as -
            switch (morse)
            {
                case "AD":
                    return "a";
                case "DAAA":
                    return "b";
                case "DADA":
                    return "c";
                case "DAA":
                    return "d";
                case "A":
                    return "e";
                case "AADA":
                    return "f";
                case "DDA":
                    return "g";
                case "AAAA":
                    return "h";
                case "AA":
                    return "i";
                case "ADDD":
                    return "j";
                case "DAD":
                    return "k";
                case "ADAA":
                    return "l";
                case "DD":
                    return "m";
                case "DA":
                    return "n";
                case "DDD":
                    return "o";
                case "ADDA":
                    return "p";
                case "DDAD":
                    return "q";
                case "ADA":
                    return "r";
                case "AAA":
                    return "s";
                case "D":
                    return "t";
                case "AAD":
                    return "u";
                case "AAAD":
                    return "v";
                case "ADD":
                    return "w";
                case "DAAD":
                    return "x";
                case "DADD":
                    return "y";
                case "DDAA":
                    return "z";
            }
            return "";
        }

        ///
        /// BINARY
        ///

        private void GetBinary()
        {
            string finalText = "";
            foreach (string code in textInput.Text.Split(' '))
            {
                finalText += GetBinaryCharacter(code);
            }
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(finalText);
            txtOut.Show();
        }
        private string GetBinaryCharacter(string binary)
        {
            switch (binary)
            {
                case "00000":
                    return "A";
                case "00001":
                    return "B";
                case "00010":
                    return "C";
                case "00011":
                    return "D";
                case "00100":
                    return "E";
                case "00101":
                    return "F";
                case "00110":
                    return "G";
                case "00111":
                    return "H";
                case "01000":
                    return "I";
                case "01001":
                    return "J";
                case "01010":
                    return "K";
                case "01011":
                    return "L";
                case "01100":
                    return "M";
                case "01101":
                    return "N";
                case "01110":
                    return "O";
                case "01111":
                    return "P";
                case "10000":
                    return "Q";
                case "10001":
                    return "R";
                case "10010":
                    return "S";
                case "10011":
                    return "T";
                case "10100":
                    return "U";
                case "10101":
                    return "V";
                case "10110":
                    return "W";
                case "10111":
                    return "X";
                case "11000":
                    return "Y";
                case "11001":
                    return "Z";
            }
            return "";
        }

        ///
        /// PLAYFAIR
        ///

        private void OpenPlayfairTools()
        {
            PlayfairSelection PS = new PlayfairSelection(textInput.Text);
            PS.Show();
        }

        ///
        /// SCORE
        ///

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

        /// 
        /// BACON
        /// 

        private void BaconCipher()
        {
            RollingTheRick.Roll();
            string plainText = "";
            string cipherText = textInput.Text;
            string chunk;
            if (cipherText.Length >= 5 && cipherText.Length % 5 == 0)
            {
                for (int index = 0; index < (cipherText.Length); index += 5)
                {
                    chunk = cipherText.Substring(index, 5);
                    switch (chunk)
                    {
                        case "AAAAA":
                            plainText = plainText + "A";
                            break;
                        case "AAAAB":
                            plainText = plainText + "B";
                            break;
                        case "AAABA":
                            plainText = plainText + "C";
                            break;
                        case "AAABB":
                            plainText = plainText + "D";
                            break;
                        case "AABAA":
                            plainText = plainText + "E";
                            break;
                        case "AABAB":
                            plainText = plainText + "F";
                            break;
                        case "AABBA":
                            plainText = plainText + "G";
                            break;
                        case "AABBB":
                            plainText = plainText + "H";
                            break;
                        case "ABAAA":
                            plainText = plainText + "I";
                            break;
                        case "ABAAB":
                            plainText = plainText + "J";
                            break;
                        case "ABABA":
                            plainText = plainText + "K";
                            break;
                        case "ABABB":
                            plainText = plainText + "L";
                            break;
                        case "ABBAA":
                            plainText = plainText + "M";
                            break;
                        case "ABBAB":
                            plainText = plainText + "N";
                            break;
                        case "ABBBA":
                            plainText = plainText + "O";
                            break;
                        case "ABBBB":
                            plainText = plainText + "P";
                            break;
                        case "BAAAA":
                            plainText = plainText + "Q";
                            break;
                        case "BAAAB":
                            plainText = plainText + "R";
                            break;
                        case "BAABA":
                            plainText = plainText + "S";
                            break;
                        case "BAABB":
                            plainText = plainText + "T";
                            break;
                        case "BABAA":
                            plainText = plainText + "U";
                            break;
                        case "BABAB":
                            plainText = plainText + "V";
                            break;
                        case "BABBA":
                            plainText = plainText + "W";
                            break;
                        case "BABBB":
                            plainText = plainText + "X";
                            break;
                        case "BBAAA":
                            plainText = plainText + "Y";
                            break;
                        case "BBAAB":
                            plainText = plainText + "Z";
                            break;
                        default:
                            MessageBox.Show("It was jacob's fault");
                            break;
                    }
                }
                TextOutputFrm txtOut = new TextOutputFrm();
                txtOut.SetOutput(plainText);
                txtOut.Show();
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=DjelB-Z2QWo");
            }
            else
            {
                MessageBox.Show("Not Bacon Cipher");
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=DjelB-Z2QWo");
            }
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            dict.Initialize();
            speller.Dictionary = dict;
        }

        private void initQuadBtn_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            InitQuadgramsFrm iqf = new InitQuadgramsFrm();
            iqf.Show();
        }

        private void btnHill_Click(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            HillCipher hillCiper = new HillCipher();
            hillCiper.SetText(textInput.Text);
            hillCiper.Show();
        }

        /// 
        /// SPACES
        /// 

        private void Spaces()
        {
            RollingTheRick.Roll();
            TextOutputFrm TOF = new TextOutputFrm();
            TOF.SetOutput(AddSpaces(textInput.Text.ToUpper()));
            TOF.Show();
        }

        private string AddSpaces(string s)
        {
            ProgressBarForm pb = new ProgressBarForm();
            pb.Show();
            int letterIndex = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    letterIndex = i + 1;
                    break;
                }
            }
            SpaceSet[] Sets = new SpaceSet[SpaceIterations];
            Sets[0] = new SpaceSet(s, 0);
            while(letterIndex < s.Length)
            {
                List<SpaceSet> newSets = new List<SpaceSet>();
                for (int i = 0; i < Sets.Length; i++)
                {
                    if (Sets[i] == null)
                        break;
                    SpaceSet currentSet = Sets[i];
                    SpaceSet spaces = new SpaceSet(currentSet.Text.Substring(0, letterIndex + currentSet.Spaces) + " " + currentSet.Text.Substring(letterIndex + currentSet.Spaces), currentSet.Spaces + 1);
                    SpaceSet nonSpaces = new SpaceSet(currentSet.Text, currentSet.Spaces);
                    InsertIntoSets(newSets, nonSpaces);
                    InsertIntoSets(newSets, spaces);
                }
                Sets = newSets.ToArray();
                letterIndex++;
                pb.loadingBar.Value = (int)Math.Floor((letterIndex * 100f) / s.Length);
                pb.status.Text = $"{letterIndex} / {s.Length}";
                pb.Invalidate();
                pb.Refresh();
            }
            pb.Close();
            return Sets[0].Text;
        }

        private void InsertIntoSets(List<SpaceSet> spaces, SpaceSet set)
        {
            if (spaces.Count < SpaceIterations)
            {
                for (int j = 0; j <= spaces.Count; j++)
                {
                    if (j == spaces.Count)
                    {
                        spaces.Add(set);
                        break;
                    }
                    else if (set.Score() > spaces[j].Score())
                    {
                        spaces.Insert(j, set);
                        break;
                    }
                }
            }
            else if(spaces[SpaceIterations - 1].Score() < set.Score())
            {
                for (int j = 0; j < spaces.Count; j++)
                {
                    if (set.Score() > spaces[j].Score())
                    {
                        spaces.Insert(j, set);
                        break;
                    }
                }
                spaces.RemoveAt(SpaceIterations);
            }
        }

        /// 
        /// TWO SQUARE
        /// 

        private void TwoSquareCipher()
        {
            TwoSquareTools TST = new TwoSquareTools();
            TST.Setup(textInput.Text);
            TST.Show();
        }


        /// 
        /// CUSTOM MOVEABLE TAB
        /// 

        private bool mouseDown = false;
        private Point offset;

        private void dragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void dragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void dragPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /// 
        /// DROPOUT CONTROL
        ///

        private Control[] Dropouts;

        // Main methods

        private void InitDropouts()
        {
            // Set Dropouts to all dropouts
            Dropouts = new Control[]
            {
                textOperationsDropout,
                basicCiphersDropout,
                monoAlphabeticDropout,
                polyAlphabeticDropout,
                transpositionDropout
            };
        }
        private void ChangeDropout(Control dropout)
        {
            // Hide dropout if already visible
            if (dropout.Visible)
                dropout.Visible = false;

            // Else hide all other dropouts and show the selected one
            else
            {
                HideAllDropouts();
                dropout.Visible = true;
            }
        }
        private void HideAllDropouts()
        {
            // Iterate through each dropout and hide
            foreach(Control drop in Dropouts)
            {
                drop.Visible = false;
            }
        }

        // Button methods

        private void textOperationsBtn_Click(object sender, EventArgs e)
        {
            ChangeDropout(textOperationsDropout);
        }

        private void basicCipherBtn_Click(object sender, EventArgs e)
        {
            ChangeDropout(basicCiphersDropout);
        }

        private void monoAlphabeticBtn_Click(object sender, EventArgs e)
        {
            ChangeDropout(monoAlphabeticDropout);
        }

        private void polyAlphabeticBtn_Click(object sender, EventArgs e)
        {
            ChangeDropout(polyAlphabeticDropout);
        }

        private void transpositionBtn_Click_1(object sender, EventArgs e)
        {
            ChangeDropout(transpositionDropout);
        }

        private void textInput_Enter(object sender, EventArgs e)
        {
            HideAllDropouts();
        }
    }
}
