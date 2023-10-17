using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens
{
    public class StringVariableToken : StringToken
    {
        private readonly UndefinedToken Undefined;

        public StringVariableToken(UndefinedToken undefined, int line) : base(line)
        {
            Undefined = undefined;
        }

        public override string GetString(ExecutionMemory memory, out Error error)
        {
            string value = memory.GetString(Undefined.Value, out Error err, Line);
            if(err != null)
            {
                error = err;
                return string.Empty;
            }

            error = null;
            return value;
        }
    }
}
