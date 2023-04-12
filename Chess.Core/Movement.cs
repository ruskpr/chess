using Chess.Core.Pieces;
using System;
using System.Runtime.CompilerServices;

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

        internal static IList<Tile> GetKingMoves(Board board, King king, int[][] templates)
        {
            if (board == null) throw new ArgumentNullException("board");
            if (king == null) throw new ArgumentNullException("king");
            if (templates == null || !templates.Any()) return new List<Tile>();

            var range = 1; // king can only move one space at a time
            bool inCheck = board.KingInCheck == king.Color;

            if (inCheck)
            {
                var ret = new List<Tile>();
                char attackerColor = king.Color == 'w' ? 'b' : 'w';

                // board to apply future moves to
                var tmpBoard = new Board(board.Tiles);
                var tmpKing = tmpBoard.GetTile(king.CurrentLocation).Piece;

                var originalLocation = tmpKing.CurrentLocation;

                var allMoves = GetMoves(tmpBoard,
                    tmpBoard.GetPiece(tmpKing.CurrentLocation.Row, tmpKing.CurrentLocation.Column), 
                    range, 
                    templates);

                IPiece? tempPiece = null;
                BoardLocation? pieceLocation;

                // if the king can move to a location that is not in check, then we can move the king



                foreach (var tmpMove in allMoves)
                {
                    var tmpLocation = new BoardLocation(tmpMove.Row, tmpMove.Column);

                    // if the king is moving to a location that is occupied by a piece
                    // then we need to temporarily remove the piece from the board
                    // so that we can check if the king is in check
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

                    tmpBoard.MovePiece(tmpKing.CurrentLocation, tmpLocation, false);

                    if (!tmpBoard.IsKingInCheck(attackerColor))
                        ret.Add(new Tile(tmpLocation.Row, tmpLocation.Column));


                    // move king back to original position
                    tmpBoard.MovePiece(tmpLocation, originalLocation, false);

                    // restore the piece that was removed
                    if (tempPiece != null)
                        tmpBoard.AddPiece(pieceLocation.Row, pieceLocation.Column, tempPiece);
                }


                return ret;
            }
            else
                return GetMoves(board, king, range, templates);
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
