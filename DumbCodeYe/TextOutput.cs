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
    public partial class TextOutputFrm : Form
    {
        public TextOutputFrm()
        {
            InitializeComponent();
        }

        public void SetOutput(string output)
        {
            textOut.Text = output;
        }

        public static TextOutputFrm CreateOutput(string output)
        {
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(output);
            txtOut.Show();
            return txtOut;
        }
    }
}
