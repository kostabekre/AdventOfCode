using Solutions.Day_1;
using SolutionTests.Helpers;
using Xunit.Abstractions;
using StringReader = System.IO.StringReader;

namespace SolutionTests.Tests.Day_1;

public class DayOneHistorianHysteriaTest
{
    private readonly ITestOutputHelper _output;

    public DayOneHistorianHysteriaTest(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public void ExampleFirstPart()
    {
        var args = new DayOneArgs([3, 4, 2, 1, 3, 3], [4, 3, 5, 3, 9, 3]);

        var answer = new DayOneHistorianHysteria(args, _output).SolveFirstPart();

        Assert.Equal(11, answer);
    }
    
    [Fact]
    public void ExampleSecondPart()
    {
        var args = new DayOneArgs([3, 4, 2, 1, 3, 3], [4, 3, 5, 3, 9, 3]);

        var answer = new DayOneHistorianHysteria(args, _output).SolveSecondPart();

        Assert.Equal(31, answer);
    }

    [Fact]
    public void FirstPartTest()
    {
        var args = GetArgs();
        
        var answer = new DayOneHistorianHysteria(args, _output).SolveFirstPart();
        
        Assert.Equal(2196996, answer);
    }

    [Fact]
    public void SecondPartTest()
    {
        var args = GetArgs();
        
        var answer = new DayOneHistorianHysteria(args, _output).SolveSecondPart();
        
        Assert.Equal(23655822, answer); 
    }

    private DayOneArgs GetArgs()
    {
        var text = FileHelper.ReadFileAsString("input.txt");

        var firstList = new List<int>();
        var secondList = new List<int>();
        
        using (var reader = new StringReader(text))
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                var splittedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var firstNumberStr = splittedLine[0];
                var secondNumberStr = splittedLine[1];

                firstList.Add(Int32.Parse(firstNumberStr));
                secondList.Add(Int32.Parse(secondNumberStr));
                
                line = reader.ReadLine();
            }
        }

        return new DayOneArgs(firstList.ToArray(), secondList.ToArray());
    }
}