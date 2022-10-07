using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Polybius
{
    public partial class PolybiusGrid : Form
    {
        private TextBox[][] Grid; 
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        private PolybiusTools PT;
        public PolybiusGrid()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private char[][] GetValues()
        {
            try
            {
                char[][] values = new char[][]
                {
                    new char[] { Value11.Text[0], Value12.Text[0], Value13.Text[0], Value14.Text[0], Value15.Text[0] },
                    new char[] { Value21.Text[0], Value22.Text[0], Value23.Text[0], Value24.Text[0], Value25.Text[0] },
                    new char[] { Value31.Text[0], Value32.Text[0], Value33.Text[0], Value34.Text[0], Value35.Text[0] },
                    new char[] { Value41.Text[0], Value42.Text[0], Value43.Text[0], Value44.Text[0], Value45.Text[0] },
                    new char[] { Value51.Text[0], Value52.Text[0], Value53.Text[0], Value54.Text[0], Value55.Text[0] },
                };
                return values;
            }
            catch
            {
                return null;
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            char[][] values = GetValues();
            if(values == null)
            {
                errorTxt.Text = $"There is an empty value";
                return;
            }
            bool[] replaced = new bool[26];
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    int charIndex = Characters.IndexOf(values[x][y]);
                    if (charIndex == -1)
                    {
                        if (values[x][y] != '#')
                        {
                            errorTxt.Text = $"row {x + 1}, column {y + 1} has no valid value";
                            return;
                        }
                    }
                    else
                    {
                        if (replaced[charIndex])
                        {
                            errorTxt.Text = $"There are more than one value of {values[x][y]}";
                            return;
                        }
                        replaced[charIndex] = true;
                    }
                }
            }
            PT.replacements = values;
            errorTxt.Text = "";
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Grid[x][y].Text = "#";
                }
            }
        }

        public void Setup(PolybiusTools pt)
        {
            PT = pt;
            Grid = new TextBox[][]
            {
                new TextBox[] { Value11, Value12, Value13, Value14, Value15 },
                new TextBox[] { Value21, Value22, Value23, Value24, Value25 },
                new TextBox[] { Value31, Value32, Value33, Value34, Value35 },
                new TextBox[] { Value41, Value42, Value43, Value44, Value45 },
                new TextBox[] { Value51, Value52, Value53, Value54, Value55 }
            };
        }
    }
}
