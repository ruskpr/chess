using System.Diagnostics.Contracts;

namespace Chess.Core.Pieces
{
    public class King : Piece
    {
        #region constructors

        public King() : base()
        {
            _symbol = 'k';
        }

        public King(char player, int row, int col) : base(player, row, col)
        {
            _symbol = 'k';
        }

        #endregion

        private static readonly int[][] MoveTemplates = new int[][]
        {
            new [] { 1, -1 },
            new [] { 1, 0 },
            new [] { 1, 1 },
            new [] { 0, -1 },
            new [] { 0, 1 },
            new [] { -1, -1 },
            new [] { -1, 0 },
            new [] { -1, 1 },
        };

        public override IList<Tile> GetValidMoves(Board board)
        {
            var moves = Movement.GetMoves(board, this, 1, MoveTemplates);
           
            return moves;
        }

    }
}
