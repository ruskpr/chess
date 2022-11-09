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

        #region Color packages
        public static List<Tuple<Color, Color, Color>> ColorPackages = new List<Tuple<Color, Color, Color>>()
        {
            new Tuple<Color, Color, Color>(Color.LightSlateGray, Color.White, Color.Pink),
            new Tuple<Color, Color, Color>(Color.CornflowerBlue, Color.DarkOliveGreen, Color.LightSlateGray)
        };

        #endregion 

        public static void SwapTurns() => 
            Turn = Turn == PlayerTurn.p1 ? PlayerTurn.p2 : PlayerTurn.p1;
    }
}
