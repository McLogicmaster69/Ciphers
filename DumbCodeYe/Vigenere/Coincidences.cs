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
    public partial class Coincidences : Form
    {
        public Coincidences()
        {
            InitializeComponent();
        }
        public void Setup(string[] shifted, int[] coincidences)
        {
            for (int i = 0; i < shifted.Length; i++)
            {
                shiftedText.Text += shifted[i] + "\n";
                coincidencesText.Items.Add(coincidences[i].ToString());
                Console.WriteLine(coincidences[i]);
            }
        }
    }
}
