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
            board[0, 0] = "E";
            board[0, 1] = "E";
            board[0, 2] = "E";
            board[1, 0] = "E";
            board[1, 1] = "E";
            board[1, 2] = "E";
            board[2, 0] = "E";
            board[2, 1] = "E";
            board[2, 2] = "E";
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

            for (var row = 0; row < board.GetLength(0); row++)
            {
                var rowWin = ValidateRow(marker, row);

                if (rowWin) return true;
            }

            return false;
        }

        private bool ValidateRow(string marker, int row)
        {
            var rowWin = (board[row, 0].Equals(marker)
                          && board[row, 1].Equals(marker)
                          && board[row, 2].Equals(marker));
            return rowWin;
        }
    }
}