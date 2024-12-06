using Xunit.Abstractions;

namespace Solutions.Day_1;

public class DayOneHistorianHysteria : ISolution
{
    private readonly int[] _listOne;
    private readonly int[] _listTwo;
    
    private readonly ITestOutputHelper _output;
    public DayOneHistorianHysteria(DayOneArgs args, ITestOutputHelper output)
    {
        _listOne = args.ListOne;
        _listTwo = args.ListTwo;
        _output = output;
    }
    
    public int SolveFirstPart()
    {
        var sortedListOne = _listOne.Order().ToArray();
        var sortedListTwo = _listTwo.Order().ToArray();

        var count = _listOne.Length;
        
        var differenceArr = new int[count];
        for (int i = 0; i < count; i++)
        {
            differenceArr[i] = Math.Abs(sortedListOne[i] - sortedListTwo[i]);
        }
        
        var sum = differenceArr.Sum();
        
        _output.WriteLine($"The difference is {string.Join(", ", differenceArr )} and sum is {sum}");
        
        return sum;
    }

    public int SolveSecondPart()
    {
        var dictionary = new Dictionary<int, int>(_listTwo.Length);
        foreach (var number in _listTwo)
        {
            if(!dictionary.TryAdd(number, 1))
            {
                dictionary[number] += 1;
            }
        }

        foreach (var pair in dictionary)
        {
            _output.WriteLine($"Number {pair.Key} encounters {pair.Value} times.");
        }

        var sum = 0;

        foreach (var number in _listOne)
        {
            dictionary.TryGetValue(number, out var multiply);

            sum += number * multiply;
        }

        return sum;
    }
}