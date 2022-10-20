using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessGame.Piece;

namespace ChessGame
{
    public class King : Piece
    {
        public King(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? MyAssets.W_KingImg : MyAssets.B_KingImg;
        }
        public override void GetValidMoves(Tile tile)
        {
            MessageBox.Show("Test" + this.ToString());
        }
    }
}
