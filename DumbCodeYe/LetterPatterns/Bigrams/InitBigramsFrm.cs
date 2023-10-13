using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.LetterPatterns.Bigrams
{
    public partial class InitBigramsFrm : Form
    {
        private int originalSize;
        public InitBigramsFrm()
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
            getTotalBtn.Enabled = false;
            Worker.RunWorkerAsync();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            string output = "";
            string[] toTest = new string[] { "TH", "HE", "SO", "XP", "WZ" };
            long[] expectedValue = new long[] { 10027294596, 8669733672, 1121470593, 188533463, 0 };
            for (int i = 0; i < toTest.Length; i++)
            {
                output += $"{toTest[i]}: {BigramsData.GetFrequency(toTest[i])} Expected: {expectedValue[i]}\r\n";
            }
            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(output);
            tof.Show();
        }

        private void getTotalBtn_Click(object sender, EventArgs e)
        {
            long total = 0;
            for (int i = 0; i < BigramsData.DataSet.Values.Length; i++)
            {
                total += BigramsData.DataSet.Values[i];
            }
            BigramsData.TotalData = total;
            statusLbl.Text = $"Total: {total}";
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] keys;
            long[] vals;
            if (BigramsData.CheckDataExists())
                OpenDataSet(out keys, out vals);
            else
                SortDataSet(out keys, out vals);
            BigramsData.CompileDataSet(keys, vals);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingBar.Value = (int)Math.Floor(e.ProgressPercentage / 1000d);
            statusLbl.Text = (e.ProgressPercentage / 1000d).ToString() + "%";
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusLbl.Text = "Data has been loaded";
            initBtn.Enabled = true;
            closeBtn.Enabled = true;
            testBtn.Enabled = true;
            getTotalBtn.Enabled = true;
        }
        public void OpenDataSet(out string[] keys, out long[] vals)
        {
            string[] data = BigramsData.OpenDataFile();
            List<string> identifiers = new List<string>();
            List<long> values = new List<long>();

            decimal index = 0;
            foreach (string d in data)
            {
                string[] splitString = d.Split(' ');
                identifiers.Add(splitString[0].ToUpper());
                values.Add(long.Parse(splitString[1]));
                index++;
                Worker.ReportProgress((int)Math.Floor(index / data.Length));
            }

            keys = identifiers.ToArray();
            vals = values.ToArray();
        }
        public void SortDataSet(out string[] keys, out long[] vals)
        {
            string[] data = BigramsData.OpenInfoFile();
            List<string> identifiers = new List<string>();
            List<long> values = new List<long>();

            foreach (string d in data)
            {
                string[] splitString = d.Split(' ');
                identifiers.Add(splitString[0].ToUpper());
                values.Add(long.Parse(splitString[1]));
            }

            originalSize = identifiers.Count;
            string[] sortedIdentifiers = Sort(identifiers, values, out long[] sortedValues);
            string dataFileText = "";
            for (int i = 0; i < sortedIdentifiers.Length; i++)
            {
                if (i == sortedIdentifiers.Length - 1)
                    dataFileText += $"{sortedIdentifiers[i]} {sortedValues[i]}";
                else
                    dataFileText += $"{sortedIdentifiers[i]} {sortedValues[i]}\n";
            }
            BigramsData.SaveDataFile(dataFileText);
            keys = sortedIdentifiers;
            vals = sortedValues;
        }
        private string[] Sort(List<string> data, List<long> vals, out long[] newValues)
        {
            //Declare lists
            List<List<string>> lists = new List<List<string>>();
            List<List<long>> Values = new List<List<long>>();
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
