using Solutions.Day_6;
using SolutionTests.Helpers;

namespace SolutionTests.Tests.Day_6;

public static class DaySixCommon
{
    public static DaySixArgs GetArgs(string fileName)
    {
        var text = TestFileHelper.ReadFileAsString(fileName);

        using var reader = new StringReader(text);

        var line = reader.ReadLine();

        var map = new List<char[]>();
        Coordinate guardPosition = default;
        var lineIndex = 0;
            
        while (line != null)
        {
            var mapLine = line.ToCharArray();
            var indexOfGuard = Array.IndexOf(mapLine, DaySixGuardGallivant.GuardCharacter);
            if (indexOfGuard > -1)
            {
                guardPosition = new Coordinate(indexOfGuard, lineIndex);
            }
            map.Add(mapLine);

            lineIndex++;
            line = reader.ReadLine();
        }

        return new DaySixArgs(map.ToArray(), guardPosition);
    }
}