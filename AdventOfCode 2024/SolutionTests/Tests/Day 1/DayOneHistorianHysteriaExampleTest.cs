using Solutions.Day_1;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_1;

public class DayOneHistorianHysteriaExampleTest(ITestOutputHelper output) : BaseTest(output), IExampleTest
{
    private readonly DayOneArgs _exampleArgs = new([3, 4, 2, 1, 3, 3], [4, 3, 5, 3, 9, 3]);

    [Fact]
    public void ExampleFirstPart()
    {
        var answer = new DayOneHistorianHysteria(_exampleArgs, Output).SolveFirstPart();

        Assert.Equal(11, answer);
    }
    
    [Fact]
    public void ExampleSecondPart()
    {
        var answer = new DayOneHistorianHysteria(_exampleArgs, Output).SolveSecondPart();

        Assert.Equal(31, answer);
    }
}