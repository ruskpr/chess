using Core;
using Core.Pieces;

namespace Chess.Tests
{
    public class PieceMovementTests
    {
        #region king

        [Fact]
        public void Test_KingCanMoveLeft()
        {
            var board = new Board(8, false);
            board.AddPiece<King>(3,3, 'w');

            var king = board.GetPiece(3, 3) as King;

            var moves = king.GetValidMoves(board);

            Assert.Equal(3, moves.Count);
        }

        #endregion


    }
}