using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Bifid
{
    public class BifidGrid : IEnumerable<char>
    {
        private char[,] _grid = new char[5, 5];

        public void SetCell(int row, int column, char c) => _grid[row, column] = c;

        public char GetCell(int row, int column) => _grid[row, column];

        public static BifidGrid GetBlankGrid(string characters)
        {
            if (characters.Length != 25)
                throw new Exception("Expected 25 characters");

            BifidGrid grid = new BifidGrid();
            int row = 0;
            int column = 0;

            foreach(char c in characters)
            {
                grid.SetCell(row, column, c);
                column++;

                if(column == 5)
                {
                    row++;
                    column = 0;
                }
            }

            return grid;
        }

        public string GetRow(int row) => $"{_grid[row, 0]}{_grid[row, 1]}{_grid[row, 2]}{_grid[row, 3]}{_grid[row, 4]}";

        public string GetColumn(int column) => $"{_grid[0, column]}{_grid[1, column]}{_grid[2, column]}{_grid[3, column]}{_grid[4, column]}";

        private IEnumerable<char> GetValues()
        {
            for (int column = 0; column < 5; column++)
            {
                for (int row = 0; row < 5; row++)
                {
                    yield return GetCell(row, column);
                }
            }
        }

        public IEnumerator<char> GetEnumerator() => GetValues().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
