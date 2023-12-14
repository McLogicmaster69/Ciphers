using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Substitution
{
    public partial class SubstitutePatternAnalysis : Form
    {
        public SubstitutePatternAnalysis()
        {
            InitializeComponent();
        }

        public void SetupPatterns(List<string> patterns, List<int> repeats)
        {
            bool ignoreOneRule = patterns[0].Length == 1;

            for (int i = 0; i < patterns.Count; i++)
            {
                if(repeats[i] > 1 || ignoreOneRule)
                {
                    patternsList.Items.Add($"{patterns[i]} with freq of {repeats[i]}");
                }
            }
        }
    }
}
