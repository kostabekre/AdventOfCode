namespace Day_2
{
    public class Round
    {
        public Round(RoundCube[] cubes)
        {
            _cubes = cubes;
        }
        private RoundCube[] _cubes;

        public int GetAmount(Color color)
        {
            var a = _cubes.Where(cube => cube.Color == color);
            if (a.Count() > 0)
            {
                return a.Select(cube => cube.Amount).Sum();
            }
            return 0;
        }
    }
}