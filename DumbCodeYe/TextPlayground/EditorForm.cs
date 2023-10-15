using DumbCodeYe.TextPlayground.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.TextPlayground
{
    public partial class EditorForm : Form
    {
        private readonly string Input;

        public EditorForm(string input)
        {
            InitializeComponent();

            Input = input;
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            ParseOutput parseOutput = Parser.Parse(textInput.Text);
            if(parseOutput.Errors.Length != 0)
            {
                MessageBox.Show("ERROR WHILE PARSING");
                return;
            }
            Executer.Execute(parseOutput.Tokens, Input);
        }
    }
}
