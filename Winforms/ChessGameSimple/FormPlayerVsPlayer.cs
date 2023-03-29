using Chess.Core;
using Chess.Core.Pieces;
using System.Resources;

namespace ChessGameSimple
{
    public partial class FormPlayerVsPlayer : Form
    {
        
        const int BOARDSIZE = 8;

        static Color Color1 = Color.Gainsboro;
        static Color Color2 = Color.Cornsilk;


        private char _turn = 'w';

        int tileSize = 80;

        private Tile? _selectedTile = null;

        private Button[,] _buttonArray = new Button[BOARDSIZE, BOARDSIZE];
        private Board _board;
        private Game _game;
        private Player _white;
        private Player _black;

        public FormPlayerVsPlayer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = this.Size;

            _white = new Player("White", 'w', PlayerType.AI),
            _black = new Player("Black", 'b', PlayerType.AI));

            _board = new Board(BOARDSIZE, true);

            ChessUtils.CreateTiles(this, _buttonArray, _board, tileSize, Color1, Color2, tileClickEvent);
            ChessUtils.DrawSymbols(_buttonArray, _board);
        }

        private void tileClickEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int row = Convert.ToInt32(btn.Tag.ToString().Split(',')[0]); 
            int col = Convert.ToInt32(btn.Tag.ToString().Split(',')[1]);

            // if no piece is selected, select the piece
            if (_selectedTile == null)
            {
                var piece = _board.GetPiece(row, col);

                if (piece != null)
                {
                    Tile selectedTile = _board.GetTile(row, col);

                    if (selectedTile.Piece.Color != _turn) return;

                    _selectedTile = selectedTile;
                    ChessUtils.ShowMoves(_buttonArray, _board, _selectedTile);
                }

                lbSelected.Text = $"Selected: {row}, {col}";
            }
            // unselect the piece if it is already selected
            else if (_selectedTile == _board.GetTile(row, col))
            {
                ChessUtils.HideMoves(_buttonArray);
                _selectedTile = null;
                lbSelected.Text = $"Selected:";
            }
            // if a piece is selected, try to move it
            else
            {
                Tile to = _board.GetTile(row, col);

                // if the piece is the same color as the selected piece, select the new piece
                if (to.Piece != null)
                {
                    if (_selectedTile.Piece.Color == to.Piece.Color)
                    {
                        _selectedTile = to;
                        ChessUtils.HideMoves(_buttonArray);
                        ChessUtils.ShowMoves(_buttonArray, _board, _selectedTile);
                        return;
                    }
                }

                bool moveSuccessful = _board.TryMakeMove(_selectedTile, to);

                if (moveSuccessful)
                {
                    ChessUtils.HideMoves(_buttonArray);
                    _selectedTile = null;
                    lbSelected.Text = $"Selected:";
                    SwapTurns();
                    ChessUtils.DrawSymbols(_buttonArray, _board);
                    return;
                }
                else
                {
                    _selectedTile = null;
                    lbSelected.Text = "Invalid move";
                    return;
                }
            }

        }

        private void SwapTurns()
        {
            _turn = _turn == 'w' ? 'b' : 'w';
            lbTurn.Text = _turn == 'w' ? "White" : "Black";
        }
    }
}