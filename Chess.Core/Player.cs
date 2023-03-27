namespace Chess.Core
{
    public enum PlayerType
    {
        LocalPlayer,
        OnlinePlayer,
        AI,
    }

    public class Player
    {
        
        public string Name { get; set; }
        public char Color { get; set; }
        public PlayerType Type { get; set; }

        public Player(string name, char color, PlayerType type)
        {
            if (color != 'w' && color != 'b')
                throw new ArgumentException("Player must be either 'w' or 'b' (white or black");

            Name = name;
            Color = color;
            Type = type;
        }
    }
}