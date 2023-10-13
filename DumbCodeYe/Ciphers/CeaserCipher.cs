﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers
{
    public static class CeaserCipher
    {
        public static void TryCeaser(string text)
        {
            // Check frequency analysis for patterns
            float[] scores = new float[26];
            float[] freq = CipherEvaluation.GetFrequencyProfile(text);
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
                if (CipherEvaluation.IsCharacter(input[i]))
                {
                    // Offset the character
                    output += GeneralConstants.CHARACTERS[(CipherEvaluation.GetCharacterValue(input[i]) - offset + 26) % 26];
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

        public static float CalculateScore(float[] freq, int offset)
        {
            float[] inp = new float[26];
            for (int i = offset, j = 0; i < offset + 26; i++, j++)
            {
                inp[j] = freq[i % 26];
            }
            return CipherEvaluation.CalculateScore(inp);
        }
    }
}