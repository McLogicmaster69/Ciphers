using DumbCodeYe.Ciphers;
using DumbCodeYe.Ciphers.Substitution;
using DumbCodeYe.Ciphers.Transposition;
using DumbCodeYe.Ciphers.Vigenere;
using DumbCodeYe.LetterPatterns.BasicWordLib;
using DumbCodeYe.LetterPatterns.Bigrams;
using DumbCodeYe.LetterPatterns.Quadgrams;
using DumbCodeYe.LetterPatterns.WordFreq;
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

namespace DumbCodeYe
{
    public enum CipherType
    {
        Ceaser,
        Substitution,
        Transposition,
        Vigenere
    }

    public partial class AutoSolverFrm : Form
    {
        public const int MAX_ATTEMPTS = 3;

        private readonly string _input;
        private int _tabIndex = 0;

        public static void Solve(string input)
        {
            AutoSolverFrm frm = new AutoSolverFrm(input);
            frm.Show();
            frm.Run();
        }

        public AutoSolverFrm(string input)
        {
            InitializeComponent();

            _input = input;
        }
        
        public void Run()
        {
            AutoSolve();
        }

        public void AutoSolve()
        {
            InitialiseLibs();
            Output("");
            string workingCipher = _input;
            bool foundText = false;

            // Cracking process begins

            for (int i = 0; i < MAX_ATTEMPTS; i++)
            {
                if (CheckTextIsDone(workingCipher)) 
                {
                    foundText = true;
                    break;
                }

                Output("Attempting to crack cipher");
                _tabIndex++;
                string temp = ApplyCipher(workingCipher);
                _tabIndex--;
                if (temp == workingCipher)
                {
                    Output("No changes have occured to the text");
                    Output("Exiting loop");
                    break;
                }
                workingCipher = temp.ToUpper();
            }

            // Cracking is finished
            
            if (!foundText)
            {
                foundText = CheckTextIsDone(workingCipher);
            }

            Output("");
            Output("Auto solve complete");
            if (foundText)
            {
                Output("Status: success");
                TextOutputFrm.CreateOutput(workingCipher);
            }
            else
            {
                Output("Status: failure");
            }
        }

        private bool CheckTextIsDone(string text)
        {
            long averageValue = QuadgramsData.GetAverageValue(text);
            Output($"Average quadgram value of text: {averageValue}");
            if(averageValue >= QuadgramsData.EXPECTED_ENGLISH_AVERAGE)
            {
                Output("Value is accepted as english text");
                return true;
            }
            else
            {
                Output("Value is not accepted as english text");
                return false;
            }
        }

        private void InitialiseLibs()
        {
            Output("Initialise BasicWordLib");
            BasicWordData.Initialise();
            Output("Initalised");
            Output("Initialise Bigrams");
            BigramsData.Initialise();
            Output("Initalised");
            Output("Initialise Quadgrams");
            QuadgramsData.Initialise();
            Output("Initalised");
            Output("Initialise WordFreq");
            WordFreqData.Initialise();
            Output("Initalised");
        }

        private string ApplyCipher(string input)
        {
            Output("Checking for morse");
            if (MorseCode.IsMorse(input))
            {
                Output("Morse code suspected");
                _tabIndex++;
                string output = ApplyMorse(input);
                _tabIndex--;
                return output;
            }

            Output("Getting frequency scores");
            float[] freqScores = CeaserCipher.GetFrequencyShifts(input);

            if(freqScores[0] < CeaserCipher.EXPECTED_ENGLISH_SCORE)
            {
                Output("Transposition suspected");
                _tabIndex++;
                string output = ApplyTransposition(input);
                _tabIndex--;
                return output;
            }

            for (int i = 1; i < 26; i++)
            {
                if(freqScores[i] < 400)
                {
                    Output($"Ceaser suspected at shift {i}");
                    _tabIndex++;
                    string output = ApplyCeaser(input, i);
                    _tabIndex--;
                    return output;
                }
            }

            Output("Checking vigenere");
            _tabIndex++;
            string vigenereOutput = VigenereCipher.AutoSolve(input, Output);
            _tabIndex--;

            if (vigenereOutput != input)
                return vigenereOutput;

            Output("Trying substitution");
            _tabIndex++;
            string substitutionOutput = SubstitutionCipher.AutoSolve(input);
            _tabIndex--;

            Output("Unknown cipher");
            return input;
        }

        private string ApplyCeaser(string input, int shift)
        {
            Output($"Applying ceaser at shift {shift}");
            return CeaserCipher.Ceaser(input, shift);
        }

        private string ApplyMorse(string input)
        {
            Output("Applying morse code");

            List<char> characers = new List<char>();
            List<int> frequency = new List<int>();

            foreach(char c in input)
            {
                if (!characers.Contains(c))
                {
                    characers.Add(c);
                    frequency.Add(1);
                    continue;
                }

                for (int i = 0; i < characers.Count; i++)
                {
                    if(characers[i] == c)
                    {
                        frequency[i]++;
                        break;
                    }
                }
            }

            char firstCommon = characers[0];
            char secondCommon = characers[1];
            int firstFreq = frequency[0];
            int secondFreq = frequency[1];

            for (int i = 2; i < characers.Count; i++)
            {
                if (characers[i] == ' ')
                    continue;
                if(frequency[i] > firstFreq)
                {
                    char tempChar = firstCommon;
                    int tempFreq = firstFreq;
                    firstCommon = characers[i];
                    firstFreq = frequency[i];
                    if(tempFreq > secondFreq)
                    {
                        secondCommon = tempChar;
                        secondFreq = tempFreq;
                    }
                }
                else if (frequency[i] > secondFreq)
                {
                    secondCommon = characers[i];
                    secondFreq = frequency[i];
                }
            }

            Output($"Trying dot as {firstCommon.ToString()} and dash as {secondCommon.ToString()}");
            string morse1 = MorseCode.GetMorseCode(input, firstCommon.ToString(), secondCommon.ToString(), '/', ' ');
            Output($"Trying dot as {secondCommon.ToString()} and dash as {firstCommon.ToString()}");
            string morse2 = MorseCode.GetMorseCode(input, secondCommon.ToString(), firstCommon.ToString(), '/', ' ');

            if(string.IsNullOrEmpty(morse1) && string.IsNullOrEmpty(morse2))
            {
                Output("Morse code did not work");
                return input;
            }
            else if(string.IsNullOrEmpty(morse1) == false && string.IsNullOrEmpty(morse2) == false)
            {
                Output("Unable to decide what is a dot and what is a dash");
                return input;
            }
            else if (!string.IsNullOrEmpty(morse1))
            {
                return morse1;
            }
            else
            {
                return morse2;
            }
        }

        private string ApplyTransposition(string input)
        {
            Output("Applying transposition");
            _tabIndex++;
            string output = TranspositionCipher.AutoSolve(input, Output);
            _tabIndex--;
            return output;
        }

        private void Output(string output)
        {
            string tab = "";
            for (int i = 0; i < _tabIndex; i++)
            {
                tab += "-";
            }
            if (!string.IsNullOrEmpty(tab))
                tab += " ";

            textOut.AppendText($"{tab}{output}\r\n");
        }
    }
}
