using Core.Pieces;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.IO;
using System.Data.Common;

namespace Core
{
    public class Tile
    {
        #region properties

        //public Board Board { get; set; }
        public Piece? Piece { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsEmptySpace { get { return Piece == null; } }

        #endregion


        #region constructors

        // default
        public Tile(int row, int col)
        {
            Row = row;
            Column = col;
            Piece = null;
        }

        // with piece
        public Tile(int row, int col, Piece? piece)
        {
            Row = row;
            Column = col;
            Piece = piece;
        }

        #endregion

        public string GetDisplayCoordinates()
        {
            // 0 + 65 is the start of ascii uppercase characters
            // 65 + 32 is the start of ascii lowercase characters
            char rowCoordinate = Convert.ToChar(Row + 65 + 32);

            return rowCoordinate + Column.ToString();
        }

    }
}
