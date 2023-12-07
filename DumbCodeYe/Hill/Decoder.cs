using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Hill
{
    public static class Decoder
    {
        public static string Decode(string text)
        {
            return null;
        }
        #region character handling
        public static string ConvertToAlphabet(int number)
        {
            if (number == 0)    //checks for the letter z
                number += 26;
            return Convert.ToString(Convert.ToChar(number + 65));
        }
        public static int ConvertToNumber(string character)
        {
            return (Convert.ToInt32(Convert.ToChar(character)) - 65) % 26;
        }
        #endregion
        #region main
        
        #endregion
    }
}
