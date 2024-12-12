using Solutions.Day_5;
using SolutionTests.Helpers;
using Xunit.Abstractions;
using UpdateList = Solutions.Day_5.UpdateList;

namespace SolutionTests.Tests.Day_5;

public class DayFivePrintQueueFirstPart(ITestOutputHelper output) : BaseTest(output), IFirstPart
{
    [Fact]
    public void ExampleFirstPart()
    {
        var args = DayFiveCommon.GetArgs("test_input.txt");

        var answer = new DayFivePrintQueue(args, output).SolveFirstPart();
        
        Assert.Equal(143, answer);
    }

    [Fact]
    public void FirstPartTest()
    {
        var args = DayFiveCommon.GetArgs("input.txt");

        var answer = new DayFivePrintQueue(args, output).SolveFirstPart();
        
        Assert.True(answer < 9650, $"{answer} is bigger than 9650 or equal to 9650.");
        Assert.Equal(5129, answer);
    }
}