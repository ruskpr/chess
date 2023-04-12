namespace Chess.Core
{
    public abstract class Piece : IPiece
    {
        #region fields

        protected BoardLocation _currentLocation;
        protected char _symbol;

        #endregion

        #region properties

        public char Color { get; set; }

        public char Symbol
        {
            get
            {
                if (Color == 'b')
                {
                    return Char.ToUpper(_symbol);
                }
                else
                {
                    return Char.ToLower(_symbol);
                }
            }

            protected set { _symbol = value; }
        }

        #endregion

        public BoardLocation CurrentLocation
        {
            get => _currentLocation;
            set => _currentLocation = value ?? throw new ArgumentNullException();
        }


        public abstract IList<Tile> GetValidMoves(Board board);



        public Piece() { }

        public Piece(char player, int row, int col)
        {
            if (player != 'w' && player != 'b')
                throw new ArgumentException("Player must be either 'w' or 'b' (white or black");

            Color = player;
            _currentLocation = new BoardLocation(row, col);
        }

        public override string ToString()
        {
            
            return $"{Color} {Symbol} at {CurrentLocation}";
        }

    }
}
