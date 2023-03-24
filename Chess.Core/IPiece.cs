namespace Core
{
    public interface IPiece
    {
        char Player { get; set; }

        BoardLocation CurrentLocation { get; set; }

        IList<Tile> GetValidMoves(Board board);
    }
}