using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Playfair
{
    public partial class PlayfairSelection : Form
    {
        private string Text;

        public PlayfairSelection(string text)
        {
            InitializeComponent();
            Text = text;
        }

        private void grid5Btn_Click(object sender, EventArgs e)
        {
            Playfair5GridV2 P5G = new Playfair5GridV2();
            P5G.Show();
            MovementMode hori = MovementMode.HorizontalLeft;
            MovementMode vert = MovementMode.VerticalUp;
            Console.WriteLine(horizontalRule.SelectedIndex);
            switch (horizontalRule.SelectedIndex)
            {
                case 0:
                    hori = MovementMode.VerticalUp;
                    break;
                case 1:
                    hori = MovementMode.VerticalDown;
                    break;
                case 2:
                    hori = MovementMode.HorizontalRight;
                    break;
                case 3:
                    hori = MovementMode.HorizontalLeft;
                    break;
            }
            switch (verticalRule.SelectedIndex)
            {
                case 0:
                    vert = MovementMode.VerticalUp;
                    break;
                case 1:
                    vert = MovementMode.VerticalDown;
                    break;
                case 2:
                    vert = MovementMode.HorizontalRight;
                    break;
                case 3:
                    vert = MovementMode.HorizontalLeft;
                    break;
            }
            P5G.BeginGrind(Text, (int)iterationNum.Value, /*(int)keyLength.Value,*/ modeRule.SelectedIndex == 0, hori, vert);
        }

        private void grid6Btn_Click(object sender, EventArgs e)
        {
            grid6Btn_Click(null, null);
        }
    }
}
