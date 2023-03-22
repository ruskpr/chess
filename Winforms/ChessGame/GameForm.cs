using ChessLibrary;

namespace ChessGame
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            Game chessboard = new Game(this);
        } 
    }
}