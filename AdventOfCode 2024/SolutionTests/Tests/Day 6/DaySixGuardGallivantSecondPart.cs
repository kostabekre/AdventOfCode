using Solutions.Day_6;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_6;

public class DaySixGuardGallivantSecondPart(ITestOutputHelper output) : BaseTest(output), ISecondPart
{
    [Fact]
    public void ExampleSecondPart()
    {
        DaySixArgs args = DaySixCommon.GetArgs("test_input.txt");

        var answer = new DaySixGuardGallivant(args, output).SolveSecondPart();
        
        Assert.Equal(6, answer);
    }

    [Fact]
    public void SecondPartTest()
    {
        DaySixArgs args = DaySixCommon.GetArgs("input.txt");

        var answer = new DaySixGuardGallivant(args, output).SolveSecondPart();
        
        Assert.Equal(1686, answer);
    }
}