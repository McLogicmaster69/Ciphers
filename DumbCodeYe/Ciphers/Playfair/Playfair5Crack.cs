using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Playfair
{
    public partial class Playfair5Crack : Form
    {
        private string MainText;
        public Playfair5Crack(string text)
        {
            InitializeComponent();
            MainText = text;
        }

    }
}
