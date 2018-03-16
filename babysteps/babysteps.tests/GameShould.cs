using NUnit.Framework;
using System;

namespace Tests
{
    public class GameShould
    {
        private Game game;
        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void Ensure_X_Plays_First()
        {

            Assert.IsTrue(game.PlayerIs("X"));
        }

        [Test]
        public void Ensure_next_player_is_O()
        {
            game.Play(1, 1);

            Assert.IsTrue(game.PlayerIs("O"));
        }

        [Test]
        public void Ensure_a_player_plays_in_alternate_positions()
        {
            Assert.IsTrue(game.PlayerIs("X"));
            game.Play(1, 1);
            Assert.IsTrue(game.PlayerIs("O"));
            game.Play(1, 2);
            Assert.IsTrue(game.PlayerIs("X"));

        }

        [Test]
        public void Throws_an_exception_when__played_on_occupied_position()
        {

            game.Play(0, 1);

            Assert.Throws(typeof(ArgumentOutOfRangeException), () => game.Play(0, 1));

        }

        [Test]
        public void Ensure_a_player_wins_when_three_of_the_same_markers_are_in_a_row()
        {

            game.Play(0, 0);
            game.Play(1, 1);
            game.Play(0, 1);
            game.Play(1, 2);
            game.Play(0, 2);
            Assert.IsTrue(game.Won("X"));

        }

        [Test]
        public void Ensure_no_wins__without_three_of_the_same_markers_are_in_a_row()
        {

            game.Play(0, 0);
            game.Play(1, 1);
            game.Play(1, 2);
            game.Play(0, 2);
            Assert.IsFalse(game.Won("O"));

        }
    }
}