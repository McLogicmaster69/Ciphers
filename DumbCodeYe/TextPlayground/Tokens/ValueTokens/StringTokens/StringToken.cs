using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens
{
    public class StringToken : ValueToken
    {
        public StringToken() : base(ValueType.String)
        {
        }

        public virtual string GetString() => string.Empty;

        public override object GetValue() => GetString();
    }
}
