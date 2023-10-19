using DumbCodeYe.TextPlayground.Errors;
using DumbCodeYe.TextPlayground.Tokens.ValueTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens
{
    public class OutputToken : Token
    {
        private StringToken Value;

        public OutputToken(StringToken value, int line) : base(TokenType.Output, line)
        {
            Value = value;
        }

        public override Error Run(ExecutionMemory memory)
        {
            TextOutputFrm.CreateOutput(Value.GetString(memory, out Error err));
            return err;
        }
    }
}
