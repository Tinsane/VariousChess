using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.Chess.WarChess;
using WarChess.Domain.WarChess;

namespace WarChess.UserInterface.WarChess
{
    public class WarChessForm : Form
    {
        /*
         * Этот класс должен расположить все элементы на экране: 
         * 1. Поле для шахмат.
         * 2. Поля для отображения уже срубленных фигур. (опционально)
         * 3. Историю. (опционально)
         * 4. Сообщения игрокам. (опционально)
         */
        public WarChessForm(WarChessApp game, IChessStyle chessStyle, IBoardStyle boardStyle)
        {// здесь нужен не IWarChessGame, а класс с уровня application
            var board = new ChessBoard(boardStyle, chessStyle.BitmapWidth, chessStyle.BitmapHeight);
            
            // need some layout
        }
    }
}
