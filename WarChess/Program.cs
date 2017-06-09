using System;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.UserInterface;
using WarChess.UserInterface.ChessUI;

namespace WarChess
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var game = new MockChessGame();
            var app = new ChessApp(game);
            var form = new ChessForm(app, new StandardBoardStyle(), 
                new ChessCellBitmapSelector(new SimpleChessStyle()),
                new ChessMessageSelector());
            System.Windows.Forms.Application.Run(new MainForm(new []{form}));
        }
    }
}