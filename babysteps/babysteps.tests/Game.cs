using System;
using System.Linq;
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

            return false;
        }

        private const int LEFT = 0;
        private const int CENTER = 1;
        private const int RIGHT = 2;
        private bool ValidateRow(string marker, int row)
        {
            var leftCell = board[row, LEFT];
            var centerCell = board[row, CENTER];
            var rightCell = board[row, RIGHT];

            var rowWin = (HasMarker(leftCell, marker)
                          && HasMarker(centerCell,marker)
                          && HasMarker(rightCell,marker));
            return rowWin;
        }

        private bool HasMarker(string cell, string marker)
        {
            if (cell != null && cell.Equals(marker))
                return true;

            return false;
        }
    }
}