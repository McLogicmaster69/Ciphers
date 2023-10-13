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

namespace DumbCodeYe.Ciphers.Substitution
{
    public partial class SmartBrute : Form
    {
        private const string Capitals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random rand;
        private TextBox[] Values;
        private WordDictionary dict = new WordDictionary();
        private Spelling speller = new Spelling();
        private SubstitueTool ST;
        public SmartBrute(SubstitueTool st)
        {
            ST = st;
            InitializeComponent(); 
            rand = new Random();
            dict.Initialize();
            speller.Dictionary = dict;
            Values = new TextBox[] { AValue, BValue, CValue, DValue, EValue, FValue, GValue, HValue, IValue, JValue, KValue, LValue, MValue, NValue, OValue, PValue, QValue, RValue, SValue, TValue, UValue, VValue, WValue, XValue, YValue, ZValue };
        }
        public void BeginGrind(string input, int generations)
        {
            // FREQUENCY ANALYSIS TO GAIN BEST START

            WordFrequencyLibrary lib = GetSortedFrequency(input);
            SmartReplacementGrid startingGrid = new SmartReplacementGrid();
            RunDictionaryAttack(lib, startingGrid, 5);

            // RANDOM IMMPROVEMENT

            SmartReplacementGrid bestGrid = new SmartReplacementGrid(startingGrid);
            bestGrid.FillRest();
            float bestScore = float.MinValue;
            maxIterationTxt.Text = generations.ToString();
            for (int gen = 0; gen < generations; gen++)
            {
                SmartReplacementGrid testGrid = new SmartReplacementGrid(bestGrid);
                for (int i = 0; i < rand.Next(1, 3); i++)
                {
                    testGrid.SmartSwap();
                }
                string testOutput = testGrid.Decrypt(input);
                float testScore = ScoreText(testOutput);
                if (testScore > bestScore)
                {
                    bestScore = testScore;
                    bestGrid = new SmartReplacementGrid(testGrid);
                    bestAnswetTxt.Text = testOutput;
                    SetRaplacements(testGrid.Replacements); 
                    ST.replacements = testGrid.Replacements;
                }
                currentIterationTxt.Text = gen.ToString();
                bestScoreTxt.Text = bestScore.ToString();
                outputTxt.Text = testOutput;
                Invalidate();
                Refresh();
            }
        }
        private SmartReplacementGrid GetRandomGrid()
        {
            string grid = "";
            List<char> tempCap = new List<char>(Capitals);
            for (int i = 0; i < 26; i++)
            {
                int randIndex = rand.Next(0, tempCap.Count);
                grid += tempCap[randIndex].ToString().ToLower();
                tempCap.RemoveAt(randIndex);
            }
            return new SmartReplacementGrid(grid.ToCharArray());
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
        private WordFrequencyLibrary GetSortedFrequency(string input)
        {
            string filterInput = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Capitals.Contains(input[i].ToString()) || input[i] == ' ')
                {
                    filterInput += input[i];
                }
            }
            string[] words = filterInput.Split(' ');
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            List<string> wordsForFreq = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (wordFreq.ContainsKey(words[i]))
                    wordFreq[words[i]]++;
                else
                {
                    wordFreq.Add(words[i], 1);
                    wordsForFreq.Add(words[i]);
                }
            }
            int wordFreqCount = wordFreq.Count;
            Dictionary<string, int> sortedFreq = new Dictionary<string, int>();
            List<string> sortedWordsForFreq = new List<string>();
            for (int i = 0; i < wordFreqCount; i++)
            {
                int highestValue = int.MinValue;
                int indexOfHighest = -1;
                for (int j = 0; j < wordFreq.Count; j++)
                {
                    if (wordFreq[wordsForFreq[j]] > highestValue)
                    {
                        highestValue = wordFreq[wordsForFreq[j]];
                        indexOfHighest = j;
                    }
                }
                sortedFreq.Add(wordsForFreq[indexOfHighest], wordFreq[wordsForFreq[indexOfHighest]]);
                sortedWordsForFreq.Add(wordsForFreq[indexOfHighest]);
                wordFreq.Remove(wordsForFreq[indexOfHighest]);
                wordsForFreq.RemoveAt(indexOfHighest);
            }

            WordFrequencyLibrary wfl = new WordFrequencyLibrary();
            for (int i = 0; i < sortedFreq.Count; i++)
            {
                wfl.AddWord(sortedWordsForFreq[i], sortedFreq[sortedWordsForFreq[i]]);
            }
            return wfl;
        }
        private void SearchPattern(WordFrequencyLibrary lib, SmartReplacementGrid grid, string pattern, string word)
        {
            string foundPattern = lib.GetFirstPattern(pattern);
            if (foundPattern != "")
            {
                grid.AddLockedWord(foundPattern, word);
                lib.ApplyReplacements(grid.Replacements);
            }
        }
        private void RunDictionaryAttack(WordFrequencyLibrary lib, SmartReplacementGrid grid, int attacks)
        {
            for (int i = 0; i < attacks; i++)
            {
                #region the
                SearchPattern(lib, grid, "012", "the");
                #endregion
                #region that
                SearchPattern(lib, grid, "th0t", "that");
                #endregion
                #region to
                SearchPattern(lib, grid, "t0", "to");
                #endregion
                #region i
                SearchPattern(lib, grid, "0", "i");
                #endregion
                #region there
                SearchPattern(lib, grid, "the0e", "there");
                #endregion
                #region and
                SearchPattern(lib, grid, "a01", "and");
                #endregion
                #region you
                SearchPattern(lib, grid, "0o1", "you");
                SearchPattern(lib, grid, "0ou", "you");
                SearchPattern(lib, grid, "y0u", "you");
                SearchPattern(lib, grid, "yo0", "you");
                #endregion
                #region will
                SearchPattern(lib, grid, "wi00", "will");
                #endregion
                #region be
                SearchPattern(lib, grid, "0e", "be");
                #endregion
                #region my
                SearchPattern(lib, grid, "0y", "my");
                #endregion
                #region dear
                SearchPattern(lib, grid, "dea0", "dear");
                #endregion
                #region was
                SearchPattern(lib, grid, "w0s", "was");
                SearchPattern(lib, grid, "wa0", "was");
                #endregion
                #region great
                SearchPattern(lib, grid, "0reat", "great");
                SearchPattern(lib, grid, "grea0", "great");
                #endregion
                #region morning
                SearchPattern(lib, grid, "0orning", "morning");
                SearchPattern(lib, grid, "m0rning", "morning");
                SearchPattern(lib, grid, "mo0ning", "morning");
                SearchPattern(lib, grid, "mor0i0g", "morning");
                SearchPattern(lib, grid, "morn0ng", "morning");
                SearchPattern(lib, grid, "mornin0", "morning");
                #endregion
                #region afternoon
                SearchPattern(lib, grid, "0fternoon", "afternoon");
                SearchPattern(lib, grid, "a0ternoon", "afternoon");
                SearchPattern(lib, grid, "af0ernoon", "afternoon");
                SearchPattern(lib, grid, "aft0rnoon", "afternoon");
                SearchPattern(lib, grid, "afte0noon", "afternoon");
                SearchPattern(lib, grid, "after0oo0", "afternoon");
                SearchPattern(lib, grid, "aftern00n", "afternoon");
                #endregion
                #region evening
                SearchPattern(lib, grid, "0v0ning", "evening");
                SearchPattern(lib, grid, "e0ening", "evening");
                SearchPattern(lib, grid, "eve0i0g", "evening");
                SearchPattern(lib, grid, "even0ng", "evening");
                SearchPattern(lib, grid, "evenin0", "evening");
                #endregion
                #region foward
                SearchPattern(lib, grid, "0orward", "forward");
                SearchPattern(lib, grid, "f0rward", "forward");
                SearchPattern(lib, grid, "fo0wa0d", "forward");
                SearchPattern(lib, grid, "for0ard", "forward");
                SearchPattern(lib, grid, "forw0rd", "forward");
                SearchPattern(lib, grid, "forwar0", "forward");
                #endregion
                #region backward
                SearchPattern(lib, grid, "0ackward", "backward");
                SearchPattern(lib, grid, "b0ckw0rd", "backward");
                SearchPattern(lib, grid, "ba0kward", "backward");
                SearchPattern(lib, grid, "bac0ward", "backward");
                SearchPattern(lib, grid, "back0ard", "backward");
                SearchPattern(lib, grid, "backwa0d", "backward");
                SearchPattern(lib, grid, "backwar0", "backward");
                #endregion
                #region meeting
                SearchPattern(lib, grid, "0eeting", "meeting");
                SearchPattern(lib, grid, "m00ting", "meeting");
                SearchPattern(lib, grid, "mee0ing", "meeting");
                SearchPattern(lib, grid, "meet0ng", "meeting");
                SearchPattern(lib, grid, "meeti0g", "meeting");
                SearchPattern(lib, grid, "meetin0", "meeting");
                #endregion
                #region investigate
                SearchPattern(lib, grid, "0nvest0gate", "investigate");
                SearchPattern(lib, grid, "i0vestigate", "investigate");
                SearchPattern(lib, grid, "in0estigate", "investigate");
                SearchPattern(lib, grid, "inv0stigat0", "investigate");
                SearchPattern(lib, grid, "inve0tigate", "investigate");
                SearchPattern(lib, grid, "inves0iga0e", "investigate");
                SearchPattern(lib, grid, "investi0ate", "investigate");
                #endregion
                #region expenses
                SearchPattern(lib, grid, "0xp0ns0s", "expenses");
                SearchPattern(lib, grid, "e0penses", "expenses");
                SearchPattern(lib, grid, "ex0enses", "expenses");
                SearchPattern(lib, grid, "expe0ses", "expenses");
                SearchPattern(lib, grid, "expen0e0", "expenses");
                #endregion
                #region all
                SearchPattern(lib, grid, "0ll", "all");
                SearchPattern(lib, grid, "a00", "all");
                #endregion
                #region dead
                SearchPattern(lib, grid, "0ea0", "dead");
                SearchPattern(lib, grid, "d0ad", "dead");
                SearchPattern(lib, grid, "de0d", "dead");
                #endregion
                #region chair
                SearchPattern(lib, grid, "0hair", "chair");
                SearchPattern(lib, grid, "c0air", "chair");
                SearchPattern(lib, grid, "cha0r", "chair");
                #endregion
                #region floor
                SearchPattern(lib, grid, "0loor", "floor");
                SearchPattern(lib, grid, "f0oor", "floor");
                #endregion
                #region from
                SearchPattern(lib, grid, "0rom", "from");
                SearchPattern(lib, grid, "f0om", "from");
                SearchPattern(lib, grid, "fr0m", "from");
                SearchPattern(lib, grid, "fro0", "from");
                #endregion
                #region accept
                SearchPattern(lib, grid, "0ccept", "accept");
                SearchPattern(lib, grid, "a00ept", "accept");
                SearchPattern(lib, grid, "acc0pt", "accept");
                SearchPattern(lib, grid, "acce0t", "accept");
                SearchPattern(lib, grid, "accep0", "accept");
                #endregion
                #region no
                SearchPattern(lib, grid, "n0", "no");
                #endregion
                #region travel
                SearchPattern(lib, grid, "t0avel", "travel");
                SearchPattern(lib, grid, "tr0vel", "travel");
                SearchPattern(lib, grid, "tra0el", "travel");
                SearchPattern(lib, grid, "trav0l", "travel");
                SearchPattern(lib, grid, "trave0", "travel");
                #endregion
                #region writing
                SearchPattern(lib, grid, "0riting", "writing");
                SearchPattern(lib, grid, "w0iting", "writing");
                SearchPattern(lib, grid, "wr0t0ng", "writing");
                SearchPattern(lib, grid, "wri0ing", "writing");
                SearchPattern(lib, grid, "writi0g", "writing");
                SearchPattern(lib, grid, "writin0", "writing");
                #endregion
                #region capacity
                SearchPattern(lib, grid, "0apa0ity", "capacity");
                SearchPattern(lib, grid, "c0p0city", "capacity");
                SearchPattern(lib, grid, "ca0acity", "capacity");
                SearchPattern(lib, grid, "capac0ty", "capacity");
                SearchPattern(lib, grid, "capaci0y", "capacity");
                SearchPattern(lib, grid, "capacit0", "capacity");
                #endregion
                #region Jodie
                SearchPattern(lib, grid, "#odie", "jodie");
                SearchPattern(lib, grid, "j#die", "jodie");
                SearchPattern(lib, grid, "jo#ie", "jodie");
                SearchPattern(lib, grid, "jod#e", "jodie");
                SearchPattern(lib, grid, "jodi#", "jodie");
                #endregion
                #region Harry
                SearchPattern(lib, grid, "#arry", "harry");
                SearchPattern(lib, grid, "h#rry", "harry");
                SearchPattern(lib, grid, "ha##y", "harry");
                SearchPattern(lib, grid, "harr#", "harry");
                #endregion
            }
        }
    }
}
