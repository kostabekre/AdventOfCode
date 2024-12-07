using Solutions.Day_3;
using SolutionTests.Helpers;

namespace SolutionTests.Tests.Day_3;

public static class DayThreeCommon
{
    public static DayThreeArgs GetArgs()
    {
        var text = TestFileHelper.ReadFileAsString("input.txt");

        var allCorruptedStrings = new List<string>();
        
        using (var reader = new StringReader(text))
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                allCorruptedStrings.Add(line);
                
                line = reader.ReadLine();
            }
        }

        return new DayThreeArgs(allCorruptedStrings.ToArray());
    }
}