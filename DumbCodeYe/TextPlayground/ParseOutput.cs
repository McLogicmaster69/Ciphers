using DumbCodeYe.TextPlayground.Errors;
using DumbCodeYe.TextPlayground.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground
{
    public class ParseOutput
    {
        public Token[] Tokens;
        public Error[] Errors;

        public ParseOutput(Token[] tokens, Error[] errors)
        {
            Tokens = tokens;
            Errors = errors;
        }
    }
}
