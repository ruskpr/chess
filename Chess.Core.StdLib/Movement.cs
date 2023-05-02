using Chess.Core.Pieces;
using System;
using System.Data;
using System.Drawing;
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

            bool kingInCheck = board.KingInCheck == piece.Color;

            // if king is in check, generate moves to where the king can escape
            if (kingInCheck)
                return GenerateMovesToEscapeCheck(board, piece, range, templates);
                
            // return default moves if no above condition are met
            return piece is Pawn ? 
                GeneratePawnMoves(board, (Pawn)piece, templates) :
                GenerateDefaultTemplateMoves(board, piece, range, templates);
        }

        private static IList<Tile> GenerateDefaultTemplateMoves(Board board, IPiece piece, int range, IEnumerable<int[]> templates)
        {
            List<Tile> ret = new List<Tile>();

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

                        // if the piece collides, add the tile and break out of the template direction
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

        internal static bool MovePutsKingInCheck(Board board, Tile from, Tile to)
        {
            var tmpBoard = board.Copy();
            
            var attackerColor = tmpBoard.GetTile(from.Row, from.Column).Piece.Color == 'w' ? 'b' : 'w';
            tmpBoard.MovePiece(from, to);

            if (IsKingInCheck(tmpBoard, attackerColor))
            {
                tmpBoard.UndoMove();
                return true;
            }

            tmpBoard.UndoMove();
            return false;
        }


        /// <summary>
        /// 
        /// Used to generate moves for a piece when the king is in check.
        /// 
        /// </summary>
        private static IList<Tile> GenerateMovesToEscapeCheck(Board board, IPiece piece, int pieceRange, IEnumerable<int[]> templates)
        {
            var ret = new List<Tile>();

            var tmpBoard = board.Copy();
            var attackerColor = piece.Color == 'w' ? 'b' : 'w';
            var originalLoc = piece.CurrentLocation;

            var tmpPiece = tmpBoard.GetPiece(piece.CurrentLocation);

            var moves = piece is Pawn ? GeneratePawnMoves(tmpBoard, (Pawn)tmpPiece, templates) :
                GenerateDefaultTemplateMoves(tmpBoard, tmpPiece, pieceRange, templates);

            foreach (var tmpMove in moves)
            {
                var tmpTo = new BoardLocation() { Row = tmpMove.Row, Column = tmpMove.Column };
                tmpBoard.MovePiece(originalLoc, tmpTo);

                if (!IsKingInCheck(tmpBoard, attackerColor))
                    ret.Add(new Tile(tmpTo.Row, tmpTo.Column));

                //tmpBoard.MovePiece(tmpMove, originalTile);
                tmpBoard.UndoMove();
            }

            return ret;
        }

        #region pawn movement

        private static IList<Tile> GeneratePawnMoves(Board board, Pawn pawn, IEnumerable<int[]> templates)
        {
            var moves = new List<Tile>();

            if (!PawnHasPieceInfront(board, pawn))
            moves.AddRange(GenerateDefaultTemplateMoves(board, pawn, 1, templates).ToList());

            if (PawnIsInOpeningSpace(pawn, pawn.CurrentLocation.Row))
            {
                var secondSpace = GetSecondSpace(board, pawn);

                if (secondSpace != null)
                    moves.Add(secondSpace);
            }

            // will add moves if pawn is able to capture pieces
            moves.AddRange(GetPawnDiagonalCaptures(board, pawn));

            return moves;
        }

        private static bool PawnHasPieceInfront(Board board, Pawn pawn)
        {
            var forwardTile = board.GetTile(pawn.CurrentLocation.Row + GetDirection(pawn), pawn.CurrentLocation.Column);
            return forwardTile != null && forwardTile.Piece != null;
        }

        private static Tile? GetSecondSpace(Board board, Pawn pawn)
        {
            var twoSpaceTile = board.GetTile(pawn.CurrentLocation.Row + (GetDirection(pawn) * 2), pawn.CurrentLocation.Column);
            if (twoSpaceTile != null && twoSpaceTile.Piece == null)
                return twoSpaceTile;
            else return null;
        }

        internal static int GetDirection(IPiece piece)
        {
            // white goes up, black goes down
            return piece.Color == 'w' ? -1 : 1;
        }

        private static bool PawnIsInOpeningSpace(IPiece piece, int row)
        {
            return piece.Color == 'w' ? row == 6 : row == 1;
        }

        /// <summary>
        /// 
        /// returns the moves to capture a piece if the tiles diagonal/forward 
        /// to the pawn contains pieces
        /// 
        /// </summary>
        private static List<Tile> GetPawnDiagonalCaptures(Board board, Pawn pawn)
        {
            var ret = new List<Tile>();

            // check if diagonal moves have a piece to capture
            var left = board.GetTile(pawn.CurrentLocation.Row + GetDirection(pawn), pawn.CurrentLocation.Column - 1);
            var right = board.GetTile(pawn.CurrentLocation.Row + GetDirection(pawn), pawn.CurrentLocation.Column + 1);

            if (right != null)
                if (right.Piece != null && right.Piece.Color != pawn.Color)
                    ret.Add(right);

            if (left != null)
                if (left.Piece != null && left.Piece.Color != pawn.Color)
                    ret.Add(left);

            return ret;
        }

        #endregion

        private static bool IsKingInCheck(Board board, char attackerColor)
        {
            var kingPos = attackerColor == 'w' ? board.BlackKingLocation : board.WhiteKingLocation;
            var king = board.GetTile(kingPos);

            foreach (var tile in board.Tiles)
            {
                if (tile.Piece == null) continue;
                if (tile.Piece is King) continue;

                if (tile.Piece.Color == attackerColor)
                {
                    board.KingInCheck = null;
                    var attackerMoves = board.GetPiece(tile.Row, tile.Column).GetValidMoves(board);
                    if (attackerMoves.Any(a => a.Row == kingPos.Row && a.Column == kingPos.Column))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsSameColor(Board board, IPiece piece, BoardLocation compareLocation)
        {
            Tile? newTile = board.GetTile(compareLocation.Row, compareLocation.Column);

            if (newTile == null) throw new NullReferenceException("compareLocation");
            if (newTile.Piece == null) return false;

            if (piece.Color != newTile.Piece.Color)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 
        /// return true if the newRow/newCol contains a piece.
        /// 'collidingLocation' returns the piece where the collision occurs on the board
        /// 
        /// </summary>
        /// <param name="collidingLocation"></param>
        /// <returns></returns>
        private static bool CollidesIntoOpponentPiece(Board board, IPiece piece, int newRow, int newCol, out Tile? collidingLocation)
        {
            collidingLocation = null;

            // knight is the only piece that can jump over other pieces
            // so it is impossible to collide with another piece
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

        /// <summary>
        /// 
        /// return true if the move: 'from' -> 'to' is valid for the piece at 'from' location
        /// 
        /// </summary>
        internal static bool MoveIsValid(Board board, Tile from, Tile to)
        {
            var piece = board.GetPiece(from.Row, from.Column);
            if (piece == null) return false;
            var moves = piece.GetValidMoves(board);

            return moves.Any(m => m.Row == to.Row && m.Column == to.Column);
        }

    }
}
