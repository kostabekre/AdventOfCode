namespace Day_2
{
    public class Game
    {
        private readonly Round[] _rounds;

        public Game(int index, Round[] rounds)
        {
            _rounds = rounds;
            Index = index;
        }
        public int Index {get; private set;}
        public int GetAmount(Color color)
        {
            int sum = _rounds.Select(r => r.GetAmount(color)).Sum();
            return sum;
        }
        public int MaxAmountAcrossAllRounds(Color color)
        {
            int max = _rounds.Select(r => r.GetAmount(color)).Max();
            return max;
        }
    }
}