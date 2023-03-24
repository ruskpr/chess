using Chess.Core;

namespace Core.Pieces
{
    public class Rook : Piece
    {
        public Rook(char player) : base(player) { }

        private readonly static int[][] MoveTemplates = new int[][]
        {
            new [] { 1, 0 }, // right
            new [] { 0, -1 }, // left
            new [] { 0, 1 }, // up
            new [] { -1, 0 }, // down
        };

        public override IList<Tile> GetValidMoves(Board board)
        {
            return Movement.GetMoves(board, this, board.Size, MoveTemplates);
        }
    }
}
