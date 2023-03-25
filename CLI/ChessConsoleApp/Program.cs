using Chess.Core;

internal class Program
{
    private static void Main()
    {
        var board = new Board(8, true);

        DrawBoard(board);

        // take user input to make a move
        while (true)
        {
            Console.WriteLine("Enter the piece you want to move");
            var selectedPieceInput = Console.ReadLine();
            int fromRow = Convert.ToInt32(selectedPieceInput[0].ToString());
            int fromCol = Convert.ToInt32(selectedPieceInput[1].ToString());
            var pieceToMove = board.GetPiece(fromRow, fromCol);
            Console.WriteLine($"Selected: {pieceToMove.Color} {pieceToMove.Symbol}");
            Console.WriteLine("Enter the tile you want to move to, type x to cancel");
            string tileInput = Console.ReadLine();
            if (tileInput == "x") continue;
            int toRow = Convert.ToInt32(tileInput[0].ToString());
            int toCol = Convert.ToInt32(tileInput[1].ToString());

            var tileToMoveTo = board.GetTile(toRow, toCol);

            Console.Clear();

            if (pieceToMove == null)
            {
                Console.WriteLine("Invalid piece");
                continue;
            }
            if (tileToMoveTo == null)
            {
                Console.WriteLine("Invalid tile");
                continue;
            }

            if (board.TryMakeMove(board.GetTile(pieceToMove), tileToMoveTo))
            {
                DrawBoard(board);
                continue;
            }
            else
            {
                Console.WriteLine("Invalid move");
            }

            DrawBoard(board);

        }

    }

    private static void DrawBoard(Board board)
    {
        // draw the chess board
        for (int i = 0; i < board.Size; i++)
        {
            Console.WriteLine("---------------------------------");

            for (int j = 0; j < board.Size; j++)
            {

                var tile = board.Tiles[i, j];
                if (tile.Piece != null)
                {

                    Console.Write("|");
                    if (j == 7)
                    {
                        Console.Write($" {tile.Piece.Symbol} |");
                        continue;
                    }

                    Console.Write($" {tile.Piece.Symbol} ");
                }
                else
                {
                    if (j == 7)
                    {
                        Console.Write("|   |");
                        continue;
                    }
                    Console.Write("|   ");
                }
            }

            Console.WriteLine();
        }
        Console.WriteLine("---------------------------------");

    }

}