using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Transposition
{
    public static class TranspositionCipher
    {
        public const int MAX_FACTOR = 10;

        /// <summary>
        /// Creates a grid where it inputs text in going horizontally
        /// </summary>
        /// <param name="input"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static GridOutput CreateRowsFirst(string input, int columns)
        {
            string text = GetStringMod(input, columns);
            int rows = (int)Math.Ceiling((decimal)text.Length / columns);
            char[,] grid = new char[rows, columns];
            int index = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    grid[r, c] = text[index];
                    index++;
                }
            }
            return new GridOutput(grid, rows, columns);
        }

        /// <summary>
        /// Creates a grid where it inputs text in going vertically
        /// </summary>
        /// <param name="input"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static GridOutput CreateColumnsFirst(string input, int columns)
        {
            string text = GetStringMod(input, columns);
            int rows = (int)Math.Ceiling((decimal)text.Length / columns);
            char[,] grid = new char[rows, columns];
            int index = 0;
            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    grid[r, c] = text[index];
                    index++;
                }
            }
            return new GridOutput(grid, rows, columns);
        }

        /// <summary>
        /// Gets a string that is multiple of a value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static string GetStringMod(string text, int mod)
        {
            int stringRemainder = text.Length % mod;
            return text.Substring(0, text.Length - stringRemainder);
        }

        /// <summary>
        /// Gets a string that is multiple of a value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static string GetStringMod(string text, int mod, out string remainder)
        {
            int stringRemainder = text.Length % mod;
            remainder = text.Substring(text.Length - stringRemainder);
            return text.Substring(0, text.Length - stringRemainder);
        }

        /// <summary>
        /// Attempts to auto solve a tranposition cipher
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string AutoSolve(string input, OutputMethod output = null)
        {
            output("Trying to solve grids with rows inputted first");
            for (int i = 2; i <= MAX_FACTOR; i++)
            {
                output($"Trying factor of {i}");
                GridOutput grid = CreateGrid(true, GetStringMod(input, i, out string remainder), i);
                if(grid.AutoSolve(out string finalOutput, output))
                {
                    output($"Factor of {i} was successful");
                    return string.IsNullOrEmpty(remainder) ? finalOutput : finalOutput + $"::{remainder}";
                }
            }

            output("Trying to solve grids with columns inputted first");
            for (int i = 2; i <= MAX_FACTOR; i++)
            {
                output($"Trying factor of {i}");
                GridOutput grid = CreateGrid(false, GetStringMod(input, i, out string remainder), i);
                if (grid.AutoSolve(out string finalOutput, output))
                {
                    output($"Factor of {i} was successful");
                    return string.IsNullOrEmpty(remainder) ? finalOutput : finalOutput + $"::{remainder}";
                }
            }

            output("Could not find a suitable grid for cipher");
            return input;
        }

        /// <summary>
        /// Creates a new grid
        /// </summary>
        /// <param name="rowsFirst"></param>
        /// <param name="input"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static GridOutput CreateGrid(bool rowsFirst, string input, int columns) => rowsFirst ? CreateRowsFirst(input, columns) : CreateColumnsFirst(input, columns);
    }
}
