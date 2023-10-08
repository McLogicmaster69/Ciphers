using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe
{
    public struct ButtonInformation
    {
        public string Text;
        public CipherMethod OnClick;

        public ButtonInformation(string text, CipherMethod onClick)
        {
            Text = text;
            OnClick = onClick;
        }
    }
}
