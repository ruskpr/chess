using Core;

namespace Chess.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Create_Local_Game()
        {
            var p1 = new Player("Player 1", 'w', PlayerType.LocalPlayer);
            var p2 = new Player("Player 2", 'b', PlayerType.LocalPlayer);
            var board = new Board();

            Game game = new Game(board, p1, p2);

            Assert.True(true);
        }
    }
}