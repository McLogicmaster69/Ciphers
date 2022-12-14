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
    public partial class Patterns : Form
    {
        public Patterns()
        {
            InitializeComponent();
        }
        public void SetupPatterns(List<string> patterns, List<int> spacing)
        {
            for (int i = 0; i < patterns.Count; i++)
            {
                string patternFormat = patterns[i] + "  -  ";
                for (int j = 2; j <= 20; j++)
                {
                    if (spacing[i] % j == 0)
                        patternFormat += "::  ";
                    else
                        patternFormat += "    ";
                }
                patternFormat += "-  " + spacing[i].ToString();
                patternList.Items.Add(patternFormat);
            }
        }
    }
}
