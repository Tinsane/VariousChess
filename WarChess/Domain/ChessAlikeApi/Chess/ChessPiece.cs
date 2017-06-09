namespace WarChess.Domain.ChessAlikeApi.Chess
{
    public class ChessPiece : IChessAlikePiece
    {
        public string Name { get; } // Чисто для mock-а, чтобы побыстрее писать. Потом будет визитор.
        public Color Color { get; }
    }
}