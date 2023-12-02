public class TrebuchetCalibrator
{
    private ILogger _logger;
    private ITrebuchetNumberFinder _finder;

    public TrebuchetCalibrator(ITrebuchetNumberFinder finder, ILogger logger)
    {
        _logger = logger;
        _finder = finder;
    }
    public int GetNumbersSum(string path)
    {

        var numbers = new List<int>();

        using (var sr = new StreamReader(path))
        {
            // Start reading first line
            string line = sr.ReadLine();


            while(line != null)
            {
                int num1 = _finder.FindFirstNumber(line);
                int num2 = _finder.FindSecondNumber(line);
                if(num1 == '-' || num2 == '-')
                {
                    throw new ArgumentException("Could not find a number!");
                }
                string number = new string($"{num1}{num2}");
                _logger.Log(number);
                int theNumber = Int32.Parse(number);
                numbers.Add(theNumber);
                line = sr.ReadLine();
            }
        }
        int result = numbers.Sum();
        return result;
    }
}


