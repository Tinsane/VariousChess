using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi.WarChess;

namespace WarChess.UserInterface.WarChess
{
    public class WarChessMessageSelector : IMessageSelector<IWarChessGame>
    {
        public IEnumerable<string> GetMessages(IWarChessGame game)
        {
            throw new NotImplementedException();
        }
    }
}
