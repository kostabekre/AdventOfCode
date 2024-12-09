using Solutions.Day_4;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_4;

public class DayFourCeresSearchSecondPart(ITestOutputHelper output) : BaseTest(output), ISecondPart
{
    [Fact]
    public void ExampleSecondPart()
    {
        var answer = new DayFourCeresSearch(new DayFourArgs(DayFourCommon.Example, "MAS"), output).SolveSecondPart();
        
        Assert.Equal(9, answer);
    }

    [Fact]
    public void SecondPartTest()
    {
        var args = DayFourCommon.GetArgs("MAS");
        
        var answer = new DayFourCeresSearch(args, output).SolveSecondPart();
        
        Assert.Equal(1873, answer);
    }
}