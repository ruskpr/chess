using Newtonsoft.Json;

namespace Chess.Core
{
    public class BoardLocation
    {
        private const int BoardSize = 8;

        public int Row { get; set; }
        public int Column { get; set; }

        private static bool IsInRange(int pos)
        {
            return (pos >= 1) && (pos <= BoardSize);
        }

        public BoardLocation(int row, int col)
        {
            //if (!IsInRange(row))
            //{
            //    throw new ArgumentOutOfRangeException("row");
            //}
            //if (!IsInRange(col))
            //{
            //    throw new ArgumentOutOfRangeException("col");
            //}

            Row = row;
            Column = col;
        }

        [JsonConstructor]
        public BoardLocation() { }


        public override string ToString()
        {
            return $"{Row},{Column}";
        }
    }
}