using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Vigenere
{
    public static class VigenereCipher
    {
        public const float MINIMUM_SHIFT_AVERAGE = 90f;

        /// <summary>
        /// Attempts to auto solve a vigenere cipher
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string AutoSolve(string input, OutputMethod outputMethod = null)
        {
            outputMethod?.Invoke("Finding most likely shift");
            int shift = GetLikelyShift(input);
            if (shift == -1)
            {
                outputMethod?.Invoke("No shift found");
                outputMethod?.Invoke("Suspected not to be a vigenere cipher");
                return input;
            }
            outputMethod?.Invoke($"Found likely shift of {shift}");
            outputMethod?.Invoke("Running vigenere cipher");
            return Vigenere(input, shift);
        }

        public static int GetLikelyShift(string input)
        {
            int[] coincidences = GetCoincidences(input, 30);

            for (int i = 2; i < 10; i++)
            {
                float total = 0;
                int divider = 0;
                for (int j = i - 1; j < coincidences.Length; j += i)
                {
                    total += coincidences[j];
                    divider++;
                }
                if (total / divider >= MINIMUM_SHIFT_AVERAGE)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Gets the number of coincidences in an array of shifted text
        /// </summary>
        /// <param name="input"></param>
        /// <param name="shifts"></param>
        /// <returns></returns>
        public static int[] GetCoincidences(string input, int shifts) => GetCoincidences(input, shifts, out string[] _);

        /// <summary>
        /// Gets the number of coincidences in an array of shifted text
        /// </summary>
        /// <param name="input"></param>
        /// <param name="shifts"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int[] GetCoincidences(string input, int shifts, out string[] text)
        {
            if (input.Length < shifts)
            {
                shifts = input.Length;
            }

            Console.WriteLine(shifts);

            string[] shiftedText = new string[shifts];
            int[] totalCoincidences = new int[shifts];

            for (int i = 0; i < shifts; i++)
            {
                string shifted = "";
                for (int j = 0; j < input.Length; j++)
                {
                    int index = (j - i) - 1;
                    if (index < 0)
                        shifted += '#';
                    else
                        shifted += input[index];
                }
                shiftedText[i] = shifted;
            }

            for (int i = 0; i < shifts; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == shiftedText[i][j])
                        totalCoincidences[i]++;
                }
            }

            text = shiftedText;
            return totalCoincidences;
        }

        /// <summary>
        /// Gets all the patterns of three letter sequences in a group of text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="foundPatterns"></param>
        /// <param name="patternSpacing"></param>
        public static void GetPatterns(string text, out List<string> foundPatterns, out List<int> patternSpacing)
        {
            List<string> checkedPatterns = new List<string>();
            foundPatterns = new List<string>();
            patternSpacing = new List<int>();

            for (int i = 0; i < text.Length - 3; i++)
            {
                string pat = text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString();
                if (!checkedPatterns.Contains(pat))
                {
                    checkedPatterns.Add(pat);
                    for (int j = i + 1; j < text.Length - 3; j++)
                    {
                        string secPat = text[j].ToString() + text[j + 1].ToString() + text[j + 2].ToString();
                        if (pat == secPat)
                        {
                            foundPatterns.Add(pat);
                            patternSpacing.Add(j);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Applies a vigenere cipher to text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keywordLength"></param>
        /// <returns></returns>
        public static string Vigenere(string text, int keywordLength) => Vigenere(text, text, keywordLength);

        /// <summary>
        /// Applies a vigenere cipher to text
        /// </summary>
        /// <param name="mainText">Text without spaces</param>
        /// <param name="normalText">Text with spaces</param>
        /// <param name="keywordLength"></param>
        /// <returns></returns>
        public static string Vigenere(string mainText, string normalText, int keywordLength)
        {
            string[] textSubsets = new string[keywordLength];
            int currentSubset = 0;
            for (int i = 0; i < mainText.Length; i++)
            {
                textSubsets[currentSubset] += mainText[i];
                currentSubset++;
                if (currentSubset == keywordLength)
                    currentSubset = 0;
            }

            string[] ceaserSubsets = new string[keywordLength];
            for (int i = 0; i < keywordLength; i++)
            {
                ceaserSubsets[i] = TryCeaser(textSubsets[i]);
            }

            string compoundAnswer = "";
            currentSubset = 0;
            int currentIndex = 0;
            for (int i = 0; i < normalText.Length; i++)
            {
                if (GeneralConstants.CAPITALS.Contains(normalText[i]))
                {
                    compoundAnswer += ceaserSubsets[currentSubset][currentIndex];
                    currentSubset++;
                    if (currentSubset == keywordLength)
                    {
                        currentSubset = 0;
                        currentIndex++;
                    }
                }
                else
                {
                    compoundAnswer += normalText[i];
                }
            }
            return compoundAnswer;
        }

        /// <summary>
        /// Tries to apply a ceaser cipher to a group of letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TryCeaser(string input)
        {
            float[] scores = new float[26];
            float[] freq = CipherEvaluation.GetFrequencyProfile(input);
            float lowestScore = float.MaxValue;
            int lowestIndex = -1;
            for (int i = 0; i < 26; i++)
            {
                scores[i] = CeaserCipher.CalculateScore(freq, i);
                if (scores[i] < lowestScore)
                {
                    lowestScore = scores[i];
                    lowestIndex = i;
                }
            }
            return CeaserCipher.Ceaser(input, lowestIndex);
        }
    }
}
