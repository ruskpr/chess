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

        private int[][] GetTemplates(Board board)
        {
            var templates = new List<int[]>();

            // add the forward move
            templates.Add(new[] { GetDirection(), 0 });

            // add the double forward move
            if (!CompletedFirstMove())
            {
                templates.Add(new[] { GetDirection() * 2, 0 });
            }

            // check if diagnal moves have a piece to capture
            var currentPawn = board.GetTileByPiece(this);
            var left = board.GetTile(currentPawn.Row + GetDirection(), currentPawn.Column - 1);
            var right = board.GetTile(currentPawn.Row + GetDirection(), currentPawn.Column + 1);

            if (right != null)
                if (right.Piece != null && right.Piece.Color != Color)
                    templates.Add(new[] { GetDirection(), 1 });

            if (left != null)
                if (left.Piece != null && left.Piece.Color != Color)
                    templates.Add(new[] { GetDirection(), -1 });

            //



            // TODO: check if current pawn is in the en passant position
            if (currentPawn.Column == 4)
            {
                var leftEnPassant = board.GetTile(currentPawn.Row, currentPawn.Column - 1);
                if (leftEnPassant != null)
                    if (leftEnPassant.Piece != null && leftEnPassant.Piece.Color != Color)
                        templates.Add(new[] { GetDirection(), -1 });
            }
                        
            return templates.ToArray();
        }

        public override IList<Tile> GetValidMoves(Board board)
        {
            // check to see row of current piece on board

            return Movement.GetMoves(board, this, 1, GetTemplates(board));
        }
    }
}
