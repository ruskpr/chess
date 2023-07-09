using Chess.Core;
using Chess.Core.Algorithms;
using Chess.Core.Pieces;
using System.Resources;

namespace ChessClient;

public partial class FormAIvsAI : Form
{

    const int BOARDSIZE = 8;

    static Color Color1 = Color.Gainsboro;
    static Color Color2 = Color.Cornsilk;

    private char _turn = 'w';

    int tileSize = 80;

    private Tile? _selectedTile = null;

    private Button[,] _buttonArray = new Button[BOARDSIZE, BOARDSIZE];
    private Board _board;

    public FormAIvsAI()
    {
        InitializeComponent();
        this.Icon = new Icon("icon.ico");
        this.StartPosition = FormStartPosition.CenterScreen;
        this.MinimumSize = this.Size;
        this.Text = "";

        _board = new Board(BOARDSIZE, true);

        ChessUtils.CreateTiles(this, _buttonArray, _board, tileSize, Color1, Color2, false, null);
        ChessUtils.DrawSymbols(_buttonArray, _board);
    }


    private Task PlayAsync()
    {
        return Task.Factory.StartNew(() =>
        {
            while (!_board.IsGameOver)
            {
                // run minimax algorithm to get move
                Move? move = null;// = MiniMax.FindBestMove(_board, 15, int.MinValue, int.MaxValue, true);

                if (move == null)
                    move = RandomMove.FindRandomMove(_board);

                _board.TryMakeMove(move.From, move.To);

                SwapTurns();
            }
        });
    }

    private void SwapTurns()
    {
        _turn = _turn == 'w' ? 'b' : 'w';
    }

    private async void btnStart_Click(object sender, EventArgs e)
    {
        await PlayAsync();
    }
}