using Chess.Core;
using Chess.Core.Pieces;

internal class Program
{
    private static void Main()
    {
        var board = new Board(8, true);

        while (true)
        {

            DrawBoard(board);
            Console.WriteLine("Enter the piece you want to move (ex. 02)");

            IPiece? pieceToMove = null;

            try
            {
                var selectedPieceInput = Console.ReadLine();
                int fromRow = Convert.ToInt32(selectedPieceInput[0].ToString());
                int fromCol = Convert.ToInt32(selectedPieceInput[1].ToString());
                pieceToMove = board.GetPiece(fromRow, fromCol);
            }
            catch { continue; }
           

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