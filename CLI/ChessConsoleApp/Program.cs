using Chess.Core;
using Chess.Core.Pieces;

internal class Program
{
    private static void Main()
    {
        var board = new Board(8, false);
        var king = board.AddPiece<King>(3, 3, 'b');

        //var moves = king.GetValidMoves(board);

        //var from = board.GetTile(0, 3);
        //var to = board.GetTile(1, 3);
        //board.TryMakeMove(from, to);
        //DrawBoard(board);
        //Console.ReadLine();

        // take user input to make a move
        while (true)
        {

            DrawBoard(board);
            Console.WriteLine("Enter the piece you want to move");
            var selectedPieceInput = Console.ReadLine();
            int fromRow = Convert.ToInt32(selectedPieceInput[0].ToString());
            int fromCol = Convert.ToInt32(selectedPieceInput[1].ToString());
            var pieceToMove = board.GetPiece(fromRow, fromCol);

            if (pieceToMove == null)
            {
                Console.WriteLine("Invalid piece");
                continue;
            }

            DrawBoard(board, pieceToMove.GetValidMoves(board));

            Console.WriteLine($"Selected: {pieceToMove.Color} {pieceToMove.Symbol}");
            Console.WriteLine("Enter the tile you want to move to, type x to cancel");
            string tileInput = Console.ReadLine();
            if (tileInput == "x") continue;
            int toRow = Convert.ToInt32(tileInput[0].ToString());
            int toCol = Convert.ToInt32(tileInput[1].ToString());

            var tileToMoveTo = board.GetTile(toRow, toCol);

            if (tileToMoveTo == null)
            {
                Console.WriteLine("Invalid tile");
                continue;
            }

            // try to make the move
            if (board.TryMakeMove(board.GetTileByPiece(pieceToMove), tileToMoveTo))
            {
                DrawBoard(board);
                continue;
            }
            else
            {
                Console.WriteLine("Invalid move");
            }

        }

    }

    private static void DrawBoard(Board board, IList<Tile>? moves = null)
    {
        // draw the chess board
        for (int i = 0; i < board.Size; i++)
        {
            Console.WriteLine("---------------------------------");

            for (int j = 0; j < board.Size; j++)
            {
                // draw the move
                if (moves != null)
                {
                    if (moves.Contains(board.GetTile(i, j)))
                    {
                        Console.Write("| X ");
                        continue;
                    }
                }   


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