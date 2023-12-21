using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers.Bifid
{
    public partial class BifidTools : Form
    {
        private string _mainText = "";
        private const string POLYBIUS_DIGITS = "12345";
        private BifidGridTools _gridTools;
        public char[][] replacements = new char[][]
        {
            new char[] { '#', '#', '#', '#', '#' },
            new char[] { '#', '#', '#', '#', '#' },
            new char[] { '#', '#', '#', '#', '#' },
            new char[] { '#', '#', '#', '#', '#' },
            new char[] { '#', '#', '#', '#', '#' }
        };
        public BifidTools()
        {
            InitializeComponent();
        }
        public void SetupText(string text)
        {
            _mainText = text;
            OutputText.Text = _mainText;
        }

        private void openGridBtn_Click(object sender, EventArgs e)
        {
            if (_gridTools == null)
                _gridTools = new BifidGridTools();
            _gridTools.Setup(this);
            _gridTools.Show();
        }

        private void applyGridBtn_Click(object sender, EventArgs e)
        {
            int period = (int)PeriodNmrc.Value;
            int size = _mainText.Length / period;
            string output = "";
            for (int i = 0; i < _mainText.Length; i += size)
            {
                output += ApplyBifid(_mainText.Substring(i, size));
            }
            OutputText.Text = output;
        }

        private string ApplyBifid(string text)
        {
            string numbers = Backward(text);
            string newNumbers = PairHalves(numbers);
            string output = Forward(newNumbers);
            return output;
        }

        private string Forward(string input)
        {
            string message = "";
            for (int i = 0; i < input.Length; i += 2)
            {
                if (input[i] == '+' || input[i + 1] == '+')
                {
                    message += "#";
                    continue;
                }
                int row = Convert.ToInt32(input[i].ToString());
                int column = Convert.ToInt32(input[i + 1].ToString());
                message += replacements[row][column];
            }
            return message;
        }

        private string Backward(string input)
        {
            string message = "";
            foreach(char c in input)
            {
                message += CharacterToCode(c.ToString().ToLower()[0]);
            }
            return message;
        }

        private string PairHalves(string input)
        {
            string output = "";
            int length = input.Length;
            for (int i = 0; i < length / 2; i++)
            {
                output += input[i].ToString() + input[length / 2 + i].ToString();
            }
            return output;
        }

        private string CharacterToCode(char c)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if(replacements[row][column] == c)
                    {
                        return $"{row}{column}";
                    }
                }
            }
            return "++";
        }

        private void PolybiusTools_Load(object sender, EventArgs e)
        {
            _gridTools = new BifidGridTools();
            _gridTools.Setup(this);
        }

        private void FactorsBtn_Click(object sender, EventArgs e)
        {
            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            for (int i = 1; i <= _mainText.Length; i++)
            {
                if (_mainText.Length % i == 0)
                {
                    rows.Add(i);
                    columns.Add(_mainText.Length / i);
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

        private void PeriodGraphBtn_Click(object sender, EventArgs e)
        {
            BifidGrid grid = BifidGrid.GetBlankGrid("ABCDEFGHIKLMNOPQRSTUVWXYZ");
            BifidText text = new BifidText(_mainText);

            string output = "";
            for (int i = 0; i < 50; i++)
            {
                output += $"{i}: {(BifidCipher.PDistance(i, _mainText.Length, grid, text) * 1000000) - 1410}\r\n";
            }

            TextOutputFrm.CreateOutput(output);
        }
    }
}
