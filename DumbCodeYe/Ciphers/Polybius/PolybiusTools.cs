using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Polybius
{
    public partial class PolybiusTools : Form
    {
        private string mainText = "";
        private string polybiusDigits = "12345";
        private PolybiusGrid PG;
        public char[][] replacements = new char[][]
        {
            new char[] { '#', '#', '#', '#', '#' },
            new char[] { '#', '#', '#', '#', '#' },
            new char[] { '#', '#', '#', '#', '#' },
            new char[] { '#', '#', '#', '#', '#' },
            new char[] { '#', '#', '#', '#', '#' }
        };
        public PolybiusTools()
        {
            InitializeComponent();
        }
        public void SetupText(string text)
        {
            foreach(char c in text)
            {
                if (polybiusDigits.Contains(c))
                    mainText += c;
            }
            mainTxt.Text = mainText;
        }

        private void openGridBtn_Click(object sender, EventArgs e)
        {
            if (PG == null)
                PG = new PolybiusGrid();
            PG.Setup(this);
            PG.Show();
        }

        private void applyGridBtn_Click(object sender, EventArgs e)
        {
            string message = "";
            for (int i = 0; i < mainText.Length; i += 2)
            {
                int row = Convert.ToInt32(mainText[i].ToString()) - 1;
                int column = Convert.ToInt32(mainText[i + 1].ToString()) - 1;
                if (replacements[row][column] == '#')
                    message += (row + 1).ToString() + (column + 1).ToString();
                else
                    message += replacements[row][column];
            }
            mainTxt.Text = message;
        }

        private void PolybiusTools_Load(object sender, EventArgs e)
        {
            PG = new PolybiusGrid();
            PG.Setup(this);
        }
    }
}
