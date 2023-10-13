using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.Bigrams
{
    class BigramsData
    {
        public static readonly string DataFileName = "BigramsData.txt";
        public static readonly string InfoFileName = "english_bigrams.txt";
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
            string bigram = inp.ToUpper();
            if (bigram.Length != 2)
                return -1;
            int frontPointer = 0;
            int backPointer = DataSet.Count - 1;
            while (frontPointer <= backPointer)
            {
                int mid = (frontPointer + backPointer) / 2;
                string midstring = DataSet.Keys[mid];
                if (DataSet.Keys[mid] == bigram)
                    return DataSet.Values[mid];
                else
                {
                    bool inpGreaterThan = false;
                    for (int i = 0; i < 2; i++)
                    {
                        if (bigram[i] > DataSet.Keys[mid][i])
                        {
                            inpGreaterThan = true;
                            break;
                        }
                        else if (bigram[i] < DataSet.Keys[mid][i])
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
        public static double GetLogProbability(string quadgram)
        {
            long total = GetFrequency(quadgram);
            if (total == -1)
                return 0;
            if (total == 0)
                return Math.Log10(0.0001d / TotalData);
            else
                return Math.Log10((double)total / TotalData);
        }
        public static long GetAverageValue(string text)
        {
            long totalScore = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                string bigram = text[i].ToString() + text[i + 1].ToString();
                totalScore += GetFrequency(bigram);
            }
            return totalScore / (text.Length - 1);
        }
    }
}
