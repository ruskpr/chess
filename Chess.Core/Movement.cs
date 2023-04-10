namespace Chess.Core
{
    internal class Movement
    {
        private static bool IsValid(Board board, BoardLocation current, int deltaRow, int deltaCol, out BoardLocation location)
        {
            location = null;
            var newRow = current.Row + deltaRow;
            if ((newRow < 0) || (newRow > board.Size)) return false;

            var newCol = current.Column + deltaCol;
            if ((newCol < 0) || (newCol > board.Size)) return false;

            location = new BoardLocation(newRow, newCol);
            return true;
        }

        internal static IList<Tile> GetMoves(Board board, IPiece piece, int range, IEnumerable<int[]> templates)
        {
            if (board == null) throw new ArgumentNullException("board");
            if (piece == null) throw new ArgumentNullException("piece");
            if (range < 1) throw new ArgumentOutOfRangeException("range");
            if (templates == null || !templates.Any()) return new List<Tile>();

            var ret = new List<Tile>();

            foreach (var template in templates)
            {
                for (var radius = 1; radius <= range; radius++)
                {
                    var deltaX = radius * template[0];
                    var deltaY = radius * template[1];

                    if (IsValid(board, piece.CurrentLocation, deltaX, deltaY, out BoardLocation newLocation))
                    {
                        ret.Add(new Tile(newLocation.Row, newLocation.Column));
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return ret;
        }

        internal static bool MoveIsValid(Board board, Tile from, Tile to)
        {
            if (board == null) throw new ArgumentNullException("board");
            if (from == null) throw new ArgumentNullException("from");
            if (to == null) throw new ArgumentNullException("to");

            var piece = board.GetPiece(from.Row, from.Column);
            if (piece == null) return false;
            var moves = piece.GetValidMoves(board);

            return moves.Any(m => m.Row == to.Row && m.Column == to.Column);

        }

    }
}
