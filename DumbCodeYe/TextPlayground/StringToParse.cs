using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground
{
    public struct StringToParse
    {
        public readonly string Value;
        public readonly int Line;
        
        public StringToParse(string value, int line)
        {
            Value = value;
            Line = line;
        }
    }
}
