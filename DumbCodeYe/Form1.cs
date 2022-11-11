using DumbCodeYe.Playfair;
using DumbCodeYe.Polybius;
using DumbCodeYe.Quadgrams;
using DumbCodeYe.Substitution;
using DumbCodeYe.Transposition;
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
        public mainFrm()
        {
            InitializeComponent();
        }
        private void upperBtn_Click(object sender, EventArgs e)
        {
            textInput.Text = textInput.Text.ToUpper();
        }
        private void ceaserBtn_Click(object sender, EventArgs e)
        {
            TryCeaser();
        }
        private void substituteBtn_Click(object sender, EventArgs e)
        {
            OpenSubstituteTool();
        }
        private void vigenereBtn_Click(object sender, EventArgs e)
        {
            OpenVigenereTool();
        }
        private void polybiusBtn_Click(object sender, EventArgs e)
        {
            OpenPolybiusTool();
        }
        private void transpositionBtn_Click(object sender, EventArgs e)
        {
            OpenTransposition();
        }
        private void morseBtn_Click(object sender, EventArgs e)
        {
            GetMorseCode();
        }
        private void binaryBtn_Click(object sender, EventArgs e)
        {
            GetBinary();
        }
        private void playfairBtn_Click(object sender, EventArgs e)
        {
            OpenPlayfairTools();
        }
        private void lettersBtn_Click(object sender, EventArgs e)
        {
            string outputText = "";
            foreach (char c in textInput.Text)
            {
                if (Capitals.Contains(c))
                    outputText += c;
            }
            textInput.Text = outputText;
        }

        // CEASER

        private void TryCeaser()
        {
            float[] scores = new float[26];
            float[] freq = GetFrequencyProfile(textInput.Text);
            string freqText = "";
            for (int i = 0; i < 26; i++)
            {
                scores[i] = CalculateScore(freq, i);
                freqText += $"offset {i} gives score {scores[i]}\n";
                if (scores[i] < 400)
                {
                    Ceaser(textInput.Text, i);
                }
            }
            FrequencyFrm frequency = new FrequencyFrm();
            frequency.UpdateFreqLabel(freqText);
            frequency.Show();
        }
        private void Ceaser(string input, int offset)
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
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(output);
            txtOut.Show();
        }

        // TRANSPOSITION

        private void OpenTransposition()
        {
            TranspositionTools TT = new TranspositionTools();
            TT.Setup(textInput.Text);
            TT.Show();
        }

        // SUBSTITUTE

        private void OpenSubstituteTool()
        {
            SubstitueTool st = new SubstitueTool();
            st.SetupText(textInput.Text);
            st.Show();
        }

        // VIGENERE

        private void OpenVigenereTool()
        {
            VigenereTools vt = new VigenereTools();
            vt.SetupText(textInput.Text);
            vt.Show();
        }

        // POLYBIUS

        private void OpenPolybiusTool()
        {
            PolybiusTools pt = new PolybiusTools();
            pt.SetupText(textInput.Text);
            pt.Show();
        }

        // MORSE

        private void GetMorseCode()
        {
            string finalText = "";
            foreach (string code in textInput.Text.Split(' '))
            {
                finalText += GetMorseCharacter(code);
            }
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(finalText);
            txtOut.Show();
        }
        private string GetMorseCharacter(string morse) // A = DOT , D = DASH
        {
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

        // BINARY

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

        // PLAYFAIR

        private void OpenPlayfairTools()
        {
            PlayfairSelection PS = new PlayfairSelection(textInput.Text);
            PS.Show();
        }

        // OTHER

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

        private void btnBacon_Click(object sender, EventArgs e)
        {
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
        }

        private void initQuadBtn_Click(object sender, EventArgs e)
        {
            InitQuadgramsFrm iqf = new InitQuadgramsFrm();
            iqf.Show();
        }
    }
}
