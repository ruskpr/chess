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

        public void CheckIfInCheck(Tile mostRecentTile)
        {
            foreach (Tile move in mostRecentTile.Piece.CurrentValidMoves)
            {
                if (move.Piece is King && move.Piece.Player !=
                    mostRecentTile.Piece.Player)
                {
                    King checkedKing = (King)move.Piece; // type cast to king
                    HandleKingChecked.Invoke(checkedKing);
                    break;
                }
            }
        }

        #endregion

        #region private

        #endregion

        

    }
}
