using Solutions.Day_3;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_3;

public class DayThreeMullItOverSecondPart(ITestOutputHelper output) : BaseTest(output), ISecondPart
{
    private readonly DayThreeArgs _exampleArgsTwo =
        new(["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"]);
    
    [Fact]
    public void ExampleSecondPart()
    {
        var answer = new DayThreeMullItOver(_exampleArgsTwo, Output).SolveSecondPart();
        
        Assert.Equal(48, answer);
    }

    [Fact]
    public void SecondPartTest()
    {
        var args = DayThreeCommon.GetArgs();
        
        var answer = new DayThreeMullItOver(args, Output).SolveSecondPart();
        
        Assert.True(answer < 95085090,$"The answer {answer} is bigger than 95085090");
        Assert.Equal(90044227, answer);
    }
}