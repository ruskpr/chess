using Chess.Core.Pieces;

namespace Chess.Core
{
    internal class Movement
    {
        private static bool IsValidAndInBounds(Board board, IPiece currPiece, int deltaRow, int deltaCol, out BoardLocation location)
        {
            location = null;
            var newRow = currPiece.CurrentLocation.Row + deltaRow;
            if ((newRow < 0) || (newRow > board.Size)) return false;

            var newCol = currPiece.CurrentLocation.Column + deltaCol;
            if ((newCol < 0) || (newCol > board.Size)) return false;


            if (Collision(board, currPiece, newRow, newCol))
                return false;

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

                    if (IsValidAndInBounds(board, piece, deltaX, deltaY, out BoardLocation newLocation))
                    {   
                        if (IsSameColor(board, piece, newLocation))
                            break;
                        
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

        private static bool IsSameColor(Board board, IPiece currPiece, BoardLocation newLoc)
        {
            Tile newTile = board.GetTile(newLoc.Row, newLoc.Column);

            if (newTile == null) return false;
            if (newTile.Piece == null) return false;

            if (currPiece.Color != newTile.Piece.Color)
                return false;
            else
                return true;
        }

        private static bool Collision(Board board, IPiece currPiece, int newRow, int newCol)
        {
            // knight is the only piece that can jump over other peices
            // so it is impossible to collide with another piece
            if (currPiece is Knight) return false;

            Tile? newLoc = board.GetTile(newRow, newCol);
            if (newLoc == null) return false;

            // if there is a piece and the colors match
            if (newLoc.Piece != null && newLoc.Piece.Color == currPiece.Color) return true;

            return false;
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
