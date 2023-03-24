using Core.Pieces;

namespace Core
{
    public abstract class Piece : IPiece
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

        private BoardLocation _currentLocation;
        public BoardLocation CurrentLocation
        {
            get => _currentLocation;
            set => _currentLocation = value ?? throw new ArgumentNullException();
        }

        public abstract IList<Tile> GetValidMoves(Board board);

        IList<Tile> IPiece.GetValidMoves(Board board)
        {
            throw new NotImplementedException();
        }

        #region constructor

        public Piece(char player)
        {
            if (player != 'w' || player != 'b')
                throw new ArgumentException("Player must be either 'w' or 'b' (white or black");

            Player = player;
            //CurrentTile = tile;
            //Pieces.Add(this);
        }



        #endregion

        #region methods


        #endregion



    }
}
