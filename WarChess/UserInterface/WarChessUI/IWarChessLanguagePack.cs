using WarChess.Domain.WarChess;
using WarChess.UserInterface.ChessUI;

namespace WarChess.UserInterface.WarChessUI
{
    public interface IWarChessLanguagePack : ILanguagePack<WarChessGame>, IChessLanguagePack
    {
        string MessagePawnCanAttack { get; }
    }
}