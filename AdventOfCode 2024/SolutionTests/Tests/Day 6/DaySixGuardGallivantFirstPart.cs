using Solutions.Day_6;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_6;

public class DaySixGuardGallivantFirstPart(ITestOutputHelper output) : BaseTest(output), IFirstPart
{
    [Fact]
    public void ExampleFirstPart()
    {
        DaySixArgs args = DaySixCommon.GetArgs("test_input.txt");

        var answer = new DaySixGuardGallivant(args, output).SolveFirstPart();
        
        Assert.Equal(41, answer);
    }

    [Fact]
    public void FirstPartTest()
    {
        DaySixArgs args = DaySixCommon.GetArgs("input.txt");

        var answer = new DaySixGuardGallivant(args, output).SolveFirstPart();
        
        Assert.Equal(5177, answer);
    }
}