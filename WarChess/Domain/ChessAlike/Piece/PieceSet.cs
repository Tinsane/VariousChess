namespace WarChess.Domain.ChessAlike.Piece
{
    public class PieceSet
    {
        public PieceSet(PieceGenerator[] generator)
        {
            Generator = generator;
        }

        public PieceGenerator[] Generator { get; }
    }
}