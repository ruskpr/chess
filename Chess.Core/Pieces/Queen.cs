using Chess.Core;

namespace Core.Pieces
{
    public class Queen : Piece
    {
        public Queen(char player) : base(player) { }

        private readonly static int[][] MoveTemplates = new int[][]
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
            return Movement.GetMoves(board, this, board.Size, MoveTemplates);
        }
    }
}
