using System.Collections.Generic;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessMessageSelector : IMessageSelector<IChessGame>
    {
        public IEnumerable<string> GetMessages(IChessGame game)
        {
            if (game.IsCheck)
                yield return "Шах";
            if (game.IsFinished)
                yield return "Мат";
        }
    }
}
