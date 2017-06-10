using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;

namespace WarChess.UserInterface.ChessUI
{
    public interface IChessLanguagePack : ILanguagePack<ChessGame>
    {
        string MessageCheck { get; }
        string MessageMate { get; }
        string MessageStaleMate { get; }
    }
}
