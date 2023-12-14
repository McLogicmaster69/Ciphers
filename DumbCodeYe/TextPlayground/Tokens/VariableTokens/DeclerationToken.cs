﻿using DumbCodeYe.TextPlayground.Errors;
using DumbCodeYe.TextPlayground.Tokens.ValueTokens;
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
        public readonly ValueToken DefaultValue;

        public DeclerationToken(ValueTokens.ValueType valueType, UndefinedToken name, int line) : base(TokenType.Declearion, line)
        {
            ValueType = valueType;
            Name = name;
            DefaultValue = null;
        }

        public DeclerationToken(ValueTokens.ValueType valuType, UndefinedToken name, ValueToken defaultValue, int line) : base(TokenType.Declearion, line)
        {
            ValueType = valuType;
            Name = name;
            DefaultValue = defaultValue;
        }

        public override Error Run(ExecutionMemory memory)
        {
            switch (ValueType)
            {
                case ValueTokens.ValueType.String:
                    if(DefaultValue != null)
                        memory.DeclareString(new StringVariable(Name.Value, (string)DefaultValue.GetValue(memory, out Error strErr)), Line);
                    else
                        memory.DeclareString(new StringVariable(Name.Value), Line);
                    break;
            }
            return null;
        }
    }
}