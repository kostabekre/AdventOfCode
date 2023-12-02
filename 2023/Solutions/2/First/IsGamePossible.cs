namespace Day_2.FirstSolution
{
    public static class IsGamePossible
    {
        private const int DEFAULT_MAX_RED_CUBES = 12;
        private const int DEFAULT_MAX_GREEN_CUBES = 13;
        private const int DEFAULT_MAX_BLUE_CUBES = 14;
        public static bool Check(Game game, int maxRed, int maxGreen, int maxBlue)
        {

            int red = game.MaxAmountAcrossAllRounds(Color.Red);
            int green = game.MaxAmountAcrossAllRounds(Color.Green);
            int blue = game.MaxAmountAcrossAllRounds(Color.Blue);
            if (red > maxRed
            || green > maxGreen
            || blue > maxBlue)
            {
                return false;
            }
            return true;
        }
        public static bool CheckDefault(Game game)
        {
            return Check(game, DEFAULT_MAX_RED_CUBES, DEFAULT_MAX_GREEN_CUBES, DEFAULT_MAX_BLUE_CUBES);
        }
    }
}