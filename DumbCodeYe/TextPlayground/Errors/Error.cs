using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Errors
{
    public enum ErrorType
    {
        UnimplementedToken,

        UnknownToken,
        MissingToken,
        UnexpectedToken,
        IncompleteString,

        DuplicatedVariable,
        UnknownVariable
    }

    public class Error
    {
        public readonly ErrorType Type;
        public readonly int Line;
        public Error(ErrorType type, int line)
        {
            Type = type;
            Line = line;
        }
    }
}
