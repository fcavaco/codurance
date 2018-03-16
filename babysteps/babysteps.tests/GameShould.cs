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
            Assert.IsTrue(game.IsFirst("X"));
        }
    }
}