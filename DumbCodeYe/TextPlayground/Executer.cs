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
        public static string Input { get; private set; }

        public static ExecutionOutput Execute(Token[] tokens, string input)
        {
            Input = input;

            ExecutionMemory memory = new ExecutionMemory();
            int tokenIndex = 0;
            while(tokenIndex < tokens.Length)
            {
                tokens[tokenIndex].Run(memory);
                tokenIndex++;
            }
            return new ExecutionOutput();
        }

        public static string GetInput() => Input;
    }
}
