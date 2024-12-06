using Solutions.Day_2;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_2;

public class DayTwoRedNosedReportsTest
{
    private readonly ITestOutputHelper _output;

    public DayTwoRedNosedReportsTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void ExampleFirstPath()
    {
        var input = new DayTwoArgs([
            [7, 6, 4, 2, 1],
            [1, 2, 7, 8, 9],
            [9, 7, 6, 2, 1],
            [1, 3, 2, 4, 5],
            [8, 6, 4, 4, 1],
            [1, 3, 6, 7, 9]
        ]);

        var answer = new DayTwoRedNosedReports(input, _output).SolveFirstPart();
        
        Assert.Equal(2, answer);
    }
    
    [Fact]
    public void ExampleSecondPath()
    {
        var input = new DayTwoArgs([
            [7, 6, 4, 2, 1],
            [1, 2, 7, 8, 9],
            [9, 7, 6, 2, 1],
            [1, 3, 2, 4, 5],
            [8, 6, 4, 4, 1],
            [1, 3, 6, 7, 9]
        ]);

        var answer = new DayTwoRedNosedReports(input, _output).SolveSecondPart();
        
        Assert.Equal(4, answer);
    }

    [Fact]
    public void FirstPartTest()
    {
        var args = GetArgs();

        var answer = new DayTwoRedNosedReports(args, _output).SolveFirstPart();
        
        Assert.Equal(598, answer);
    }
    
    [Fact]
    public void SecondPartTest()
    {
        var args = GetArgs();

        var answer = new DayTwoRedNosedReports(args, _output).SolveSecondPart();
        
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