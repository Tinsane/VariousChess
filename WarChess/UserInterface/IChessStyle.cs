using System.Drawing;

namespace WarChess.UserInterface
{
    public interface IChessStyle
    {
        // All the bitmaps should have size (width, height)
        int BitmapWidth { get; }
        int BitmapHeight { get; }
        Color BlackPieceColor { get; }
        Color WhitePieceColor { get; }
        Bitmap Pawn { get; }
        Bitmap Bishop { get; }
        Bitmap Knight { get; }
        Bitmap Rook { get; }
        Bitmap Queen { get; }
        Bitmap King { get; }
    }
}
