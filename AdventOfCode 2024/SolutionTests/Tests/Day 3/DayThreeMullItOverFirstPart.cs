using Solutions.Day_3;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_3;

public class DayThreeMullItOverFirstPart(ITestOutputHelper output) : BaseTest(output), IFirstPart
{
    private readonly DayThreeArgs _exampleArgs =
        new(["xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"]);
    

    [Fact]
    public void FirstPartTest()
    {
        var args = DayThreeCommon.GetArgs();

        var answer = new DayThreeMullItOver(args, Output).SolveFirstPart();
        
        Assert.Equal(184511516, answer);
    }
    
    [Fact]
    public void ExampleFirstPart()
    {
        var answer = new DayThreeMullItOver(_exampleArgs, Output).SolveFirstPart();
        
        Assert.Equal(161, answer);
    }

}