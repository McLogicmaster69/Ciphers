using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.FourSquare
{
    public struct RowColumnScore
    {
        public int Row;
        public int Column;
        public decimal Score;

        public RowColumnScore(int row, int column, decimal score)
        {
            Row = row;
            Column = column;
            Score = score;
        }
    }
}
