using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens
{
    public abstract class StringToken : ValueToken
    {
        public StringToken(int line) : base(ValueType.String, line)
        {
        }

        public abstract string GetString(ExecutionMemory memory, out Error error);

        public override object GetValue(ExecutionMemory memory, out Error error) => GetString(memory, out error);
    }
}
