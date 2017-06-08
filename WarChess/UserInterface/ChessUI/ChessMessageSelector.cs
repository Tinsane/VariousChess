using System.Collections.Generic;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessMessageSelector : IMessageSelector<ChessGame>
    {
        public IEnumerable<string> GetMessages(ChessGame game)
        {
            if (game.IsCheck)
                yield return "Шах";
            if (game.IsFinished)
                yield return "Мат";
        }
    }
}
