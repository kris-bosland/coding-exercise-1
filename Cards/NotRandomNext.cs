using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace Cards
{
    public class NotRandomNext : IRandomNext
    {
        private Queue<int> _values;
        public NotRandomNext(IEnumerable<int> values)
        {
            _values = new Queue<int>(values);
        }

        public int Next(int minValue, int maxValue)
        {
            return _values.Any() ? _values.Dequeue() : 0;
        }
    }
}
