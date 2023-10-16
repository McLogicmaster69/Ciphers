using DumbCodeYe.Ciphers;
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

        public AffineCipherToken(StringToken input) : base(CipherType.Affine)
        {
            Input = input;
        }

        public override string GetCipherOutput() => AffineCipher.TryAffineCipherValue(Input.GetString());
    }
}
