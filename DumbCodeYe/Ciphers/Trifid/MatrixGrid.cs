using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Trifid
{
    public class MatrixGrid
    {
        private char[,] grid = new char[3, 3];

        public void SetCell(int row, int column, char c) => grid[row, column] = c;

        public char GetCell(int row, int column) => grid[row, column];
    }
}
