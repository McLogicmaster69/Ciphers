using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.WordFreq
{
    public struct DataSet
    {
        public string[] Keys { get; private set; }
        public long[] Values { get; private set; }
        public int Count { get { return Keys.Length; } }
        public DataSet(string[] keys, long[] values)
        {
            Keys = keys;
            Values = values;
        }
    }
}
