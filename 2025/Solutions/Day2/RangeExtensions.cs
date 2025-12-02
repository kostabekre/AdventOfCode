using System.Numerics;

namespace solutions.Day2;

internal static class RangeExtensions
{
    public static Range[] ConvertToRanges(this IList<string> ranges)
    {
        var result = new List<Range>(ranges.Count);

        foreach (var range in ranges)
        {
            var splitted = range.Split('-');

            if (splitted.Length != 2)
            {
                throw new ArgumentException("Range must contain -");
            }

            var converted = new Range()
            {
                Start = BigInteger.Parse(splitted[0]),
                End = BigInteger.Parse(splitted[1])
            };

            result.Add(converted);
        }

        return result.ToArray();
    }
}

