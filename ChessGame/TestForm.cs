namespace ChessGame
{
    public partial class TestForm : Form
    {
        Size tileSize;
        public static bool TestingMode = true;

        private string peiceName;
        private int selectedPlayer;

        Board board;
        public TestForm()
        {
            InitializeComponent();
            Tile.SendTile += Tile_SendCoordinate;
            Tile.CreateTestPiece += Tile_CreateTestPiece;

            board = new Board(this);

            tileSize = new Size(board.Width / 8, board.Width / 8);

            cbPiece.SelectedIndex = 2;
            peiceName = cbPiece.SelectedText;
            selectedPlayer = 1;

            Format.Center(board);
            AddTiles(board);
        }

        private void Tile_CreateTestPiece(Tile tile)
        {

            tile.CreatePiece(peiceName, selectedPlayer); 

        }

        void AddTiles(Control control)
        {
            int locX = 0;
            int locY = 0;
            Color tileColor;
            bool colorToggle = true;


            for (int i = 0; i < 8; i++) // column
            {
                colorToggle = !colorToggle;
                for (int j = 0; j < 8; j++) // row
                {
                    tileColor = colorToggle ? Color.MediumVioletRed : Color.DarkOrange;

                    Tile tile = new Tile(this, board, tileSize, new Point(locX, locY), i, j, tileColor);

                    board.Tiles[i, j] = tile;

                    locX += tileSize.Width;
                    colorToggle = !colorToggle;
                    control.Controls.Add(tile);
                }
                locX = 0;
                locY += tileSize.Height;
            }
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
