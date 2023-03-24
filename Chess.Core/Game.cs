using Core.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Game
    {
        public delegate void OnKingChecked(King k);
        public event OnKingChecked HandleKingChecked;

        public delegate void OnGameOver();
        public event OnGameOver HandleGameOver;

        public Board Board { get; set; }
        public Player White { get; set; }
        public Player Black { get; set; }
        public char Turn { get; set; } = 'w';

        private bool _isGameOver = false;

        public Game(Board board, Player white, Player black)
        {
            if (white.Color != 'w' || black.Color != 'b')
                throw new ArgumentException("Player must be contain valid color - 'w' or 'b' (white or black)");

            Board = board;
            White = white;
            Black = black;
        }

        #region public

        public void StartGame()
        {
            while (!_isGameOver)
            {

            }
        }

        public void SwapTurn()
        {
            Turn = Turn == 'w' ? 'b' : 'w';
        }

        #endregion

        #region private

        #endregion

        

    }
}
