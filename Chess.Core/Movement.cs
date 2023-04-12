using Chess.Core.Pieces;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Chess.Core
{
    internal class Movement
    {
        private static bool IsValidAndInBounds(Board board, IPiece currPiece, int deltaRow, int deltaCol, out BoardLocation location)
        {
            location = null;
            var newRow = currPiece.CurrentLocation.Row + deltaRow;
            if ((newRow < 0) || (newRow >= board.Size)) return false;

            var newCol = currPiece.CurrentLocation.Column + deltaCol;
            if ((newCol < 0) || (newCol >= board.Size)) return false;           

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
            bool kingInCheck = board.KingInCheck == piece.Color;

            if (kingInCheck)
                return GenerateMovesToEscapeCheck(board, piece, range, templates);

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

                        if (CollidesIntoOpponentPiece(board, piece, newLocation.Row, newLocation.Column, out Tile? collidingLocation))
                        {
                            if (collidingLocation != null)
                                ret.Add(collidingLocation);

                            break;
                        }

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

        private static IList<Tile> GenerateMovesToEscapeCheck(Board board, IPiece piece, int pieceRange, IEnumerable<int[]> templates)
        {
            var kingPosition = board.KingInCheck == 'w' ? board._whiteKingLocation : board._blackKingLocation;

            var ret = new List<Tile>();

            // board to apply future moves to
            var tmpBoard = new Board(board.Tiles);
            tmpBoard._blackKingLocation = board._whiteKingLocation;
            tmpBoard._whiteKingLocation = board._blackKingLocation;
            var attackerColor = piece.Color == 'w' ? 'b' : 'w';
            var originalLocation = piece.CurrentLocation;

            var allMoves = GetMoves(tmpBoard, tmpBoard.GetPiece(piece.CurrentLocation), pieceRange, templates);

            IPiece? tempPiece = null;
            BoardLocation? pieceLocation;

            foreach (var tmpMove in allMoves)
            {
                var tmpLocation = new BoardLocation(tmpMove.Row, tmpMove.Column);

                // temporarily remove the piece from the board (if there is one in the location being checked)
                if (tmpBoard.GetTile(tmpLocation).Piece != null)
                {
                    tempPiece = tmpBoard.GetTile(tmpLocation).Piece;
                    pieceLocation = tempPiece.CurrentLocation;
                    tmpBoard.RemovePiece(tempPiece);
                }
                else
                {
                    tempPiece = null;
                    pieceLocation = null;
                }

                tmpBoard.TempMove(originalLocation, tmpLocation);

                if (!IsKingInCheck(tmpBoard, attackerColor))
                {
                    // move piece back to original position
                    tmpBoard.TempMove(tmpLocation, originalLocation);

                    // restore the piece that was removed
                    if (tempPiece != null)
                        tmpBoard.AddPiece(pieceLocation.Row, pieceLocation.Column, tempPiece);
                    ret.Add(new Tile(tmpLocation.Row, tmpLocation.Column));
                    return ret;
                }

                // move piece back to original position
                tmpBoard.TempMove(tmpLocation, originalLocation);

                // restore the piece that was removed
                if (tempPiece != null)
                    tmpBoard.AddPiece(pieceLocation.Row, pieceLocation.Column, tempPiece);
            }

            return ret;
        }

        internal static bool IsKingInCheck(Board board, char attackerColor)
        {
            var kingPos = attackerColor == 'w' ? board._blackKingLocation : board._whiteKingLocation;
            var king = board.GetTile(kingPos);

            foreach (var tile in board.Tiles)
            {
                if (tile.Piece == null) continue;
                if (tile.Piece is King) continue;

                if (tile.Piece.Color == attackerColor)
                {
                    var tmpCheckState = board.KingInCheck;
                    board.KingInCheck = null;
                    var attackerMoves = board.GetPiece(tile.Row, tile.Column).GetValidMoves(board);
                    board.KingInCheck = tmpCheckState;
                    if (attackerMoves.Any(a => a.Row == kingPos.Row && a.Column == kingPos.Column))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsSameColor(Board board, IPiece piece, BoardLocation newLoc)
        {
            Tile newTile = board.GetTile(newLoc.Row, newLoc.Column);

            if (newTile == null) return false;
            if (newTile.Piece == null) return false;

            if (piece.Color != newTile.Piece.Color)
                return false;
            else
                return true;
        }

        private static bool CollidesIntoOpponentPiece(Board board, IPiece piece, int newRow, int newCol, out Tile? collidingLocation)
        {
            // knight is the only piece that can jump over other peices
            // so it is impossible to collide with another piece
            collidingLocation = null;

            if (piece is Knight) return false;

            Tile? newLoc = board.GetTile(newRow, newCol);
            if (newLoc == null) return false;

            // if there is a piece and the colors match
            if (newLoc.Piece != null)
            {
                collidingLocation = newLoc;
                return true;
            }

            return false;
        }

        public static bool CanMoveKingOutOfCheck(Board board, char? colorThatIsChecked)
        {
            throw new NotImplementedException();
            return true;
        }

        internal static bool MoveIsValid(Board board, Tile from, Tile to)
        {
            var piece = board.GetPiece(from.Row, from.Column);
            if (piece == null) return false;
            var moves = piece.GetValidMoves(board);

            return moves.Any(m => m.Row == to.Row && m.Column == to.Column);
        }

    }
}
