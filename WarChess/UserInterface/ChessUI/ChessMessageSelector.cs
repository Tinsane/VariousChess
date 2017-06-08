using System.Collections.Generic;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessMessageSelector : IMessageSelector<Chess>
    {
        public IEnumerable<string> GetMessages(Chess game)
        {
            throw new System.NotImplementedException();
        }
    }
}
