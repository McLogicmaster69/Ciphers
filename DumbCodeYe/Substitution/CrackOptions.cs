using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe
{
    public partial class CrackOptions : Form
    {
        private Options Options;
        public CrackOptions()
        {
            InitializeComponent();
        }
        public void SetupOptions(Options options)
        {
            Options = options;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            List<string> oneWordsList = new List<string>();
            List<string> twoWordsList = new List<string>();
            List<string> threeWordsList = new List<string>();
            List<string> fourWordsList = new List<string>();
            foreach(var s in oneWords.CheckedItems)
            {
                oneWordsList.Add(s.ToString());
            }
            foreach (var s in twoWords.CheckedItems)
            {
                twoWordsList.Add(s.ToString());
            }
            foreach (var s in threeWords.CheckedItems)
            {
                threeWordsList.Add(s.ToString());
            }
            foreach (var s in fourWords.CheckedItems)
            {
                fourWordsList.Add(s.ToString());
            }
            List<string[]> CommonWordsList = new List<string[]>();
            List<string[]> UnsortedWords = new List<string[]> { oneWordsList.ToArray(), twoWordsList.ToArray(), threeWordsList.ToArray(), fourWordsList.ToArray() };
            List<int> UnsortedOrder = new List<int> { (int)oneWordOrder.Value, (int)twoWordOrder.Value, (int)threeWordOrder.Value, (int)fourWordOrder.Value};
            for (int i = 0; i < 4; i++)
            {
                int lowestOrder = int.MaxValue;
                int index = 0;
                for (int j = 0; j < UnsortedOrder.Count; j++)
                {
                    if(UnsortedOrder[j] < lowestOrder)
                    {
                        lowestOrder = UnsortedOrder[j];
                        index = j;
                    }
                }
                CommonWordsList.Add(UnsortedWords[index]);
                UnsortedWords.RemoveAt(index);
                UnsortedOrder.RemoveAt(index);
            }
            Options.CommonWords = CommonWordsList.ToArray();
            Options.CommonLetters = (int)commonLetters.Value;
        }
    }
}
