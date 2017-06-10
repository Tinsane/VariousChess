using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.AbstractGame;
using WarChess.Domain.ChessAlikeApi.Chess;

namespace WarChess.UserInterface
{
    public interface ILanguagePack<TGame>
        where TGame : IChessGame
    {
        string GameName { get; }
        string Language { get; }
    }
}
