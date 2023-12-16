using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Trifid
{
    public partial class TrifidTools : Form
    {
        private string text = "";

        public TrifidTools(string input)
        {
            InitializeComponent();
            text = input;
        }

        private void CrackBtn_Click(object sender, EventArgs e)
        {
            string output = TrifidCipher.Crack(text, keywordTxt.Text);
            TextOutputFrm.CreateOutput(output).Show();
        }
    }
}
