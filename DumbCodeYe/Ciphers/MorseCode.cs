using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers
{
    public static class MorseCode
    {
        public static string GetMorseCode(string text, string dot, string dash, char space, char newCharacter)
        {
            string finalText = "";
            // Split code into characters
            foreach (string word in text.Split(space))
            {
                foreach(string character in word.Split(newCharacter))
                {
                    if (string.IsNullOrEmpty(character))
                        continue;
                    // Get character for each morse character
                    string englishCharacter = GetMorseCharacter(character, dot, dash);
                    if (string.IsNullOrEmpty(englishCharacter))
                        return string.Empty;
                    finalText += englishCharacter;
                }
            }
            return finalText;
        }
        public static string GetMorseCharacter(string morse, string dot, string dash) // A = DOT , D = DASH
        {
            // Check according to A as . and D as -
            if(morse == $"{dot}{dash}")
                return "a";
            if(morse == $"{dash}{dot}{dot}{dot}")
                return "b";
            if(morse == $"{dash}{dot}{dash}{dot}")
                return "c";
            if(morse == $"{dash}{dot}{dot}")
                return "d";
            if(morse == $"{dot}")
                return "e";
            if(morse == $"{dot}{dot}{dash}{dot}")
                return "f";
            if(morse == $"{dash}{dash}{dot}")
                return "g";
            if(morse == $"{dot}{dot}{dot}{dot}")
                return "h";
            if(morse == $"{dot}{dot}")
                return "i";
            if(morse == $"{dot}{dash}{dash}{dash}")
                return "j";
            if(morse == $"{dash}{dot}{dash}")
                return "k";
            if(morse == $"{dot}{dash}{dot}{dot}")
                return "l";
            if(morse == $"{dash}{dash}")
                return "m";
            if(morse == $"{dash}{dot}")
                return "n";
            if(morse == $"{dash}{dash}{dash}")
                return "o";
            if(morse == $"{dot}{dash}{dash}{dot}")
                return "p";
            if(morse == $"{dash}{dash}{dot}{dash}")
                return "q";
            if(morse == $"{dot}{dash}{dot}")
                return "r";
            if(morse == $"{dot}{dot}{dot}")
                return "s";
            if(morse == $"{dash}")
                return "t";
            if(morse == $"{dot}{dot}{dash}")
                return "u";
            if(morse == $"{dot}{dot}{dot}{dash}")
                return "v";
            if(morse == $"{dot}{dash}{dash}")
                return "w";
            if(morse == $"{dash}{dot}{dot}{dash}")
                return "x";
            if(morse == $"{dash}{dot}{dash}{dash}")
                return "y";
            if(morse == $"{dash}{dash}{dot}{dot}")
                return "z";
            return string.Empty;
        }
        public static bool IsMorse(string input)
        {
            List<char> characters = new List<char>();
            foreach(char c in input)
            {
                if (!characters.Contains(c))
                    characters.Add(c);
                if (characters.Count > 4)
                    return false;
            }
            return characters.Count > 2;
        }
    }
}
