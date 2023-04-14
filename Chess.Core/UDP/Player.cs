namespace Chess.Core.UDP
{
    public class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public Player(string name, char color)
        {
            if (color != 'w' && color != 'b')
                throw new ArgumentException("Player must be either 'w' or 'b' (white or black");

            Name = name;
            Symbol = color;
        }

        public Player() { }
    }
}