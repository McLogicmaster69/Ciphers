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
    public partial class SubsitutePatterns : Form
    {
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        private SubstitueTool ST;

        public SubsitutePatterns()
        {
            InitializeComponent();
        }

        public void Setup(SubstitueTool st)
        {
            ST = st;
        }
        private void runBtn_Click(object sender, EventArgs e)
        {
            string mainText = "";
            for (int i = 0; i < ST.mainTxt.Text.Length; i++)
            {
                if (Characters.Contains(ST.mainTxt.Text[i].ToString().ToLower()))
                    mainText += ST.mainTxt.Text[i];
            }

            List<string> foundPatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < mainText.Length - (int)patternLength.Value; i++)
            {
                string pat = mainText.Substring(i, (int)patternLength.Value);
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

            List<string> sortedFoundPatterns = new List<string>();
            List<int> sortedPatternRepeats = new List<int>();
            int lengthOfList = foundPatterns.Count;
            for (int i = 0; i < lengthOfList; i++)
            {
                int highestRepeat = int.MinValue;
                int highestIndex = 0;
                for (int j = 0; j < foundPatterns.Count; j++)
                {
                    if(patternRepeats[j] > highestRepeat)
                    {
                        highestRepeat = patternRepeats[j];
                        highestIndex = j;
                    }
                }
                sortedFoundPatterns.Add(foundPatterns[highestIndex]);
                sortedPatternRepeats.Add(patternRepeats[highestIndex]);
                foundPatterns.RemoveAt(highestIndex);
                patternRepeats.RemoveAt(highestIndex);
            }

            SubstitutePatternAnalysis spa = new SubstitutePatternAnalysis();
            spa.SetupPatterns(sortedFoundPatterns, sortedPatternRepeats);
            spa.Show();
        }
    }
}
