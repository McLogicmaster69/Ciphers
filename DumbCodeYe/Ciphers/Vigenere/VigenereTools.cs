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
        private readonly string _mainText;
        private readonly string _normalText;

        public const int COINCIDENCE_SHIFTS = 30;

        public VigenereTools(string input)
        {
            InitializeComponent();

            _normalText = input;
            _mainText = "";
            foreach (char c in input)
            {
                if (GeneralConstants.CAPITALS.Contains(c))
                    _mainText += c;
            }
        }

        private void coincidencesBtn_Click(object sender, EventArgs e)
        {
            GetCoincidences();
        }

        private void patternsBtn_Click(object sender, EventArgs e)
        {
            VigenereCipher.GetPatterns(_mainText, out List<string> foundPatterns, out List<int> patternSpacing);
            Patterns patternFrm = new Patterns(foundPatterns, patternSpacing);
            patternFrm.Show();
        }

        private void resultsBtn_Click(object sender, EventArgs e)
        {
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(VigenereCipher.Vigenere(_mainText, _normalText, (int)suspectedKeyLength.Value));
            txtOut.Show();
        }

        private void autoSolveBtn_Click(object sender, EventArgs e)
        {
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(VigenereCipher.AutoSolve(_mainText));
            txtOut.Show();
        }

        private void GetCoincidences()
        {
            int[] totalCoincidences = VigenereCipher.GetCoincidences(_mainText, COINCIDENCE_SHIFTS, out string[] shiftedText);

            Coincidences coincidences = new Coincidences(shiftedText, totalCoincidences);
            coincidences.Show();
        }
    }
}
