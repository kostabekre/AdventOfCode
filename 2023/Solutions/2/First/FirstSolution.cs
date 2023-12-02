namespace Day_2.FirstSolution
{
    public class FirstSolution : ISolution
    {
        private readonly ILogger _logger;

        public FirstSolution(ILogger logger)
        {
            _logger = logger;
        }
        public string Solve()
        {

            List<Game> validGames = new List<Game>();
            using (var sr = new StreamReader(FilePath.PATH))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    var game = GameCreator.CreateFromString(line);

                    if (IsGamePossible.CheckDefault(game) == false)
                    {
                        line = sr.ReadLine();
                        continue;
                    }

                    validGames.Add(game);
                    line = sr.ReadLine();
                }
            }
            int sumOfIndex = validGames.Select(g => g.Index).Sum();
            return sumOfIndex.ToString();
        }
    }
}