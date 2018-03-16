namespace Tests
{
    internal class Game
    {
        private string player;
        public Game()
        {
        }

        public bool PlayerIs(string player)
        {
            if (player.Equals("X")) return true;

            return false;
        }

        internal void Play()
        {
            player = "O";

        }


    }
}