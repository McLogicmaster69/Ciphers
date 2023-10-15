using DumbCodeYe.TextPlayground.Errors;
using DumbCodeYe.TextPlayground.Tokens;
using DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens.CipherTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground
{
    public static class Parser
    {
        public static ParseOutput Parse(string text)
        {
            List<string> textTokens = GetTextTokens(text);
            Error[] errors;
            Token[] tokens = ParseText(textTokens.ToArray(), out errors);
            ParseOutput output = new ParseOutput(tokens, errors);
            return output;
        }

        private static List<string> GetTextTokens(string text)
        {
            string input = text.ToUpper();
            List<string> textTokens = new List<string>();
            string currentWord = "";
            foreach (char c in input)
            {
                if (c != ' ' || c != '\n' || c != '\r')
                {
                    currentWord += c.ToString();
                }
                else
                {
                    if (string.IsNullOrEmpty(currentWord))
                    {
                        textTokens.Add(currentWord);
                        currentWord = "";
                    }
                }
            }
            if (string.IsNullOrEmpty(currentWord))
            {
                textTokens.Add(currentWord);
                currentWord = "";
            }
            return textTokens;
        }

        private static Token[] ParseText(string[] stringTokens, out Error[] errors)
        {
            List<Token> tokens = new List<Token>();
            List<Error> errorList = new List<Error>();
            errors = errorList.ToArray();
            return tokens.ToArray();
        }

        private static Token ParseStringToken(string stringToken)
        {
            switch (stringToken)
            {
                case "CEASERCIPHER":
                    return new CeaserCipherToken();
            }
        }
    }
}
