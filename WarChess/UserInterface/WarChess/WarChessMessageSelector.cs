using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess.WarChess;

namespace WarChess.UserInterface.WarChess
{
    public class WarChessMessageSelector : IMessageSelector<IWarChessGame>
    {
        public string GetMessage(IWarChessGame game)
        {
            switch (game.Alert)
            {
                case WarChessAlert.Check:
                    return "Шах";
                case WarChessAlert.Mate:
                    return "Мат";
                case WarChessAlert.PawnCanAttack:
                    return "Пешка может рубить";
                default:
                    throw new ArgumentException($"Unknown alert type: {game.Alert}");
            }
        }
    }
}
