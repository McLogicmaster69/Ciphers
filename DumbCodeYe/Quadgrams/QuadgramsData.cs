using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace DumbCodeYe.Quadgrams
{
    public static class QuadgramsData
    {
        public static readonly string DataFileName = "QuadgramsData.txt";
        public static readonly string InfoFileName = "english_quadgrams.txt";
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
        public static void CompileDataSet(string[] keys, int[] values)
        {
            DataSet = new DataSet(keys, values);
        }
        public static int GetFrequency(string inp)
        {
            string quadgram = inp.ToUpper();
            if (quadgram.Length != 4)
                return -1;
            int frontPointer = 0;
            int backPointer = DataSet.Count - 1;
            while(frontPointer <= backPointer)
            {
                int mid = (frontPointer + backPointer) / 2;
                string midstring = DataSet.Keys[mid];
                if (DataSet.Keys[mid] == quadgram)
                    return DataSet.Values[mid];
                else
                {
                    bool inpGreaterThan = false;
                    for (int i = 0; i < 4; i++)
                    {
                        if (quadgram[i] > DataSet.Keys[mid][i])
                        {
                            inpGreaterThan = true;
                            break;
                        }
                        else if(quadgram[i] < DataSet.Keys[mid][i])
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
            int total = GetFrequency(quadgram);
            if (total == -1)
                return 0;
            if (total == 0)
                return Math.Log10(0.0001d / TotalData);
            else
                return Math.Log10((double)total / TotalData);
        }
    }
}
