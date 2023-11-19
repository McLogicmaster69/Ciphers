using DumbCodeYe.Ciphers;
using DumbCodeYe.Ciphers.Substitution;
using DumbCodeYe.Ciphers.Hill;
using DumbCodeYe.Ciphers.Playfair;
using DumbCodeYe.Ciphers.Polybius;
using DumbCodeYe.Ciphers.Transposition;
using DumbCodeYe.Ciphers.TwoSquare;
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
using DumbCodeYe.LetterPatterns.Bigrams;
using DumbCodeYe.LetterPatterns.WordFreq;
using DumbCodeYe.LetterPatterns.BasicWordLib;
using DumbCodeYe.LetterPatterns.Quadgrams;
using DumbCodeYe.Ciphers.Vigenere;
using DumbCodeYe.TextPlayground;
using DumbCodeYe.LetterPatterns.Spaces;

namespace DumbCodeYe
{
    public partial class mainFrm : Form
    {
        private const int SPACE_ITERATIONS = 400;
        private const int TEXT_INPUT_WIDTH_BUFFER = 616;

        private DropdownMenuBuilder _menuBuilder;

        private WordDictionary dict = new WordDictionary();
        private Spelling speller = new Spelling();

        ///
        /// START METHODS
        ///

        public mainFrm()
        {
            InitializeComponent();

            _menuBuilder = new DropdownMenuBuilder(this);
        }
        private void mainFrm_Load(object sender, EventArgs e)
        {
            RollingTheRick.Roll();
            dict.Initialize();
            speller.Dictionary = dict;
        }

        #region Operations

        private void JustLetters()
        {
            // Check each character if it is either upper or lowercase of the english alphabet
            RollingTheRick.Roll();
            string outputText = "";
            foreach (char c in textInput.Text)
            {
                if (GeneralConstants.CAPITALS.Contains(c.ToString().ToUpper()))
                    outputText += c;
            }
            textInput.Text = outputText;
        }
        private void ToUpper()
        {
            textInput.Text = textInput.Text.ToUpper();
        }

        #endregion

        #region Basic

        private void Ceaser()
        {
            CeaserCipher.TryCeaser(textInput.Text);
        }
        private void Morse()
        {
            MorseCode.GetMorseCode(textInput.Text);
        }
        private void Binary()
        {
            BinaryCipher.GetBinary(textInput.Text);
        }

        #endregion

        #region Monoalphabetic

        private void Substitute()
        {
            SubstitueTool st = new SubstitueTool();
            st.SetupText(textInput.Text);
            st.Show();
        }
        private void Affine()
        {
            AffineCipher.TryAffineCipher(textInput.Text);
        }
        private void Bacon()
        {
            BaconCipher.Bacon(textInput.Text);
        }

        #endregion

        #region Polyalphabetic

        private void Vigenere()
        {
            VigenereTools vt = new VigenereTools();
            vt.SetupText(textInput.Text);
            vt.Show();
        }
        private void Polybius()
        {
            PolybiusTools pt = new PolybiusTools();
            pt.SetupText(textInput.Text);
            pt.Show();
        }
        private void Hill()
        {
            RollingTheRick.Roll();
            HillCipher hillCiper = new HillCipher();
            hillCiper.SetText(textInput.Text);
            hillCiper.Show();
        }

        #endregion

        #region Transposition

        private void OpenTransposition()
        {
            TranspositionTools TT = new TranspositionTools();
            TT.Setup(textInput.Text);
            TT.Show();
        }

        #endregion

        #region Inistialise

        private void InitBigrams(object sender, EventArgs e)
        {
            InitBigramsFrm ibw = new InitBigramsFrm();
            ibw.Show();
        }
        private void InitWordFreq(object sender, EventArgs e)
        {
            InitWordFreq iqf = new InitWordFreq();
            iqf.Show();
        }
        private void InitDictionary(object sender, EventArgs e)
        {
            InitBasicWord ibw = new InitBasicWord();
            ibw.Show();
        }
        private void InitQuadgrams(object sender, EventArgs e)
        {
            InitQuadgramsFrm iqf = new InitQuadgramsFrm();
            iqf.Show();
        }

        #endregion

        ///
        /// PLAYFAIR
        ///

        private void OpenPlayfairTools()
        {
            PlayfairSelection PS = new PlayfairSelection(textInput.Text);
            PS.Show();
        }

        /// 
        /// SPACES
        /// 

        private void Spaces()
        {
            TextOutputFrm TOF = new TextOutputFrm();
            TOF.SetOutput(SpaceAdder.Add(textInput.Text.ToUpper()));
            TOF.Show();
        }

        private string AddSpaces(string s)
        {
            ProgressBarForm pb = new ProgressBarForm();
            pb.Show();
            int letterIndex = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    letterIndex = i + 1;
                    break;
                }
            }
            SpaceSet[] Sets = new SpaceSet[SPACE_ITERATIONS];
            Sets[0] = new SpaceSet(s, 0);
            while(letterIndex < s.Length)
            {
                List<SpaceSet> newSets = new List<SpaceSet>();
                for (int i = 0; i < Sets.Length; i++)
                {
                    if (Sets[i] == null)
                        break;
                    SpaceSet currentSet = Sets[i];
                    SpaceSet spaces = new SpaceSet(currentSet.Text.Substring(0, letterIndex + currentSet.Spaces) + " " + currentSet.Text.Substring(letterIndex + currentSet.Spaces), currentSet.Spaces + 1);
                    SpaceSet nonSpaces = new SpaceSet(currentSet.Text, currentSet.Spaces);
                    InsertIntoSets(newSets, nonSpaces);
                    InsertIntoSets(newSets, spaces);
                }
                Sets = newSets.ToArray();
                letterIndex++;
                pb.loadingBar.Value = (int)Math.Floor((letterIndex * 100f) / s.Length);
                pb.status.Text = $"{letterIndex} / {s.Length}";
                pb.Invalidate();
                pb.Refresh();
            }
            pb.Close();
            return Sets[0].Text;
        }

        private void InsertIntoSets(List<SpaceSet> spaces, SpaceSet set)
        {
            if (spaces.Count < SPACE_ITERATIONS)
            {
                for (int j = 0; j <= spaces.Count; j++)
                {
                    if (j == spaces.Count)
                    {
                        spaces.Add(set);
                        break;
                    }
                    else if (set.Score() > spaces[j].Score())
                    {
                        spaces.Insert(j, set);
                        break;
                    }
                }
            }
            else if(spaces[SPACE_ITERATIONS - 1].Score() < set.Score())
            {
                for (int j = 0; j < spaces.Count; j++)
                {
                    if (set.Score() > spaces[j].Score())
                    {
                        spaces.Insert(j, set);
                        break;
                    }
                }
                spaces.RemoveAt(SPACE_ITERATIONS);
            }
        }

        /// 
        /// TWO SQUARE
        /// 

        private void TwoSquareCipher()
        {
            TwoSquareTools TST = new TwoSquareTools();
            TST.Setup(textInput.Text);
            TST.Show();
        }

        private void textOperationsBtn_Click(object sender, EventArgs e)
        {
            _menuBuilder.OpenDropdown(new ButtonInformation[]
            {
                new ButtonInformation("TO UPPER", ToUpper),
                new ButtonInformation("TO LETTERS", JustLetters),
                new ButtonInformation("ADD SPACES", Spaces)
            }, new Point(300, 0));
        }

        private void basicCipherBtn_Click(object sender, EventArgs e)
        {
            _menuBuilder.OpenDropdown(new ButtonInformation[]
            {
                new ButtonInformation("CEASER", Ceaser),
                new ButtonInformation("MORSE", Morse),
                new ButtonInformation("BINARY", Binary)
            }, new Point(300, 40));
        }

        private void monoAlphabeticBtn_Click(object sender, EventArgs e)
        {
            _menuBuilder.OpenDropdown(new ButtonInformation[]
            {
                new ButtonInformation("SUBSTITUTION", Substitute),
                new ButtonInformation("AFFINE", Affine),
                new ButtonInformation("BACON", Bacon)
            }, new Point(300, 80));
        }

        private void polyAlphabeticBtn_Click(object sender, EventArgs e)
        {
            _menuBuilder.OpenDropdown(new ButtonInformation[]
            {
                new ButtonInformation("VIGENERE", Vigenere),
                new ButtonInformation("POLYBIUS", Polybius),
                new ButtonInformation("HILL", Hill)
            }, new Point(300, 120));
        }

        private void transpositionBtn_Click(object sender, EventArgs e)
        {
            OpenTransposition();
        }

        private void textInput_Enter(object sender, EventArgs e)
        {
            _menuBuilder.CloseDropdown();
        }

        private void mainFrm_Resize(object sender, EventArgs e)
        {
            textInput.Width = this.Width - TEXT_INPUT_WIDTH_BUFFER;
        }

        private void textEditorBtn_Click(object sender, EventArgs e)
        {
            EditorForm frm = new EditorForm(textInput.Text);
            frm.Show();
        }

        private void initButtons_Click(object sender, EventArgs e)
        {
            new InitBasicWord().Show();
            new InitBigramsFrm().Show();
            new InitQuadgramsFrm().Show();
            new InitWordFreq().Show();
        }
    }
}
