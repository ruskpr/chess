using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Game
    {
        public enum PlayerTurn { p1 = 1, p2 = 2};
        public static PlayerTurn Turn = Game.PlayerTurn.p1;

        public Game()
        {
            
        }

        #region public

        #endregion

        #region private

        #endregion

        public static void SwapTurn() => Turn = Turn == PlayerTurn.p1 ? PlayerTurn.p2 : PlayerTurn.p1;
    }
}
