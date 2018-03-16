namespace Tests
{
    internal class Game
    {
        private string _player = "X";
        public Game()
        {
        }

        public bool PlayerIs(string player)
        {
            if (_player.Equals(player)) return true;

            return false;
        }

        internal void Play()
        {
            _player = "O";

        }


    }
}