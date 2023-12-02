using Day_2.SecondSolution;

class Program
{
    public static void Main()
    {
        var logger = new FileLogger();
        ISolution solution = new SecondSolution(logger);
        string result = solution.Solve();
        logger.Dispose();
        Console.WriteLine(result);
    }
}
