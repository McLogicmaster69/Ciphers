using DumbCodeYe.TextPlayground.Errors;
using DumbCodeYe.TextPlayground.Tokens;
using DumbCodeYe.TextPlayground.Tokens.ValueTokens;
using DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens;
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
            List<StringToParse> textTokens = GetTextTokens(text);
            Token[] tokens = ParseText(textTokens.ToArray(), out Error[] errors);
            ParseOutput output = new ParseOutput(tokens, errors);
            return output;
        }

        private static List<StringToParse> GetTextTokens(string text)
        {
            string input = text.ToUpper();
            List<StringToParse> textTokens = new List<StringToParse>();
            string currentWord = "";
            int currentLine = 0;
            foreach (char c in input)
            {
                if (c != ' ' && c != '\n' && c != '\r')
                {
                    currentWord += c.ToString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentWord))
                    {
                        textTokens.Add(new StringToParse(currentWord, currentLine));
                        currentWord = "";
                    }
                    if (c == '\n')
                        currentLine++;
                }
            }
            if (!string.IsNullOrEmpty(currentWord))
                textTokens.Add(new StringToParse(currentWord, currentLine));
            return textTokens;
        }

        private static Token[] ParseText(StringToParse[] stringTokens, out Error[] errors)
        {
            List<Token> tokens = new List<Token>();
            List<Error> errorList = new List<Error>();

            int index = 0;
            while(index < stringTokens.Length)
            {
                Token token = ParseStringToken(stringTokens, ref index, out Error err);
                if (err != null)
                    errorList.Add(err);
                else
                    tokens.Add(token);
                index++;
            }

            errors = errorList.ToArray();
            return tokens.ToArray();
        }

        private static Token ParseStringToken(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToParse str = stringTokens[index];

            switch (str.Value)
            {
                case "INPUT":
                    return INPUT(stringTokens, ref index, out error);
                case "OUTPUT":
                    return OUTPUT(stringTokens, ref index, out error);
                case "CEASER":
                    return CEASER(stringTokens, ref index, out error);
            }

            error = new Error(ErrorType.UnknownToken, str.Line);
            return null;
        }

        #region Value

        private static StringToken GetNextStringToken(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToParse str = stringTokens[index];
            index++;
            if (index >= stringTokens.Length)
            {
                error = new Error(ErrorType.MissingToken, str.Line);
                return null;
            }
            StringToParse newStr = stringTokens[index];

            Token nextToken = ParseStringToken(stringTokens, ref index, out Error err);

            if (err != null)
            {
                error = err;
                return null;
            }
            if (nextToken.Type != TokenType.ValueToken)
            {
                error = new Error(ErrorType.UnexpectedToken, newStr.Line);
                return null;
            }
            if (((ValueToken)nextToken).ValueType != Tokens.ValueTokens.ValueType.String)
            {
                error = new Error(ErrorType.UnexpectedToken, newStr.Line);
                return null;
            }

            error = null;
            return (StringToken)nextToken;
        }

        #endregion

        #region General

        private static InputToken INPUT(StringToParse[] stringTokens, ref int index, out Error error)
        {
            error = null;
            return new InputToken();
        }

        private static OutputToken OUTPUT(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToken stringToken = GetNextStringToken(stringTokens, ref index, out Error err);

            if (err != null)
            {
                error = err;
                return null;
            }

            error = null;
            return new OutputToken(stringToken);
        }

        #endregion

        #region Ciphers

        private static CeaserCipherToken CEASER(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToken stringToken = GetNextStringToken(stringTokens, ref index, out Error err);

            if(err != null)
            {
                error = err;
                return null;
            }

            error = null;
            return new CeaserCipherToken(stringToken);
        }

        #endregion
    }
}
