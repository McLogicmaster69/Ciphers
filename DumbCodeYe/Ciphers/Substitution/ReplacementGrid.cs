using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Substitution
{
    public class ReplacementGrid
    {
        public readonly char[] Replacements;
        public ReplacementGrid()
        {
            Replacements = new char[26];
            for (int i = 0; i < 26; i++)
            {
                Replacements[i] = '#';
            }
        }
        public ReplacementGrid(char[] grid)
        {
            Replacements = grid;
        }
        public ReplacementGrid(ReplacementGrid grid)
        {
            Replacements = grid.Replacements;
        }
        public virtual bool Contains(char c)
        {
            foreach(char r in Replacements)
            {
                if (r == c)
                    return true;
            }
            return false;
        }
        public virtual void ChangeCharacter(int index, char c)
        {
            if(!Contains(c))
                Replacements[index] = c;
        }
        public virtual void ChangeCharacter(char character, char c)
        {
            ChangeCharacter(GetIndexOfCapital(character), c);
        }
        public virtual void SwapCharacters(int c1, int c2)
        {
            char temp = Replacements[c1];
            Replacements[c1] = Replacements[c2];
            Replacements[c2] = temp;
        }
        public virtual char GetReplacement(int index)
        {
            return Replacements[index];
        }
        public virtual char GetReplacement(char character)
        {
            return GetReplacement(GetIndexOfCapital(character));
        }
        public virtual int GetIndexOfCapital(char character)
        {
            switch (character)
            {
                case 'A':
                    return 0;
                case 'B':
                    return 1;
                case 'C':
                    return 2;
                case 'D':
                    return 3;
                case 'E':
                    return 4;
                case 'F':
                    return 5;
                case 'G':
                    return 6;
                case 'H':
                    return 7;
                case 'I':
                    return 8;
                case 'J':
                    return 9;
                case 'K':
                    return 10;
                case 'L':
                    return 11;
                case 'M':
                    return 12;
                case 'N':
                    return 13;
                case 'O':
                    return 14;
                case 'P':
                    return 15;
                case 'Q':
                    return 16;
                case 'R':
                    return 17;
                case 'S':
                    return 18;
                case 'T':
                    return 19;
                case 'U':
                    return 20;
                case 'V':
                    return 21;
                case 'W':
                    return 22;
                case 'X':
                    return 23;
                case 'Y':
                    return 24;
                case 'Z':
                    return 25;
            }
            return -1;
        }
        public virtual string Decrypt(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (GeneralConstants.CAPITALS.Contains(c))
                    output += GetReplacement(c);
                else
                    output += c.ToString();
            }
            return output;
        }
    }
}
