using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens
{
    public class PlainStringToken : StringToken
    {
        public readonly string String;

        public PlainStringToken(string str)
        {
            String = str;
        }

        public override string GetString() => String;
    }
}
