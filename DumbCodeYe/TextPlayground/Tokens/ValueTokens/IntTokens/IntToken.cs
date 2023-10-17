using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.IntTokens
{
    public abstract class IntToken : ValueToken
    {
        public IntToken(int line) : base(ValueType.Int, line)
        {
        }

        public abstract int GetInt(ExecutionMemory memory, out Error error);

        public override object GetValue(ExecutionMemory memory, out Error error) => GetInt(memory, out error);
    }
}
