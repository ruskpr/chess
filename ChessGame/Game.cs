namespace ChessGame
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            Board board = new Board(this);
        } 
    }
}