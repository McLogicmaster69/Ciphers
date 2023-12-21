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
            //BigramsData.TotalData = total;
            statusLbl.Text = $"Total: {total}";
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BigramsData.Initialise(Worker);
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
    }
}
