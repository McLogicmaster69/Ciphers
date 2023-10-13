using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers
{
    public static class MorseCode
    {
        public static void GetMorseCode(string text)
        {
            string finalText = "";
            // Split code into characters
            foreach (string code in text.Split(' '))
            {
                // Get character for each morse character
                finalText += GetMorseCharacter(code);
            }
            // Output
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(finalText);
            txtOut.Show();
        }
        public static string GetMorseCharacter(string morse) // A = DOT , D = DASH
        {
            // Check according to A as . and D as -
            switch (morse)
            {
                case "AD":
                    return "a";
                case "DAAA":
                    return "b";
                case "DADA":
                    return "c";
                case "DAA":
                    return "d";
                case "A":
                    return "e";
                case "AADA":
                    return "f";
                case "DDA":
                    return "g";
                case "AAAA":
                    return "h";
                case "AA":
                    return "i";
                case "ADDD":
                    return "j";
                case "DAD":
                    return "k";
                case "ADAA":
                    return "l";
                case "DD":
                    return "m";
                case "DA":
                    return "n";
                case "DDD":
                    return "o";
                case "ADDA":
                    return "p";
                case "DDAD":
                    return "q";
                case "ADA":
                    return "r";
                case "AAA":
                    return "s";
                case "D":
                    return "t";
                case "AAD":
                    return "u";
                case "AAAD":
                    return "v";
                case "ADD":
                    return "w";
                case "DAAD":
                    return "x";
                case "DADD":
                    return "y";
                case "DDAA":
                    return "z";
            }
            return "";
        }
    }
}
