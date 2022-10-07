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
    public partial class Replacements : Form
    {
        private SubstitueTool ST;
        private string Characters = "abcdefghijklmnopqrstuvwxyz";
        public Replacements(SubstitueTool st)
        {
            InitializeComponent();
            ST = st;
        }

        public void SetValues(char[] values)
        {
            AValue.Text = values[0].ToString();
            BValue.Text = values[1].ToString();
            CValue.Text = values[2].ToString();
            DValue.Text = values[3].ToString();
            EValue.Text = values[4].ToString();
            FValue.Text = values[5].ToString();
            GValue.Text = values[6].ToString();
            HValue.Text = values[7].ToString();
            IValue.Text = values[8].ToString();
            JValue.Text = values[9].ToString();
            KValue.Text = values[10].ToString();
            LValue.Text = values[11].ToString();
            MValue.Text = values[12].ToString();
            NValue.Text = values[13].ToString();
            OValue.Text = values[14].ToString();
            PValue.Text = values[15].ToString();
            QValue.Text = values[16].ToString();
            RValue.Text = values[17].ToString();
            SValue.Text = values[18].ToString();
            TValue.Text = values[19].ToString();
            UValue.Text = values[20].ToString();
            VValue.Text = values[21].ToString();
            WValue.Text = values[22].ToString();
            XValue.Text = values[23].ToString();
            YValue.Text = values[24].ToString();
            ZValue.Text = values[25].ToString();
        }
        public char[] GetValues()
        {
            try
            {
                return new char[]
                {
                AValue.Text[0],
                BValue.Text[0],
                CValue.Text[0],
                DValue.Text[0],
                EValue.Text[0],
                FValue.Text[0],
                GValue.Text[0],
                HValue.Text[0],
                IValue.Text[0],
                JValue.Text[0],
                KValue.Text[0],
                LValue.Text[0],
                MValue.Text[0],
                NValue.Text[0],
                OValue.Text[0],
                PValue.Text[0],
                QValue.Text[0],
                RValue.Text[0],
                SValue.Text[0],
                TValue.Text[0],
                UValue.Text[0],
                VValue.Text[0],
                WValue.Text[0],
                XValue.Text[0],
                YValue.Text[0],
                ZValue.Text[0]
                };
            }
            catch
            {
                return new char[0];
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            char[] replacements = GetValues();
            if(replacements.Length == 0)
            {
                errorTxt.Text = $"There is an empty value";
                return;
            }
            bool[] replaced = new bool[26];
            for (int i = 0; i < 26; i++)
            {
                int charIndex = Characters.IndexOf(replacements[i]);
                if(charIndex == -1)
                {
                    if(replacements[i] != '#')
                    {
                        errorTxt.Text = $"letter {Characters[i].ToString().ToUpper()} has no valid value";
                        return;
                    }
                }
                else
                {
                    if (replaced[charIndex])
                    {
                        int errorIndex = 0;
                        for (int j = 0; j < i; j++)
                        {
                            if(replacements[j] == replacements[i])
                            {
                                errorIndex = j;
                                break;
                            }
                        }
                        errorTxt.Text = $"letter {Characters[i].ToString().ToUpper()} and letter {Characters[errorIndex].ToString().ToUpper()} have the same value of {replacements[i]}";
                        return;
                    }
                    replaced[charIndex] = true;
                }
            }
            ST.replacements = replacements;
            errorTxt.Text = "";
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            char[] replacements = new char[26]; 
            for (int i = 0; i < 26; i++)
            {
                replacements[i] = '#';
            }
            SetValues(replacements);
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            SetValues(ST.replacements);
        }
    }
}
