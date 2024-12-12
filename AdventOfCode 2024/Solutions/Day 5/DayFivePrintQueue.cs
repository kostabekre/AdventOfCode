using Xunit.Abstractions;

namespace Solutions.Day_5;

public class DayFivePrintQueue : ISolution
{
    private readonly Rule[] _rules;
    private readonly UpdateList[] _updateLists;
    private readonly ITestOutputHelper _output;
    
    public DayFivePrintQueue(DayFiveArgs args, ITestOutputHelper output)
    {
        _output = output;
        _rules = args.Rules;
        _updateLists = args.UpdateLists;
    }
    
    public int SolveFirstPart()
    {
        var rulesSet = new Dictionary<int, HashSet<int>>();

        foreach (var rule in _rules)
        {
            if (rulesSet.ContainsKey(rule.X))
            {
                rulesSet[rule.X].Add(rule.Y);
            }
            else
            {
                rulesSet.Add(rule.X, new HashSet<int>(){rule.Y});
            }
        }

        int sum = 0;
        foreach (var updateList in _updateLists)
        {
            var pages = updateList.Pages;

            bool isValid = true;
            
            for (int i = pages.Length - 1; i > 0; i--)
            {
                if (rulesSet.ContainsKey(pages[i]) && IsDisjoint(rulesSet[pages[i]], new HashSet<int>(){pages[i - 1]}) == false)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                sum += pages[pages.Length / 2];
            }
        }

        return sum;
    }

    private bool IsDisjoint(HashSet<int> one, HashSet<int> two)
    {
        return !one.Intersect(two).Any();
    }

    public int SolveSecondPart()
    {
        var rulesSet = new Dictionary<int, HashSet<int>>();

        foreach (var rule in _rules)
        {
            if (rulesSet.ContainsKey(rule.X))
            {
                rulesSet[rule.X].Add(rule.Y);
            }
            else
            {
                rulesSet.Add(rule.X, new HashSet<int>(){rule.Y});
            }
        }

        int sum = 0;
        foreach (var updateList in _updateLists)
        {
            var isInvalid = true;
            var pages = updateList.Pages;
            bool wasInvalid = false;

            while (isInvalid)
            {
                isInvalid = false;
                
                for (int i = pages.Length - 1; i > 0; i--)
                {
                    if (rulesSet.ContainsKey(pages[i]) && IsDisjoint(rulesSet[pages[i]], new HashSet<int>(){pages[i - 1]}) == false)
                    {
                        var temp = pages[i];
                        pages[i] = pages[i - 1];
                        pages[i - 1] = temp;
                        isInvalid = true;
                        wasInvalid = true;
                        break;
                    }
                }
            }

            if (wasInvalid)
            {
                sum += pages[pages.Length / 2];
            }
        }

        return sum;
    }
}