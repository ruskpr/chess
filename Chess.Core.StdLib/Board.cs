using Chess.Core.Pieces;
using Newtonsoft.Json;

namespace Chess.Core
{
    public enum GameOverType
    {
        Checkmate,
        Stalemate
    }

    public class Board
    {
        #region delegates / events

        //event is called on main form constructor
        //public delegate void PieceMovedDelegate();
        //public event PieceMovedDelegate? OnPieceMoved;

        public delegate void KingChecked(King? kingThatIsChecked);
        public event KingChecked? OnKingChecked;

        public delegate void GameOver(char? winner, GameOverType type);
        public event GameOver OnGameOver;

        #endregion

        #region fields

        const int DEFAULT_SIZE = 8;

        private Tile[,] _tiles;
        public Stack<Tuple<BoardLocation, BoardLocation, IPiece?>> MoveStack = new Stack<Tuple<BoardLocation, BoardLocation, IPiece?>>();

        private BoardLocation _whiteKingLocation;
        private BoardLocation _blackKingLocation;
        private char? _kingInCheck;
        private bool _gameOver = false;
        private char? _winner = null;

        #endregion

        #region props

        public Tile[,] Tiles { get { return _tiles; } set { _tiles = value; } }
        public int Size { get; set; }
        public char? KingInCheck { get => _kingInCheck; set => _kingInCheck = value; }
        public bool IsGameOver { get => _gameOver; set => _gameOver = value; }
        public char? Winner { get => _winner; set => _winner = value; }
        public BoardLocation WhiteKingLocation { get => _whiteKingLocation; set => _whiteKingLocation = value; }
        public BoardLocation BlackKingLocation { get => _blackKingLocation; set => _blackKingLocation = value; }

        #endregion

        #region constructor

        // default constructor
        public Board(int size, bool addDefaultPieces)
        {
            _tiles = new Tile[size, size];
            Size = size;
            CreateTiles(size, size);

            if (addDefaultPieces)
            {
                AddDefaultPieces();
                _blackKingLocation = new BoardLocation(0, 4);
                _whiteKingLocation = new BoardLocation(7, 4);
            }
        }
         
        // overload to allow custom board
        public Board(Tile[,] tiles)
        {
            _tiles = tiles;
            Size = tiles.GetLength(0);
        }

        // for json serialization
        [JsonConstructor]
        public Board() { }

        ~Board() => System.Diagnostics.Debug.WriteLine($"Chessboard was disposed");

        #endregion

        #region private

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

        private void AddDefaultPieces()
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

        private void UpdateKingPosition(char color, int row, int col)
        {
            if (color == 'w')
                _whiteKingLocation = new BoardLocation(row, col);
            else
                _blackKingLocation = new BoardLocation(row, col);
        }

        #endregion

        #region public

        public bool TryMakeMove(Tile? from, Tile? to)
        {
            if (_gameOver) return false;
            if (from.Piece is null) return false;  
            

            // validates that the selected piece can move to the selected tile
            if (!Movement.MoveIsValid(this, from, to))
                return false;

            if (Movement.MovePutsKingInCheck(this, from, to))
                return false;

            if (from.Piece.Color == to.Piece?.Color) return false; // same color check
            if (to.Piece is King) return false; // king piece check

            MovePiece(from, to);

            if (IsKingInCheck(to.Piece.Color))
            {
                var kingLoc = to.Piece.Color == 'w' ? _blackKingLocation : _whiteKingLocation;
                King king = GetPiece(kingLoc.Row, kingLoc.Column) as King;

                _kingInCheck = king.Color;
                OnKingChecked?.Invoke(king);

                if (GenerateAllValidMoves(king.Color).Count == 0)
                {
                    _gameOver = true;
                    _winner = king.Color == 'w' ? 'b' : 'w';
                    OnGameOver?.Invoke(_winner, GameOverType.Checkmate);
                }
            }
            else
                _kingInCheck = null;

            return true;

        }

        public void UndoMove()
        {
            if (MoveStack.Count == 0) return;

            var lastMove = MoveStack.Pop();

            var from = GetTile(lastMove.Item1.Row, lastMove.Item1.Column);
            var to = GetTile(lastMove.Item2.Row, lastMove.Item2.Column);

            from.Piece = to.Piece;
            if (from.Piece != null)
                from.Piece.CurrentLocation = new BoardLocation(from.Row, from.Column);

            to.Piece = lastMove.Item3; // restore captured piece (if there was one)            

            if (from.Piece is King)
                UpdateKingPosition(from.Piece.Color, from.Row, from.Column);

            if (_gameOver) _gameOver = false;
            if (_kingInCheck != null) _kingInCheck = null;

        }

        #region add/get/remove pieces and tiles

        /// <summary>
        /// 
        /// Places a custom piece on the board at the specified location.
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="color"></param>
        /// <returns>The piece that was added.</returns>
        public IPiece AddPiece<T>(int row, int col, char color) where T : IPiece, new()
        {
            if (row >= Size || col >= Size)
                throw new IndexOutOfRangeException("Row or column is out of range.");

            T piece = new T();
            piece.CurrentLocation = new BoardLocation(row, col);
            piece.Color = color;
            _tiles[row, col].Piece = piece;

            if (piece is King && piece.Color == 'b')
                _blackKingLocation = new BoardLocation(row, col);
            else if (piece is King && piece.Color == 'w')
                _whiteKingLocation = new BoardLocation(row, col);

            return piece;
        }

        /// <summary>
        /// 
        /// Add a piece to the board at the specified location.
        /// Will replace any existing piece at that location.
        /// Returns the piece that was added.
        /// 
        /// </summary>
        public IPiece AddPiece(int row, int col, IPiece piece)
        {
            if (row >= Size || col >= Size)
                throw new IndexOutOfRangeException("Row or column is out of range.");

            piece.CurrentLocation = new BoardLocation(row, col);
            _tiles[row, col].Piece = piece;

            if (piece is King && piece.Color == 'b')
                _blackKingLocation = new BoardLocation(row, col);
            else if (piece is King && piece.Color == 'w')
                _whiteKingLocation = new BoardLocation(row, col);

            return piece;
        }

        public IPiece? GetPiece(int row, int col)
        {
            return _tiles[row, col].Piece ?? null;
        }

        public IPiece? GetPiece(BoardLocation boardLocation)
        {
            return _tiles[boardLocation.Row, boardLocation.Column].Piece ?? null;
        }

        public Tile? GetTile(int row, int col)
        {
            try
            {
                return _tiles[row, col];
            }
            catch { return null; }
        }

        /// <summary>
        ///  
        /// Gets the tile at the specified location on the board.
        /// 
        /// </summary>
        public Tile GetTile(BoardLocation boardLocation)
        {
            try
            {
                return _tiles[boardLocation.Row, boardLocation.Column];
            }
            catch { throw new NullReferenceException("tile doesn't exist."); }
        }

        /// <summary>
        /// 
        /// Gets the tile where the piece is located on the board.
        /// If it is not found on the board, it will return null.
        /// 
        /// </summary>
        public Tile? GetTileByPiece(IPiece piece)
        {
            foreach (Tile tile in _tiles)
            {
                if (tile.Row == piece.CurrentLocation.Row && tile.Column == piece.CurrentLocation.Column)
                    return tile;
            }
            return null;
        }

        /// <summary>
        /// 
        /// Will remove the piece that is passed in through the parameters
        /// if it exists on the board.
        /// 
        /// </summary>
        public void RemovePiece(IPiece piece)
        {
            var tile = GetTileByPiece(piece);
            if (tile != null)
                tile.Piece = null;
        }

        /// <summary>
        /// 
        /// If a piece exists at the specified location, it will be removed.
        /// 
        /// </summary>
        public void RemovePiece(int row, int col)
        {
            var tile = GetTile(row, col);
            if (tile != null)
                tile.Piece = null;
        }

        #endregion

        #endregion

        #region interal

        internal void MovePiece(Tile from, Tile to)
        {
            // store the moves details in a stack
            var fromLoc = new BoardLocation(from.Row, from.Column);
            var toLoc = new BoardLocation(to.Row, to.Column);
            IPiece? capturedPiece = to.Piece;
            MoveStack.Push(Tuple.Create(fromLoc, toLoc, capturedPiece));

            // move piece
            to.Piece = from.Piece;
            to.Piece.CurrentLocation = new BoardLocation(to.Row, to.Column);
            from.Piece = null;

            if (to.Piece is King)
                UpdateKingPosition(to.Piece.Color, to.Row, to.Column);
        }

        internal void MovePiece(BoardLocation from, BoardLocation to)
        {
            // store the moves details in a stack
            var fromLoc = new BoardLocation(from.Row, from.Column);
            var toLoc = new BoardLocation(to.Row, to.Column);

            IPiece? capturedPiece = GetTile(to).Piece;
            MoveStack.Push(Tuple.Create(fromLoc, toLoc, capturedPiece));

            var toTile = GetTile(to);
            var fromTile = GetTile(from);

            // move piece
            toTile.Piece = fromTile.Piece;
            toTile.Piece.CurrentLocation = new BoardLocation(toTile.Row, toTile.Column);
            fromTile.Piece = null;

            if (toTile.Piece is King)
                UpdateKingPosition(toTile.Piece.Color, toTile.Row, toTile.Column);
        }

        // create a method to check if the king is in check
        internal bool IsKingInCheck(char attackerColor)
        {

            var kingPos = attackerColor == 'w' ? _blackKingLocation : _whiteKingLocation;
            foreach (var tile in _tiles)
            {
                if (tile.Piece == null) continue;
                if (tile.Piece is King) continue;

                if (tile.Piece.Color == attackerColor)
                {
                    var attackerMoves = GetPiece(tile.Row, tile.Column).GetValidMoves(this);
                    if (attackerMoves.Any(a => a.Row == kingPos.Row && a.Column == kingPos.Column))
                    {
                        var tmpKing = GetPiece(kingPos.Row, kingPos.Column) as King;
                        if (tmpKing.Color != attackerColor)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        #endregion


        /// <summary>
        /// 
        /// Get all moves of all the pieces on the board. Mainly used for AI algorithms.
        /// Leave the parameter null to get moves for both players.
        /// 
        /// </summary>
        internal List<Move> GenerateAllValidMoves(char? playerColor = null)
        {
            List<Move> moves = new List<Move>();

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    var currentTile = GetTile(row, col);
                    if (currentTile.Piece == null) continue;

                    if (playerColor != null)
                        if (currentTile.Piece.Color != playerColor) continue;

                    foreach (var move in currentTile.Piece.GetValidMoves(this))
                        moves.Add(new Move(currentTile, move));
                }
            }

            return moves;
        }

        internal Board Copy()
        {
            return new Board()
            {
                Tiles = this.Tiles,
                Size = this.Size,
                KingInCheck = this.KingInCheck,
                IsGameOver = this.IsGameOver,
                Winner = this.Winner,
                _blackKingLocation = this._blackKingLocation,
                _whiteKingLocation = this._whiteKingLocation,
                MoveStack = this.MoveStack,
            };
        }
    }
}
