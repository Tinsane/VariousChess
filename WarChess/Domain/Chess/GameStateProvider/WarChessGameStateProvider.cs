using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.ChessAlikeApi;
using WarChess.Domain.WarChess;

namespace WarChess.Domain.Chess.GameStateProvider
{
    class WarChessGameStateProvider : ChessGameStateProvider, IWarChessGameStateProvider
    {
        public WarChessGameStateProvider(IPawnTransformer pawnTransformer) : base(pawnTransformer)
        {
        }

        public WarChessGameState FromRepr(string[] repr, Color moverColor = Color.White)
        {
            return new WarChessGameState(new ChessBoard(GetBoard(repr, moverColor)), (int)moverColor);
        }

        public WarChessGameState GetInitialWarGameState() => FromRepr(InitialBoardRepr);
    }
}
