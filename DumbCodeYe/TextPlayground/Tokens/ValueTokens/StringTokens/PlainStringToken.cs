using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens
{
    public class PlainStringToken : StringToken
    {
        public readonly string String;

        public PlainStringToken(string str, int line) : base(line)
        {
            String = str;
        }

        public override string GetString(ExecutionMemory memory, out Error error)
        {
            error = null;
            return String;
        }
    }
}
