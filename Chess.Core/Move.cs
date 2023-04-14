namespace Chess.Core
{
    public class Move
    {
        public Tile From { get; set; }
        public Tile To { get; set; }

        public Move(Tile from, Tile to)
        {
            From = from;
            To = to;
        }

        public int EvaluateBoard(Board board)
        {
            int score = 0;

            // Loop through the board and evaluate each piece
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    IPiece piece = board.GetPiece(row, col); // Get the piece at the current position

                    switch (piece.Symbol)
                    {
                        case 'P':
                            score += 1;
                            break;
                        case 'R':
                            score += 5; break;

                        case 'N':
                            score += 3; break;

                        case 'B':
                            score += 3; break;

                        case 'Q':
                            score += 9; break;

                        case 'K':
                            score += 100; break;

                        case 'p':
                            score -= 1; break;

                        case 'r':
                            score -= 5; break;

                        case 'n':
                            score -= 3; break;

                        case 'b':
                            score -= 3; break;

                        case 'q':
                            score -= 9; break;

                        case 'k':
                            score -= 100; break;
                        default:
                            break;

                    }

                }
            }

            return score;
        }
    }
}
