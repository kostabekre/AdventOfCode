using System.Reflection;
using solutions.Day2;
using Solutions.Day3;
using Solutions.Logging;

var lines = GetInput(false);

var answer = new Day3Lobby(new NullLogger()).GetSumOfMost2PowerfulBatteriesInBanks(lines);

Console.WriteLine(answer);

static string[] GetInput(bool splitByComma = false)
{
    string? projectFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new NullReferenceException("Can't find project folder");

    // string path = Path.Combine(projectFolderPath, @"Inputs/input_day_3_test.txt");
    string path = Path.Combine(projectFolderPath, @"Inputs/input_day_3.txt");

    var lines = System.IO.File.ReadAllLines(path);

    if (splitByComma)
    {
        var result = new List<string>();

        foreach (var line in lines)
        {
            result.AddRange(line.Split(','));
        }

        return result.ToArray();
    }
    else
    {
        return lines;
    }
}
