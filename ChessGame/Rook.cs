using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessGame.Piece;

namespace ChessGame
{
    public class Rook : Piece
    {

        public Rook(Player player, Tile tile) : base(player, tile)
        {
            this.Image = player == Player.Player_One ? MyAssets.W_RookImg : MyAssets.B_RookImg;
        }

        public override void GetValidMoves(Tile tile)
        {
            MessageBox.Show("Test" + this.ToString());
        }
    }
}
