using Xunit.Abstractions;

namespace Solutions.Day_2;

public class DayTwoRedNosedReports : ISolution
{
    private readonly int[][] _reports;
    private readonly ITestOutputHelper _output;
    
    public DayTwoRedNosedReports(DayTwoArgs args, ITestOutputHelper output)
    {
        _output = output;
        _reports = args.Reports;
    }
    
    public int SolveFirstPart()
    {
        var amountOfSaveReports = 0;
        
        for (int reportIndex = 0; reportIndex < _reports.Length; reportIndex++)
        {
            var report = _reports[reportIndex];

            var direction = report[0] > report[1] ? ReportDirection.Decreasing : ReportDirection.Increasing;

            bool areAllLevelsSafe = IsReportSafe(report, direction);

            if (areAllLevelsSafe)
            {
                _output.WriteLine($"{string.Join(" ", report)} is safe.");
                amountOfSaveReports++;
            }
            else
            {
                _output.WriteLine($"{string.Join(" ", report)} is not safe.");
            }
        }

        return amountOfSaveReports;
    }
    
    public int SolveSecondPart()
    {
        var amountOfSaveReports = 0;
        
        for (int reportIndex = 0; reportIndex < _reports.Length; reportIndex++)
        {
            var report = _reports[reportIndex];

            var direction = report[0] > report[1] ? ReportDirection.Decreasing : ReportDirection.Increasing;

            _output.WriteLine($"Checking initial report {string.Join(" ", report)}. Direction is {direction}");
            
            var allLevelsSafe = IsReportSafeForgetOneError(report, direction);

            if (!allLevelsSafe)
            {
                var differentDirection = direction == ReportDirection.Decreasing
                    ? ReportDirection.Increasing
                    : ReportDirection.Decreasing;
                
                allLevelsSafe = IsReportSafeForgetOneError(report, differentDirection);
            }

            _output.WriteLine("===CONCLUSION");
            if (allLevelsSafe)
            {
                _output.WriteLine($"{string.Join(" ", report)} is safe.");
                amountOfSaveReports++;
            }
            else
            {
                _output.WriteLine($"{string.Join(" ", report)} is not safe.");
            }
            
            _output.WriteLine("---");
        }

        return amountOfSaveReports;
    }

    private bool IsReportSafeForgetOneError(int[] report, ReportDirection direction)
    {
        var previous = report[0];
        bool allLevelsSafe = true; 
        for (int levelIndex = 1; levelIndex < report.Length; levelIndex++)
        {
            var current = report[levelIndex];
                
            var diff = previous - current;
            var diffAbs = Math.Abs(diff);
                
            if (direction == ReportDirection.Increasing && diff > 0
                || direction == ReportDirection.Decreasing && diff < 0
                || diffAbs > 3)
            {
                if (direction == ReportDirection.Increasing && diffAbs <= 3)
                {
                    _output.WriteLine($"{previous} is more then {current}");
                }
                else if (direction == ReportDirection.Decreasing && diffAbs <= 3)
                {
                    _output.WriteLine($"{previous} is less then {current}");
                }
                else
                {
                    _output.WriteLine($"The difference ({diffAbs}) is more than 3 between {previous} and {current}");
                }

                var updatedReport = GetReportWithoutIndex(report, levelIndex - 1);
                var areLevelsSafeAfterRemove = IsReportSafe(updatedReport, direction);

                if (areLevelsSafeAfterRemove)
                {
                    break;
                }
                else
                {
                    updatedReport = GetReportWithoutIndex(report, levelIndex);
                    allLevelsSafe = IsReportSafe(updatedReport, direction);
                    break;
                }
            } 
                
            if (diffAbs == 0)
            {
                var updatedReport = GetReportWithoutIndex(report, levelIndex - 1);
                    
                allLevelsSafe = IsReportSafe(updatedReport, direction);;
                break;
            }
                
            previous = current;
        }

        return allLevelsSafe;
    }

    private int[] GetReportWithoutIndex(int[] report, int index)
    {
        var updatedReport = new List<int>(report.Length - 1);
        for (int i = 0; i < report.Length; i++)
        {
            if (i == index)
            {
                continue;
            }
                        
            updatedReport.Add(report[i]);
        }

        return updatedReport.ToArray();
    }
    private bool IsReportSafe(int[] updatedReport, ReportDirection direction)
    {
        _output.WriteLine($"Checking report {string.Join(" ", updatedReport)}");
        
        var previous = updatedReport[0];
        var allLevelsSafe = true;
        
        for (int levelIndex = 1; levelIndex < updatedReport.Length; levelIndex++)
        {
            var current = updatedReport[levelIndex];
                
            var diff = previous - current;
            
            if (direction == ReportDirection.Increasing && diff > 0)
            {
                _output.WriteLine($"{previous} is less then {current}");
                allLevelsSafe = false;
                break;
            } 
            else if (direction == ReportDirection.Decreasing && diff < 0)
            {
                _output.WriteLine($"{previous} is more then {current}");
                allLevelsSafe = false;
                break;
            }
                
            var diffAbs = Math.Abs(diff);
            if (diffAbs > 3 || diffAbs == 0)
            {
                _output.WriteLine($"The difference ({diffAbs}) is more than 3 between {previous} and {current}");
                
                allLevelsSafe = false;
                break;
            }
                
            previous = current;
        }

        var safeStr = allLevelsSafe ? "safe" : "not safe";
        _output.WriteLine($"Report {string.Join(" ", updatedReport)} is {safeStr}");
        return allLevelsSafe;
    }
}