using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Variables
{
    public class StringVariable
    {
        public readonly string Name;
        public string Value { get; private set; }

        public StringVariable(string name)
        {
            Name = name;
            Value = string.Empty;
        }

        public StringVariable(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public void ChangeValue(string value)
        {
            Value = value;
        }
    }
}
