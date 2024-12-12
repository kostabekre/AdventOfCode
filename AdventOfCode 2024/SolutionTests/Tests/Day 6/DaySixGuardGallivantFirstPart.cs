using Solutions.Day_6;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_6;

public class DaySixGuardGallivantFirstPart(ITestOutputHelper output) : BaseTest(output), IFirstPart
{
    [Fact]
    public void ExampleFirstPart()
    {
        DaySixArgs args = GetArgs("test_input.txt");

        var answer = new DaySixGuardGallivant(args).SolveFirstPart();
        
        Assert.Equal(41, answer);
    }

    [Fact]
    public void FirstPartTest()
    {
        DaySixArgs args = GetArgs("input.txt");

        var answer = new DaySixGuardGallivant(args).SolveFirstPart();
        
        Assert.Equal(5177, answer);
    }
    
    private DaySixArgs GetArgs(string fileName)
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