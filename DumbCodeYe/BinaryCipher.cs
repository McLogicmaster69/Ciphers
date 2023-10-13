using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe
{
    public static class BinaryCipher
    {
        public static void GetBinary(string text)
        {
            string finalText = "";
            foreach (string code in text.Split(' '))
            {
                finalText += GetBinaryCharacter(code);
            }
            TextOutputFrm txtOut = new TextOutputFrm();
            txtOut.SetOutput(finalText);
            txtOut.Show();
        }
        public static string GetBinaryCharacter(string binary)
        {
            switch (binary)
            {
                case "00000":
                    return "A";
                case "00001":
                    return "B";
                case "00010":
                    return "C";
                case "00011":
                    return "D";
                case "00100":
                    return "E";
                case "00101":
                    return "F";
                case "00110":
                    return "G";
                case "00111":
                    return "H";
                case "01000":
                    return "I";
                case "01001":
                    return "J";
                case "01010":
                    return "K";
                case "01011":
                    return "L";
                case "01100":
                    return "M";
                case "01101":
                    return "N";
                case "01110":
                    return "O";
                case "01111":
                    return "P";
                case "10000":
                    return "Q";
                case "10001":
                    return "R";
                case "10010":
                    return "S";
                case "10011":
                    return "T";
                case "10100":
                    return "U";
                case "10101":
                    return "V";
                case "10110":
                    return "W";
                case "10111":
                    return "X";
                case "11000":
                    return "Y";
                case "11001":
                    return "Z";
            }
            return "";
        }
    }
}
