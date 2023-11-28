using DumbCodeYe.Ciphers;
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
                workingCipher = temp;
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

            Output("Unknown cipher");
            return input;
        }

        private string ApplyCeaser(string input, int shift)
        {
            Output($"Applying ceaser at shift {shift}");
            return CeaserCipher.Ceaser(input, shift);
        }

        private string ApplyTransposition(string input)
        {
            Output("Applying transposition");
            return input;
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
