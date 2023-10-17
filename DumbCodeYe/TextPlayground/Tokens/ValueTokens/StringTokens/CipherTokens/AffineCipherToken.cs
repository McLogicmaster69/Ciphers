using DumbCodeYe.Ciphers;
using DumbCodeYe.TextPlayground.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens.CipherTokens
{
    public class AffineCipherToken : CipherToken
    {
        private readonly StringToken Input;

        public AffineCipherToken(StringToken input, int line) : base(CipherType.Affine, line)
        {
            Input = input;
        }

        public override string GetCipherOutput(ExecutionMemory memory, out Error error)
        {
            string str = Input.GetString(memory, out Error err);
            if(err != null)
            {
                error = err;
                return string.Empty;
            }

            error = null;
            return AffineCipher.TryAffineCipherValue(str);
        }
    }
}
