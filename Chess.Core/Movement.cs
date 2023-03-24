using Core;

namespace Chess.Core
{
    internal class Movement
    {
        private static bool IsValid(Board board, BoardLocation current, int deltaRow, int deltaCol, out BoardLocation location)
        {
            location = null;
            var newRow = current.Row + deltaRow;
            if ((newRow <= 0) || (newRow > board.Size)) return false;

            var newCol = current.Column + deltaCol;
            if ((newCol <= 0) || (newCol > board.Size)) return false;

            location = new BoardLocation(newRow, newCol);
            return true;
        }

        internal static IList<Tile> GetMoves(Board board, IPiece piece, int range, IEnumerable<int[]> mults)
        {
            if (board == null) throw new ArgumentNullException("board");
            if (piece == null) throw new ArgumentNullException("piece");
            if (range < 1) throw new ArgumentOutOfRangeException("range");
            if (mults == null || !mults.Any()) throw new ArgumentException("mults");

            var ret = new List<Tile>();

            foreach (var mult in mults)
            {
                for (var radius = 1; radius <= range; radius++)
                {
                    var deltaX = radius * mult[0];
                    var deltaY = radius * mult[1];

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

    }
}
