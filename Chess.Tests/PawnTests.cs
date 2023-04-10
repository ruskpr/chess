using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.Tests
{
    public class PawnTests
    {
        #region white pawn

        [Fact]
        public void WhitePawnCanMoveForward()
        {
            var board = new Board(8, false);
            var whitePawn = board.AddPiece<Pawn>(1, 1, 'w');

            // move up 1 tile
            bool successfulMove = board.TryMakeMove(board.Tiles[1, 1], board.Tiles[0, 1]);

            Assert.True(successfulMove);
            Assert.Equal(whitePawn, board.Tiles[0, 1].Piece);
        }

        [Fact] 
        public void WhitePawnCanCaptureForwardRight()
        {
            var board = new Board(8, false);
            var whitePawn = board.AddPiece<Pawn>(2, 2, 'w');
            var blackPawn = board.AddPiece<Pawn>(1, 3, 'b');

            Assert.Equal(blackPawn, board.Tiles[1, 3].Piece);

            bool successfulMove = board.TryMakeMove(board.Tiles[2, 2], board.Tiles[1, 3]);

            Assert.True(successfulMove);
            Assert.Equal(whitePawn, board.Tiles[1, 3].Piece);
        }

        [Fact]
        public void WhitePawnCanCaptureForwardLeft()
        {
            var board = new Board(8, false);
            var whitePawn = board.AddPiece<Pawn>(2, 2, 'w');
            var blackPawn = board.AddPiece<Pawn>(1, 1, 'b');

            Assert.Equal(blackPawn, board.Tiles[1, 1].Piece);

            bool successfulMove = board.TryMakeMove(board.Tiles[2, 2], board.Tiles[1, 1]);

            Assert.True(successfulMove);
            Assert.Equal(whitePawn, board.Tiles[1, 1].Piece);
        }

        [Fact]
        public void WhitePawnCANNOTMoveBackward()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 1, 'w');
            bool moveSuccessful = board.TryMakeMove(board.Tiles[1, 1], board.Tiles[2, 1]);

            Assert.False(moveSuccessful);
            Assert.Equal(blackPawn, board.Tiles[1, 1].Piece);
        }

        [Fact] 
        public void WhitePawnCANNOTCaptureForwardPiece()
        {
            var board = new Board(8, false);
            var whitePawn = board.AddPiece<Pawn>(2, 2, 'w');
            var blackPawn = board.AddPiece<Pawn>(1, 2, 'b');

            Assert.Equal(blackPawn, board.Tiles[1, 2].Piece);

            bool successfulMove = board.TryMakeMove(board.Tiles[2, 2], board.Tiles[1, 2]);

            Assert.False(successfulMove);
            Assert.Equal(whitePawn, board.Tiles[2, 2].Piece);
            Assert.Equal(blackPawn, board.Tiles[1, 2].Piece);
        }

        [Fact]
        public void WhitePawnCanJumpForwardTwiceFromStartingPosition()
        {
            var board = new Board(8, false);
            var whitePawn = board.AddPiece<Pawn>(6, 6, 'w');

            // move forward 2 tiles
            bool successfulMove = board.TryMakeMove(board.Tiles[6, 6], board.Tiles[4, 6]);

            Assert.True(successfulMove);
            Assert.Equal(whitePawn, board.Tiles[4, 6].Piece);
        }

        #endregion

        #region black pawn

        [Fact]
        public void BlackPawnCanMoveForward()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 1, 'b');
            bool moveSuccessful = board.TryMakeMove(board.Tiles[1, 1], board.Tiles[2, 1]);

            Assert.True(moveSuccessful);
            Assert.Equal(blackPawn, board.Tiles[2, 1].Piece);
        }

        [Fact]
        public void BlackPawnCanCaptureForwardRight()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 3, 'b');
            var whitePawn = board.AddPiece<Pawn>(2, 2, 'w');

            bool successfulMove = board.TryMakeMove(board.Tiles[1, 3], board.Tiles[2, 2]);

            Assert.True(successfulMove);
            Assert.Equal(blackPawn, board.Tiles[2, 2].Piece);
        }

        [Fact]
        public void BlackPawnCanCaptureForwardLeft()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 1, 'b');
            var whitePawn = board.AddPiece<Pawn>(2, 2, 'w');

            bool successfulMove = board.TryMakeMove(board.Tiles[1, 1], board.Tiles[2, 2]);

            Assert.True(successfulMove);
            Assert.Equal(blackPawn, board.Tiles[2, 2].Piece);
        }

        [Fact]
        public void BlackPawnCANNOTMoveBackward()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 1, 'b');
            bool moveSuccessful = board.TryMakeMove(board.Tiles[1, 1], board.Tiles[0, 1]);

            Assert.False(moveSuccessful);
            Assert.Equal(blackPawn, board.Tiles[1, 1].Piece);
        }

        [Fact]
        public void BlackPawnCANNOTCaptureForwardPiece()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 2, 'b');
            var whitePawn = board.AddPiece<Pawn>(2, 2, 'w');

            bool successfulMove = board.TryMakeMove(board.Tiles[1, 2], board.Tiles[2, 2]);

            Assert.False(successfulMove);
            Assert.Equal(blackPawn, board.Tiles[1, 2].Piece);
            Assert.Equal(whitePawn, board.Tiles[2, 2].Piece);
        }

        [Fact]
        public void BlackPawnCanJumpForwardTwiceFromStartingPosition()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 1, 'b');

            // move forward 2 tiles
            bool successfulMove = board.TryMakeMove(board.Tiles[1, 1], board.Tiles[3, 1]);

            Assert.True(successfulMove);
            Assert.Equal(blackPawn, board.Tiles[3, 1].Piece);
        }

        #endregion

    }
}