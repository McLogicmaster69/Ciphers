using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Bifid
{
    public static class BifidCipher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d">d where message[d - 1] is the first character</param>
        /// <param name="l">the length of the message</param>
        /// <returns></returns>
        public static float PDistance(float d, float l, BifidGrid grid, BifidText text)
        {
            if(d <= (l - 1) / 2f)
            {
                return RSum(grid, text) + (1f / l) * (2 * USum(grid, text) - VSum(grid, text) - RSum(grid, text)) - ((2f * d) / l) * (RSum(grid, text) - VSum(grid, text));
            }
            else if(d > (l - 1) / 2f && d < l)
            {
                return 2 * VSum(grid, text) - RSum(grid, text) + (1f / l) * (2 * USum(grid, text) - VSum(grid, text) - RSum(grid, text)) + ((2f * d) / l) * (RSum(grid, text) - VSum(grid, text));
            }
            else if(d == l)
            {
                return RSum(grid, text) + (1f / l) * (SSum(grid, text) - RSum(grid, text));
            }

            return 0;
        }

        public static float RSum(BifidGrid grid, BifidText text)
        {
            float total = 0;

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    total += (float)Math.Pow(BSum(grid.GetRow(row), grid.GetColumn(column), text), 2) + (float)Math.Pow(ASum(grid.GetColumn(column), grid.GetRow(row), text), 2);
                }
            }

            return total;
        }

        public static float SSum(BifidGrid grid, BifidText text)
        {
            float total = 0;

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    total += (float)Math.Pow(CSum(grid.GetRow(row), grid.GetColumn(column), text), 2);
                }
            }

            return total;
        }

        public static float USum(BifidGrid grid, BifidText text)
        {
            float total = 0;

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    total += CSum(grid.GetRow(row), grid.GetColumn(column), text) * (BSum(grid.GetRow(row), grid.GetColumn(column), text) + ASum(grid.GetColumn(column), grid.GetRow(row), text));
                }
            }

            return total;
        }

        public static float VSum(BifidGrid grid, BifidText text)
        {
            float total = 0;

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    total += BSum(grid.GetRow(row), grid.GetColumn(column), text) * ASum(grid.GetColumn(column), grid.GetRow(row), text);
                }
            }

            return total;
        }

        public static float BSum(string row, string column, BifidText text)
        {
            float total = 0;
            foreach(char beta in row)
            {
                foreach(char gamma in column)
                {
                    total += text.GetBigramProbability(beta.ToString() + gamma.ToString());
                }
            }
            return total;
        }

        public static float CSum(string row, string column, BifidText text) => Rho(row, text) * Kappa(column, text);

        public static float ASum(string column, string row, BifidText text)
        {
            float total = 0;
            foreach (char beta in column)
            {
                foreach (char gamma in row)
                {
                    total += text.GetBigramProbability(beta.ToString() + gamma.ToString());
                }
            }
            return total;
        }

        public static float Rho(string row, BifidText text)
        {
            float total = 0;
            foreach(char c in row)
            {
                total += text.GetCharacterProbability(c);
            }
            return total;
        }

        public static float Kappa(string column, BifidText text)
        {
            float total = 0;
            foreach (char c in column)
            {
                total += text.GetCharacterProbability(c);
            }
            return total;
        }
    }
}
