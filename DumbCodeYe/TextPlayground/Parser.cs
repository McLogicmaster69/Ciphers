using DumbCodeYe.TextPlayground.Errors;
using DumbCodeYe.TextPlayground.Tokens;
using DumbCodeYe.TextPlayground.Tokens.ValueTokens;
using DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens;
using DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens.CipherTokens;
using DumbCodeYe.TextPlayground.Tokens.VariableTokens;
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
            List<StringToParse> textTokens = GetTextTokens(text, out Error err);
            if(err != null)
            {
                return new ParseOutput(null, new Error[] { err });
            }
            Token[] tokens = ParseText(textTokens.ToArray(), out Error[] errors);
            ParseOutput output = new ParseOutput(tokens, errors);
            return output;
        }

        private static List<StringToParse> GetTextTokens(string text, out Error err)
        {
            List<StringToParse> textTokens = new List<StringToParse>();
            string currentWord = "";
            int currentLine = 0;
            bool isString = false;
            foreach (char c in text)
            {
                if (isString)
                {
                    if(c == '\"')
                    {
                        isString = false;
                        textTokens.Add(new StringToParse(currentWord, currentLine, StringType.String));
                        currentWord = "";
                    }
                    else
                    {
                        if (c == '\n')
                            currentLine++;
                        currentWord += c.ToString();
                    }
                }
                else
                {
                    if (c == '\"')
                    {
                        isString = true;
                    }
                    else if (c != ' ' && c != '\n' && c != '\r')
                    {
                        currentWord += c.ToString().ToUpper();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(currentWord))
                        {
                            textTokens.Add(new StringToParse(currentWord, currentLine, StringType.Normal));
                            currentWord = "";
                        }
                        if (c == '\n')
                            currentLine++;
                    }
                }
            }
            if(isString)
            {
                err = new Error(ErrorType.IncompleteString, currentLine);
                return null;
            }
            if (!string.IsNullOrEmpty(currentWord))
                textTokens.Add(new StringToParse(currentWord, currentLine, StringType.Normal));
            err = null;
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

            if (str.Type == StringType.String)
            {
                error = null;
                return new PlainStringToken(str.Value, str.Line);
            }

            switch (str.Value)
            {
                case "INPUT":
                    return INPUT(stringTokens, ref index, out error);
                case "OUTPUT":
                    return OUTPUT(stringTokens, ref index, out error);

                case "STRING":
                    return STRING(stringTokens, ref index, out error);

                case "CEASER":
                    return CEASER(stringTokens, ref index, out error);
                case "AFFINE":
                    return AFFINE(stringTokens, ref index, out error);
            }

            //error = new Error(ErrorType.UnknownToken, str.Line);
            //return null;

            error = null;
            return new UndefinedToken(str.Value, str.Line);
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
            if(nextToken.Type == TokenType.Undefined)
            {
                error = null;
                return new StringVariableToken((UndefinedToken)nextToken, nextToken.Line);
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

        private static UndefinedToken GetNextUndefinedToken(StringToParse[] stringTokens, ref int index, out Error error)
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
            if(nextToken.Type != TokenType.Undefined)
            {
                error = new Error(ErrorType.UnexpectedToken, newStr.Line);
                return null;
            }

            error = null;
            return (UndefinedToken)nextToken;
        }

        #endregion

        #region General

        private static InputToken INPUT(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToParse str = stringTokens[index];
            error = null;
            return new InputToken(str.Line);
        }

        private static OutputToken OUTPUT(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToParse str = stringTokens[index];
            StringToken stringToken = GetNextStringToken(stringTokens, ref index, out Error err);

            if (err != null)
            {
                error = err;
                return null;
            }

            error = null;
            return new OutputToken(stringToken, str.Line);
        }

        #endregion

        #region Ciphers

        private static CeaserCipherToken CEASER(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToParse str = stringTokens[index];
            StringToken stringToken = GetNextStringToken(stringTokens, ref index, out Error err);

            if(err != null)
            {
                error = err;
                return null;
            }

            error = null;
            return new CeaserCipherToken(stringToken, str.Line);
        }

        private static AffineCipherToken AFFINE(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToParse str = stringTokens[index];
            StringToken stringToken = GetNextStringToken(stringTokens, ref index, out Error err);
            
            if(err != null)
            {
                error = err;
                return null;
            }

            error = null;
            return new AffineCipherToken(stringToken, str.Line);
        }

        #endregion

        #region Variables

        private static DeclerationToken STRING(StringToParse[] stringTokens, ref int index, out Error error)
        {
            StringToParse str = stringTokens[index];
            UndefinedToken undefined = GetNextUndefinedToken(stringTokens, ref index, out Error err);

            if (err != null)
            {
                error = err;
                return null;
            }

            error = null;
            return new DeclerationToken(Tokens.ValueTokens.ValueType.String, undefined, str.Line);
        }

        #endregion
    }
}
