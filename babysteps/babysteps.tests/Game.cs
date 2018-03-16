using System;

namespace Tests
{
    internal class Game
    {
        private string _player = "X";
        private string _previousPlayer = "";
        private int _turn = 1;
        public Game()
        {
        }

        public bool PlayerIs(string player)
        {
            if (_player.Equals(player)) return true;

            return false;
        }

        private int lastRow;
        private int lastCol;
        internal void Play(int row, int col)
        {
            if (_turn > 1)
            {
                if (row == lastRow && col == lastCol)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            _previousPlayer = _player;
            var turn = _turn % 2;
            if (turn == 0)
            {
                
                _player = "X";
            }
            else
            {
                
                _player = "O";
            }

            _turn++;
            lastRow = row;
            lastCol = col;
        }


        public bool Won(string player)
        {
            return _previousPlayer.Equals(player);
        }
    }
}