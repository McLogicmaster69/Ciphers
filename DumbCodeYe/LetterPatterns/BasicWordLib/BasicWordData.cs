using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.BasicWordLib
{
    public static class BasicWordData
    {
        public static readonly string DataFileName = "basicWordData.txt";
        public static readonly string InfoFileName = "basicWord.txt";
        public static string[] DataSet;

        public static bool CheckDataExists()
        {
            return File.Exists(DataFileName);
        }
        public static string[] OpenInfoFile()
        {
            return File.ReadAllLines(InfoFileName);
        }
        public static string[] OpenDataFile()
        {
            return File.ReadAllLines(DataFileName);
        }
        public static void SaveDataFile(string s)
        {
            File.WriteAllText(DataFileName, s);
        }
        public static void CompileDataSet(string[] words)
        {
            DataSet = words;
        }
        public static bool IsWord(string inp)
        {
            string word = inp.ToLower();
            int frontPointer = 0;
            int backPointer = DataSet.Length - 1;
            while (frontPointer <= backPointer)
            {
                int mid = (frontPointer + backPointer) / 2;
                string midstring = DataSet[mid];
                if (DataSet[mid] == word)
                    return true;
                else
                {
                    bool inpGreaterThan = false;
                    for (int i = 0; i < word.Length || i < DataSet[mid].Length; i++)
                    {
                        if (i == word.Length)
                        {
                            inpGreaterThan = false;
                            break;
                        }
                        else if (i == DataSet[mid].Length)
                        {
                            inpGreaterThan = true;
                            break;
                        }
                        else if (word[i] > DataSet[mid][i])
                        {
                            inpGreaterThan = true;
                            break;
                        }
                        else if (word[i] < DataSet[mid][i])
                        {
                            inpGreaterThan = false;
                            break;
                        }
                    }
                    if (inpGreaterThan)
                        frontPointer = mid + 1;
                    else
                        backPointer = mid - 1;
                }
            }
            return false;
        }
    }
}
