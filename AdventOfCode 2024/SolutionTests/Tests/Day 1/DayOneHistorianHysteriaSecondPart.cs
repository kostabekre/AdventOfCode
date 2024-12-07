using Solutions.Day_1;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_1;

public class DayOneHistorianHysteriaSecondPart(ITestOutputHelper output) : BaseTest(output), ISecondPart
{
    [Fact]
    public void ExampleSecondPart()
    {
        var answer = new DayOneHistorianHysteria(DayOneCommon.ExampleArgs, Output).SolveSecondPart();

        Assert.Equal(31, answer);
    }
    
    [Fact]
    public void SecondPartTest()
    {
        var args = DayOneCommon.GetArgs();
        
        var answer = new DayOneHistorianHysteria(args, Output).SolveSecondPart();
        
        Assert.Equal(23655822, answer); 
    }
    
}