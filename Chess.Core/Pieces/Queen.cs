
namespace Chess.Core.Pieces
{
    public class Queen : Piece
    {

        public Queen() : base()
        {
            _symbol = 'q';
        }

        public Queen(char player, int row, int col) : base(player, row, col)
        {
            _symbol = 'q';
        }

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
