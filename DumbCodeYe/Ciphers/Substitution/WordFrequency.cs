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
    public partial class WordFrequencyFrm : Form
    {
        public WordFrequencyFrm()
        {
            InitializeComponent();
        }
        public void UpdateFreqLbl(string text)
        {
            textOut.Text = text;
        }
    }
}
