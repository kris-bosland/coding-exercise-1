using System;
using System.Collections.Generic;

namespace Cards
{
    public class RandomNext : IRandomNext
    {
        private readonly Random random = new Random();

        public int Next(int minValue, int maxValue) => random.Next(minValue, maxValue);
    }
}