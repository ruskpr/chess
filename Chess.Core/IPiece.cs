namespace Chess.Core
{
    public interface IPiece
    {
        char Color { get; set; }

        BoardLocation CurrentLocation { get; set; }

        char Symbol { get; }

        IList<Tile> GetValidMoves(Board board);
    }
}