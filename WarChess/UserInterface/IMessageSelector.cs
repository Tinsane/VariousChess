using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.UserInterface
{
    public interface IMessageSelector<in TGame>
    {
        string GetMessage(TGame game);
    }
}
