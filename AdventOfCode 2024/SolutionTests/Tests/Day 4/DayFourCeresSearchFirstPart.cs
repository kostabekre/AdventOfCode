using Solutions.Day_3;
using Solutions.Day_4;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_4;

public class DayFourCeresSearchFirstPart(ITestOutputHelper output) : BaseTest(output), IFirstPart
{
    [Fact]
    public void ExampleFirstPart()
    {
        var answer = new DayFourCeresSearch(new DayFourArgs(DayFourCommon.Example, "XMAS"), output).SolveFirstPart();
        
        Assert.Equal(18, answer);
    }

    [Fact]
    public void FirstPartTest()
    {
        var args = DayFourCommon.GetArgs("XMAS");
        
        var answer = new DayFourCeresSearch(args, output).SolveFirstPart();
        
        Assert.Equal(2524, answer);
    }
}