using System.Reflection;
using solutions.Day2;

var lines = GetInput(true);

var answer = new Day2GiftShop().FindInvalidIds(lines);

Console.WriteLine(answer);

static string[] GetInput(bool splitByComma = false)
{
    string? projectFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new NullReferenceException("Can't find project folder");

    string path = Path.Combine(projectFolderPath, @"Inputs/input_day_2.txt");

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
