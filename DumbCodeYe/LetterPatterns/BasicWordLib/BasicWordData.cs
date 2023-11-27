using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static void CompileDataSet(string[] words)
        {
            DataSet = words;
            IsCompiled = true;
        }

        /// <summary>
        /// Checks if a word exists in the data set
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsWord(string input)
        {
            if (!IsCompiled)
                Initialise();

            string word = input.ToLower();
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

        /// <summary>
        /// Initialises the data set
        /// </summary>
        /// <param name="worker"></param>
        public static void Initialise(BackgroundWorker worker = null)
        {
            string[] data;
            if (BasicWordData.CheckDataExists())
                OpenDataSet(out data);
            else
                SortDataSet(out data, worker);
            CompileDataSet(data);
        }

        /// <summary>
        /// Opens the data set stored in a file
        /// </summary>
        /// <param name="ordered"></param>
        public static void OpenDataSet(out string[] ordered)
        {
            string[] data = OpenDataFile();
            ordered = data;
        }

        /// <summary>
        /// Sorts data in an info file
        /// </summary>
        /// <param name="ordered"></param>
        private static void SortDataSet(out string[] ordered, BackgroundWorker worker = null)
        {
            Console.WriteLine("Data");
            List<string> data = new List<string>(BasicWordData.OpenInfoFile());

            List<string> filtedData = new List<string>();
            for (int i = 0; i < data.Count; i++)
            {
                string s = data[i];
                worker?.ReportProgress((int)Math.Floor((i * 100000d) / data.Count));
                if (!filtedData.Contains(s))
                    filtedData.Add(s);
                else
                    Console.WriteLine("lol");
            }

            string[] sortedIdentifiers = Sort(filtedData, data.Count, worker);
            string dataFileText = "";
            for (int i = 0; i < sortedIdentifiers.Length; i++)
            {
                worker?.ReportProgress((int)Math.Floor((i * 100000d) / sortedIdentifiers.Length));
                if (i == sortedIdentifiers.Length - 1)
                    dataFileText += $"{sortedIdentifiers[i]}";
                else
                    dataFileText += $"{sortedIdentifiers[i]}\n";
            }
            worker?.ReportProgress(100000);
            Console.WriteLine("Data");
            Console.WriteLine(dataFileText);
            BasicWordData.SaveDataFile(dataFileText);
            ordered = sortedIdentifiers;
        }

        /// <summary>
        /// Sorts a list of strings
        /// </summary>
        /// <param name="items"></param>
        /// <param name="originalSize"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        private static string[] Sort(List<string> items, int originalSize, BackgroundWorker worker = null)
        {
            //Declare lists
            List<List<string>> lists = new List<List<string>>();
            lists.Add(items);

            //Split
            bool complete = false;
            while (!complete)
            {
                complete = true;
                int i = 0;

                //Check if list has more than one set of data
                while (i < lists.Count)
                {
                    if (lists[i].Count > 1)
                    {
                        //Create pivot and new lists
                        complete = false;
                        lists.Insert(i, new List<string>());
                        lists.Insert(i, new List<string>());
                        i++;
                        lists[i].Add(lists[i + 1][0]);
                        lists[i + 1].RemoveAt(0);

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
                                    lists[i + 1].RemoveAt(j);
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
                                    lists[i + 1].RemoveAt(j);
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
                            i++;
                        }
                        else if (lists[i + 1].Count == 0)
                        {
                            lists.RemoveAt(i + 1);
                            i++;
                        }
                        else
                        {
                            i += 2;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            //Compile down
            List<string> final = new List<string>();
            foreach (List<string> l in lists)
            {
                if (l.Count == 1)
                {
                    final.Add(l[0]);
                }
            }
            return final.ToArray();
        }
    }
}
