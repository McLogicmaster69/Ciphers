using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.LetterPatterns.WordFreq
{
    public partial class InitWordFreq : Form
    {
        private int originalSize;
        public InitWordFreq()
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

        private void testBtn_Click(object sender, EventArgs e)
        {
            string output = "";
            string[] toTest = new string[] { "the", "of", "sticky", "wto", "golgw" };
            long[] expectedValue = new long[] { 23135851162, 13151942776, 5698936, 5692621, 12711 };
            for (int i = 0; i < toTest.Length; i++)
            {
                output += $"{toTest[i]}: {WordFreqData.GetFrequency(toTest[i])} Expected: {expectedValue[i]}\r\n";
            }
            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(output);
            tof.Show();
        }

        private void getTotalBtn_Click(object sender, EventArgs e)
        {
            long total = 0;
            for (int i = 0; i < WordFreqData.DataSet.Values.Length; i++)
            {
                total += WordFreqData.DataSet.Values[i];
            }
            WordFreqData.TotalData = total;
            statusLbl.Text = $"Total: {total}";
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            WordFreqData.Initialise(Worker);
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
