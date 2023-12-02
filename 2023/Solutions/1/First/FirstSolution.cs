namespace Day_1
{
    public class FirstSolution : ISolution
    {
        private ILogger _logger;

        private class NumberFinder : ITrebuchetNumberFinder
        {
            public int FindFirstNumber(string line)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsNumber(line[i]))
                    {
                        return line[i];
                    }
                }
                return '-';
            }

            public int FindSecondNumber(string line)
            {
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (Char.IsNumber(line[i]))
                    {
                        return line[i];
                    }
                }
                return '-';

            }
        }
        public FirstSolution(ILogger logger)
        {
            _logger = logger;
        }
        public string Solve()
        {
            var finder = new NumberFinder();
            var solver = new TrebuchetCalibrator(finder, _logger);
            int solution = solver.GetNumbersSum(FilePath.PATH);
            return solution.ToString();
        }
    }

}