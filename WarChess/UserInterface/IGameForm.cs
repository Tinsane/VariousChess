using System.Windows.Forms;

namespace WarChess.UserInterface
{
    public interface IGameForm
    {
        string GameName { get; }
        void Run(Form previous); // not sure about it right now
    }
}