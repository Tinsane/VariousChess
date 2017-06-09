using System;
using System.Collections.Generic;
using System.Linq;
using WarChess.Domain.Chess.GameStateProvider;
using WarChess.Domain.Chess.Moves;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Domain.GridGame2D;

namespace WarChess.Domain.Chess
{
    public class ChessGame : ChessAlikeGame<ChessGameState, ChessCell, ChessPiece>, IChessGame
    {
        public ChessGame(IChessGameStateProvider gameStateProvider) : base(gameStateProvider.GetInitialGameState()) { }

        public IChessBoard<ChessPiece> Board =>
            (IChessBoard<ChessPiece>) CurrentState.Field;

        public bool IsMate => CurrentState.IsMate();
        public bool IsStaleMate => CurrentState.IsStaleMate();
        public Color WhoseTurn => (Color) CurrentState.CurrentPlayerId;

        public bool TryMakeMove(ChessPosition from, ChessPosition to)
            => TryMakeMove(from, (GridPosition2D) to);

        public bool IsCheck => CurrentState.IsCheck();

        protected IEnumerable<IChessAlikeMove<ChessGameState, ChessCell, ChessPiece>> GetPossibleMoves(
            GridPosition2D from, GridPosition2D to)
        {
            var sourceCell = CurrentState.Field[@from];
            return sourceCell.ContainsPiece ? sourceCell.Piece.GetPossibleMoves(from, to) : new List<IChessMove>();
        }

        public bool TryMakeMove(GridPosition2D from, GridPosition2D to)
        {
            if (!CurrentState.Field.Contains(from))
                throw new ArgumentException(nameof(from));
            if (!CurrentState.Field.Contains(to))
                throw new ArgumentException(nameof(to));
            return GetPossibleMoves(from, to).Any(TryMakeMove);
        }
    }
}