using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.WordFreq
{
    public static class SpellCheckDictionary
    {
        private static WordDictionary dict = new WordDictionary();
        private static Spelling speller = new Spelling();
        static SpellCheckDictionary()
        {
            speller.Dictionary = dict;
        }
        public static bool IsWord(string word) => speller.TestWord(word);
    }
}
