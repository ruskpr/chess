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

        private bool IsInOpeningSpace(int row)
        {
            return Color == 'w' ? row == 6 : row == 1;
        }

        private int[][] GetTemplates(Board board)
        {
            var templates = new List<int[]>();
            var currentTile = board.GetTileByPiece(this);

            // add the forward move if it is empty
            var forwardTile = board.GetTile(currentTile.Row + GetDirection(), currentTile.Column);
            if (forwardTile != null && forwardTile.Piece == null)
                templates.Add(new[] { GetDirection(), 0 });

            // check if diagnal moves have a piece to capture
            var left = board.GetTile(currentTile.Row + GetDirection(), currentTile.Column - 1);
            var right = board.GetTile(currentTile.Row + GetDirection(), currentTile.Column + 1);

            if (right != null)
                if (right.Piece != null && right.Piece.Color != Color)
                    templates.Add(new[] { GetDirection(), 1 });

            if (left != null)
                if (left.Piece != null && left.Piece.Color != Color)
                    templates.Add(new[] { GetDirection(), -1 });


            // TODO: check if current pawn is in the en passant position
            if (currentTile.Column == 4)
            {
                var leftEnPassant = board.GetTile(currentTile.Row, currentTile.Column - 1);
                if (leftEnPassant != null)
                    if (leftEnPassant.Piece != null && leftEnPassant.Piece.Color != Color)
                        templates.Add(new[] { GetDirection(), -1 });
            }
                        
            return templates.ToArray();
        }

        public override IList<Tile> GetValidMoves(Board board)
        {
            var moves = Movement.GetMoves(board, this, 1, GetTemplates(board));

            // check if pawn can move two spaces

            // these methods will append the move to the list if they are valid
            GetTwoSpacesForward(board, moves);
            //GetCaptureForwardLeft(board, moves);
            //GetCaptureForwardRight(moves);
            
            return moves;
        }

        private void GetCaptureForwardRight(IList<Tile> moves)
        {
            throw new NotImplementedException();
        }

        private void GetCaptureForwardLeft(Board board, IList<Tile> moves)
        {
            throw new NotImplementedException();
        }

        private void GetTwoSpacesForward(Board board, IList<Tile> moves)
        {
            var currentTile = board.GetTileByPiece(this);

            if (IsInOpeningSpace(currentTile.Row))
            {
                // check if the second space is empty
                var twoSpaceTile = board.GetTile(currentTile.Row + (GetDirection() * 2), currentTile.Column);
                if (twoSpaceTile != null && twoSpaceTile.Piece == null)
                    moves.Add(twoSpaceTile);
            }
        }
    }
}
