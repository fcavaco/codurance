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

        [Test]
        public void Ensure_a_player_plays_in_alternate_positions()
        {
            Game game = new Game();
            Assert.IsTrue(game.PlayerIs("X"));
            game.Play();
            Assert.IsTrue(game.PlayerIs("O"));
            game.Play();
            Assert.IsTrue(game.PlayerIs("X"));
            
        }
    }
}