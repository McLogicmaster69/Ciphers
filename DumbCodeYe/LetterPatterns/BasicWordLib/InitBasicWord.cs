using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.LetterPatterns.BasicWordLib
{
    public partial class InitBasicWord : Form
    {
        private int originalSize;
        public InitBasicWord()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initBtn_Click(object sender, EventArgs e)
        {
            initBtn.Enabled = false;
            closeBtn.Enabled = false;
            testBtn.Enabled = false;
            Worker.RunWorkerAsync();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            string output = "";
            string[] toTest = new string[] { "the", "of", "sticky", "abc", "qwertyuiop" };
            bool[] expectedValue = new bool[] { true, true, true, false, false };
            for (int i = 0; i < toTest.Length; i++)
            {
                output += $"{toTest[i]}: {BasicWordData.IsWord(toTest[i])} Expected: {expectedValue[i]}\r\n";
            }
            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(output);
            tof.Show();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] data;
            if (BasicWordData.CheckDataExists())
                OpenDataSet(out data);
            else
                SortDataSet(out data);
            BasicWordData.CompileDataSet(data);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingBar.Value = (int)Math.Floor(e.ProgressPercentage / 1000d);
            statusLbl.Text = (e.ProgressPercentage / 1000d).ToString() + "%";
            this.Invalidate();
            this.Refresh();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusLbl.Text = "Data has been loaded";
            initBtn.Enabled = true;
            closeBtn.Enabled = true;
            testBtn.Enabled = true;
        }
        public void OpenDataSet(out string[] ordered)
        {
            string[] data = BasicWordData.OpenDataFile();
            ordered = data;
        }
        public void SortDataSet(out string[] ordered)
        {
            Console.WriteLine("Data");
            List<string> data = new List<string>(BasicWordData.OpenInfoFile());

            List<string> filtedData = new List<string>();
            for(int i = 0; i < data.Count; i++)
            {
                string s = data[i];
                Worker.ReportProgress((int)Math.Floor((i * 100000d) / data.Count));
                if (!filtedData.Contains(s))
                    filtedData.Add(s);
                else
                    Console.WriteLine("lol");
            }

            originalSize = data.Count;
            string[] sortedIdentifiers = Sort(filtedData);
            string dataFileText = "";
            for (int i = 0; i < sortedIdentifiers.Length; i++)
            {
                Worker.ReportProgress((int)Math.Floor((i * 100000d) / sortedIdentifiers.Length));
                if (i == sortedIdentifiers.Length - 1)
                    dataFileText += $"{sortedIdentifiers[i]}";
                else
                    dataFileText += $"{sortedIdentifiers[i]}\n";
            }
            Worker.ReportProgress(100000);
            Console.WriteLine("Data");
            Console.WriteLine(dataFileText);
            BasicWordData.SaveDataFile(dataFileText);
            ordered = sortedIdentifiers;
        }
        private string[] Sort(List<string> nums)
        {
            //Declare lists
            List<List<string>> lists = new List<List<string>>();
            lists.Add(nums);

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
                            Worker.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d + ((double)j / lists[i + 1].Count) * (100000d / originalSize)));
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
