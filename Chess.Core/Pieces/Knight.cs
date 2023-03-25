namespace Chess.Core.Pieces
{
    public class Knight : Piece
    {

        public Knight() : base()
        {
            _symbol = 'n';
        }

        public Knight(char player, int row, int col) : base(player, row, col)
        {
            _symbol = 'n';
        }

        private readonly static int[][] MoveTemplates = new int[][]
        {
            new [] { 1, 2 }, // right 1 up 2
            new [] { 2, 1 }, // right 2 up 1
            new [] { -1, 2 }, // left 1 up 2
            new [] { -2, 1 }, // left 2 up 1
            new [] { -2, -1 }, // left 2 down 1
            new [] { -1, -2 }, // left 1 down 2
            new [] { 1, -2 }, // right 1 down 2
            new [] { 2, -1 }, // right 2 down 1
        };

        public override IList<Tile> GetValidMoves(Board board)
        {
            return Movement.GetMoves(board, this, 1, MoveTemplates);
        }
    }
}
