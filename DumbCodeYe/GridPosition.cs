using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe
{
    public struct GridPosition
    {
        public int Row;
        public int Column;
        public GridPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
