using System;
using System.Collections.Generic;
using WarChess.Domain.WarChess;
using WarChess.UserInterface.ChessUI;

namespace WarChess.UserInterface.WarChessUI
{
    public class WarChessMessageSelector : ChessMessageSelector, IMessageSelector<IWarChessGame>
    {
        public IEnumerable<string> GetMessages(IWarChessGame game)
        {
            if (game.PawnCanAttack)
                yield return "Пешка может рубить";
            foreach (var message in base.GetMessages(game))
                yield return message;
        }
    }
}
