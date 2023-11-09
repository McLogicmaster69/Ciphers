using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.TwoSquare
{
    public partial class TwoSquareTools : Form
    {
        char[][] grid1;
        char[][] grid2;
        string MainText;
        public TwoSquareTools()
        {
            InitializeComponent();
        }
        public void Setup(string text)
        {
            MainText = text;
        }

        private void freqBtn_Click(object sender, EventArgs e)
        {
            List<string> bigrams = new List<string>();
            List<int> freq = new List<int>();
            for(int i = 2; i < MainText.Length; i += 2)
            {
                string bigram = MainText[i].ToString() + MainText[i + 1].ToString();
                if (bigrams.Contains(bigram))
                {
                    for (int j = 0; j < bigrams.Count; j++)
                    {
                        if (bigrams[j] == bigram)
                        {
                            freq[j]++;
                            break;
                        }
                    }
                }
                else
                {
                    bigrams.Add(bigram);
                    freq.Add(1);
                }
            }

            for(int i = 0; i < bigrams.Count; i++)
            {
                for (int j = 0; j < bigrams.Count - 1 - i; j++)
                {
                    if(freq[j] > freq[j + 1])
                    {
                        int tempFreq = freq[j];
                        string tempBi = bigrams[j];

                        freq[j] = freq[j + 1];
                        bigrams[j] = bigrams[j + 1];

                        freq[j + 1] = tempFreq;
                        bigrams[j + 1] = tempBi;
                    }
                }
            }

            string output = "";
            for (int i = 0; i < bigrams.Count; i++)
            {
                output += $"{bigrams[i]} : {freq[i]}\r\n";
            }

            TextOutputFrm TOF = new TextOutputFrm();
            TOF.SetOutput(output);
            TOF.Show();
        }
        public void ApplyGrid(int gridID, char[][] grid)
        {
            if (gridID == 0)
                grid1 = grid;
            else
                grid2 = grid;
        }

        private GridPosition GetGrid1Position(char c)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (grid1[x][y] == c)
                        return new GridPosition(x, y);
                }
            }
            return new GridPosition(-1, -1);
        }
        private GridPosition GetGrid2Position(char c)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (grid2[x][y] == c)
                        return new GridPosition(x, y);
                }
            }
            return new GridPosition(-1, -1);
        }

        private void grid1Btn_Click(object sender, EventArgs e)
        {
            Grid grid = new Grid();
            grid.Setup(0, this);
            grid.Show();
        }

        private void grid2Btn_Click(object sender, EventArgs e)
        {
            Grid grid = new Grid();
            grid.Setup(1, this);
            grid.Show();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            string output = "";
            for (int i = 0; i < MainText.Length; i += 2)
            {
                GridPosition gp1 = GetGrid1Position(MainText[i]);
                GridPosition gp2 = GetGrid2Position(MainText[i + 1]);
                if (gp1.Column == -1 || gp2.Column == -1)
                    output += MainText[i].ToString() + MainText[i + 1].ToString();
                else
                {
                    if (gp1.Column == gp2.Column)
                        output += MainText[i].ToString().ToLower() + MainText[i + 1].ToString().ToLower();
                    else
                    {
                        char topCharacter = grid1[gp1.Row][gp2.Column];
                        char bottomCharacter = grid2[gp2.Row][gp1.Column];
                        if (topCharacter == '#' || bottomCharacter == '#')
                            output += MainText[i].ToString() + MainText[i + 1].ToString();
                        else
                            output += topCharacter.ToString().ToLower() + bottomCharacter.ToString().ToLower();
                    }
                }
            }
            mainTxt.Text = output;
        }

        private void followingBtn_Click(object sender, EventArgs e)
        {
            List<string> bigrams = new List<string>();
            List<int> freq = new List<int>();
            string text = mainTxt.Text;
            bool next = false;
            for (int i = 0; i < MainText.Length; i += 2)
            {
                if (next)
                {
                    next = false;
                    string bigram = text[i].ToString() + text[i + 1].ToString();
                    if (bigrams.Contains(bigram))
                    {
                        for (int j = 0; j < bigrams.Count; j++)
                        {
                            if (bigrams[j] == bigram)
                            {
                                freq[j]++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        bigrams.Add(bigram);
                        freq.Add(1);
                    }
                }
                if (text[i].ToString() + text[i + 1].ToString() == bigramTxt.Text)
                {
                    next = true;
                }
            }

            for (int i = 0; i < bigrams.Count; i++)
            {
                for (int j = 0; j < bigrams.Count - 1 - i; j++)
                {
                    if (freq[j] > freq[j + 1])
                    {
                        int tempFreq = freq[j];
                        string tempBi = bigrams[j];

                        freq[j] = freq[j + 1];
                        bigrams[j] = bigrams[j + 1];

                        freq[j + 1] = tempFreq;
                        bigrams[j + 1] = tempBi;
                    }
                }
            }

            string output = "";
            for (int i = 0; i < bigrams.Count; i++)
            {
                output += $"{bigrams[i]} : {freq[i]}\r\n";
            }

            TextOutputFrm TOF = new TextOutputFrm();
            TOF.SetOutput(output);
            TOF.Show();
        }
    }
}
