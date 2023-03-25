namespace Chess.Core.Pieces
{
    public class Rook : Piece
    {
        public Rook()
        {
            _symbol = 'r';
        }

        public Rook(char color, int row, int col) : base(color, row, col)
        {
            _symbol = 'r';
        }

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
