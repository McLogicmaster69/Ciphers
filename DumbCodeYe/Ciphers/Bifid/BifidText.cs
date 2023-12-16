using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.Ciphers.Bifid
{
    public class BifidText
    {
        public readonly string Text;
        public readonly CharacterCollectionFrequency[] CharacterFrequencies;
        public readonly CharacterCollectionFrequency[] BigramFrequencies;

        public int Length { get { return Text.Length; } }

        public BifidText(string text)
        {
            Text = text;

            CharacterFrequencies = GetCharacterFrequencies(text);
            BigramFrequencies = GetBigramFrequencies(text);
        }

        public float GetCharacterProbability(char c) => CharacterFrequencies[c.ToString().ToUpper()[0] - 65].Frequency / (float)Length;

        public float GetBigramProbability(string bigram)
        {
            int index = BinarySearch(BigramFrequencies, bigram);
            if (index == -1)
                return 0;
            return BigramFrequencies[index].Frequency / (Length - 1f);
        }

        private CharacterCollectionFrequency[] GetCharacterFrequencies(string text)
        {
            CharacterCollectionFrequency[] freqs = new CharacterCollectionFrequency[26];
            for (int i = 0; i < 26; i++)
            {
                freqs[i] = new CharacterCollectionFrequency(GeneralConstants.CAPITALS[i].ToString(), 0);
            }
            foreach(char c in text)
            {
                freqs[c.ToString().ToUpper()[0] - 65].IncrementFrequency();
            }
            return freqs;
        }

        private CharacterCollectionFrequency[] GetBigramFrequencies(string text)
        {
            List<CharacterCollectionFrequency> list = new List<CharacterCollectionFrequency>();

            for (int i = 0; i < text.Length - 1; i++)
            {
                string bigram = text[i].ToString() + text[i + 1].ToString();
                int index = BinarySearch(list, bigram);

                if(index != -1)
                {
                    list[index].IncrementFrequency();
                    continue;
                }

                int sortIndex = BinarySort(list, bigram);
                list.Insert(sortIndex, new CharacterCollectionFrequency(bigram));
            }

            return list.ToArray();
        }

        private ComparisonResult CompareStrings(string string1, string string2)
        {
            string stringLower1 = string1.ToLower();
            string stringLower2 = string2.ToLower();

            if (stringLower1 == stringLower2)
                return ComparisonResult.Equal;

            for (int i = 0; i < stringLower1.Length && i < stringLower2.Length; i++)
            {
                char c1 = stringLower1[i];
                char c2 = stringLower2[i];

                if (c2 > c1)
                    return ComparisonResult.Greater;
                if (c2 < c1)
                    return ComparisonResult.Lesser;
            }

            if (stringLower2.Length < stringLower1.Length)
                return ComparisonResult.Lesser;
            return ComparisonResult.Greater;
        }

        private int BinarySearch(List<CharacterCollectionFrequency> list, string searchTerm)
        {
            int bottom = 0;
            int top = list.Count;

            while (bottom != top)
            {
                int middle = bottom + (top - bottom) / 2;

                switch (CompareStrings(list[middle].Characters, searchTerm))
                {
                    case ComparisonResult.Equal:
                        return middle;
                    case ComparisonResult.Greater:
                        bottom = middle + 1;
                        break;
                    case ComparisonResult.Lesser:
                        top = middle;
                        break;
                }
            }

            // Could not find object
            return -1;
        }

        private int BinarySearch(CharacterCollectionFrequency[] list, string searchTerm)
        {
            int bottom = 0;
            int top = list.Length;

            while (bottom != top)
            {
                int middle = bottom + (top - bottom) / 2;

                switch (CompareStrings(list[middle].Characters, searchTerm))
                {
                    case ComparisonResult.Equal:
                        return middle;
                    case ComparisonResult.Greater:
                        bottom = middle + 1;
                        break;
                    case ComparisonResult.Lesser:
                        top = middle;
                        break;
                }
            }

            // Could not find object
            return -1;
        }

        private int BinarySort(List<CharacterCollectionFrequency> list, string value)
        {
            if (list.Count == 0)
                return 0;

            int bottom = 0;
            int top = list.Count - 1;

            while (bottom != top)
            {
                int middle = bottom + (top - bottom) / 2;

                switch (CompareStrings(list[middle].Characters, value))
                {
                    case ComparisonResult.Equal:
                        return middle;
                    case ComparisonResult.Greater:
                        bottom = middle + 1;
                        break;
                    case ComparisonResult.Lesser:
                        top = middle;
                        break;
                }
            }

            switch (CompareStrings(list[top].Characters, value))
            {
                case ComparisonResult.Equal:
                    return top;
                case ComparisonResult.Greater:
                    return top + 1;
                case ComparisonResult.Lesser:
                    return top;
            }

            // Code here will never be reached
            // Just here to prevent errors from occuring
            return 0;
        }
    }
}
