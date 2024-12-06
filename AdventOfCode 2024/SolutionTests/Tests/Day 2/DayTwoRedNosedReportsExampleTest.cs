using Solutions.Day_2;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_2;

public class DayTwoRedNosedReportsExampleTest(ITestOutputHelper output) : BaseTest(output), IExampleTest
{
    private readonly DayTwoArgs _exampleInput = new([
            [7, 6, 4, 2, 1],
            [1, 2, 7, 8, 9],
            [9, 7, 6, 2, 1],
            [1, 3, 2, 4, 5],
            [8, 6, 4, 4, 1],
            [1, 3, 6, 7, 9]
        ]);

    [Fact]
    public void ExampleFirstPart()
    {
        var answer = new DayTwoRedNosedReports(_exampleInput, Output).SolveFirstPart();
        
        Assert.Equal(2, answer);
    }
    
    [Fact]
    public void ExampleSecondPart()
    {
        var answer = new DayTwoRedNosedReports(_exampleInput, Output).SolveSecondPart();
        
        Assert.Equal(4, answer);
    }
}