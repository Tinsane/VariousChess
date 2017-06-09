using System.Drawing;

namespace WarChess.UserInterface
{
    public interface IChessStyle
    {
        // All the bitmaps should have size (width, height)
        int BitmapWidth { get; }
        int BitmapHeight { get; }
        Bitmap WhitePawn { get; }
        Bitmap WhiteBishop { get; }
        Bitmap WhiteKnight { get; }
        Bitmap WhiteRook { get; }
        Bitmap WhiteQueen { get; }
        Bitmap WhiteKing { get; }
        Bitmap BlackPawn { get; }
        Bitmap BlackBishop { get; }
        Bitmap BlackKnight { get; }
        Bitmap BlackRook { get; }
        Bitmap BlackQueen { get; }
        Bitmap BlackKing { get; }
    }
}
