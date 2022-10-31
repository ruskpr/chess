using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public class GameManager
    {
        public enum PlayerTurn { p1 = 1, p2 = 2};
        public static PlayerTurn Turn = GameManager.PlayerTurn.p1;

        public static Color TileColorA = Color.LightSlateGray;
        public static Color TileColorB = Color.White;
        public static Color SelectionColor = Color.Pink;
    }
}
