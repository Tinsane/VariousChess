namespace WarChess.Domain.ChessAlikeApi.Chess
{
    public class ChessPiece : IChessAlikePiece
    {
        public Color Color { get; }
        public string Name { get; } // Чисто для mock-а, чтобы побыстрее писать. Потом будет визитор.
    }
}
