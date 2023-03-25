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

        private int GetDirection()
        {
            // white goes up, black goes down
            return Color == 'w' ? -1 : 1;
        }

        private bool CompletedFirstMove()
        {
            //return Player == 'w' ? Position.Row == 1 : Position.Row == 6;
            return true;
        }

        private int[][] GetTemplates()
        {
            var templates = new List<int[]>();
            // add the forward move
            templates.Add(new[] { 0, GetDirection() });
            // add the double forward move
            if (!CompletedFirstMove())
            {
                templates.Add(new[] { GetDirection() * 2, 0 });
            }
            // add the diagonal moves
            templates.Add(new[] { GetDirection(), -1 });
            templates.Add(new[] { GetDirection(), 1 });
            return templates.ToArray();
        }

        private int GetRange()
        {
            if (CompletedFirstMove())
            {
                return 1;
            }

            return 2;
        }

        public override IList<Tile> GetValidMoves(Board board)
        {
            // check to see row of current piece on board

            return Movement.GetMoves(board, this, GetRange(), GetTemplates());
        }
    }
}
