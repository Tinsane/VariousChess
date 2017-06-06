using System.Collections.Generic;

namespace WarChess.Domain.Chess.WarChess
{
    // Этот интерфейс - для "финального" класса.
    // Для уже собранной игры в военные шахматы. Ведь именно их мы будем визуализировать. Вот для них мне интерфейс и нужен.
    // Та "абстрактная" игра, которую ты хочешь писать, в общем-то не должна его реализовывать.
    public interface IWarChessGame
    {
        Color WhoseMove { get; }

        // Потенциально ещё тут могут быть методы, для отмены хода и для возврата полной истории ходов.
        // Можно, кстати, совместить эти штуки, реализовав undo/redo, но это всё пока не принцпиально.
        IChessBoard<IChessPiece> Board { get; }

        // Нельзя здесь возвращать GameState. Он умеет слишком много. Это что-то внутреннее.
        WarChessAlert Alert { get; }

        /// <summary>
        ///     Returns true if move was successful, otherwise returns false.
        /// </summary>
        bool TryMakeMove(ChessPosition from, ChessPosition to);
    }
}