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
            var color = piece.Color == Domain.ChessAlikeApi.Color.Black
                ? style.BlackPieceColor
                : style.WhitePieceColor;
            return BitmapUtils.GetColoredBitmap(selectedBitmap, color);
        }

        public void Visit(Bishop bishop) => selectedBitmap = style.Bishop;

        public void Visit(King king) => selectedBitmap = style.King;

        public void Visit(Queen queen) => selectedBitmap = style.Queen;

        public void Visit(Knight knight) => selectedBitmap = style.Knight;

        public void Visit(Pawn pawn) => selectedBitmap = style.Pawn;

        public void Visit(Rook rook) => selectedBitmap = style.Rook;
    }
}
