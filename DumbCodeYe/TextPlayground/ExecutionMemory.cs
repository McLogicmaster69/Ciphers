using DumbCodeYe.TextPlayground.Errors;
using DumbCodeYe.TextPlayground.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground
{
    public class ExecutionMemory
    {
        public readonly string Input;

        private List<StringVariable> StringVariables = new List<StringVariable>();

        public ExecutionMemory(string input)
        {
            Input = input;
        }

        public Error DeclareString(StringVariable value, int line)
        {
            foreach(StringVariable v in StringVariables)
            {
                if(v.Name == value.Name)
                {
                    return new Error(ErrorType.DuplicatedVariable, line);
                }
            }
            StringVariables.Add(value);
            return null;
        }

        public string GetString(string name, out Error error, int line)
        {
            foreach(StringVariable v in StringVariables)
            {
                if(v.Name == name)
                {
                    error = null;
                    return v.Value;
                }
            }
            error = new Error(ErrorType.UnknownVariable, line);
            return string.Empty;
        }

        public Error SetString(string name, string value, int line)
        {
            foreach (StringVariable v in StringVariables)
            {
                if (v.Name == name)
                {
                    v.ChangeValue(value);
                    return null;
                }
            }
            return new Error(ErrorType.UnknownVariable , line);
        }
    }
}
