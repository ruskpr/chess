using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Algorithms
{
    public class MiniMax
    {
        // Find best move using minimax with alpha-beta pruning
        public static Move FindBestMove(Board board, int depth, int alpha, int beta, bool maximizingPlayer)
        {
            if (depth == 0) // Leaf node reached, evaluate the board state
                return null; // Return null as the best move, as we are not implementing the actual evaluation logic here

            Board tmpBoard = board;

            List<Move> legalMoves = tmpBoard.GenerateAllValidMoves();

            Move bestMove = null;

            if (maximizingPlayer)
            {
                int maxEval = int.MinValue;

                foreach (var move in legalMoves)
                {
                    // Make the move on a temporary board
                    tmpBoard.MovePiece(move.From, move.To);

                    int eval = FindBestMove(tmpBoard, depth - 1, alpha, beta, false).EvaluateBoard(tmpBoard); // Recursively evaluate the child node

                    // Undo the move on the temporary tmpBoard
                    tmpBoard.UndoMove();

                    if (eval > maxEval)
                    {
                        maxEval = eval;
                        bestMove = move;
                    }

                    alpha = Math.Max(alpha, eval);
                    if (beta <= alpha)
                        break; // Beta cutoff
                }

                return bestMove;
            }
            else
            {
                int minEval = int.MaxValue;

                foreach (var move in legalMoves)
                {
                    // Make the move on a temporary tmpBoard
                    tmpBoard.MovePiece(move.From, move.To);

                    int eval = FindBestMove(tmpBoard, depth - 1, alpha, beta, true).EvaluateBoard(tmpBoard); // Recursively evaluate the child node

                    // Undo the move on the temporary tmpBoard
                    tmpBoard.UndoMove();

                    if (eval < minEval)
                    {
                        minEval = eval;
                        bestMove = move;
                    }

                    beta = Math.Min(beta, eval);
                    if (beta <= alpha)
                        break; // Alpha cutoff
                }

                return bestMove;
            }
        }

        
    }
}
