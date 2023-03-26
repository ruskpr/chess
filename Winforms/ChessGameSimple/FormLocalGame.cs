using Chess.Core;
using Chess.Core.Pieces;

namespace ChessGameSimple
{
    public partial class FormLocalGame : Form
    {
        Board _board;
        Game _game;
        const int BOARDSIZE = 8;

        static Color Color1 = Color.Gainsboro;
        static Color Color2 = Color.Gray;


        int gap = 20;
        int tileSize = 80;

        private Tile? _selectedTile = null;

        private Button[,] _buttonArray = new Button[BOARDSIZE, BOARDSIZE];

        private Button? btnPrev = null;
        public FormLocalGame()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = this.Size;

            _board = new Board(BOARDSIZE, true);
            _game = new Game(_board,
                new Player("White", 'w', PlayerType.LocalPlayer),
                new Player("Black", 'b', PlayerType.LocalPlayer));

            CreateTiles();
            DrawSymbols();
        }

        private void btnTile_Click(object sender, EventArgs e)
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
                    _selectedTile = _board.GetTile(row, col);
                    ShowMoves(_selectedTile);

                }

                lbSelected.Text = $"Selected: {row}, {col}";
            }
            // unselect the piece if it is already selected
            else if (_selectedTile == _board.GetTile(row, col))
            {
                _selectedTile = null;
                lbSelected.Text = $"Selected:";
            }
            // if a piece is selected, try to move it
            else
            {
                bool moveSuccessful = _board.TryMakeMove(_selectedTile, _board.GetTile(row, col));

                if (moveSuccessful)
                {
                    _selectedTile = null;
                    lbSelected.Text = $"Selected:";
                    DrawSymbols();
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

        private void ShowMoves(Tile tile)
        {
            if (tile.Piece == null) return;

            var moves = tile.Piece.GetValidMoves(_board);

            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                }
            }
        }

        private void DrawSymbols()
        {

            for (int row = 0; row < BOARDSIZE; row++)
            {
                for (int col = 0; col < BOARDSIZE; col++)
                {
                    if (_board.Tiles[row, col].Piece == null)
                    {
                        _buttonArray[row, col].Text = "";
                        continue;
                    }

                    _buttonArray[row, col].Text = _board.Tiles[row, col].Piece.Symbol.ToString();
                }
            }
        }

        private void CreateTiles()
        {
            int x = 0;
            int y = 1;
            for (int row = 0; row < _board.Size; row++)
            {

                for (int col = 0; col < _board.Size; col++)
                {
                    Tile tile = _board.Tiles[row, col];
                    Button btn = new Button();
                    btn.Size = new Size(tileSize, tileSize);
                    btn.Location = new Point(col * tileSize + gap, row * tileSize + gap);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = x % 2 == 0 ? Color1 : Color2;
                    btn.Click += btnTile_Click;
                    btn.Tag = row + "," + col;
                    x++;
                    _buttonArray[row, col] = btn;
                    this.Controls.Add(btn);
                }
                x++;
            }
        }


    }
}