﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class GameManager
    {
        public enum PlayerTurn { p1, p2};
        public static PlayerTurn Turn = GameManager.PlayerTurn.p1;
    }
}