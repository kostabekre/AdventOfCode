namespace Day_2.SecondSolution
{
    public class SecondSolution : ISolution
    {
        private readonly ILogger _logger;

        public SecondSolution(ILogger logger)
        {
            _logger = logger;
        }
        public string Solve()
        {
            List<int> powers = new List<int>();
            using (var sr = new StreamReader(FilePath.PATH))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    var game = GameCreator.CreateFromString(line);


                    int red = game.MaxAmountAcrossAllRounds(Color.Red);
                    int green = game.MaxAmountAcrossAllRounds(Color.Green);
                    int blue = game.MaxAmountAcrossAllRounds(Color.Blue);

                    powers.Add(red * green * blue);
                    line = sr.ReadLine();
                }
            }
            int sumOfIndex = powers.Sum();
            return sumOfIndex.ToString();
        }
    }
}