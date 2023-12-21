using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Bifid
{
    public struct CharacterCollectionFrequency
    {
        public readonly string Characters;
        public int Frequency { get; private set; }

        public CharacterCollectionFrequency(string characters)
        {
            Characters = characters;
            Frequency = 1;
        }

        public CharacterCollectionFrequency(string characters, int defaultFrequency)
        {
            Characters = characters;
            Frequency = defaultFrequency;
        }

        public void IncrementFrequency() => Frequency++;
    }
}
