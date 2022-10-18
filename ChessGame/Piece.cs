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

        public Bitmap Image { get; set; }

        public Tile CurrentTile { get; set; }
        public enum Player
        {
            None,
            PlayerOne,
            PlayerTwo
        }

        public Piece(Player player, Tile tile)
        {
            CurrentTile = tile;
            this.Image = null;
            pieceList.Add(this);

        }

        public void Remove()
        {
            pieceList.Remove(this);
        }

    }
}
