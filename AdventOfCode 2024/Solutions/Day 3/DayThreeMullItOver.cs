using System.Text;
using System.Text.RegularExpressions;
using Xunit.Abstractions;

namespace Solutions.Day_3;

public class DayThreeMullItOver : ISolution
{
    private readonly ITestOutputHelper _output;
    private readonly string[] _corruptedStrings;
    public DayThreeMullItOver(DayThreeArgs args, ITestOutputHelper output)
    {
        _output = output;
        _corruptedStrings = args.CorruptedStrings;
    }

    public int SolveFirstPart()
    {
        var sum = 0;

        var re = new Regex(@"mul\((\d+),(\d+)\)");
        foreach (var corruptedString in _corruptedStrings)
        {
            var matches = re.Matches(corruptedString);
            foreach (Match match in matches)
            {
                var firstNumber = Int32.Parse(match.Groups[1].Value);
                var secondNumber = Int32.Parse(match.Groups[2].Value);

                sum += firstNumber * secondNumber;
            }
        }

        return sum;
    }

    public int SolveSecondPart()
    {
        var sum = 0;

        var re = new Regex(@"mul\((\d+),(\d+)\)");
        var reDo = new Regex(@"do\(\)");
        var reDoNot = new Regex(@"don't\(\)");
        var concat = string.Concat(_corruptedStrings);
        var matches = re.Matches(concat);
        var doMatches = reDo.Matches(concat);
        var doNotMatches = reDoNot.Matches(concat);
        var ranges = GetRanges(doMatches, doNotMatches, concat.Length - 1);
        foreach (Match match in matches)
        {
            var isWorking = IsWorking(match.Index,ranges);
            if (isWorking == false)
            {
                continue;
            }
            var firstNumber = Int32.Parse(match.Groups[1].Value);
            var secondNumber = Int32.Parse(match.Groups[2].Value);

            var multiplyRes = firstNumber * secondNumber;
            sum += multiplyRes;
        }
            
        return sum;
    }

    private CommandRange[] GetRanges(MatchCollection doMatch, MatchCollection doNotMatch, int lastIndexOfString)
    {
        var doIndexies = doMatch.Select(m => m.Index).ToArray();
        var doNotIndexies = doNotMatch.Select(m => m.Index).ToArray();
        var ranges = new List<CommandRange>();

        var currentDoIndex = 0;
        var currentDoNotIndex = 0;

        var isWorking = true;
        var currentIndex = 0;
        
        while (true)
        {
            if (isWorking)
            {
                if (doNotIndexies.Length == 0)
                {
                    break;
                }
                else if (currentDoNotIndex == doNotIndexies.Length)
                {
                    ranges.Add(new CommandRange([currentIndex, lastIndexOfString], true));
                    break;
                }
                
                int nextNotWorking = doNotIndexies[currentDoNotIndex];
                if (nextNotWorking > currentIndex)
                {
                    isWorking = false;
                    ranges.Add(new CommandRange([currentIndex, nextNotWorking], true));
                    currentIndex = nextNotWorking;
                }

                currentDoNotIndex++;
                
            }
            else
            {
                if (doIndexies.Length == 0)
                {
                    break;
                }
                else if (currentDoIndex == doIndexies.Length)
                {
                    ranges.Add(new CommandRange([currentIndex, lastIndexOfString], false));
                    break;
                }
                
                var nextWorking = doIndexies[currentDoIndex];
                if (nextWorking > currentIndex)
                {
                    isWorking = true;
                    ranges.Add(new CommandRange([currentIndex, nextWorking], false));
                    currentIndex = nextWorking;
                }

                currentDoIndex++;
            }
        }

        return ranges.ToArray();
    }
    private bool IsWorking(int matchIndex, CommandRange[] ranges)
    {
        foreach (var commandRange in ranges)
        {
            // var isWorkingStr = commandRange.IsWorking ? "working" : "not working";
            // _output.WriteLine($"The range from {commandRange.Range[0]}, to {commandRange.Range[1]} is {isWorkingStr}");
            if (matchIndex >= commandRange.Range[0] && matchIndex <= commandRange.Range[1])
            {
                return commandRange.IsWorking;
            }
        }

        throw new IndexOutOfRangeException();
    }

    private record CommandRange(int[] Range, bool IsWorking);
}