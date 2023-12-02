using Day_2;
using Day_2.FirstSolution;
using Xunit;

namespace Tests
{
    public class FirstSolutionTests
    {

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
        public void AreGamesPossibleUsingDefault(string input)
        {
            var game = GameCreator.CreateFromString(input);

            bool result = IsGamePossible.CheckDefault(game);

            Assert.True(result);
        }


        [Theory]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
        public void AreGamesImpossibleUsingDefault(string input)
        {
            var game = GameCreator.CreateFromString(input);

            bool result = IsGamePossible.CheckDefault(game);

            Assert.False(result);
        }
    }
}