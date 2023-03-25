using Core;
using Core.Pieces;

namespace Chess.Tests
{
    public class KingTests
    {
        #region king

        [Fact]
        public void Test_KingCanMoveLeft()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3,3, 'w');

            // move left 1 tile
            board.MovePiece(board.Tiles[3, 3], board.Tiles[2, 3]);

            Assert.Equal(board.Tiles[2, 3].Piece, king);
        }

        [Fact]
        public void Test_KingCanMoveRight()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3, 3, 'w');

            // move right 1 tile
            board.MovePiece(board.Tiles[3, 3], board.Tiles[4, 3]);

            Assert.Equal(board.Tiles[4, 3].Piece, king);
        }

        [Fact]
        public void Test_KingCanMoveUp()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3, 3, 'b');

            // move right 1 tile
            board.MovePiece(board.Tiles[3, 3], board.Tiles[3, 4]);

            Assert.Equal(board.Tiles[3, 4].Piece, king);
        }

        [Fact]
        public void Test_KingCanMoveDown()
        {
            var board = new Board(8, false);
            var king = board.AddPiece<King>(3, 3, 'b');

            // move right 1 tile
            board.MovePiece(board.Tiles[3, 3], board.Tiles[3, 2]);

            Assert.Equal(board.Tiles[3, 2].Piece, king);
        }

        #endregion


    }
}