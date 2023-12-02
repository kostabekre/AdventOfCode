namespace Day_1
{
    public class SecondSolution : ISolution
    {
        private readonly ILogger _logger;

        public SecondSolution(ILogger logger)
        {
            _logger = logger;
        }
        private class LetterFinder : ITrebuchetNumberFinder
        {
            private Dictionary<string, int> words = new Dictionary<string, int>()
            {
                {"one", 1},
                    {"two", 2},
                    {"three", 3},
                    {"four", 4},
                    {"five", 5},
                    {"six", 6},
                    {"seven", 7},
                    {"eight", 8},
                    {"nine", 9}
            };
            public int FindFirstNumber(string line)
            {
                int indexOfInt = -1;
                var positionAndNumber = new Dictionary<int, int>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsNumber(line[i]))
                    {
                        positionAndNumber[i] = (int)Char.GetNumericValue(line[i]);
                        break;
                    }
                }
                foreach (var word in words)
                {
                    int index = line.IndexOf(word.Key);
                    if (index != -1)
                    {
                        positionAndNumber[index] = word.Value;
                    }
                }
                int theNumber = positionAndNumber.MinBy(kv => kv.Key).Value;
                return theNumber;
            }

            public int FindSecondNumber(string line)
            {
                int indexOfInt = -1;
                var positionAndNumber = new Dictionary<int, int>();
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (Char.IsNumber(line[i]))
                    {
                        positionAndNumber[i] = (int)Char.GetNumericValue(line[i]);
                        break;
                    }
                }
                foreach (var word in words)
                {
                    int index = line.LastIndexOf(word.Key);
                    if (index != -1)
                    {
                        positionAndNumber[index] = word.Value;
                    }
                }
                int theNumber = positionAndNumber.MaxBy(kv => kv.Key).Value;
                return theNumber;
            }
        }

        public string Solve()
        {
            var finder = new LetterFinder();
            var solver = new TrebuchetCalibrator(finder, _logger);
            int solution = solver.GetNumbersSum(FilePath.PATH);
            return solution.ToString();
        }
    }


}