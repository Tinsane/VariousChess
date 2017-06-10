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
using WarChess.Domain;
using WarChess.Domain.AbstractGame;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.GameStateProvider;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.WarChess;
using WarChess.UserInterface.FocusBitmapSupplier;
using WarChess.UserInterface.WarChessUI;

namespace WarChess
{
    public class Program
    {
        private static void BindContainer(StandardKernel container)
        {
            container.Bind<IPawnTransformer>().To<QueenPawnTransformer>().InSingletonScope();
            container.Bind<IChessGameStateProvider>().To<ChessGameStateProvider>();
            container.Bind(c => c
                .FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom<IGame>()
                .BindDefaultInterface()
                .Configure(b => b.InTransientScope()));
            container.Bind(c => c
                .FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom<IApp>()
                .BindToSelf());
            container.Bind<IChessStyle>().To<SimpleChessStyle>().InSingletonScope();
            container.Bind<IBoardStyle>().To<StandardBoardStyle>().InSingletonScope();
            container.Bind<IFocusBitmapSupplier>().To<GreenFocusBitmapSupplier>().InSingletonScope();
            var chessStyle = container.Get<IChessStyle>();
            container.Bind<Size>().ToConstant(new Size(chessStyle.BitmapWidth, chessStyle.BitmapHeight));
            container.Bind<AbstractBoardControl>().To<BoardControl>();
            container.Bind<IMessageSelector<IChessGame>>().To<ChessMessageSelector>();
            container.Bind<ICellBitmapSelector<ChessPiece>>().To<ChessCellBitmapSelector>().WhenInjectedExactlyInto<ChessForm>();
            container.Bind<IMessageSelector<IWarChessGame>>().To<WarChessMessageSelector>();
            container.Bind<ICellBitmapSelector<ChessPiece>>().To<ChessCellBitmapSelector>().WhenInjectedExactlyInto<WarChessForm>();
            container.Bind(c => c
                .FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom<IGameForm>()
                .BindAllInterfaces());
        }

        [STAThread]
        public static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var container = new StandardKernel();
            BindContainer(container);
            IGameForm[] FormsSupplier() => container.GetAll<IGameForm>().ToArray();
            System.Windows.Forms.Application.Run(new MainForm(FormsSupplier));
        }
    }
}