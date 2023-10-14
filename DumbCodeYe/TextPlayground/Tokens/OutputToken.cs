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

        public OutputToken(StringToken value) : base(TokenType.Output)
        {
            Value = value;
        }

        public override void Run()
        {
            TextOutputFrm.CreateOutput(Value.GetString());
        }
    }
}
