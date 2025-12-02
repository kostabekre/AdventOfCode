using System.Numerics;

namespace solutions.Day2;

internal class Range
{
    public BigInteger Start { get; init; }
    public BigInteger End { get; init; }

    public override string ToString()
    {
        return $"{Start}-{End}";
    }
}


