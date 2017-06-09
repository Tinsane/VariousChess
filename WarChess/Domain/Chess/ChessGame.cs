using System;
using System.Collections.Generic;
using WarChess.Domain.Chess.Moves;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlike;
using WarChess.Domain.ChessAlike.Moves;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Domain.GridGame2D;
using ChessPiece = WarChess.Domain.Chess.Pieces.ChessPiece;

namespace WarChess.Domain.Chess
{
    public class ChessGame : ChessAlikeGame<ChessGameState, ChessCell, ChessPiece>, IChessGame
    {
        public ChessGame(Func<ChessPiece> pawnTransformer) : base(GetInitialState(pawnTransformer)) { }

        public IChessBoard<ChessAlikeApi.Chess.ChessPiece> Board =>
            (IChessBoard<ChessAlikeApi.Chess.ChessPiece>) CurrentState.Field;

        public bool IsFinished => !CurrentState.CanCurrentPlayerMove();
        public Color WhoseTurn => (Color) CurrentState.CurrentPlayerId;

        public bool IsCheck => CurrentState.IsCheck();

        private static ChessGameState GetInitialState(Func<ChessPiece> pawnTransformer)
        {
            var field = new ChessCell[Utils.BoardSize, Utils.BoardSize];
            for (var i = 0; i < Utils.BoardSize; ++i)
            for (var j = 0; j < Utils.BoardSize; ++j)
                field[i, j] = new ChessCell();
            // Pawns
            for (var i = 0; i < Utils.BoardSize; ++i)
            {
                field[1, i] = new ChessCell(new Pawn(Utils.WhitePlayerId, false, pawnTransformer));
                field[Utils.BoardSize - 2, i] = new ChessCell(new Pawn(Utils.BlackPlayerId, false, pawnTransformer));
            }
            // Rooks
            field[0, 0] = new ChessCell(new Rook(Utils.WhitePlayerId, false));
            field[0, Utils.BoardSize - 1] = new ChessCell(new Rook(Utils.WhitePlayerId, false));
            field[Utils.BoardSize - 1, 0] = new ChessCell(new Rook(Utils.BlackPlayerId, false));
            field[Utils.BoardSize - 1, Utils.BoardSize - 1] = new ChessCell(new Rook(Utils.BlackPlayerId, false));
            // Knights
            field[0, 1] = new ChessCell(new Knight(Utils.WhitePlayerId));
            field[0, Utils.BoardSize - 2] = new ChessCell(new Knight(Utils.WhitePlayerId));
            field[Utils.BoardSize - 1, 1] = new ChessCell(new Knight(Utils.BlackPlayerId));
            field[Utils.BoardSize - 1, Utils.BoardSize - 2] = new ChessCell(new Knight(Utils.BlackPlayerId));
            // Bishops
            field[0, 2] = new ChessCell(new Bishop(Utils.WhitePlayerId));
            field[0, Utils.BoardSize - 3] = new ChessCell(new Bishop(Utils.WhitePlayerId));
            field[Utils.BoardSize - 1, 2] = new ChessCell(new Bishop(Utils.BlackPlayerId));
            field[Utils.BoardSize - 1, Utils.BoardSize - 3] = new ChessCell(new Bishop(Utils.BlackPlayerId));
            // Kings
            field[0, 4] = new ChessCell(new King(Utils.WhitePlayerId, false));
            field[Utils.BoardSize - 1, 4] = new ChessCell(new King(Utils.BlackPlayerId, false));
            // Queens
            field[0, 3] = new ChessCell(new Queen(Utils.WhitePlayerId));
            field[Utils.BoardSize - 1, 3] = new ChessCell(new Queen(Utils.BlackPlayerId));
            return new ChessGameState(new ChessBoard(field), Utils.WhitePlayerId, null);
        }

        protected override IEnumerable<IChessAlikeMove<ChessGameState, ChessCell, ChessPiece>> GetPossibleMoves(
            GridPosition2D from, GridPosition2D to)
        {
            var sourceCell = CurrentState.Field[from];
            return sourceCell.ContainsPiece ? sourceCell.Piece.GetPossibleMoves(from, to) : new List<IChessMove>();
        }
    }
}