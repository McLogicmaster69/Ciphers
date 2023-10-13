using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.TwoSquare
{
    public partial class Grid : Form
    {
        private TwoSquareTools TST;
        private int ID;
        public Grid()
        {
            InitializeComponent();
        }
        public void Setup(int id, TwoSquareTools tst)
        {
            ID = id;
            TST = tst;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            TST.ApplyGrid(ID, GetValues());
        }
        private char[][] GetValues()
        {
            try
            {
                char[][] values = new char[][]
                {
                    new char[] { Value11.Text[0], Value12.Text[0], Value13.Text[0], Value14.Text[0], Value15.Text[0], Value16.Text[0], Value17.Text[0], Value18.Text[0], Value19.Text[0] },
                    new char[] { Value21.Text[0], Value22.Text[0], Value23.Text[0], Value24.Text[0], Value25.Text[0], Value26.Text[0], Value27.Text[0], Value28.Text[0], Value29.Text[0] },
                    new char[] { Value31.Text[0], Value32.Text[0], Value33.Text[0], Value34.Text[0], Value35.Text[0], Value36.Text[0], Value37.Text[0], Value38.Text[0], Value39.Text[0] },
                    new char[] { Value41.Text[0], Value42.Text[0], Value43.Text[0], Value44.Text[0], Value45.Text[0], Value46.Text[0], Value47.Text[0], Value48.Text[0], Value49.Text[0] },
                    new char[] { Value51.Text[0], Value52.Text[0], Value53.Text[0], Value54.Text[0], Value55.Text[0], Value56.Text[0], Value57.Text[0], Value58.Text[0], Value59.Text[0] },
                    new char[] { Value61.Text[0], Value62.Text[0], Value63.Text[0], Value64.Text[0], Value65.Text[0], Value66.Text[0], Value67.Text[0], Value68.Text[0], Value69.Text[0] },
                    new char[] { Value71.Text[0], Value72.Text[0], Value73.Text[0], Value74.Text[0], Value75.Text[0], Value76.Text[0], Value77.Text[0], Value78.Text[0], Value79.Text[0] },
                    new char[] { Value81.Text[0], Value82.Text[0], Value83.Text[0], Value84.Text[0], Value85.Text[0], Value86.Text[0], Value87.Text[0], Value88.Text[0], Value89.Text[0] },
                    new char[] { Value91.Text[0], Value92.Text[0], Value93.Text[0], Value94.Text[0], Value95.Text[0], Value96.Text[0], Value97.Text[0], Value98.Text[0], Value99.Text[0] },
                };
                return values;
            }
            catch
            {
                return null;
            }
        }
    }
}
