using System;
using System.Drawing;
using WarChess.Domain.Chess.Pieces;
using WarChess.Domain.ChessAlikeApi.Chess;
using WarChess.Infrastructure;

namespace WarChess.UserInterface.ChessUI
{
    public class ChessCellBitmapSelector : ICellBitmapSelector<ChessPiece>, IChessPieceVisitor
    {
        private readonly IChessStyle style;
        private Bitmap selectedBitmap;

        public ChessCellBitmapSelector(IChessStyle style)
        {
            this.style = style;
        }

        public int BitmapWidth => style.BitmapWidth;

        public int BitmapHeight => style.BitmapHeight;

        public Bitmap SelectBitmap(ChessPiece piece)
        {
            if (piece == null)
                return BitmapUtils.GetMonochromeBitmap(BitmapWidth, BitmapHeight, Color.FromArgb(0));
            piece.AcceptVisitor(this);
            return selectedBitmap;
        }

        public void Visit(Bishop bishop) => selectedBitmap = bishop.Color == Domain.ChessAlikeApi.Color.Black ? style.BlackBishop : style.WhiteBishop;

        public void Visit(King king) => selectedBitmap = king.Color == Domain.ChessAlikeApi.Color.Black ? style.BlackKing : style.WhiteKing;

        public void Visit(Queen queen) => selectedBitmap = queen.Color == Domain.ChessAlikeApi.Color.Black ? style.BlackQueen : style.WhiteQueen;

        public void Visit(Knight knight) => selectedBitmap = knight.Color == Domain.ChessAlikeApi.Color.Black ? style.BlackKnight : style.WhiteKnight;

        public void Visit(Pawn pawn) => selectedBitmap = pawn.Color == Domain.ChessAlikeApi.Color.Black ? style.BlackPawn : style.WhitePawn;

        public void Visit(Rook rook) => selectedBitmap = rook.Color == Domain.ChessAlikeApi.Color.Black ? style.BlackRook : style.WhiteRook;
    }
}
