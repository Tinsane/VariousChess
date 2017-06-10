using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface
{
    public interface IMessageSelector<in TGame>
    {
        IEnumerable<string> GetMessages(TGame game);
    }
}
