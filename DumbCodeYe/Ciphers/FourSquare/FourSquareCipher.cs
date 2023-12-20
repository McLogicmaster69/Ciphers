using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.FourSquare
{
    public static class FourSquareCipher
    {
        public static readonly string[][] CHARACTER_GRID = new string[5][]
        {
            new string[5] {"a", "b", "c", "d", "e"},
            new string[5] {"f", "g", "h", "i", "k"},
            new string[5] {"l", "m", "n", "o", "p"},
            new string[5] {"q", "r", "s", "t", "u"},
            new string[5] {"v", "w", "x", "y", "z"}
        };
        
        public static string Decipher(string input, TextBox[][] grid1, TextBox[][] grid2)
        {
            string mainText = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (GeneralConstants.CHARACTERS.Contains(input[i].ToString().ToLower()))
                    mainText += input[i];
            }

            string output = "";
            for (int i = 0; i < mainText.Length - 1; i += 2)
            {
                output += DecrpytBigram(mainText.Substring(i, 2), grid1, grid2);
            }

            return output;
        }

        public static string DecrpytBigram(string bigram, TextBox[][] grid1, TextBox[][] grid2)
        {
            bool char1 = CharacterInGrid(grid1, bigram[0].ToString(), out int r1, out int c1);
            bool char2 = CharacterInGrid(grid2, bigram[1].ToString(), out int r2, out int c2);

            if (char1 && char2)
                return $"{CHARACTER_GRID[r1][c2]}{CHARACTER_GRID[r2][c1]}";
            else
                return bigram;
        }

        public static string EncryptBigram(string bigram, TextBox[][] grid1, TextBox[][] grid2)
        {
            bool char1 = CharacterInGrid(CHARACTER_GRID, bigram[0].ToString(), out int r1, out int c1);
            bool char2 = CharacterInGrid(CHARACTER_GRID, bigram[1].ToString(), out int r2, out int c2);

            if (char1 && char2)
                return $"{grid1[r1][c2].Text}{grid2[r2][c1].Text}";
            else
                return bigram;
        }

        public static bool CharacterInGrid(TextBox[][] grid, string character, out int r, out int c)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (grid[row][column].Text.ToUpper() == character.ToUpper())
                    {
                        r = row;
                        c = column;
                        return true;
                    }
                }
            }

            r = -1;
            c = -1;
            return false;
        }

        public static bool CharacterInGrid(string[][] grid, string character, out int r, out int c)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (grid[row][column].ToUpper() == character.ToUpper())
                    {
                        r = row;
                        c = column;
                        return true;
                    }
                }
            }

            r = -1;
            c = -1;
            return false;
        }
    }
}
