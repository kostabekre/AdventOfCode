using Solutions.Day_5;
using SolutionTests.Helpers;

namespace SolutionTests.Tests.Day_5;

public static class DayFiveCommon
{
    
    public static DayFiveArgs GetArgs(string fileName)
    {
        var text = TestFileHelper.ReadFileAsString(fileName);

        using var reader = new StringReader(text);
        

        var rules = ReadRules(reader);

        var updateLists = ReadUpdateLists(reader);

        return new DayFiveArgs(rules, updateLists);
    }

    private static UpdateList[] ReadUpdateLists(StringReader reader)
    {
        var line = reader.ReadLine();
        
        var updateLists = new List<UpdateList>();

        while (!string.IsNullOrEmpty(line))
        {
            var pages = line.Split(",").Select(numStr => Int32.Parse(numStr)).ToArray();
            var updateList = new UpdateList(pages);
            updateLists.Add(updateList);
            
            line = reader.ReadLine();
        }

        return updateLists.ToArray();
    }

    private static Rule[] ReadRules(StringReader reader)
    {
        var line = reader.ReadLine();
        
        var rules = new List<Rule>();
        
        while (!string.IsNullOrEmpty(line))
        {
            var splitted = line.Split("|").Select(numStr => Int32.Parse(numStr)).ToArray();
            var rule = new Rule(splitted[0], splitted[1]);
            rules.Add(rule);

            line = reader.ReadLine();
        }

        return rules.ToArray();
    }
}