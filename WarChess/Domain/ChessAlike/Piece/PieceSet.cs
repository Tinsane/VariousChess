namespace WarChess.Domain.ChessAlike.Piece
{
    public class PieceSet
    {
        public PieceSet(PieceInfo[] info)
        {
            Info = info;
        }

        public PieceInfo[] Info { get; }
    }
}