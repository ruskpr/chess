using Chess.Core.Pieces;

namespace Chess.Core
{
    public class Game
    {
        public delegate void KingChecked(King k);
        public event KingChecked OnKingChecked;

        public delegate void GameOver();
        public event GameOver OnGameOver;

        public enum PromoteOptions
        {
            Queen = 0, Rook = 1, Bishop = 2, Knight = 3
        }

        public Board Board { get; set; }
        public Player White { get; set; }
        public Player Black { get; set; }
        
        public char Turn { get; set; } = 'w';

        private bool _isGameOver = false;

        public Game(Board board, Player white, Player black)
        {
            if (white.Symbol != 'w' || black.Symbol != 'b')
                throw new ArgumentException("Player must be contain valid color - 'w' or 'b' (white or black)");

            Board = board;
            White = white;
            Black = black;

        }

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
