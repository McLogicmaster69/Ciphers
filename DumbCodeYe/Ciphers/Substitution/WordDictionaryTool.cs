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
    public partial class WordDictionaryTool : Form
    {
        private WordDictionary dict = new WordDictionary();
        private Spelling speller = new Spelling();
        public WordDictionaryTool()
        {
            InitializeComponent(); 
            dict.Initialize();
            speller.Dictionary = dict;
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            string[] testWords = wordInput.Text.Split('\n');
            List<string> validWords = new List<string>();
            foreach (string word in testWords)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    bool found = false;
                    for (int j = 0; j < 26; j++)
                    {
                        string test = "";
                        for (int k = 0; k < word.Length; k++)
                        {
                            if (i == k)
                            {
                                if (GeneralConstants.CHARACTERS[j] == word[k])
                                {
                                    test = "";
                                    break;
                                }
                                else
                                {
                                    test += GeneralConstants.CHARACTERS[j];
                                }
                            }
                            else
                            {
                                if (word[k] == word[i])
                                    test += GeneralConstants.CHARACTERS[j];
                                else
                                    test += word[k];
                            }
                        }
                        if (test == "")
                            continue;
                        else
                        {
                            if (speller.TestWord(test))
                            {
                                found = true;
                                validWords.Add(test);
                            }
                        }
                    }
                    if (!found)
                    {
                        string outputWord = "";
                        for (int j = 0; j < word.Length; j++)
                        {
                            if (i == j)
                                outputWord += '#';
                            else
                            {
                                if (word[j] == word[i])
                                    outputWord += '#';
                                else
                                    outputWord += word[j];
                            }
                        }
                        validWords.Add(outputWord);
                    }
                }
            }
            string output = "";
            foreach (string word in validWords)
            {
                output += word;
                output += "\r\n";
            }
            Console.WriteLine(output);
            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(output);
            tof.Show();
        }
    }
}
