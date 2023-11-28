using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static void CompileDataSet(string[] keys, long[] values)
        {
            DataSet = new DataSet(keys, values);
            IsCompiled = true;
        }
        public static long GetFrequency(string inp)
        {
            if (!IsCompiled)
                Initialise();

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

        public static void Initialise(BackgroundWorker worker = null)
        {
            if (IsCompiled)
                return;

            string[] keys;
            long[] vals;
            if (WordFreqData.CheckDataExists())
                OpenDataSet(out keys, out vals, worker);
            else
                SortDataSet(out keys, out vals, worker);
            CompileDataSet(keys, vals);
        }
        private static void OpenDataSet(out string[] keys, out long[] vals, BackgroundWorker worker)
        {
            string[] data = WordFreqData.OpenDataFile();
            List<string> identifiers = new List<string>();
            List<long> values = new List<long>();

            decimal index = 0;
            foreach (string d in data)
            {
                string[] splitString = d.Split(' ');
                identifiers.Add(splitString[0]);
                values.Add(long.Parse(splitString[1]));
                index++;
                worker?.ReportProgress((int)Math.Floor(index / data.Length));
            }

            keys = identifiers.ToArray();
            vals = values.ToArray();
        }
        private static void SortDataSet(out string[] keys, out long[] vals, BackgroundWorker worker)
        {
            Console.WriteLine("Data");
            string[] data = WordFreqData.OpenInfoFile();
            List<string> identifiers = new List<string>();
            List<long> values = new List<long>();

            foreach (string d in data)
            {
                string[] splitString = d.Split(' ');
                identifiers.Add(splitString[0].ToUpper());
                values.Add(long.Parse(splitString[1]));
            }

            string[] sortedIdentifiers = Sort(identifiers, values, out long[] sortedValues, worker);
            string dataFileText = "";
            for (int i = 0; i < sortedIdentifiers.Length; i++)
            {
                worker?.ReportProgress((int)Math.Floor((i * 100000d) / sortedIdentifiers.Length));
                if (i == sortedIdentifiers.Length - 1)
                    dataFileText += $"{sortedIdentifiers[i]} {sortedValues[i]}";
                else
                    dataFileText += $"{sortedIdentifiers[i]} {sortedValues[i]}\n";
            }
            worker?.ReportProgress(100000);
            Console.WriteLine("Data");
            Console.WriteLine(dataFileText);
            WordFreqData.SaveDataFile(dataFileText);
            keys = sortedIdentifiers;
            vals = sortedValues;
        }
        private static string[] Sort(List<string> data, List<long> vals, out long[] newValues, BackgroundWorker worker)
        {
            //Declare lists
            List<List<string>> lists = new List<List<string>>();
            List<List<long>> Values = new List<List<long>>();
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
                        Values.Insert(i, new List<long>());
                        Values.Insert(i, new List<long>());
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
                            for (int k = 0; k < lists[i + 1][j].Length || k < lists[i][0].Length; k++)
                            {
                                if (k == lists[i + 1][j].Length)
                                {
                                    lists[i - 1].Add(lists[i + 1][j]);
                                    Values[i - 1].Add(Values[i + 1][j]);
                                    lists[i + 1].RemoveAt(j);
                                    Values[i + 1].RemoveAt(j);
                                    break;
                                }
                                else if (k == lists[i][0].Length)
                                {
                                    j++;
                                    break;
                                }
                                else if (lists[i + 1][j][k] < lists[i][0][k])
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
            List<long> finalValues = new List<long>();
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
