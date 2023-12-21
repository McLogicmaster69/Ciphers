using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.Bigrams
{
    public struct DataSet
    {
        public string[] Keys { get; private set; }
        public long[] Values { get; private set; }
        public int Count { get { return Keys.Length; } }

        private long _valuesTotal;
        public DataSet(string[] keys, long[] values)
        {
            Keys = keys;
            Values = values;
            _valuesTotal = -1;
        }

        public long GetValueTotal()
        {
            if(_valuesTotal == -1)
            {
                foreach(long l in Values)
                {
                    _valuesTotal += l;
                }
            }
            return _valuesTotal;
        }
    }
}
