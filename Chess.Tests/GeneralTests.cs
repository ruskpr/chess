using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.Tests
{
    public class GeneralTests
    {
        #region basic movement

        [Fact]
        public void BlackRookCantMoveOverBlackPawnOnStart()
        {
            var board = new Board(8, true);

            // move rook 2 forward
            bool successfulMove = board.TryMakeMove(board.Tiles[0, 0], board.Tiles[2, 0]);

            Assert.False(successfulMove);
        }

        [Fact]
        public void BlackKnightCanMoveOverBlackPawnsOnStart()
        {
            var board = new Board(8, true);

            // move knight over pawns
            bool successfulMove = board.TryMakeMove(board.Tiles[0, 1], board.Tiles[2, 0]);

            Assert.True(successfulMove);
        }

        [Fact]
        public void WhiteRookCantMoveOverWhitePawnOnStart()
        {
            var board = new Board(8, true);

            // move rook 2 forward
            bool successfulMove = board.TryMakeMove(board.Tiles[7, 7], board.Tiles[5, 7]);

            Assert.False(successfulMove);
        }

        [Fact]
        public void WhiteKnightCanMoveOverWhitePawnsOnStart()
        {
            var board = new Board(8, true);

            // move knight over pawns
            bool successfulMove = board.TryMakeMove(board.Tiles[7, 6], board.Tiles[5, 7]);

            Assert.True(successfulMove);
        }

        #endregion
    }
}