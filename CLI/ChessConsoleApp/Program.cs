using Chess.Core;
using Core;

internal class Program
{
    private static void Main()
    {
        var board = new Board(8, true);

        DrawBoard(board);

        Console.ReadLine();

    }

    private static void DrawBoard(Board board)
    {
        // draw the chess board
        for (int i = 0; i < board.Size; i++)
        {
            for (int j = 0; j < board.Size; j++)
            {
                var tile = board.Tiles[i, j];
                if (tile.Piece != null)
                {
                    Console.Write(tile.Piece.Symbol);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}