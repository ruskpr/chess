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

        public delegate void OnGameOver(Player? p);
        public event OnGameOver HandleGameOver;


        public Board Board { get; set; }
        public Player White { get; set; }
        public Player Black { get; set; }
        public char Turn { get; set; } = 'w';

        public Game(Board board, Player w, Player b)
        {
            Board = board;
            White = w;
            Black = b;
        }

        #region public
        public void StartGame()
        {
            Board.Init();


        }

        #region Check if in king is in check method
        public void CheckIfInCheck(Tile mostRecentTile)
        {
            foreach (Tile move in mostRecentTile.CurrPiece.CurrentValidMoves)
            {
                if (move.CurrPiece is King && move.CurrPiece.Player !=
                    mostRecentTile.CurrPiece.Player)
                {
                    King checkedKing = (King)move.CurrPiece; // type cast to king
                    HandleKingChecked.Invoke(checkedKing);
                    break;
                }
            }
        }
        #endregion
        #endregion

        #region private

        #endregion

        public static void SwapTurn() => Turn = Turn == PlayerTurn.p1 ? PlayerTurn.p2 : PlayerTurn.p1;
    }
}
