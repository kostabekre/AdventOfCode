using Solutions.Day_2;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_2;

public class DayTwoRedNosedReportsActualTest(ITestOutputHelper output) : BaseTest(output), IActualTest
{
    [Fact]
    public void FirstPartTest()
    {
        var args = GetArgs();

        var answer = new DayTwoRedNosedReports(args, Output).SolveFirstPart();
        
        Assert.Equal(598, answer);
    }
    
    [Fact]
    public void SecondPartTest()
    {
        var args = GetArgs();

        var answer = new DayTwoRedNosedReports(args, Output).SolveSecondPart();
        
        Assert.True(answer < 674);
        Assert.True(answer > 626);
        Assert.Equal(634, answer);
    }

    private DayTwoArgs GetArgs()
    {
        var text = TestFileHelper.ReadFileAsString("input.txt");

        var allReports = new List<int[]>();
        
        using (var reader = new StringReader(text))
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                var splittedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var report = splittedLine.Select(numStr => Int32.Parse(numStr)).ToArray(); 
                
                allReports.Add(report);
                
                line = reader.ReadLine();
            }
        }

        return new DayTwoArgs(allReports.ToArray());
    }

}