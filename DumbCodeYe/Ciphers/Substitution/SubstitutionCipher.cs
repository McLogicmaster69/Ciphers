using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Substitution
{
    public static class SubstitutionCipher
    {
        public static string AutoSolve(string input)
        {
            ReplacementGrid grid = new ReplacementGrid();
            float[] scores = CipherEvaluation.GetFrequencyProfile(input);
            List<int> orderIndexes = new List<int>();
            for (int i = 0; i < scores.Length; i++)
            {
                bool inserted = false;
                for (int j = 0; j < orderIndexes.Count; j++)
                {
                    if (scores[i] > scores[orderIndexes[j]])
                    {
                        inserted = true;
                        orderIndexes.Insert(j, i);
                        break;
                    }
                }
                if (!inserted)
                {
                    orderIndexes.Add(i);
                }
            }

            grid.SetCharacter(orderIndexes[0], 'e');
            GetPatterns(input, 2, out List<string> patterns2, out List<int> frequencies2);
            GetPatterns(input, 3, out List<string> patterns3, out List<int> frequencies3);
            GetPatterns(input, 4, out List<string> patterns4, out List<int> frequencies4);

            return string.Empty;
        }

        public static void GetPatterns(string text, int length, out List<string> patterns, out List<int> frequency)
        {
            List<string> foundPatterns = new List<string>();
            List<int> patternRepeats = new List<int>();
            for (int i = 0; i < text.Length - length; i++)
            {
                string pat = text.Substring(i, length);
                if (foundPatterns.Contains(pat))
                {
                    int index = foundPatterns.IndexOf(pat);
                    patternRepeats[index]++;
                }
                else
                {
                    foundPatterns.Add(pat);
                    patternRepeats.Add(1);
                }
            }

            List<string> sortedFoundPatterns = new List<string>();
            List<int> sortedPatternRepeats = new List<int>();
            int lengthOfList = foundPatterns.Count;
            for (int i = 0; i < lengthOfList; i++)
            {
                int highestRepeat = int.MinValue;
                int highestIndex = 0;
                for (int j = 0; j < foundPatterns.Count; j++)
                {
                    if (patternRepeats[j] > highestRepeat)
                    {
                        highestRepeat = patternRepeats[j];
                        highestIndex = j;
                    }
                }
                sortedFoundPatterns.Add(foundPatterns[highestIndex]);
                sortedPatternRepeats.Add(patternRepeats[highestIndex]);
                foundPatterns.RemoveAt(highestIndex);
                patternRepeats.RemoveAt(highestIndex);
            }

            patterns = sortedFoundPatterns;
            frequency = sortedPatternRepeats;
        }
    }
}
