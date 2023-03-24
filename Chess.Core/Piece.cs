using Core.Pieces;

namespace Core
{
    public abstract class Piece : IDisposable
    {
        #region fields

        public static List<Piece> Pieces = new List<Piece>();
        public static List<Piece> White_CapturedPieces = new List<Piece>();
        public static List<Piece> Black_CapturedPieces = new List<Piece>();
        private bool disposed;

        #endregion

        #region properties

        public char Player { get; set; }
        //public Tile? CurrentTile { get; set; }
        public List<Tile> CurrentValidMoves { get; set; } = new List<Tile>();

        #endregion

        #region constructor

        public Piece(char player)
        {
            if (player != 'w' || player != 'b')
                throw new ArgumentException("Player must be either 'w' or 'b' (white or black");

            Player = player;
            //CurrentTile = tile;
            Pieces.Add(this);
        }
        #endregion

        #region methods

        public abstract void GetValidMoves(Board board, Tile origin);

        #endregion

        #region handle dispose

        public void Dispose()
        {
            Dispose(true);
            GC.Collect();
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // CurrentPlayer = null;
                    CurrentTile = null;
                    CurrentValidMoves = null;
                    Image = null;
                    Pieces.Clear();
                }

                // Dispose unmanaged resources here.
            }

            disposed = true;
        }
        #endregion

        #region tostring

        public override string ToString() => $"{Player.ToString().Replace("_", " ")}'s {GetType().Name}";

        #endregion
    }
}
