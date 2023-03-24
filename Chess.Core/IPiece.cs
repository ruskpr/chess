namespace Core
{
    public interface IPiece
    {
        List<Tile> CurrentValidMoves { get; set; }

        char Player { get; set; }

        void GetValidMoves(Board board, Tile origin);
    }
}