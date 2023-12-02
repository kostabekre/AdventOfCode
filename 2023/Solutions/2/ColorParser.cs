namespace Day_2
{
    public static class ColorParser
    {
        public static Color GetColor(string input)
        {
            switch (input.ToLower())
            {
                case "red":
                    return Color.Red;
                case "blue":
                    return Color.Blue;
                case "green":
                    return Color.Green;
                default:
                    return Color.Unknown;
            }
        }
    }
}