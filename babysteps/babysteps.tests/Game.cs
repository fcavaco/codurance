﻿namespace Tests
{
    internal class Game
    {
        private string _player = "X";
        private int _turn = 1;
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
            var turn = _turn % 2;
            if (turn == 0)
            {
                _player = "X";
            }

            _player = "O";
            _turn++;


        }


    }
}