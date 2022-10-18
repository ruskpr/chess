using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Pawn : Piece
    {
        public Pawn(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? MyAssets.W_PawnImg : MyAssets.B_PawnImg;
            CompletedFirstMove = false;
        }


        public void Move()
        {
            
        }
        
    }
}
