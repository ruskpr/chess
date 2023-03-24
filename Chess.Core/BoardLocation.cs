namespace Core
{
    public class BoardLocation
    {
        private const int BoardSize = 8;

        public int Row { get; }
        public int Column { get; }

        private static bool IsInRange(int pos)
        {
            return (pos >= 1) && (pos <= BoardSize);
        }

        public BoardLocation(int row, int col)
        {
            if (!IsInRange(row))
            {
                throw new ArgumentOutOfRangeException("row");
            }
            if (!IsInRange(col))
            {
                throw new ArgumentOutOfRangeException("col");
            }

            Row = row;
            Column = col;
        }
        
    }
}