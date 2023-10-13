using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.Quadgrams
{
    public struct DataSet
    {
        public string[] Keys { get; private set; }
        public int[] Values { get; private set; }
        public int Count { get { return Keys.Length; } }
        public DataSet(string[] keys, int[] values)
        {
            Keys = keys;
            Values = values;
        }
    }
}
