using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Substitution
{
    public class SmartReplacementGrid : ReplacementGrid
    {
        public bool[] LockedChars { get; protected set; }
        public List<char> RemainingChars { get; protected set; } = new List<char>(GeneralConstants.CAPITALS.ToLower().ToCharArray());

        private Random rand;
        private bool _smartSwapStated = false;

        public List<int> _availableIndexes { get; private set; } = new List<int>();
        public int _indexA { get; private set; } = 0;
        public int _indexB { get; private set; } = 0;

        public SmartReplacementGrid() : base()
        {
            Instantiate();
        }
        public SmartReplacementGrid(char[] grid) : base(grid)
        {
            Instantiate();
        }
        public SmartReplacementGrid(ReplacementGrid grid) : base(grid)
        {
            Instantiate();
        }
        public SmartReplacementGrid(SmartReplacementGrid grid) : base(grid.GetBase())
        {
            rand = new Random();
            LockedChars = grid.LockedChars;
            RemainingChars = new List<char>(grid.RemainingChars.ToArray());
        }
        private void Instantiate()
        {
            rand = new Random();
            LockedChars = new bool[26];
            for (int i = 0; i < 26; i++)
            {
                LockedChars[i] = false;
            }
        }
        public void SmartSwap()
        {
            List<int> availableIndexs = new List<int>();
            for (int i = 0; i < 26; i++)
            {
                if (!LockedChars[i])
                    availableIndexs.Add(i);
            }
            SwapCharacters(availableIndexs[rand.Next(0, availableIndexs.Count)], availableIndexs[rand.Next(0, availableIndexs.Count)]);
        }
        public bool NextSmartSwap()
        {
            InitIndexes();
            if (!IncrementNext())
                return false;

            SwapCharacters(_availableIndexes[_indexA], _availableIndexes[_indexB]);
            return true;
        }
        public bool IncrementNext()
        {
            _indexB++;
            if (_indexB >= _availableIndexes.Count)
            {
                _indexA++;
                _indexB = _indexA + 1;
                if (_indexB >= _availableIndexes.Count)
                    return false;
            }
            return true;
        }
        public void InitIndexes()
        {
            if (!_smartSwapStated)
            {
                _smartSwapStated = true;
                _availableIndexes = new List<int>();
                for (int i = 0; i < 26; i++)
                {
                    if (!LockedChars[i])
                        _availableIndexes.Add(i);
                }
            }
        }
        public void InitWithIndexes(int a, int b, List<int> availableIndexes)
        {
            _indexA = a;
            _indexB = b;
            _availableIndexes = availableIndexes;
            _smartSwapStated = true;
        }
        public void FillRest()
        {
            for (int i = 0; i < 26; i++)
            {
                if (!LockedChars[i])
                {
                    int randIndex = rand.Next(0, RemainingChars.Count);
                    Replacements[i] = RemainingChars[randIndex];
                    RemainingChars.RemoveAt(randIndex);
                }
            }
        }
        public void AddLockedCharacter(int pos, char c)
        {
            if (LockedChars[pos] || Contains(c))
                return;
            LockedChars[pos] = true;
            ChangeCharacter(pos, c);
        }
        public void AddLockedCharacter(char lockedChar, char c)
        {
            int pos = GetIndexOfCapital(lockedChar);
            Console.WriteLine(pos);
            if (pos != -1)
                AddLockedCharacter(pos, c);
        }
        public void AddLockedWord(string lockedWord, string word)
        {
            for (int i = 0; i < lockedWord.Length; i++)
            {
                AddLockedCharacter(lockedWord[i], word[i]);
            }
        }
        public ReplacementGrid GetBase()
        {
            return new ReplacementGrid(Replacements);
        }

        public override void ChangeCharacter(int index, char c)
        {
            if (!Contains(c))
            {
                Replacements[index] = c;
                RemainingChars.Remove(c);
            }
        }
    }
}
