using System;
using System.Collections.Generic;
using WarChess.Domain.Chess.Pieces;

namespace WarChess.Domain.Chess
{
    public class ChessGameStateProvider
    {
        private static readonly string[] InitialBoardRepr =
        {
            "RNBQKBNR",
            "PPPPPPPP",
            "........",
            "........",
            "........",
            "........",
            "pppppppp",
            "rnbqkbnr"
        };

        public ChessGameStateProvider(Func<int, ChessPiece> pawnTransformer)
        {
            ReprMapping = new Dictionary<char, Func<ChessPiece>>
            {
                {'K', () => new King(Utils.WhitePlayerId, false)},
                {'k', () => new King(Utils.BlackPlayerId, false)},
                {'R', () => new Rook(Utils.WhitePlayerId, false)},
                {'r', () => new Rook(Utils.BlackPlayerId, false)},
                {'Q', () => new Queen(Utils.WhitePlayerId)},
                {'q', () => new Queen(Utils.BlackPlayerId)},
                {'B', () => new Bishop(Utils.WhitePlayerId)},
                {'b', () => new Bishop(Utils.BlackPlayerId)},
                {'N', () => new Knight(Utils.WhitePlayerId)},
                {'n', () => new Knight(Utils.BlackPlayerId)},
                {'P', () => new Pawn(Utils.WhitePlayerId, false, pawnTransformer)},
                {'p', () => new Pawn(Utils.BlackPlayerId, false, pawnTransformer)},
                {'.', () => null}
            };
        }

        private Dictionary<char, Func<ChessPiece>> ReprMapping { get; }

        public ChessGameState FromRepr(string[] repr)
        {
            var rowsCnt = repr.Length;
            var columnsCnt = repr[0].Length;
            var field = new ChessCell[rowsCnt, columnsCnt];
            for (var i = 0; i < rowsCnt; ++i)
            for (var j = 0; j < columnsCnt; ++j)
                field[i, j] = new ChessCell(ReprMapping[repr[i][j]]());
            return new ChessGameState(new ChessBoard(field), Utils.WhitePlayerId);
        }

        public ChessGameState GetInitialGameState() => FromRepr(InitialBoardRepr);
    }
}