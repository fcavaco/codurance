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

            for (var row = 0; row < board.GetLength(0); row++)
            {
                var rowWin = ValidateRow(marker, row);

                if (rowWin) return true;
            }

            for (var col = 0; col < board.GetLength(1); col++)
            {
                var win = ValidateColumn(marker, col);

                if (win) return true;
            }

            if (ValidateDiagonal(marker)) return true;
            return false;
        }

        private bool ValidateRow(string marker, int row)
        {
            const int LEFT = 0;
            const int CENTER = 1;
            const int RIGHT = 2;

            var leftCell = board[row, LEFT];
            var centerCell = board[row, CENTER];
            var rightCell = board[row, RIGHT];

            var rowWin = (HasMarker(leftCell, marker)
                          && HasMarker(centerCell, marker)
                          && HasMarker(rightCell, marker));
            return rowWin;
        }




        private bool ValidateColumn(string marker, int col)
        {
            const int TOP = 0;
            const int CENTER = 1;
            const int BOTTOM = 2;

            var top = board[TOP, col];
            var center = board[CENTER, col];
            var bottom = board[BOTTOM, col];

            var win = (HasMarker(top, marker)
                          && HasMarker(center, marker)
                          && HasMarker(bottom, marker));
            return win;
        }

        private bool ValidateDiagonal(string marker)
        {
            const int TOP = 0;
            const int BOTTOM = 2;
            const int LEFT = 0;
            const int CENTER = 1;
            const int RIGHT = 2;

            var topLeft = board[TOP, LEFT];
            var center = board[CENTER, CENTER];
            var bottomRight = board[BOTTOM, RIGHT];

            var win = (HasMarker(topLeft, marker)
                       && HasMarker(center, marker)
                       && HasMarker(bottomRight, marker));
            return win;
        }
        private bool HasMarker(string cell, string marker)
        {
            if (cell != null && cell.Equals(marker))
                return true;

            return false;
        }
    }
}