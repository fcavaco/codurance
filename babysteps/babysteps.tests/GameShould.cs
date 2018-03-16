using NUnit.Framework;

namespace Tests
{
    public class GameShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ensure_X_Plays_First()
        {
            Game game = new Game();
            Assert.IsTrue(game.PlayerIs("X"));
        }

        [Test]
        public void Ensure_next_player_is_O()
        {
            Game game = new Game();
            game.Play();

            Assert.IsTrue(game.PlayerIs("O"));
        }
    }
}