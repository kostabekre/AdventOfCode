using Solutions.Day_1;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_1;

public class DayOneHistorianHysteriaExampleTest(ITestOutputHelper output) : BaseTest(output), IFirstPart
{
    [Fact]
    public void ExampleFirstPart()
    {
        var answer = new DayOneHistorianHysteria(DayOneCommon.ExampleArgs, Output).SolveFirstPart();

        Assert.Equal(11, answer);
    }
    
    [Fact]
    public void FirstPartTest()
    {
        var args = DayOneCommon.GetArgs();
        
        var answer = new DayOneHistorianHysteria(args, Output).SolveFirstPart();
        
        Assert.Equal(2196996, answer);
    }
}