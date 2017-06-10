using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.AbstractGame;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.GameStateProvider;
using WarChess.Domain.Chess.Moves;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.WarChess
{
    //First try
    //public class WarChessGame : ChessAlikeGame<WarChessGameState, ChessCell, ChessPiece>, IChessGame
    //{
    //    public WarChessGame(WarChessGameState initialGameState) : base(initialGameState) { }
    //    public WarChessGame(IWarChessGameStateProvider gameStateProvider) : base(gameStateProvider.GetInitialWarGameState()) { }

    //    public virtual IChessBoard<ChessPiece> Board =>
    //        (IChessBoard<ChessPiece>)CurrentState.Field;

    //    public bool IsFinished => !CurrentState.CanCurrentPlayerMove();
    //    public bool IsMate => CurrentState.IsMate();
    //    public bool IsStaleMate => CurrentState.IsStaleMate();
    //    public Color WhoseTurn => (Color)CurrentState.CurrentPlayerId;
    //    public bool TryMakeMove(ChessPosition from, ChessPosition to) => base.TryMakeMove(from, to);

    //    public bool IsCheck => CurrentState.IsCheck();

    //    protected override IEnumerable<IChessAlikeMove<WarChessGameState, ChessCell, ChessPiece>> GetPossibleMoves(
    //        GridPosition2D from, GridPosition2D to)
    //    {
    //        var sourceCell = CurrentState.Field[from];
    //        return sourceCell.ContainsPiece ? sourceCell.Piece.GetPossibleMoves(from, to) : new List<IChessMove>();
    //    }
    //}



    //Second try
    public class WarChessGame : ChessGame, IWarChessGame
    {
        private readonly WarBoard warBoard;
        private IChessBoard<ChessPiece> ActualBoard => (IChessBoard<ChessPiece>)CurrentState.Field;
        public override IChessBoard<ChessPiece> Board => warBoard;
        public bool PawnCanAttack => CurrentState.PawnCanAttack();

        public WarChessGame(ChessGameState initialGameState) : base(initialGameState)
        {
            warBoard = new WarBoard(this);
        }

        public WarChessGame(IChessGameStateProvider gameStateProvider) : base(gameStateProvider)
        {
            warBoard = new WarBoard(this);
        }

        private class WarBoard : IChessBoard<ChessPiece>
        {
            private readonly WarChessGame game;

            public WarBoard(WarChessGame game)
            {
                this.game = game;
            }

            public int RowCount => game.ActualBoard.RowCount;
            public int ColumnCount => game.ActualBoard.ColumnCount;

            public ChessPiece this[ChessPosition position]
                => game.ActualBoard[position]?.Color == game.WhoseTurn ? game.ActualBoard[position] : null;
        }
    }
}
