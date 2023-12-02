using Day_2;
using Xunit;

namespace Tests
{
    public class DayTwoTests
    {
        [Fact]
        public void StringHasTwoBlueCubes()
        {
            string input = "2 blue";

            RoundCube cube = RoundCubeCreator.CreateFromString(input);

            Assert.Equal(2, cube.Amount);
        }
        [Fact]
        public void FirstRoundHasOneGreenAndTwoBlue()
        {
            string input = "1 green, 2 blue";

            Round round = RoundCreator.CreateFromString(input);

            Assert.Equal(1, round.GetAmount(Color.Green));
            Assert.Equal(2, round.GetAmount(Color.Blue));
        }
        [Fact]
        public void GameOneHasFourBlueCubes()
        {
            string input = "Game 1: 1 green, 2 blue; 13 red, 2 blue, 3 green; 4 green, 14 red";

            Game game = GameCreator.CreateFromString(input);

            Assert.Equal(4, game.GetAmount(Color.Blue));
        }

        [Fact]
        public void GameHasIndexOne()
        {
            string input = "Game 1: 1 green, 2 blue; 13 red, 2 blue, 3 green; 4 green, 14 red";

            Game game = GameCreator.CreateFromString(input);

            Assert.Equal(1, game.Index);
        }

    }
}