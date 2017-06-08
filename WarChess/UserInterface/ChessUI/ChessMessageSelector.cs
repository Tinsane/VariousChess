using System.Collections.Generic;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessMessageSelector : IMessageSelector<ChessGame>
    {
        public IEnumerable<string> GetMessages(ChessGame game)
        {
            throw new System.NotImplementedException();
        }
    }
}
