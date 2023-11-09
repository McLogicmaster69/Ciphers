using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens
{
    public class UndefinedToken : Token
    {
        public readonly string Value;

        public UndefinedToken(string value, int line) : base(TokenType.Undefined, line)
        {
            Value = value;
        }

        public override Error Run(ExecutionMemory memory)
        {
            return new Error(ErrorType.UnknownToken, Line);
        }
    }
}
