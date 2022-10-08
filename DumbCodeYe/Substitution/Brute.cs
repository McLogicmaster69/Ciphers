using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Substitution
{
    public partial class Brute : Form
    {
        private const string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random rand;
        private TextBox[] Values;
        private WordDictionary dict = new WordDictionary();
        private Spelling speller = new Spelling();
        public Brute()
        {
            InitializeComponent();
            rand = new Random();
            dict.Initialize();
            speller.Dictionary = dict;
            Values = new TextBox[] { AValue, BValue, CValue, DValue, EValue, FValue, GValue, HValue, IValue, JValue, KValue, LValue, MValue, NValue, OValue, PValue, QValue, RValue, SValue, TValue, UValue, VValue, WValue, XValue, YValue, ZValue };
        }

        public void BeginGrind(string input, int generations)
        {
            ReplacementGrid bestGrid = GetRandomGrid();
            float bestScore = float.MinValue;
            maxIterationTxt.Text = generations.ToString();
            for (int gen = 0; gen < generations; gen++)
            {
                ReplacementGrid testGrid = new ReplacementGrid(bestGrid);
                ReplacementGrid randGrid = GetRandomGrid();
                for (int i = 0; i < rand.Next(1, 4); i++)
                {
                    testGrid.SwapCharacters(rand.Next(0, 26), rand.Next(0, 26));
                }
                string testOutput = testGrid.Decrypt(input);
                string randOutput = randGrid.Decrypt(input);
                float testScore = ScoreText(testOutput);
                float randScore = ScoreText(randOutput);
                if(testScore > bestScore)
                {
                    bestScore = testScore;
                    bestGrid = new ReplacementGrid(testGrid);
                    bestAnswetTxt.Text = testOutput;
                }
                if (randScore > bestScore)
                {
                    bestScore = randScore;
                    bestGrid = new ReplacementGrid(randGrid);
                    bestAnswetTxt.Text = randOutput;
                }
                currentIterationTxt.Text = gen.ToString();
                bestScoreTxt.Text = bestScore.ToString();
                outputTxt.Text = testOutput;
                SetRaplacements(testGrid.Replacements);
                Invalidate();
                Refresh();
            }
        }

        private ReplacementGrid GetRandomGrid()
        {
            string grid = "";
            List<char> tempCap = new List<char>(Capitals);
            for (int i = 0; i < 26; i++)
            {
                int randIndex = rand.Next(0, tempCap.Count);
                grid += tempCap[randIndex].ToString().ToLower();
                tempCap.RemoveAt(randIndex);
            }
            return new ReplacementGrid(grid.ToCharArray());
        }
        private void SetRaplacements(char[] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                Values[i].Text = grid[i].ToString();
            }
        }
        private float ScoreText(string input)
        {
            float score = 0;
            foreach (string word in input.Split(' '))
            {
                string testWord = "";
                foreach (char c in word)
                {
                    if (Capitals.Contains(c.ToString().ToUpper()))
                        testWord += c.ToString();
                }
                if (speller.TestWord(testWord))
                    score++;
            }
            return score;
        }
    }
}
