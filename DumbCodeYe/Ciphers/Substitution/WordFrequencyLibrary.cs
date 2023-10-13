using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Substitution
{
    public class WordFrequencyLibrary
    {
        public List<string> Words { get; private set; }
        public List<int> Frequency { get; private set; }
        public int Count { get { return Words.Count; } }

        public WordFrequencyLibrary()
        {
            Words = new List<string>();
            Frequency = new List<int>();
        }

        public void AddWord(string word, int frequency)
        {
            Words.Add(word);
            Frequency.Add(frequency);
        }
        public string GetFirstPattern(string pattern) // a-z for known, # for unkown
        {
            for (int i = 0; i < Words.Count; i++)
            {
                if(Words[i].Length == pattern.Length)
                {
                    bool found = true;
                    char[] storedChars = new char[10];
                    for (int j = 0; j < 10; j++)
                    {
                        storedChars[j] = '#';
                    }
                    for (int j = 0; j < pattern.Length; j++)
                    {
                        if (pattern[j] == '#')
                        {
                            if (!GeneralConstants.CAPITALS.Contains(Words[i][j]))
                            {
                                found = false;
                                break;
                            }
                        }
                        else if (GeneralConstants.Numbers.Contains(pattern[j]))
                        {
                            if (!GeneralConstants.CAPITALS.Contains(Words[i][j]))
                            {
                                found = false;
                                break;
                            }
                            int index = Convert.ToInt32(pattern[j].ToString());
                            if (storedChars[index] == '#')
                                storedChars[index] = Words[i][j];
                            else
                            {
                                if(storedChars[index] != Words[i][j])
                                {
                                    found = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (pattern[j].ToString() != Words[i][j].ToString())
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                    List<char> unusedCharacters = new List<char>(GeneralConstants.CAPITALS);
                    for (int j = 0; j < 10; j++)
                    {
                        if (storedChars[j] != '#')
                        {
                            if (unusedCharacters.Contains(storedChars[j]))
                                unusedCharacters.Remove(storedChars[j]);
                            else
                            {
                                found = false;
                                break;
                            }
                        }
                    }
                    if (found)
                        return Words[i];
                }
            }
            return "";
        }
        public void ApplyReplacements(char[] replacements)
        {
            for (int i = 0; i < Words.Count; i++)
            {
                string newWord = "";
                for (int j = 0; j < Words[i].Length; j++)
                {
                    if (GeneralConstants.CAPITALS.Contains(Words[i][j]))
                    {
                        if (replacements[GetIndexOfCapital(Words[i][j])] == '#')
                            newWord += Words[i][j];
                        else
                            newWord += replacements[GetIndexOfCapital(Words[i][j])];
                    }
                    else
                        newWord += Words[i][j];
                }
                Words[i] = newWord;
            }
        }
        public int GetIndexOfCapital(char c)
        {
            switch (c)
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
    }
}
