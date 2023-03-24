namespace Core
{
    public class Player
    {
        public enum PlayerType
        {
            LocalPlayer, 
            OnlinePlayer,
            AI,
        }


        public string Name { get; set; }
        public char Color { get; set; }
        public bool IsAI { get; set; } = false;
        public PlayerType Type { get; set; }

        public Player(string name, char color, PlayerType type)
        {
            Name = name;
            Color = color;
            Type = type;
        }

        public void MovePiece(Tile from, Tile to)
        {
            to.Piece = from.Piece;
            from.Piece = null;
        }
    }
}