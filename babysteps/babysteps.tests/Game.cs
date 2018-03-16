using System;

namespace Tests
{
    internal class Game
    {
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
            throw new NotImplementedException();
        }

        internal bool? IsNext(string v)
        {
            throw new NotImplementedException();
        }
    }
}