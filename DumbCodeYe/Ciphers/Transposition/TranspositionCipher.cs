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

            output("Trying to solve using route cipher");
            string route = AutoSolveRoute(input, output);
            if(route != "")
            {
                output("Found route");
                return route;
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

        public static string Reverse(string input)
        {
            string output = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }

        public static string AutoSolveRoute(string input, OutputMethod outp = null)
        {
            for (int i = 3; i < 10; i++)
            {
                string output = AutoSolveRoute(input, i, outp);
                if (output != "")
                {
                    return output;
                }
            }
            return "";
        }

        public static string AutoSolveRoute(string input, int columns, OutputMethod output = null)
        {
            string topLeft = TopLeftRoute(input, columns, output);
            if (topLeft != "")
                return topLeft;
            string topLeftR = TopLeftRoute(Reverse(input), columns, output);
            if (topLeft != "")
                return topLeftR;
            string topRight = TopRightRoute(input, columns, output);
            if (topRight != "")
                return topRight;
            string topRightR = TopRightRoute(Reverse(input), columns, output);
            if (topRightR != "")
                return topRightR;
            string bottomLeft = BottomLeftRoute(input, columns, output);
            if (bottomLeft != "")
                return bottomLeft;
            string bottomLeftR = BottomLeftRoute(Reverse(input), columns, output);
            if (bottomLeftR != "")
                return bottomLeftR;
            string bottomRight = BottomRightRoute(input, columns, output);
            if (bottomRight != "")
                return bottomRight;
            string bottomRightR = BottomRightRoute(Reverse(input), columns, output);
            if (bottomRightR != "")
                return bottomRightR;

            return "";
        }

        private static string TopLeftRoute(string input, int columns, OutputMethod outp = null)
        {
            char[,] grid = new char[input.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = input.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < input.Length)
            {
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= input.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= input.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= input.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= input.Length)
                    break;
            }
            GridOutput GO = new GridOutput(grid, input.Length / columns, columns);
            if (GO.AutoSolve(out string output, outp))
                return output;
            return "";
        }
        private static string TopRightRoute(string input, int columns, OutputMethod outp = null)
        {
            char[,] grid = new char[input.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = input.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < input.Length)
            {
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= input.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= input.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= input.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= input.Length)
                    break;
            }
            GridOutput GO = new GridOutput(grid, input.Length / columns, columns);
            if (GO.AutoSolve(out string output, outp))
                return output;
            return "";
        }
        private static string BottomRightRoute(string input, int columns, OutputMethod outp = null)
        {
            char[,] grid = new char[input.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = input.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < input.Length)
            {
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= input.Length)
                    break;
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= input.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= input.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= input.Length)
                    break;
            }
            GridOutput GO = new GridOutput(grid, input.Length / columns, columns);
            if (GO.AutoSolve(out string output, outp))
                return output;
            return "";
        }
        private static string BottomLeftRoute(string input, int columns, OutputMethod outp = null)
        {
            char[,] grid = new char[input.Length / columns, columns];
            int upperBound = 0;
            int lowerBound = input.Length / columns - 1;
            int leftBound = 0;
            int rightBound = columns - 1;
            int letterIndex = 0;
            while (letterIndex < input.Length)
            {
                for (int i = lowerBound; i >= upperBound; i--)
                {
                    grid[i, leftBound] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                leftBound++;
                if (letterIndex >= input.Length)
                    break;
                for (int i = leftBound; i <= rightBound; i++)
                {
                    grid[upperBound, i] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                upperBound++;
                if (letterIndex >= input.Length)
                    break;
                for (int i = upperBound; i <= lowerBound; i++)
                {
                    grid[i, rightBound] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                rightBound--;
                if (letterIndex >= input.Length)
                    break;
                for (int i = rightBound; i >= leftBound; i--)
                {
                    grid[lowerBound, i] = input[letterIndex];
                    letterIndex++;
                    if (letterIndex >= input.Length)
                        break;
                }
                lowerBound--;
                if (letterIndex >= input.Length)
                    break;
            }
            GridOutput GO = new GridOutput(grid, input.Length / columns, columns);
            if (GO.AutoSolve(out string output, outp))
                return output;
            return "";
        }
    }
}
