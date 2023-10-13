using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Playfair
{
    public enum MovementMode
    {
        HorizontalRight,
        HorizontalLeft,
        VerticalUp,
        VerticalDown
    }
    public class PlayfairGrid
    {
        public readonly char[,] Grid;
        private readonly MovementMode VerticalMode;
        private readonly MovementMode HorizontalMode;
        private readonly int Size;
        public PlayfairGrid(int size, string keyword, bool restartLetters, MovementMode horizontalMode, MovementMode verticalMode)
        {
            Grid = new char[size, size];
            Size = size;
            VerticalMode = verticalMode;
            HorizontalMode = horizontalMode;

            List<char> letters;
            if(size == 5)
                letters = new List<char>("ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray());
            else
                letters = new List<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());

            int currentRow = 0;
            int currentColumn = 0;
            foreach(char c in keyword)
            {
                if (letters.Contains(c))
                {
                    letters.Remove(c);
                    Grid[currentRow, currentColumn] = c;
                    currentColumn++;
                    if(currentColumn == size)
                    {
                        currentColumn = 0;
                        currentRow++;
                    }
                }
            }
            if (!restartLetters)
            {
                string appliedLetters = "";
                foreach(char c in letters)
                {
                    if(GetCharCode(c) > keyword[keyword.Length - 1])
                    {
                        appliedLetters += c;
                        Grid[currentRow, currentColumn] = c;
                        currentColumn++;
                        if (currentColumn == size)
                        {
                            currentColumn = 0;
                            currentRow++;
                        }
                    }
                }
                foreach(char c in appliedLetters)
                {
                    letters.Remove(c);
                }
            }
            foreach (char c in letters)
            {
                Grid[currentRow, currentColumn] = c;
                currentColumn++;
                if (currentColumn == size)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }
            if(size == 6)
            {
                for (int i = 0; i < 10; i++)
                {
                    Grid[currentRow, currentColumn] = i.ToString()[0];
                    currentColumn++;
                    if (currentColumn == size)
                    {
                        currentColumn = 0;
                        currentRow++;
                    }
                }
            }
        }
        public string Decrypt(char c1, char c2)
        {
            GridPosition pos1 = GetCharPosition(c1);
            GridPosition pos2 = GetCharPosition(c2);
            string returnText = "";
            if(pos1.Row == pos2.Row)
            {
                switch (VerticalMode)
                {
                    case MovementMode.VerticalDown:
                        returnText = Grid[(pos1.Row + 1) % Size, pos1.Column].ToString() + Grid[(pos2.Row + 1) % Size, pos2.Column].ToString();
                        break;
                    case MovementMode.VerticalUp:
                        returnText = Grid[(pos1.Row + (Size - 1)) % Size, pos1.Column].ToString() + Grid[(pos2.Row + (Size - 1)) % Size, pos2.Column].ToString();
                        break;
                    case MovementMode.HorizontalRight:
                        returnText = Grid[pos1.Row, (pos1.Column + 1) % Size].ToString() + Grid[pos2.Row, (pos2.Column + 1) % Size].ToString();
                        break;
                    case MovementMode.HorizontalLeft:
                        returnText = Grid[pos1.Row, (pos1.Column + (Size - 1)) % Size].ToString() + Grid[pos2.Row, (pos2.Column + (Size - 1)) % Size].ToString();
                        break;
                }
            }
            else if(pos1.Column == pos2.Column)
            {
                switch (HorizontalMode)
                {
                    case MovementMode.VerticalDown:
                        returnText = Grid[(pos1.Row + 1) % Size, pos1.Column].ToString() + Grid[(pos2.Row + 1) % Size, pos2.Column].ToString();
                        break;
                    case MovementMode.VerticalUp:
                        returnText = Grid[(pos1.Row + Size - 1) % Size, pos1.Column].ToString() + Grid[(pos2.Row + Size - 1) % Size, pos2.Column].ToString();
                        break;
                    case MovementMode.HorizontalRight:
                        returnText = Grid[pos1.Row, (pos1.Column + 1) % Size].ToString() + Grid[pos2.Row, (pos2.Column + 1) % Size].ToString();
                        break;
                    case MovementMode.HorizontalLeft:
                        returnText = Grid[pos1.Row, (pos1.Column + (Size - 1)) % Size].ToString() + Grid[pos2.Row, (pos2.Column + (Size - 1)) % Size].ToString();
                        break;
                }
            }
            else
                returnText = Grid[pos1.Row, pos2.Column].ToString() + Grid[pos2.Row, pos1.Column].ToString();
            return returnText;
        }
        private int GetCharCode(char c)
        {
            switch (c)
            {
                case 'A':
                    return 0;
                case 'B':
                    return 1;
                case 'C':
                    return 2;
                case 'D':
                    return 3;
                case 'E':
                    return 4;
                case 'F':
                    return 5;
                case 'G':
                    return 6;
                case 'H':
                    return 7;
                case 'I':
                    return 8;
                case 'J':
                    return 9;
                case 'K':
                    return 10;
                case 'L':
                    return 11;
                case 'M':
                    return 12;
                case 'N':
                    return 13;
                case 'O':
                    return 14;
                case 'P':
                    return 15;
                case 'Q':
                    return 16;
                case 'R':
                    return 17;
                case 'S':
                    return 18;
                case 'T':
                    return 19;
                case 'U':
                    return 20;
                case 'V':
                    return 21;
                case 'W':
                    return 22;
                case 'X':
                    return 23;
                case 'Y':
                    return 24;
                case 'Z':
                    return 25;
            }
            return -1;
        }
        private GridPosition GetCharPosition(char c)
        {
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    if(Grid[row, column] == c)
                        return new GridPosition(row, column);
                }
            }
            return new GridPosition(-1, -1);
        }
    }
}
