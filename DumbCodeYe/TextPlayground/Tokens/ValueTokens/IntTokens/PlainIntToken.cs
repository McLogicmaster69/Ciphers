using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.IntTokens
{
    public class PlainIntToken : IntToken
    {
        public readonly int Int;

        public PlainIntToken(int i, int line) : base(line)
        {
            Int = i;
        }

        public override int GetInt(ExecutionMemory memory, out Error error)
        {
            error = null;
            return Int;
        }
    }
}
