using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Piece
    {
        public static List<Piece> pieceList = new List<Piece>();

        public enum Player
        {
            None,
            PlayerOne,
            PlayerTwo
        }

        public Piece(Player player)
        {


            pieceList.Add(this);
        }
    }
}
