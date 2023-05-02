using Chess.Core.Pieces;
using Chess.Core.UDP;
using Newtonsoft.Json;

namespace Chess.Core
{
    public class Game
    {
        public delegate void KingChecked(King k);
        public event KingChecked OnKingChecked;

        public delegate void GameOver();
        public event GameOver OnGameOver;    

        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        
        public char Turn { get; set; } = 'w';

        private bool _isGameOver = false;

        public Game(Board board, Player white, Player black)
        {
            if (white.Symbol != 'w' || black.Symbol != 'b')
                throw new ArgumentException("Player must be contain valid color - 'w' or 'b' (white or black)");

            Board = board;
            Player1 = white;
            Player2 = black;

        }

        [JsonConstructor]
        public Game() { }

        #region public

        public void StartGame()
        {
            
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
