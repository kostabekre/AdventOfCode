using Solutions.Day_4;
using SolutionTests.Helpers;

namespace SolutionTests.Tests.Day_4;

public static class DayFourCommon
{
    public static string Example = @"MMMSXXMASM
                                       MSAMXMSMSA
                                       AMXSXMAAMM
                                       MSAMASMSMX
                                       XMASAMXAMM
                                       XXAMMXXAMA
                                       SMSMSASXSS
                                       SAXAMASAAA
                                       MAMMMXMMMM
                                       MXMXAXMASX";
    
    public static DayFourArgs GetArgs(string searchWord)
    {
        var text = TestFileHelper.ReadFileAsString("input.txt");

        return new DayFourArgs(text, searchWord);
    }
}