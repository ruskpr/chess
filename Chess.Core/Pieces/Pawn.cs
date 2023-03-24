using Chess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(char player ) : base(player) { }

        private int GetDirection()
        {
            // white goes up, black goes down
            return Player == 'w' ? 1 : -1;
        }

        private bool CompletedFirstMove()
        {
            //return Player == 'w' ? Position.Row == 1 : Position.Row == 6;
            return true;
        }

        private int[][] GetTemplates()
        {
            var templates = new List<int[]>();
            // add the forward move
            templates.Add(new[] { GetDirection(), 0 });
            // add the double forward move
            if (!CompletedFirstMove())
            {
                templates.Add(new[] { GetDirection() * 2, 0 });
            }
            // add the diagonal moves
            templates.Add(new[] { GetDirection(), -1 });
            templates.Add(new[] { GetDirection(), 1 });
            return templates.ToArray();
        }

        private int GetRange()
        {
            if (CompletedFirstMove())
            {
                return 1;
            }

            return 2;
        }

        public override IList<Tile> GetValidMoves(Board board)
        {
            // check to see row of current piece on board

            return Movement.GetMoves(board, this, GetRange(), GetTemplates());
        }
    }
}
