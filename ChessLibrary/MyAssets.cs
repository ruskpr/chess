using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public static class Assets
    {

        // https://www.pinclipart.com/downpngs/hRbwim_file-pieces-sprite-wikimedia-chess-pieces-png-clipart/
        public static string common = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string file = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;

        //black pieces
        public static Bitmap B_PawnImg = new Bitmap("assets/pieces/pack1/BlackPawn.png");
        public static Bitmap B_RookImg = new Bitmap("assets/pieces/pack1/BlackRook.png");
        public static Bitmap B_KnightImg = new Bitmap("assets/pieces/pack1/BlackKnight.png");
        public static Bitmap B_BishopImg = new Bitmap("assets/pieces/pack1/BlackBishop.png");
        public static Bitmap B_QueenImg = new Bitmap("assets/pieces/pack1/BlackQueen.png");
        public static Bitmap B_KingImg = new Bitmap("assets/pieces/pack1/BlackKing.png");

        //white pieces
        public static Bitmap W_PawnImg = new Bitmap("assets/pieces/pack1/WhitePawn.png");
        public static Bitmap W_RookImg = new Bitmap("assets/pieces/pack1/WhiteRook.png");
        public static Bitmap W_KnightImg = new Bitmap("assets/pieces/pack1/WhiteKnight.png");
        public static Bitmap W_BishopImg = new Bitmap("assets/pieces/pack1/WhiteBishop.png");
        public static Bitmap W_QueenImg = new Bitmap("assets/pieces/pack1/WhiteQueen.png");
        public static Bitmap W_KingImg = new Bitmap("assets/pieces/pack1/WhiteKing.png");


        //valid space indicator
        public static Bitmap ValidMoveImg = new Bitmap("assets/ValidSpace.png");
        public static Bitmap ValidKillImg = new Bitmap("assets/ValidKill.png");

        public static SoundPlayer sp = new SoundPlayer("assets/sounds/levelup2.wav");

    }
}
