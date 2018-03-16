using System;

namespace Tests
{
    internal class Game
    {
        private string _player = "X";
        private string _previousPlayer = "";
        private int _turn = 1;

        private string[,] board = new string[3, 3];

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
                ValidateOccupiedPosition(row, col);
            }

            board[row, col] = _player;

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

        private void ValidateOccupiedPosition(int row, int col)
        {
            if (row == lastRow && col == lastCol)
            {
                throw new ArgumentOutOfRangeException();
            }
        }


        public bool Won(string player)
        {

            return HasWon(_previousPlayer);
        }

        private bool HasWon(string marker)
        {

            var cum = 0;
            for (var row = 0; row < board.GetLength(0); row++)
            {
                for (var col = 0; col < board.GetLength(1); col++)
                {
                    if (marker.Equals(board[row, col]))
                    {
                        cum++;
                    }
                }
            }
            return cum == 3;
        }
    }
}