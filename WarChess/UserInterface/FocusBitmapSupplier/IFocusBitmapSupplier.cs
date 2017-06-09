using System.Drawing;

namespace WarChess.UserInterface.FocusBitmapSupplier
{
    public interface IFocusBitmapSupplier
    {
        Bitmap GetFocusBitmap(int width, int height);
    }
}
