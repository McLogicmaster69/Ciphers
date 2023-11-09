using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens
{
    public enum ValueType
    {
        String,
        Int,
        Bool
    }

    public abstract class ValueToken : Token
    {
        public readonly ValueType ValueType;

        public ValueToken(ValueType type, int line) : base(TokenType.ValueToken, line)
        {
            ValueType = type;
        }

        public abstract object GetValue(ExecutionMemory memory, out Error error);
    }
}
