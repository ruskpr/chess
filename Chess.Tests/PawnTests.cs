using Chess.Core;
using Chess.Core.Pieces;

namespace Chess.Tests
{
    public class PawnTests
    {
        #region simple movement

        [Fact]
        public void BlackPawnCanMoveForward()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 1, 'b');

            // move down 1 tile
            board.TryMakeMove(board.Tiles[1, 1], board.Tiles[1, 2]);

            Assert.Equal(blackPawn, board.Tiles[1, 2].Piece);
        }

        [Fact]
        public void BlackPawnCantMoveBackward()
        {
            var board = new Board(8, false);
            var blackPawn = board.AddPiece<Pawn>(1, 1, 'b');

            board.TryMakeMove(board.Tiles[1, 1], board.Tiles[1, 0]);

            var moves = blackPawn.GetValidMoves(board);

            // make sure the pawns available moves DOES NOT contain the space behind it
            Assert.False(moves.Contains(board.Tiles[1, 0]));

           
        }

        #endregion


    }
}