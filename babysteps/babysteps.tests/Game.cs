using System;

namespace Tests
{
    internal class Game
    {
        private string player;
        public Game()
        {
        }

        public bool IsFirst(string player)
        {
            if (player.Equals("X")) return true;

            return false;
        }

        internal void Play()
        {
            player = "O";
        }

        internal bool? IsNext(string v)
        {
            if (player.Equals("O")) return true;

            return false;
        }
    }
}