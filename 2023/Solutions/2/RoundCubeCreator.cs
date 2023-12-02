namespace Day_2
{
    public static class RoundCubeCreator
    {
        public static RoundCube CreateFromString(string input)
        {
            string filteredInput = input.Trim().ToLower();
            string[] cutInput = filteredInput.Split(' ');
            int number = Int32.Parse(cutInput[0]);
            Color color = ColorParser.GetColor(cutInput[1]);
            return new RoundCube(color, number);
        }
    }
}