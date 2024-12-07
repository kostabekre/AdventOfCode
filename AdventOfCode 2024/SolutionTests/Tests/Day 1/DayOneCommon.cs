using Solutions.Day_1;
using SolutionTests.Helpers;

namespace SolutionTests.Tests.Day_1;

public static class DayOneCommon
{
    public static DayOneArgs ExampleArgs => new([3, 4, 2, 1, 3, 3], [4, 3, 5, 3, 9, 3]);
    
    public static DayOneArgs GetArgs()
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