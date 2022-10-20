using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Bishop : Piece
    {
        public Bishop(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? MyAssets.W_BishopImg : MyAssets.B_BishopImg;
        }
        public override void GetValidMoves(Tile tile)
        {
            MessageBox.Show("Test" + this.ToString());
        }
    }
}
