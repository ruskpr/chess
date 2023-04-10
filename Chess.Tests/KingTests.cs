using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.Tests
{
    public class KingTests
    {
        #region basic movement

        [Fact]
        public void KingCanMoveLeft()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3, 3, 'w');

            // move left 1 tile
            bool successfulMove = board.TryMakeMove(board.Tiles[3, 3], board.Tiles[3, 2]);

            Assert.Equal(king, board.Tiles[3, 2].Piece);
            Assert.True(successfulMove);
        }

        [Fact]
        public void KingCanMoveRight()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3, 3, 'w');

            // move right 1 tile
            bool successfulMove = board.TryMakeMove(board.Tiles[3, 3], board.Tiles[3, 4]);

            Assert.Equal(king, board.Tiles[3, 4].Piece);
            Assert.True(successfulMove);
        }

        [Fact]
        public void KingCanMoveUp()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3, 3, 'b');

            // move right 1 tile
            bool successfulMove = board.TryMakeMove(board.Tiles[3, 3], board.Tiles[2, 3]);

            Assert.Equal(king, board.Tiles[2, 3].Piece);
            Assert.True(successfulMove);
        }

        [Fact]
        public void KingCanMoveDown()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3, 3, 'b');

            // move right 1 tile
            bool successfulMove = board.TryMakeMove(board.Tiles[3, 3], board.Tiles[3, 4]);

            Assert.Equal(king, board.Tiles[3, 4].Piece);
            Assert.True(successfulMove);
        }

        [Fact]
        public void KingCanMoveToAllAdjacentTiles()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3, 3, 'b');
            var moves = king.GetValidMoves(board);
            Assert.Equal(8, moves.Count);
        }

        #endregion
    }
}