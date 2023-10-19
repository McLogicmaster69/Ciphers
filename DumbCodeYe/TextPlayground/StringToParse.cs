using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground
{
    public enum StringType
    {
        Normal,
        String
    }

    public struct StringToParse
    {
        public readonly string Value;
        public readonly int Line;
        public readonly StringType Type;
        
        public StringToParse(string value, int line, StringType type)
        {
            Value = value;
            Line = line;
            Type = type;
        }
    }
}
