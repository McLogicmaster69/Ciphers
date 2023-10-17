using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens.CipherTokens
{
    public enum CipherType
    {
        Ceaser,
        Affine
    }

    public abstract class CipherToken : StringToken
    {
        public readonly CipherType Cipher;

        public CipherToken(CipherType cipher, int line) : base(line)
        {
            Cipher = cipher;
        }

        public abstract string GetCipherOutput(ExecutionMemory memory, out Error error);

        public override string GetString(ExecutionMemory memory, out Error error) => GetCipherOutput(memory, out error);
    }
}
