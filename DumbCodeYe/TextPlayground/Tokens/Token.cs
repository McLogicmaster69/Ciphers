using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens
{
    public enum TokenType
    {
        ValueToken,
        Input,
        Output,
        Declearion,
        Undefined
    }

    public class Token
    {
        public readonly TokenType Type;
        public readonly int Line;

        public Token(TokenType type, int line)
        {
            Type = type;
            Line = line;
        }

        public virtual Error Run(ExecutionMemory memory)
        {
            return new Error(ErrorType.UnimplementedToken, Line);
        }
    }
}
