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
        public EventHandler OnClick;

        public ButtonInformation(string text, EventHandler onClick)
        {
            Text = text;
            OnClick = onClick;
        }
    }
}
