using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Transposition
{
    public partial class ReworkedTransposition : Form
    {
        private string MainText = "";

        public ReworkedTransposition(string input)
        {
            InitializeComponent();

            foreach (char c in input)
            {
                if (GeneralConstants.CAPITALS.Contains(c))
                    MainText += c;
            }
        }

        private void factorsBtn_Click(object sender, EventArgs e)
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 1; i <= MainText.Length; i++)
            {
                if (MainText.Length % i == 0)
                {
                    rows.Add(i);
                    columns.Add(MainText.Length / i);
                }
            }

            string factors = "";
            for (int i = 0; i < rows.Count; i++)
            {
                factors += $"{rows[i]}, {columns[i]}\r\n";
            }

            TextOutputFrm tof = new TextOutputFrm();
            tof.SetOutput(factors);
            tof.Show();
        }
    }
}
