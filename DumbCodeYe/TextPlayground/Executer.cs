using DumbCodeYe.TextPlayground.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground
{
    public static class Executer
    {
        public static ExecutionOutput Execute(List<Token> tokens)
        {
            int tokenIndex = 0;
            while(tokenIndex < tokens.Count)
            {
                tokens[tokenIndex].Run();
                tokenIndex++;
            }
            return new ExecutionOutput();
        }
    }
}
