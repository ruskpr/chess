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
        public Player CurrentPlayer { get; set; }
        public Pawn(Player player, Tile tile) : base(player, tile)
        {
            CurrentPlayer = player;
            this.Image = player == Player.PlayerOne ? MyAssets.W_PawnImg : MyAssets.B_PawnImg;
        }

        public override string ToString()
        {
            return $"{CurrentPlayer.ToString()}'s Pawn";
        }
    }
}
