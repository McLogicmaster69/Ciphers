using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Quadgrams
{
    public partial class InitQuadgramsFrm : Form
    {
        private int originalSize;
        public InitQuadgramsFrm()
        {
            InitializeComponent();
        }

        private void initBtn_Click(object sender, EventArgs e)
        {
            closeBtn.Enabled = false;
            Worker.RunWorkerAsync();
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] keys;
            int[] vals;
            if (QuadgramsData.CheckDataExists())
                OpenDataSet(out keys, out vals);
            else
                SortDataSet(out keys, out vals);
            QuadgramsData.CompileDataSet(keys, vals);
        }
        public void OpenDataSet(out string[] keys, out int[] vals)
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
                Worker.ReportProgress((int)Math.Floor(index / data.Length));
            }

            keys = identifiers.ToArray();
            vals = values.ToArray();
        }
        public void SortDataSet(out string[] keys, out int[] vals)
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

            originalSize = identifiers.Count;
            string[] sortedIdentifiers = Sort(identifiers, values, out int[] sortedValues);
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
        private string[] Sort(List<string> data, List<int> vals, out int[] newValues)
        {
            //Declare lists
            List<List<string>> lists = new List<List<string>>();
            List<List<int>> Values = new List<List<int>>();
            lists.Add(data);
            Values.Add(vals);
            originalSize = data.Count;

            //Split
            bool complete = false;
            while (!complete)
            {
                complete = true;
                int i = 0;

                //Check if list has more than one set of data
                while (i < lists.Count)
                {
                    Worker.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d));
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
                            Worker.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d + ((double)j / lists[i + 1].Count) * (100000d / originalSize)));
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
                    Worker.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d));
                }
                Worker.ReportProgress((int)Math.Floor((lists.Count / originalSize) * 100000d));
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

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingBar.Value = (int)Math.Floor(e.ProgressPercentage / 1000d);
            statusLbl.Text = (e.ProgressPercentage / 1000d).ToString() + "%";
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusLbl.Text = "Data has been loaded";
            closeBtn.Enabled = true;
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            string output = "";
            string[] toTest = new string[] { "TION", "AAAA", "ZZZZ", "BWDD", "FROM"};
            int[] expectedValue = new int[] { 13168375, 6705, 699, 1, 4361347 };
            for (int i = 0; i < toTest.Length; i++)
            {
                output += $"{toTest[i]}: {QuadgramsData.GetFrequency(toTest[i])} Expected: {expectedValue[i]}\r\n";
            }
            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(output);
            tof.Show();
        }
    }
}
