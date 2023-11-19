using DumbCodeYe.LetterPatterns.BasicWordLib;
using DumbCodeYe.LetterPatterns.WordFreq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.Spaces
{
    public class SpaceInsertedString
    {
        private string _originalText;
        private int _startWordIndex;
        private int _wordLength;

        public List<string> Words = new List<string>();
        public int Score { get; private set; }

        public SpaceInsertedString(string originalText, int startWordIndex, int wordLength, List<string> words, int score)
        {
            _originalText = originalText;
            _startWordIndex = startWordIndex;
            _wordLength = wordLength;
            Words = words;
            Score = score;
        }

        public SpaceInsertedString[] Generate()
        {
            SpaceInsertedString[] sis = new SpaceInsertedString[2];
            sis[0] = new SpaceInsertedString(_originalText, _startWordIndex, _wordLength + 1, new List<string>(Words), Score);

            List<string> words = new List<string>(Words);
            string newWord = _originalText.Substring(_startWordIndex, _wordLength);
            words.Add(newWord);
            sis[1] = new SpaceInsertedString(_originalText, _startWordIndex + _wordLength, 1, words, Score + ScoreWord(newWord));

            return sis;
        }

        public void CalculateLastWord()
        {
            string newWord = _originalText.Substring(_startWordIndex);
            Words.Add(newWord);
            Score += ScoreWord(newWord);
        }

        public string CompileWords()
        {
            string words = "";
            foreach(string word in Words)
            {
                words += word + " ";
            }
            return words;
        }

        private int ScoreWord(string word)
        {
            if (word.Length > 1 && BasicWordData.IsWord(word))
                return (int)WordFreqData.GetFrequency(word) * word.Length; //Math.Floor((WordFreqData.GetFrequency(word) * Math.Pow(word.Length - 1.5f, 3)) / (Math.Log10(Spaces * 0.25f + 1.1f) * 1000));
            else if (word == "I" || word == "A")
                return (int)(WordFreqData.GetFrequency(word) / 1000);
            else return 0;
        }
    }
}
