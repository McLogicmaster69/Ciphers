using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.BoolTokens
{
    public abstract class BoolToken : ValueToken
    {
        public BoolToken(int line) : base(ValueType.Bool, line)
        {
        }

        public abstract bool GetBool(ExecutionMemory memory, out Error error);

        public override object GetValue(ExecutionMemory memory, out Error error) => GetBool(memory, out error);
    }
}
