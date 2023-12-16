using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Trifid
{
    public static class TrifidCipher
    {
        public static string Crack(string input, string keyword)
        {
            MatrixGrid[] grids = InitialiseGrids(keyword);
            return string.Empty;
        }

        private static MatrixGrid[] InitialiseGrids(string keyword)
        {
            List<char> characters = new List<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ+");
            MatrixGrid[] grids = new MatrixGrid[3];
            grids[0] = new MatrixGrid();
            grids[1] = new MatrixGrid();
            grids[2] = new MatrixGrid();

            int grid = 0;
            int row = 0;
            int column = 0;

            foreach(char c in keyword)
            {
                if (characters.Contains(c))
                {
                    characters.Remove(c);
                    grids[grid].SetCell(row, column, c);

                    column++;
                    if(column == 3)
                    {
                        column = 0;
                        row++;
                        if(row == 3)
                        {
                            row = 0;
                            grid++;
                        }
                    }    
                }
            }

            foreach(char c in characters)
            {
                grids[grid].SetCell(row, column, c);

                column++;
                if (column == 3)
                {
                    column = 0;
                    row++;
                    if (row == 3)
                    {
                        row = 0;
                        grid++;
                    }
                }
            }

            return grids;
        }
    }
}
