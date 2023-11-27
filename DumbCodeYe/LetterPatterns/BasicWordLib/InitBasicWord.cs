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
            BasicWordData.Initialise(Worker);
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
    }
}
