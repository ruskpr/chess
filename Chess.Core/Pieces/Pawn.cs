namespace Chess.Core.Pieces
{
    public class Pawn : Piece
    {
        public Pawn() : base()
        {
            _symbol = 'p';
        }

        public Pawn(char player, int row, int col) : base(player, row, col)
        {
            _symbol = 'p';
        }

        private static int[][] PawnTemplates(Pawn pawn)
        {
            var direction = Movement.GetDirection(pawn);
            return new int[][] { new[] { direction, 0 }};
        }


        public override IList<Tile> GetValidMoves(Board board)
        {
            var moves = Movement.GetMoves(board, this, 1, PawnTemplates(this));

            return moves;
        }
      

        
    }
}
