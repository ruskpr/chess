using Chess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pieces
{
    public class Bishop : Piece
    {
        public Bishop() : base()
        {
            _symbol = 'b';
        }

        public Bishop(char player, int row, int col) : base(player, row, col)
        {
            _symbol = 'b';
        }

        private readonly static int[][] MoveTemplates = new int[][]
        {
            new [] { 1, -1 }, // down right
            new [] { 1, 1 }, // up right
            new [] { -1, -1 }, // down left
            new [] { -1, 1 }, // up left
        };

        public override IList<Tile> GetValidMoves(Board board)
        {
            return Movement.GetMoves(board, this, board.Size, MoveTemplates);
        }

    }
}
