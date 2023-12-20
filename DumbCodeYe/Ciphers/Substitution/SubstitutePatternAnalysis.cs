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
        private PatternClicked _onClicked;
        private List<string> _patterns;

        public SubstitutePatternAnalysis()
        {
            InitializeComponent();
        }

        public SubstitutePatternAnalysis(PatternClicked onClicked)
        {
            _onClicked = onClicked;
            InitializeComponent();
        }

        public void SetupPatterns(List<string> patterns, List<int> repeats)
        {
            _patterns = patterns;
            patternsList.Items.Clear();
            if (patterns.Count == 0)
                return;
            bool ignoreOneRule = patterns[0].Length == 1;

            for (int i = 0; i < patterns.Count; i++)
            {
                if(repeats[i] > 1 || ignoreOneRule)
                {
                    patternsList.Items.Add($"{patterns[i]} with freq of {repeats[i]}");
                }
            }
        }

        public void SetupPatterns(List<string> patterns, List<long> repeats)
        {
            _patterns = patterns;
            patternsList.Items.Clear();
            if (patterns.Count == 0)
                return;
            bool ignoreOneRule = patterns[0].Length == 1;

            for (int i = 0; i < patterns.Count; i++)
            {
                if(repeats[i] > 1 || ignoreOneRule)
                {
                    patternsList.Items.Add($"{patterns[i]} with freq of {repeats[i]}");
                }
            }
        }

        private void patternsList_DoubleClick(object sender, EventArgs e)
        {
            _onClicked?.Invoke(_patterns[patternsList.SelectedIndex]);
        }
    }
}
