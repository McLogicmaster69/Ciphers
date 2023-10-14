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
            ParseOutput output = new ParseOutput(null, null);
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
    }
}
