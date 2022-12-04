using ChessLibrary;

namespace ChessGame
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            Board chessBoard = new Board(this);
        } 
    }
}