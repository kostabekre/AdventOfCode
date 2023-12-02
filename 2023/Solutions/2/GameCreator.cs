namespace Day_2
{
    public static class GameCreator
    {
        public static Game CreateFromString(string input)
        {
            string[] idAndData = input.Split(':');
            int index = Int32.Parse(idAndData[0].Split(' ')[1]);
            string[] cut = idAndData[1].Split(';');
            Round[] rounds = new Round[cut.Length];
            for (int i = 0; i < cut.Length; i++)
            {
                rounds[i] = RoundCreator.CreateFromString(cut[i]);
            }
            return new Game(index, rounds);
        }
    }
}