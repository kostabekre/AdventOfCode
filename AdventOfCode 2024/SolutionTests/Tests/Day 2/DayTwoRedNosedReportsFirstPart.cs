using Solutions.Day_2;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_2;

public class DayTwoRedNosedReportsFirstPart(ITestOutputHelper output) : BaseTest(output), IFirstPart
{
    [Fact]
    public void ExampleFirstPart()
    {
        var answer = new DayTwoRedNosedReports(DayTwoCommon.ExampleInput, Output).SolveFirstPart();
        
        Assert.Equal(2, answer);
    }
    
    [Fact]
    public void FirstPartTest()
    {
        var args = DayTwoCommon.GetArgs();

        var answer = new DayTwoRedNosedReports(args, Output).SolveFirstPart();
        
        Assert.Equal(598, answer);
    }
}