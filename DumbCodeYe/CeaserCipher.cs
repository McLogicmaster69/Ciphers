using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe
{
    public static class CeaserCipher
    {
        public static void TryCeaser(string text)
        {
            // Check frequency analysis for patterns
            float[] scores = new float[26];
            float[] freq = GetFrequencyProfile(text);
            string freqText = "";
            for (int i = 0; i < 26; i++)
            {
                // Calculate frequency score for letter offset and output results
                scores[i] = CalculateScore(freq, i);
                freqText += $"offset {i} gives score {scores[i]}\n";
                // If score if low enough, apply ceaser to given offset
                if (scores[i] < 400)
                {
                    Ceaser(text, i);
                }
            }
            // Give output
            FrequencyFrm frequency = new FrequencyFrm();
            frequency.UpdateFreqLabel(freqText);
            frequency.Show();
        }
        public static void Ceaser(string input, int offset)
        {
            // Apply ceaser with offset
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                // Check if valid character
                if (GeneralConstants.CHARACTERS.Contains(input[i].ToString().ToLower()))
                {
                    // Offset the character
                    output += GeneralConstants.CHARACTERS[(GeneralConstants.CHARACTERS.IndexOf(input[i].ToString().ToLower()) - offset + 26) % 26];
                }
                else
                {
                    // Include the unknown character
                    output += input[i];
                }
            }
            // Output
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(output);
            txtOut.Show();
        }
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
        public static float CalculateScore(float[] freq)
        {
            float totalScore = 0;
            for (int i = 0; i < 26; i++)
            {
                totalScore += Math.Abs(GeneralConstants.CHARACTER_FREQUENCY[i] - freq[i]);
            }
            return (float)Math.Floor(totalScore * 1000);
        }
        public static float CalculateScore(float[] freq, int offset)
        {
            float[] inp = new float[26];
            for (int i = offset, j = 0; i < offset + 26; i++, j++)
            {
                inp[j] = freq[i % 26];
            }
            return CalculateScore(inp);
        }
    }
}
