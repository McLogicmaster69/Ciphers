using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens
{
    public class InputToken : StringToken
    {
        public override string GetString() => Executer.GetInput();
    }
}
