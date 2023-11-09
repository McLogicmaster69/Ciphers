using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe
{
    public static class CipherEvaluation
    {
        /// <summary>
        /// Gets the frequency of each letter in text
        /// </summary>
        /// <param name="text">The text being counted</param>
        /// <returns></returns>
        public static float[] GetFrequencyProfile(string text)
        {
            float[] freq = new float[26];
            int[] freqChars = new int[26];
            float totalChars = 0f;
            for (int i = 0; i < text.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(text[i].ToString().ToLower()))
                {
                    totalChars++;
                    switch (text[i].ToString().ToLower())
                    {
                        case "a":
                            freqChars[0]++;
                            break;
                        case "b":
                            freqChars[1]++;
                            break;
                        case "c":
                            freqChars[2]++;
                            break;
                        case "d":
                            freqChars[3]++;
                            break;
                        case "e":
                            freqChars[4]++;
                            break;
                        case "f":
                            freqChars[5]++;
                            break;
                        case "g":
                            freqChars[6]++;
                            break;
                        case "h":
                            freqChars[7]++;
                            break;
                        case "i":
                            freqChars[8]++;
                            break;
                        case "j":
                            freqChars[9]++;
                            break;
                        case "k":
                            freqChars[10]++;
                            break;
                        case "l":
                            freqChars[11]++;
                            break;
                        case "m":
                            freqChars[12]++;
                            break;
                        case "n":
                            freqChars[13]++;
                            break;
                        case "o":
                            freqChars[14]++;
                            break;
                        case "p":
                            freqChars[15]++;
                            break;
                        case "q":
                            freqChars[16]++;
                            break;
                        case "r":
                            freqChars[17]++;
                            break;
                        case "s":
                            freqChars[18]++;
                            break;
                        case "t":
                            freqChars[19]++;
                            break;
                        case "u":
                            freqChars[20]++;
                            break;
                        case "v":
                            freqChars[21]++;
                            break;
                        case "w":
                            freqChars[22]++;
                            break;
                        case "x":
                            freqChars[23]++;
                            break;
                        case "y":
                            freqChars[24]++;
                            break;
                        case "z":
                            freqChars[25]++;
                            break;
                    }
                }
            }
            for (int i = 0; i < 26; i++)
            {
                freq[i] = freqChars[i] / totalChars;
            }
            return freq;
        }

        /// <summary>
        /// Calculates the score of the text given based on english letter frequencies. Scores below 400 are likely english text.
        /// </summary>
        /// <param name="freq">The frequencies of each letter</param>
        /// <returns></returns>
        public static float CalculateScore(float[] freq)
        {
            float totalScore = 0;
            for (int i = 0; i < 26; i++)
            {
                totalScore += Math.Abs(GeneralConstants.CHARACTER_FREQUENCY[i] - freq[i]);
            }
            return (float)Math.Floor(totalScore * 1000);
        }

        /// <summary>
        /// Calculates the score of the text given based on english letter frequencies. Scores below 400 are likely english text.
        /// </summary>
        /// <param name="text">The text being scored</param>
        /// <returns></returns>
        public static float CalculateScore(string text)
        {
            return CalculateScore(GetFrequencyProfile(text));
        }

        /// <summary>
        /// Converts a character to an integer value
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int GetCharacterValue(char c) => GeneralConstants.CAPITALS.IndexOf(c.ToString().ToUpper());

        /// <summary>
        /// Checks if the character is A-Z
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsCharacter(char c) => GeneralConstants.CAPITALS.Contains(c.ToString().ToUpper());
    }
}
