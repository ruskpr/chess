using Chess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static ChessGame.Piece;

namespace Core.Pieces
{
    public class King : Piece
    {
        #region fields

        private bool inCheckedState = false;

        #endregion

        #region properties

        public bool InCheckedState { get { return inCheckedState; } }

        #endregion

        #region constructor

        public King(char player) : base(player) { }

        #endregion


        private static readonly int[][] MoveTemplates = new int[][]
        {
            new [] { 1, -1 },
            new [] { 1, 0 },
            new [] { 1, 1 },
            new [] { 0, -1 },
            new [] { 0, 1 },
            new [] { -1, -1 },
            new [] { -1, 0 },
            new [] { -1, 1 },
        };

        public override IList<Tile> GetValidMoves(Board board)
        {
            return Movement.GetMoves(board, this, 1, MoveTemplates);
        }

    }
}
