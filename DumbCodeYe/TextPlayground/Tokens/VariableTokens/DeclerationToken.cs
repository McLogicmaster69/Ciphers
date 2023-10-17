using DumbCodeYe.TextPlayground.Errors;
using DumbCodeYe.TextPlayground.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.VariableTokens
{
    public class DeclerationToken : Token
    {
        public readonly ValueTokens.ValueType ValueType;
        public readonly UndefinedToken Name;

        public DeclerationToken(ValueTokens.ValueType valueType, UndefinedToken name, int line) : base(TokenType.Declearion, line)
        {
            ValueType = valueType;
            Name = name;
        }

        public override Error Run(ExecutionMemory memory)
        {
            switch (ValueType)
            {
                case ValueTokens.ValueType.String:
                    memory.DeclareString(new StringVariable(Name.Value), Line);
                    break;
            }
            return null;
        }
    }
}
