using DumbCodeYe.Ciphers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens.CipherTokens
{
    public class CeaserCipherToken : CipherToken
    {
        private readonly StringToken Input;

        public CeaserCipherToken(StringToken input) : base(CipherType.Ceaser)
        {
            Input = input;
        }

        public override string GetCipherOutput() => CeaserCipher.TryCeaserValue(Input.GetString());
    }
}
