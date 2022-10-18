using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Board : Panel
    {
        //array of tiles
        public Tile[,] Tiles = new Tile[8, 8];
        public Board(Form pntr)
        {
            Size = new Size(800, 800);
            BackColor = Color.White;
            pntr.Controls.Add(this);
        }
    }
}
