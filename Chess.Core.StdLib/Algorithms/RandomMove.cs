using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Core.Algorithms
{
    public class RandomMove
    {
        public static Move FindRandomMove(Board board)
        {
            List<Move> legalMoves = board.GenerateAllValidMoves();
            Random rnd = new Random();
            int index = rnd.Next(legalMoves.Count);
            return legalMoves[index];
        }

    }
}
