using System;

namespace Cards
{
    public interface IRandomNext
    {
        int Next(int minValue, int maxValue);
    }
}
