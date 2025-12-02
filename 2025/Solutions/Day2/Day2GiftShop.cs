using System.Numerics;
using Solutions.Common;

namespace solutions.Day2;

public class Day2GiftShop
{
    public BigInteger FindInvalidIds(IList<string> input)
    {
        var ranges = input.ConvertToRanges();

        BigInteger sillyNumbers = 0;

        foreach (var range in ranges)
        {
            var founded = CountPatternsSillyIdsInRange(range);

            BigInteger tmp = 0;

            foreach (var nmb in founded)
            {
                tmp += nmb;
            }

            sillyNumbers += tmp;
        }

        return sillyNumbers;
    }

    private BigInteger[] CountPatternsSillyIdsInRange(Range range)
    {
        var founded = new List<BigInteger>();

        Console.WriteLine($"Parsing range {range}");

        for (BigInteger i = range.Start; i <= range.End; i++)
        {
            var str = i.ToString();

            var firstElement = str[0];

            if (str.Length > 1 && str.All(s => s == firstElement))
            {
                founded.Add(i);

                Console.WriteLine($"Str is {str}, all are {firstElement}");
                Console.WriteLine();
                continue;
            }

            var foundedSubRange = false;
            for (int subRangeLength = 2; subRangeLength <= str.Length / 2; subRangeLength++)
            {
                if (str.Length % subRangeLength > 0)
                {
                    continue;
                }

                var subRange = str.Substring(0, subRangeLength);

                var strSubRanges = StringExtensions.Split(str, subRangeLength);

                if (strSubRanges.All(x => x == subRange))
                {
                    Console.WriteLine($"Str is {str}, Subrange is {subRange}, all subranges are {string.Join(',', strSubRanges)}");

                    foundedSubRange = true;
                    break;
                }
            }

            if (foundedSubRange)
            {
                founded.Add(i);
                Console.WriteLine();
            }
        }

        return founded.ToArray();
    }

    private BigInteger[] CountSillyIdsInRange(Range range)
    {
        var founded = new List<BigInteger>();

        for (BigInteger i = range.Start; i <= range.End; i++)
        {
            var str = i.ToString();

            if (str.Length % 2 == 1)
            {
                continue;
            }

            var subStrOne = str.Substring(0, str.Length / 2);
            var subStrTwo = str.Substring(str.Length / 2, str.Length / 2);

            if (subStrTwo[0] == '0')
            {
                continue;
            }

            Console.WriteLine($"Str 1 - {subStrOne}, str 2 - {subStrTwo}");

            if (subStrOne == subStrTwo)
            {
                founded.Add(i);
            }
        }

        return founded.ToArray();
    }
}
