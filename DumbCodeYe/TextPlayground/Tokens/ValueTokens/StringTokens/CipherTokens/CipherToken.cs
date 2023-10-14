using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.TextPlayground.Tokens.ValueTokens.StringTokens.CipherTokens
{
    public enum CipherType
    {
        Ceaser
    }

    public class CipherToken : StringToken
    {
        public readonly CipherType Cipher;

        public CipherToken(CipherType cipher)
        {
            Cipher = cipher;
        }

        public virtual string GetCipherOutput() => string.Empty;

        public override string GetString() => GetCipherOutput();
    }
}
