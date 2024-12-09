using System.Security;
using System.Text.RegularExpressions;
using Solutions.Helpers;
using Xunit.Abstractions;

namespace Solutions.Day_4;

public class DayFourCeresSearch : ISolution
{
    private readonly string _input;
    private readonly string _searchWord;
    private readonly ITestOutputHelper _output;
    
    public DayFourCeresSearch(DayFourArgs args, ITestOutputHelper output)
    {
        this._output = output;
        _input = args.Input;
        _searchWord = args.SearchWord;
    }
    
    public int SolveFirstPart()
    {
        string[] lines = _input.Split(
            new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.TrimEntries
        );

        var searchWordReversed = StringHelper.Reverse(_searchWord);
        
        var sum = 0;
        
        for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            var line = lines[lineIndex];

            var searchWordFoundedTimes = Regex.Matches(line, _searchWord).Count;
            if(searchWordFoundedTimes > 0)
                _output.WriteLine($"Founded {_searchWord[0]} horizontally on line {lineIndex}, {searchWordFoundedTimes} times");
            sum += searchWordFoundedTimes;

            var reversedFoundedTimes = Regex.Matches(line, searchWordReversed).Count;
            if(reversedFoundedTimes > 0)
                _output.WriteLine($"Founded {searchWordReversed[0]} horizontally on line {lineIndex}, {reversedFoundedTimes} times");
            sum += reversedFoundedTimes;

            sum += FindWordVertically(line, lines, lineIndex, _searchWord);
            sum += FindWordVertically(line, lines, lineIndex, searchWordReversed);
            sum += FindWordDiagonally(line, lines, lineIndex, _searchWord, false);
            sum += FindWordDiagonally(line, lines, lineIndex, searchWordReversed, false);
            sum += FindWordDiagonally(line, lines, lineIndex, _searchWord, true);
            sum += FindWordDiagonally(line, lines, lineIndex, searchWordReversed, true);
        }

        return sum;
    }

    private int FindWordDiagonally(string line, string[] lines, int lineIndex, string searchWord, bool reversed)
    {
        int foundedInLine = 0;
        
        for (int letterIndex = 0; letterIndex < line.Length; letterIndex++)
        {
            bool founded = FindDiagonallyForGivenLetter(line, lines, lineIndex, searchWord, reversed, letterIndex);
            if (founded)
            {
                foundedInLine++;
            }
        }

        return foundedInLine;
    }
    
    private int FindWordDiagonallyXShape(string line, string[] lines, int lineIndex, string searchWord, string searchWordReversed)
    {
        int foundedInLine = 0;
        
        for (int letterIndex = 0; letterIndex < line.Length; letterIndex++)
        {
            bool foundedLeftLine = FindDiagonallyForGivenLetter(line, lines, lineIndex, searchWord, false, letterIndex);
            if (foundedLeftLine)
            {
                bool foundedRightLine = FindDiagonallyForGivenLetter(line, lines, lineIndex, searchWordReversed, true, letterIndex + 2);
                
                if (foundedRightLine)
                {
                    foundedInLine++;
                }
            }
        }

        return foundedInLine;
    }

    private bool FindDiagonallyForGivenLetter(string line, string[] lines, int lineIndex, string searchWord, bool reversed,
        int letterIndex)
    {
        if (line[letterIndex] == searchWord[0] && searchWord.Length <= lines.Length - lineIndex)
        {
            if (letterIndex + searchWord.Length > lines[0].Length && reversed == false)
            {
                return false;
            }

            var searchWordLength = letterIndex - (searchWord.Length - 1);
            if (searchWordLength < 0 && reversed)
            {
                return false;
            }
                
            for (int verticalIndex = 0; verticalIndex < searchWord.Length; verticalIndex++)
            {
                if (reversed == false && lines[lineIndex + verticalIndex][letterIndex + verticalIndex] != searchWord[verticalIndex])
                {
                    return false;
                }
                else if (reversed && lines[lineIndex + verticalIndex][letterIndex - verticalIndex] != searchWord[verticalIndex])
                {
                    return false;
                }
            }

            var directionStr = reversed ? "in left direction" : "in right direction";
            _output.WriteLine($"Founded {searchWord[0]} diagonally on line {lineIndex}, on index {letterIndex} {directionStr}");
            return true;
        }

        return false;
    }

    private int FindWordVertically(string line, string[] lines, int lineIndex, string searchWord)
    {
        int foundedInLine = 0;
        
        for (int letterIndex = 0; letterIndex < line.Length; letterIndex++)
        {
            if (line[letterIndex] == searchWord[0] && searchWord.Length <= lines.Length - lineIndex)
            {
                bool founded = true;
                for (int verticalIndex = 0; verticalIndex < searchWord.Length; verticalIndex++)
                {
                    if (lines[lineIndex + verticalIndex][letterIndex] != searchWord[verticalIndex])
                    {
                        founded = false;
                        break;
                    }
                }

                if (founded)
                {
                    _output.WriteLine($"Founded {searchWord[0]} vertically on line {lineIndex}, on index {letterIndex} ");
                    foundedInLine++;
                }
            }
        }

        return foundedInLine;
    }

    public int SolveSecondPart()
    {
        string[] lines = _input.Split(
            new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.TrimEntries
        );

        var searchWordReversed = StringHelper.Reverse(_searchWord);
        
        var sum = 0;
        
        for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            var line = lines[lineIndex];

            sum += FindWordDiagonallyXShape(line, lines, lineIndex, _searchWord, searchWordReversed);
            sum += FindWordDiagonallyXShape(line, lines, lineIndex, searchWordReversed, _searchWord);
            sum += FindWordDiagonallyXShape(line, lines, lineIndex, searchWordReversed, searchWordReversed);
            sum += FindWordDiagonallyXShape(line, lines, lineIndex, _searchWord, _searchWord);
        }

        return sum;
    }
}