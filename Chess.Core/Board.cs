using Chess.Core.Pieces;

namespace Chess.Core
{
    public class Board
    {
        #region delegates / events

        //event is called on main form constructor
        public delegate void PieceMovedDelegate();
        public event PieceMovedDelegate? OnPieceMoved;

        public delegate void OnKingCheckedDelegate(King kingThatIsChecked);
        public static event OnKingCheckedDelegate? OnKingChecked;

        #endregion

        #region fields

        const int DEFAULT_SIZE = 8;

        private Tile[,] _tiles = new Tile[8, 8];
        public Stack<Tuple<Piece, Tile, Tile>> MoveStack = new Stack<Tuple<Piece, Tile, Tile>>();
        private string _latestMove = "";

        #endregion

        #region props

        public Tile[,] Tiles { get { return _tiles; } set { _tiles = value; } }
        public int Size { get; set; }

        public List<Piece> WhiteCapturedPieces { get; set; } = new List<Piece>();
        public List<Piece> BlackCapturedPieces { get; set; } = new List<Piece>();

        #endregion

        #region constructor

        // default constructor
        public Board()
        {
                      
        }

        public Board(int size, bool addDefaultPieces)
        {
            Size = size;
            CreateTiles(size, size);

            if (addDefaultPieces)
                AddDefaultPieces();
        }

        // overload to allow custom board
        public Board(Tile[,] tiles)
        {
            _tiles = tiles;
        }

        ~Board() => System.Diagnostics.Debug.WriteLine($"Chessboard was disposed");

        #endregion

        private void CreateTiles(int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _tiles[i, j] = new Tile(i, j);
                }
            }
        }

        public void AddDefaultPieces()
        {
            //loop through each tile in 2d array and add pieces to board tiles
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 1)
                        _tiles[i, j].Piece = new Pawn('b', i, j); // adds 8 player black pawns to 2nd row
                    if (i == 6)
                        _tiles[i, j].Piece = new Pawn('w', i, j); // adds 8 white pawns to 7th row

                    // player 1's backrow
                    if (i == 7)
                    {
                        if (j == 0 || j == 7)
                            _tiles[i, j].Piece = new Rook('w', i, j); // adds both white rooks
                        if (j == 1 || j == 6)
                            _tiles[i, j].Piece = new Knight('w', i, j); // adds both white knights
                        if (j == 2 || j == 5)
                            _tiles[i, j].Piece = new Bishop('w', i, j); // adds both white bishops
                        if (j == 3)
                            _tiles[i, j].Piece = new Queen('w', i, j); // adds white queen
                        if (j == 4)
                            _tiles[i, j].Piece = new King('w', i, j); // adds white king
                    }

                    // player 2's backrow
                    if (i == 0)
                    {
                        if (j == 0 || j == 7)
                            _tiles[i, j].Piece = new Rook('b', i, j); // adds both black rooks
                        if (j == 1 || j == 6)
                            _tiles[i, j].Piece = new Knight('b', i, j); // adds both black knights
                        if (j == 2 || j == 5)
                            _tiles[i, j].Piece = new Bishop('b', i, j); // adds both black bishops
                        if (j == 3)
                            _tiles[i, j].Piece = new Queen('b', i, j); // adds black queen
                        if (j == 4)
                            _tiles[i, j].Piece = new King('b', i, j); // adds black king
                    }
                }
            }
        }

        // will return false until a valid move is made
        public bool TryMakeMove(Tile from, Tile to)
        {
            // check if the move is valid
            if (from.Piece.GetValidMoves(this).Contains(to))
            {
                // check if the move is a capture
                if (to.Piece != null)
                {
                    // check if the piece is the same color
                    if (to.Piece.Color == from.Piece.Color)
                    {
                        return false;
                    }
                    else
                    {
                        // if opposite color, capture the piece
                        MovePiece(from, to);
                        return true;
                    }
                }
                else
                {
                    // if no piece on tile, move the piece
                    MovePiece(from, to);
                    return true;
                }
            }

            return false;
        }

        // create a method to move a piece
        public void MovePiece(Tile from, Tile to)
        {
            to.Piece = from.Piece;
            from.Piece = null;
        }

        private void CapturePiece(Piece piece)
        {
            throw new NotImplementedException();
        }

        public void UpdatePieces()
        {
            var tasks = new List<Task>();

            foreach (Tile tile in _tiles)
            {
                if (tile.Piece != null)
                tasks.Add(Task.Run(() => tile.Piece.GetValidMoves(this)));
            }

            Task.WaitAll(tasks.ToArray());
        }
        
        #region reset board

        public void ResetBoard()
        {
            throw new NotImplementedException();
        }

        #endregion

        // place custom piece on tile
        public Piece AddPiece<T>(int row, int col, char color) where T : Piece, new()
        {
            T piece = new T();
            piece.CurrentLocation = new BoardLocation(row, col);
            piece.GetValidMoves(this);
            piece.Color = color;
            _tiles[row, col].Piece = piece;
            return piece;
        }

        public IPiece? GetPiece(int row, int col)
        {
            return _tiles[row, col].Piece ?? null;
        }

        // place custom tile
        public void PlaceTile(int row, int col, Piece? piece = null)
        {
            _tiles[row, col] = new Tile(row, col, piece);
        }

        // create a method to get tile
        public Tile? GetTile(int row, int col)
        {
            try
            {
                return _tiles[row, col];
            }
            catch { return null; }
        }

        // get tile by piece
        public Tile? GetTile(IPiece piece)
        {
            foreach (Tile tile in _tiles)
            {
                if (tile.Piece == piece)
                    return tile;
            }
            return null;
        }


    }
}
