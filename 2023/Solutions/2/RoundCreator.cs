namespace Day_2
{
    public static class RoundCreator
    {
        public static Round CreateFromString(string input)
        {
            string[] cut = input.Split(',');
            RoundCube[] cubes = new RoundCube[cut.Length];
            for (int i = 0; i < cut.Length; i++)
            {
                cubes[i] = RoundCubeCreator.CreateFromString(cut[i]);
            } 
            return new Round(cubes);
        }
    }
}