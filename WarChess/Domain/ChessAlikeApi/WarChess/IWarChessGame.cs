namespace WarChess.Domain.ChessAlikeApi.WarChess
{
    public interface IWarChessGame : IChessAlikeGame<IChessAlikePiece> 
        // здесь, видимо, вместо IChessAlikePiece будет что-то отнаследованное от ChessPiece, что умеет визитора
    {
        // Потенциально ещё тут могут быть методы, для отмены хода и для возврата полной истории ходов.
        // Можно, кстати, совместить эти штуки, реализовав undo/redo, но это всё пока не принцпиально.
        
        WarChessAlert Alert { get; }
    }
}