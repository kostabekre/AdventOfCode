using Solutions.Day_5;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_5;

public class DayFivePrintQueueSecondPart(ITestOutputHelper output) : BaseTest(output), ISecondPart
{
    [Fact]
    public void ExampleSecondPart()
    {
        var args = DayFiveCommon.GetArgs("test_input.txt");

        var answer = new DayFivePrintQueue(args, output).SolveSecondPart();
        
        Assert.Equal(123, answer);
    }

    [Fact]
    public void SecondPartTest()
    {
        var args = DayFiveCommon.GetArgs("input.txt");

        var answer = new DayFivePrintQueue(args, output).SolveSecondPart();
        
        Assert.Equal(4077, answer);
    }
}