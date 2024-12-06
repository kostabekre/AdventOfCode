using Solutions.Day_1;
using SolutionTests.Helpers;
using Xunit.Abstractions;

namespace SolutionTests.Tests.Day_1;

public class DayOneHistorianHysteriaActualTest(ITestOutputHelper output) : BaseTest(output), IActualTest
{
    [Fact]
    public void FirstPartTest()
    {
        var args = GetArgs();
        
        var answer = new DayOneHistorianHysteria(args, Output).SolveFirstPart();
        
        Assert.Equal(2196996, answer);
    }

    [Fact]
    public void SecondPartTest()
    {
        var args = GetArgs();
        
        var answer = new DayOneHistorianHysteria(args, Output).SolveSecondPart();
        
        Assert.Equal(23655822, answer); 
    }
    
    private DayOneArgs GetArgs()
    {
        var text = TestFileHelper.ReadFileAsString("input.txt");

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