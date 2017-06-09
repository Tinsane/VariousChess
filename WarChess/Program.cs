using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarChess.Application;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.UserInterface;
using WarChess.UserInterface.ChessUI;
using Ninject;
using Ninject.Extensions.Conventions;
using WarChess.UserInterface.FocusBitmapSupplier;

namespace WarChess
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var container = new StandardKernel();
            container.Bind<IChessGame>().To<MockChessGame>().InTransientScope();
            container.Bind<ChessApp>().ToSelf();
            container.Bind<IChessStyle>().To<SimpleChessStyle>().InSingletonScope();
            container.Bind<IBoardStyle>().To<StandardBoardStyle>().InSingletonScope();
            container.Bind<IFocusBitmapSupplier>().To<GreenFocusBitmapSupplier>().InSingletonScope();
            var chessStyle = container.Get<IChessStyle>();
            container.Bind<Size>().ToConstant(new Size(chessStyle.BitmapWidth, chessStyle.BitmapHeight));
            container.Bind<AbstractBoardControl>().To<BoardControl>();
            container.Bind<IMessageSelector<IChessGame>>().To<ChessMessageSelector>();
            container.Bind<ICellBitmapSelector<ChessPiece>>().To<ChessCellBitmapSelector>();
            container.Bind<IGameForm>().To<ChessForm>();

            IGameForm[] FormsSupplier() => container.GetAll<IGameForm>().ToArray();
            System.Windows.Forms.Application.Run(new MainForm(FormsSupplier));
        }
    }
}