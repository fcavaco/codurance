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
    }
}