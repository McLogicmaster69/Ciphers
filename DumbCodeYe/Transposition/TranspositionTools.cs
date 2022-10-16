using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Transposition
{
    public partial class TranspositionTools : Form
    {
        private string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string MainText = ""; 
        private string[] CommonWords = { "be", "to", "of", "in", "it", "on", "he", "as", "do", "at", "by", "we", "or", "an", "no", "the", "and", "for", "not", "you", "but", "his", "say", "her", "she", "one", "all", "yes", "one", "two", "six", "ten", "sad", "can", "that", "have", "with", "this", "from", "they", "will", "word", "what", "were", "when", "which", "would", "could", "these" };
        private ExpectedWords EW;

        public TranspositionTools()
        {
            InitializeComponent();
            EW = new ExpectedWords();
        }
        public void Setup(string input)
        {
            foreach (char c in input)
            {
                if (Capitals.Contains(c))
                    MainText += c;
            }
        }

        private void expectedBtn_Click(object sender, EventArgs e)
        {
            EW.Show();
        }
        private void rowColumnBtn_Click(object sender, EventArgs e)
        {
            TryRowColumnTransposition();
        }
        private void rowColumnarBtn_Click(object sender, EventArgs e)
        {
            TryRowColumnarTransposition();
        }

        private void TryRowColumnTransposition()
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 1; i <= MainText.Length; i++)
            {
                if (MainText.Length % i == 0)
                {
                    rows.Add(i);
                    columns.Add(MainText.Length / i);
                }
            }

            int highestScore = int.MinValue;
            string highestText = "";
            for (int i = 0; i < rows.Count; i++)
            {
                string newText = RowColumnTransposition(MainText, rows[i], columns[i]);
                int score = CalculateTranspositionScore(newText);
                if (score > highestScore)
                {
                    highestScore = score;
                    highestText = newText;
                }
            }
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(highestText);
            txtOut.Show();
        }
        private string RowColumnTransposition(string text, int rows, int columns)
        {
            char[,] grid = new char[rows, columns];
            int currentIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    grid[row, column] = text[currentIndex];
                    currentIndex++;
                }
            }
            string newText = "";
            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    newText += grid[row, column].ToString().ToLower();
                }
            }
            return newText;
        }
        private int CalculateTranspositionScore(string text)
        {
            int score = 0;
            for (int i = 0; i < text.Length; i++)
            {
                foreach (string word in CommonWords)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (j + i >= text.Length)
                            break;
                        if (word[j] != text[i + j])
                            break;
                        if (j == word.Length - 1)
                            score++;
                    }
                }
            }
            return score;
        }

        private void TryRowColumnarTransposition()
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 1; i <= MainText.Length; i++)
            {
                if (MainText.Length % i == 0)
                {
                    columns.Add(i);
                    rows.Add(MainText.Length / i);
                }
            }

            string[] ExpectedWords = EW.expectedText.Text.Split('\n');

            int highestScore = int.MinValue;
            char[,] highestGrid = null;
            int highestRow = 0;
            int highestColumn = 0;
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i] > maxColumns.Value)
                    break;
                char[,] grid = new char[rows[i], columns[i]];
                int currentIndex = 0;
                for (int column = 0; column < columns[i]; column++)
                {
                    for (int row = 0; row < rows[i]; row++)
                    {
                        grid[row, column] = MainText[currentIndex];
                        currentIndex++;
                    }
                }

                int score = 0;
                foreach (string word in ExpectedWords)
                {
                    for (int row = 0; row < rows[i]; row++)
                    {
                        for (int column = 0; column < columns[i]; column++)
                        {
                            if(word.Contains(grid[row, column]))
                            {
                                List<char> remainingWord = new List<char>();
                                foreach(char c in word)
                                {
                                    remainingWord.Add(c);
                                }
                                for (int _column = column; _column < columns[i]; _column++)
                                {
                                    if (remainingWord.Contains(grid[row, _column]))
                                        remainingWord.Remove(grid[row, _column]);
                                }
                                if (remainingWord.Count == 0)
                                    score++;
                            }
                        }
                    }
                }
                if(score > highestScore)
                {
                    highestGrid = grid;
                    highestScore = score;
                    highestRow = rows[i];
                    highestColumn = columns[i];
                }
            }

            GridOutput GO = new GridOutput();
            GO.Setup(highestGrid, highestRow, highestColumn);
            GO.Show();
        }
    }
}
