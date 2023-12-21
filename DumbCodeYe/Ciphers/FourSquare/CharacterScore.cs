using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.FourSquare
{
    public struct CharacterScore
    {
        public int Character;
        public decimal Score;

        public CharacterScore(int character, decimal score)
        {
            Character = character;
            Score = score;
        }
    }
}
