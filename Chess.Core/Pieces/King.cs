using System.Diagnostics.Contracts;

namespace Chess.Core.Pieces
{
    public class King : Piece
    {
        #region constructors

        public King() : base()
        {
            _symbol = 'k';
        }

        public King(char player, int row, int col) : base(player, row, col)
        {
            _symbol = 'k';
        }

        #endregion


        private static readonly int[][] MoveTemplates = new int[][]
        {
            new [] { 1, -1 },
            new [] { 1, 0 },
            new [] { 1, 1 },
            new [] { 0, -1 },
            new [] { 0, 1 },
            new [] { -1, -1 },
            new [] { -1, 0 },
            new [] { -1, 1 },
        };

        public override IList<Tile> GetValidMoves(Board board)
        {
            var moves = Movement.GetMoves(board, this, 1, MoveTemplates).ToList();

            //// remove all moves where an attacker is holding it
            //List<BoardLocation> movesToRemove = new List<BoardLocation>();
            //foreach (var move in moves)
            //{
            //    var tile = board.GetTile(move.Row, move.Column);
            //    if (tile == null) continue;

            //    if (tile.Piece != null && tile.Piece.Color != this.Color)
            //    {
            //        var attackerMoves = tile.Piece.GetValidMoves(board).ToList();
            //        foreach (var attackerMove in attackerMoves)
            //            if (attackerMove.Row == move.Row && attackerMove.Column == move.Column)
            //                movesToRemove.Add(new BoardLocation() { Row = attackerMove.Row, Column = attackerMove.Column });
            //    }
            //}

            //for (int i = 0; i < moves.Count; i++)
            //{
            //    for (int j = 0; j < movesToRemove.Count; j++)
            //    {
            //        if (moves[i].Row == movesToRemove[j].Row && moves[i].Column == movesToRemove[j].Column)
            //            moves.RemoveAt(i);
            //    }
            //}

            return moves;
        }

    }
}
