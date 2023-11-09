using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.WordFreq
{
    public static class WordFreqData
    {
        public static readonly string DataFileName = "wordsFreqData.txt";
        public static readonly string InfoFileName = "wordFreq.txt";
        public static DataSet DataSet;
        public static long TotalData;

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
        public static void CompileDataSet(string[] keys, long[] values)
        {
            DataSet = new DataSet(keys, values);
        }
        public static long GetFrequency(string inp)
        {
            string word = inp.ToUpper();
            int frontPointer = 0;
            int backPointer = DataSet.Count - 1;
            while (frontPointer <= backPointer)
            {
                int mid = (frontPointer + backPointer) / 2;
                string midstring = DataSet.Keys[mid];
                if (DataSet.Keys[mid] == word)
                    return DataSet.Values[mid];
                else
                {
                    bool inpGreaterThan = false;
                    for (int i = 0; i < word.Length || i < DataSet.Keys[mid].Length; i++)
                    {
                        if(i == word.Length)
                        {
                            inpGreaterThan = false;
                            break;
                        }
                        else if(i == DataSet.Keys[mid].Length)
                        {
                            inpGreaterThan = true;
                            break;
                        }
                        else if (word[i] > DataSet.Keys[mid][i])
                        {
                            inpGreaterThan = true;
                            break;
                        }
                        else if (word[i] < DataSet.Keys[mid][i])
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
            return 0;
        }
    }
}
