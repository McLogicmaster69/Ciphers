using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace DumbCodeYe.LetterPatterns.Quadgrams
{
    public static class QuadgramsData
    {
        public static readonly string DataFileName = "QuadgramsData.txt";
        public static readonly string InfoFileName = "english_quadgrams.txt";
        public static DataSet DataSet;
        public static long TotalData;

        public static bool IsCompiled { get; private set; } = false;

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
            IsCompiled = true;
        }
        public static int GetFrequency(string inp)
        {
            if (!IsCompiled)
                Initialise();

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
            if (!IsCompiled)
                Initialise();

            int total = GetFrequency(quadgram);
            if (total == -1)
                return 0;
            if (total == 0)
                return Math.Log10(0.0001d / TotalData);
            else
                return Math.Log10((double)total / TotalData);
        }
        public static long GetAverageValue(string text)
        {
            if (!IsCompiled)
                Initialise();

            long totalScore = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                string bigram = text[i].ToString() + text[i + 1].ToString();
                totalScore += GetFrequency(bigram);
            }
            return totalScore / (text.Length - 1);
        }

        public static void Initialise(BackgroundWorker worker = null)
        {
            string[] keys;
            int[] vals;
            if (QuadgramsData.CheckDataExists())
                OpenDataSet(out keys, out vals, worker);
            else
                SortDataSet(out keys, out vals, worker);
            QuadgramsData.CompileDataSet(keys, vals);
        }
        private static void OpenDataSet(out string[] keys, out int[] vals, BackgroundWorker worker)
        {
            string[] data = QuadgramsData.OpenDataFile();
            List<string> identifiers = new List<string>();
            List<int> values = new List<int>();

            decimal index = 0;
            foreach (string d in data)
            {
                string[] splitString = d.Split(' ');
                identifiers.Add(splitString[0]);
                values.Add(int.Parse(splitString[1]));
                index++;
                worker?.ReportProgress((int)Math.Floor(index / data.Length));
            }

            keys = identifiers.ToArray();
            vals = values.ToArray();
        }
        private static void SortDataSet(out string[] keys, out int[] vals, BackgroundWorker worker)
        {
            string[] data = QuadgramsData.OpenInfoFile();
            List<string> identifiers = new List<string>();
            List<int> values = new List<int>();

            foreach (string d in data)
            {
                string[] splitString = d.Split(' ');
                identifiers.Add(splitString[0]);
                values.Add(int.Parse(splitString[1]));
            }

            string[] sortedIdentifiers = Sort(identifiers, values, out int[] sortedValues, worker);
            string dataFileText = "";
            for (int i = 0; i < sortedIdentifiers.Length; i++)
            {
                if (i == sortedIdentifiers.Length - 1)
                    dataFileText += $"{sortedIdentifiers[i]} {sortedValues[i]}";
                else
                    dataFileText += $"{sortedIdentifiers[i]} {sortedValues[i]}\n";
            }
            QuadgramsData.SaveDataFile(dataFileText);
            keys = sortedIdentifiers;
            vals = sortedValues;
        }
        private static string[] Sort(List<string> data, List<int> vals, out int[] newValues, BackgroundWorker worker)
        {
            //Declare lists
            List<List<string>> lists = new List<List<string>>();
            List<List<int>> Values = new List<List<int>>();
            lists.Add(data);
            Values.Add(vals);
            int originalSize = data.Count;

            //Split
            bool complete = false;
            while (!complete)
            {
                complete = true;
                int i = 0;

                //Check if list has more than one set of data
                while (i < lists.Count)
                {
                    worker?.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d));
                    if (lists[i].Count > 1)
                    {
                        //Create pivot and new lists
                        complete = false;
                        lists.Insert(i, new List<string>());
                        lists.Insert(i, new List<string>());
                        Values.Insert(i, new List<int>());
                        Values.Insert(i, new List<int>());
                        i++;
                        lists[i].Add(lists[i + 1][0]);
                        Values[i].Add(Values[i + 1][0]);
                        lists[i + 1].RemoveAt(0);
                        Values[i + 1].RemoveAt(0);

                        //Compare data
                        int j = 0;
                        while (j < lists[i + 1].Count)
                        {
                            worker?.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d + ((double)j / lists[i + 1].Count) * (100000d / originalSize)));
                            for (int k = 0; k < 4; k++)
                            {
                                if (lists[i + 1][j][k] < lists[i][0][k])
                                {
                                    lists[i - 1].Add(lists[i + 1][j]);
                                    Values[i - 1].Add(Values[i + 1][j]);
                                    lists[i + 1].RemoveAt(j);
                                    Values[i + 1].RemoveAt(j);
                                    break;
                                }
                                else if (lists[i + 1][j][k] > lists[i][0][k])
                                {
                                    j++;
                                    break;
                                }
                            }
                        }

                        //Delete unrequired lists
                        if (lists[i - 1].Count == 0)
                        {
                            lists.RemoveAt(i - 1);
                            Values.RemoveAt(i - 1);
                            i++;
                        }
                        else if (lists[i + 1].Count == 0)
                        {
                            lists.RemoveAt(i + 1);
                            Values.RemoveAt(i + 1);
                            i++;
                        }
                        else
                            i += 2;
                    }
                    else
                        i++;
                    worker?.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d));
                }
                worker?.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d));
            }

            //Compile down
            List<string> final = new List<string>();
            List<int> finalValues = new List<int>();
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].Count == 1)
                {
                    final.Add(lists[i][0]);
                    finalValues.Add(Values[i][0]);
                }
            }

            newValues = finalValues.ToArray();
            return final.ToArray();
        }
    }
}
