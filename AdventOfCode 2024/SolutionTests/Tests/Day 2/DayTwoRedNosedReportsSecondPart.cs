using Solutions.Day_2;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_2;

public class DayTwoRedNosedReportsSecondPart(ITestOutputHelper output) : BaseTest(output), ISecondPart
{
    
    [Fact]
    public void ExampleSecondPart()
    {
        var answer = new DayTwoRedNosedReports(DayTwoCommon.ExampleInput, Output).SolveSecondPart();
        
        Assert.Equal(4, answer);
    }
    [Fact]
    public void SecondPartTest()
    {
        var args = DayTwoCommon.GetArgs();

        var answer = new DayTwoRedNosedReports(args, Output).SolveSecondPart();
        
        Assert.True(answer < 674);
        Assert.True(answer > 626);
        Assert.Equal(634, answer);
    }

}