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
        public static ExecutionOutput Execute(Token[] tokens, string input)
        {
            ExecutionMemory memory = new ExecutionMemory(input);
            int tokenIndex = 0;
            while(tokenIndex < tokens.Length)
            {
                tokens[tokenIndex].Run(memory);
                tokenIndex++;
            }
            return new ExecutionOutput();
        }
    }
}
