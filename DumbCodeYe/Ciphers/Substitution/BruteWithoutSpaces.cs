using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Substitution
{
    public partial class BruteWithoutSpaces : Form
    {
        private readonly TextBox[] _valueTextBoxes;

        public BruteWithoutSpaces(string input)
        {
            InitializeComponent();

            _valueTextBoxes = new TextBox[] { AValue, BValue, CValue, DValue, EValue, FValue, GValue, HValue, IValue, JValue, KValue, LValue, MValue, NValue, OValue, PValue, QValue, RValue, SValue, TValue, UValue, VValue, WValue, XValue, YValue, ZValue };
            
        }

        private string JustLetters(string text)
        {
            string outputText = "";
            foreach (char c in text)
            {
                if (GeneralConstants.CAPITALS.Contains(c.ToString().ToUpper()))
                    outputText += c.ToString().ToUpper();
            }
            return outputText;
        }
    }
}
