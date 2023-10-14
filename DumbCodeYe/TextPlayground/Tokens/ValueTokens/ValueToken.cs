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

    public class ValueToken : Token
    {
        public readonly ValueType ValueType;

        public ValueToken(ValueType type) : base(TokenType.ValueToken)
        {
            ValueType = type;
        }

        public virtual object GetValue()
        {
            return null;
        }
    }
}
