using WarChess.Domain.Chess;

namespace WarChess.Domain.ChessAlikeApi.Chess
{
    public class MockBoard : IChessBoard<ChessPiece>
    {
        public int RowCount => 8;
        public int ColumnCount => 8;

        public ChessPiece this[ChessPosition position] => null;
    }
}