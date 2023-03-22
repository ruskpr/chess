namespace Core
{
    public class Player
    {
        public string Name { get; set; }
        public char Color { get; set; }
        public bool IsAI { get; set; } = false;

        public Player(string name, char color)
        {
            Name = name;
            Color = color;
        }

        public void MovePiece(Tile from, Tile to)
        {
            to.CurrPiece = from.CurrPiece;
            from.CurrPiece = null;
        }
    }
}