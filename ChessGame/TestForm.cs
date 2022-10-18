namespace ChessGame
{
    public partial class TestForm : Form
    {
        Size tileSize;
        public static bool TestingMode = true;

        private string peiceName;
        private int selectedPlayer;

        static Board board;
        public TestForm()
        {
            InitializeComponent();
            Tile.SendSelectedTile += Tile_SendCoordinate;
            Tile.CreateTestPiece += Tile_CreateTestPiece;


            //initialize board
            board = new Board(this, 800);
            board.ConstructBoard();
            Format.Center(board);
        }

        private void Tile_CreateTestPiece(Tile tile)
        {

            tile.CreatePiece(peiceName, selectedPlayer); 

        }

       
        private void btnTest1_Click(object sender, EventArgs e)
        {
            
        }

        private void Tile_SendCoordinate(Tile tile)
        {
            lbTest1.Text = tile.ToString();
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
            selectedPlayer = 1;
        }

        private void btnP2_Click(object sender, EventArgs e)
        {
            selectedPlayer = 2;
        }

        private void cbPiece_SelectedIndexChanged(object sender, EventArgs e)
        {
            peiceName = cbPiece.SelectedText;
        }
    }
}
