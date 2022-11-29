using DumbCodeYe.BasicWordLib;
using DumbCodeYe.WordFreq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe
{
    public class SpaceSet
    {
        public string Text { get; private set; }
        public int Spaces { get; private set; }
        private long score = -1;
        public SpaceSet(string startingText, int spaces)
        {
            Text = startingText;
            Spaces = spaces;
        }
        public long Score()
        {
            if (score == -1)
                score = GetScore();
            return score;
        }
        public long GetScore()
        {
            string[] words = Text.Split(' ');
            long score = 0;
            if (Spaces == 0)
                return 0;
            foreach (string word in words)
            {
                if (word.Length > 1 && BasicWordData.IsWord(word))
                    score += (int)Math.Floor((WordFreqData.GetFrequency(word) * Math.Pow(word.Length - 1.5f, 3)) / (Math.Log10(Spaces * 0.25f + 1.1f) * 1000)); 
                else if (word == "I" || word == "A")
                    score += WordFreqData.GetFrequency(word) / 1000;
            }
            return score;
        }
    }
}
