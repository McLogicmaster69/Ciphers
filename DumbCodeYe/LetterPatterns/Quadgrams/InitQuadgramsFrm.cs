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

namespace DumbCodeYe.LetterPatterns.Quadgrams
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
            initBtn.Enabled = false;
            closeBtn.Enabled = false;
            testBtn.Enabled = false;
            getTotalBtn.Enabled = false;
            Worker.RunWorkerAsync();
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            QuadgramsData.Initialise(Worker);
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

        private void getTotalBtn_Click(object sender, EventArgs e)
        {
            long total = 0;
            for (int i = 0; i < QuadgramsData.DataSet.Values.Length; i++)
            {
                total += QuadgramsData.DataSet.Values[i];
            }
            QuadgramsData.TotalData = total;
            statusLbl.Text = $"Total: {total}";
        }
    }
}
