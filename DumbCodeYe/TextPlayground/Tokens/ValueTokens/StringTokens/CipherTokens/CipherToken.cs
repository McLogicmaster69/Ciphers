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

        public CipherToken(CipherType cipher)
        {
            Cipher = cipher;
        }

        public abstract string GetCipherOutput();

        public override string GetString() => GetCipherOutput();
    }
}
