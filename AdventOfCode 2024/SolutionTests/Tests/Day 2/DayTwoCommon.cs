using Solutions.Day_2;
using SolutionTests.Helpers;

namespace SolutionTests.Tests.Day_2;

public static class DayTwoCommon
{
    public static DayTwoArgs ExampleInput = new([
            [7, 6, 4, 2, 1],
            [1, 2, 7, 8, 9],
            [9, 7, 6, 2, 1],
            [1, 3, 2, 4, 5],
            [8, 6, 4, 4, 1],
            [1, 3, 6, 7, 9]
        ]);
    
    public static DayTwoArgs GetArgs()
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