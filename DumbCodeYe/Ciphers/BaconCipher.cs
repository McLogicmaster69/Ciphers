using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DumbCodeYe.Ciphers
{
    public static class BaconCipher
    {
        public static void Bacon(string text)
        {
            RollingTheRick.Roll();
            string plainText = "";
            string cipherText = text;
            string chunk;
            if (cipherText.Length >= 5 && cipherText.Length % 5 == 0)
            {
                for (int index = 0; index < (cipherText.Length); index += 5)
                {
                    chunk = cipherText.Substring(index, 5);
                    switch (chunk)
                    {
                        case "AAAAA":
                            plainText = plainText + "A";
                            break;
                        case "AAAAB":
                            plainText = plainText + "B";
                            break;
                        case "AAABA":
                            plainText = plainText + "C";
                            break;
                        case "AAABB":
                            plainText = plainText + "D";
                            break;
                        case "AABAA":
                            plainText = plainText + "E";
                            break;
                        case "AABAB":
                            plainText = plainText + "F";
                            break;
                        case "AABBA":
                            plainText = plainText + "G";
                            break;
                        case "AABBB":
                            plainText = plainText + "H";
                            break;
                        case "ABAAA":
                            plainText = plainText + "I";
                            break;
                        case "ABAAB":
                            plainText = plainText + "J";
                            break;
                        case "ABABA":
                            plainText = plainText + "K";
                            break;
                        case "ABABB":
                            plainText = plainText + "L";
                            break;
                        case "ABBAA":
                            plainText = plainText + "M";
                            break;
                        case "ABBAB":
                            plainText = plainText + "N";
                            break;
                        case "ABBBA":
                            plainText = plainText + "O";
                            break;
                        case "ABBBB":
                            plainText = plainText + "P";
                            break;
                        case "BAAAA":
                            plainText = plainText + "Q";
                            break;
                        case "BAAAB":
                            plainText = plainText + "R";
                            break;
                        case "BAABA":
                            plainText = plainText + "S";
                            break;
                        case "BAABB":
                            plainText = plainText + "T";
                            break;
                        case "BABAA":
                            plainText = plainText + "U";
                            break;
                        case "BABAB":
                            plainText = plainText + "V";
                            break;
                        case "BABBA":
                            plainText = plainText + "W";
                            break;
                        case "BABBB":
                            plainText = plainText + "X";
                            break;
                        case "BBAAA":
                            plainText = plainText + "Y";
                            break;
                        case "BBAAB":
                            plainText = plainText + "Z";
                            break;
                        default:
                            MessageBox.Show("It was jacob's fault");
                            break;
                    }
                }
                TextOutputFrm txtOut = new TextOutputFrm();
                txtOut.SetOutput(plainText);
                txtOut.Show();
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=DjelB-Z2QWo");
            }
            else
            {
                MessageBox.Show("Not Bacon Cipher");
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=DjelB-Z2QWo");
            }
        }
    }
}
