using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens
{
    public class InputToken : StringToken
    {
        public InputToken(int line) : base(line)
        {
        }

        public override string GetString(ExecutionMemory memory, out Error error)
        {
            error = null;
            return memory.Input;
        }
    }
}
