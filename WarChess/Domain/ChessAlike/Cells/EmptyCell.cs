namespace WarChess.Domain.ChessAlike.Cells
{
    public class EmptyCell : AbstractGame.Cells.EmptyCell, IChessAlikeCell
    {
        public int? PieceId => null;
    }
}