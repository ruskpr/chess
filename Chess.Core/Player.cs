namespace Core
{
    public class Player
    {

        public char Color { get; set; }

        public Player(string name, char color)
        {
            Color = color;
        }

        public void MovePiece(Tile from, Tile to)
        {
            to.CurrPiece = from.CurrPiece;
            from.CurrPiece = null;
        }

        
    }
}