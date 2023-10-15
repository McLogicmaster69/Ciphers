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
        Output
    }

    public class Token
    {
        public readonly TokenType Type;

        public Token(TokenType type)
        {
            Type = type;
        }

        public virtual void Run(ExecutionMemory memory)
        {
        }
    }
}
