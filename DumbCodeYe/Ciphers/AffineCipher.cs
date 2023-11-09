using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers
{
    public static class AffineCipher
    {
        private static readonly int[] AValues = new int[] { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
        private static readonly int[] BValues = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

        public static void TryAffineCipher(string text)
        {
            bool found = false;
            foreach(int A in AValues)
            {
                foreach(int B in BValues)
                {
                    string output = AffineShift(text, A, B);
                    if(CipherEvaluation.CalculateScore(output) < 400)
                    {
                        TextOutputFrm.CreateOutput(output);
                        found = true;
                    }
                }
            }
            if(!found)
                MessageBox.Show("Unable to decrpt message");
        }

        public static string AffineShift(string text, int A, int B)
        {
            string output = "";
            foreach(char c in text)
            {
                if (CipherEvaluation.IsCharacter(c))
                {
                    int characterShifted = ShiftCharacter(CipherEvaluation.GetCharacterValue(c), A, B);
                    output += GeneralConstants.CHARACTERS[characterShifted];
                }
                else
                {
                    output += c.ToString();
                }
            }
            return output;
        }

        public static int ShiftCharacter(int value, int A, int B) => (value * A + B) % 26;

        public static string TryAffineCipherValue(string text)
        {
            foreach (int A in AValues)
            {
                foreach (int B in BValues)
                {
                    string output = AffineShift(text, A, B);
                    if (CipherEvaluation.CalculateScore(output) < 400)
                        return output;
                }
            }
            return text;
        }
    }
}
