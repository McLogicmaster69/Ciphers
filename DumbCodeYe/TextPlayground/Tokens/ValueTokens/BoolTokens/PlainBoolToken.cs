using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.BoolTokens
{
    public class PlainBoolToken : BoolToken
    {
        public readonly bool Bool;

        public PlainBoolToken(bool b, int line) : base(line)
        {
            Bool = b;
        }

        public override bool GetBool(ExecutionMemory memory, out Error error)
        {
            error = null;
            return Bool;
        }
    }
}
