using WarChess.Domain.Chess;
using WarChess.Domain.Chess.GameStateProvider;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;

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
        public WarChessGame(ChessGameState initialGameState) : base(initialGameState) { }

        public WarChessGame(IChessGameStateProvider gameStateProvider) : base(gameStateProvider) { }

        private IChessBoard<ChessPiece> ActualBoard => (IChessBoard<ChessPiece>) CurrentState.Field;
        public override IChessBoard<ChessPiece> Board => new WarBoard(ActualBoard, CurrentState.CurrentPlayerId);

        public bool PawnCanAttack => CurrentState.PawnCanAttack();

        private class WarBoard : IChessBoard<ChessPiece>
        {
            public WarBoard(IChessBoard<ChessPiece> actualBoard, int currentPlayerId)
            {
                ActualBoard = actualBoard;
                CurrentPlayerId = currentPlayerId;
            }

            private IChessBoard<ChessPiece> ActualBoard { get; }
            private int CurrentPlayerId { get; }

            public int RowCount => ActualBoard.RowCount;
            public int ColumnCount => ActualBoard.ColumnCount;

            public ChessPiece this[ChessPosition position]
                => ActualBoard[position]?.PlayerId == CurrentPlayerId ? ActualBoard[position] : null;
        }
    }
}