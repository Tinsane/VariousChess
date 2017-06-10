using System;
using System.Collections.Generic;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessMessageSelector : IMessageSelector<IChessGame>
    {
        public ChessMessageSelector(IChessLanguagePack languagePack)
        {
            this.languagePack = languagePack;
        }
        public IEnumerable<string> GetMessages(IChessGame game)
        {
            if (game.IsCheck)
                yield return languagePack.MessageCheck;
            if (game.IsMate)
                yield return languagePack.MessageMate;
            if (game.IsStaleMate)
                yield return languagePack.MessageStaleMate;
        }

        private IChessLanguagePack languagePack;
    }
}
