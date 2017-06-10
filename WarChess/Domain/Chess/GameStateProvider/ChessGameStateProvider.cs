using System;
using System.Collections.Generic;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi;

namespace WarChess.Domain.Chess.GameStateProvider
{
    public class ChessGameStateProvider : IChessGameStateProvider
    {
        protected static readonly string[] InitialBoardRepr =
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

        public ChessGameStateProvider(IPawnTransformer pawnTransformer)
        {
            ChessPiece Transformer(int playerId) => pawnTransformer.GetTransformed((Color) playerId);
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
                {'P', () => new Pawn(Utils.WhitePlayerId, false, Transformer)},
                {'p', () => new Pawn(Utils.BlackPlayerId, false, Transformer)},
                {'.', () => null}
            };
        }

        private Dictionary<char, Func<ChessPiece>> ReprMapping { get; }

        protected ChessCell[,] GetBoard(string[] repr, Color moveColor)
        {
            var rowsCnt = repr.Length;
            var columnsCnt = repr[0].Length;
            var board = new ChessCell[rowsCnt, columnsCnt];
            for (var i = 0; i < rowsCnt; ++i)
            for (var j = 0; j < columnsCnt; ++j)
                board[i, j] = new ChessCell(ReprMapping[repr[i][j]]());
            return board;
        }

        public ChessGameState GetInitialGameState() => FromRepr(InitialBoardRepr);

        public ChessGameState FromRepr(string[] repr, Color moverColor = Color.White)
        {
            return new ChessGameState(new ChessBoard(GetBoard(repr, moverColor)), (int)moverColor);
        }
    }
}