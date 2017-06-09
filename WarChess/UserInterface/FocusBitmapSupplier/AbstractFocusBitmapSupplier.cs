using System;
using System.Drawing;

namespace WarChess.UserInterface.FocusBitmapSupplier
{
    public abstract class AbstractFocusBitmapSupplier : IFocusBitmapSupplier
    {
        public Bitmap GetFocusBitmap(int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            var widthFromBorder = width * 0.5 * FocusAreaPercent;
            var heightFromBorder = height * 0.5 * FocusAreaPercent;
            for (int i = 0; i < width; ++i)
            for (int j = 0; j < height; ++j)
            {
                if (Math.Min(i, width - i - 1) < widthFromBorder ||
                    Math.Min(j, height - j - 1) < heightFromBorder)
                    bitmap.SetPixel(i, j, FocusColor);
                else
                    bitmap.SetPixel(i, j, Color.FromArgb(0));
            }
            return bitmap;
        }

        public abstract double FocusAreaPercent { get; }
        public abstract Color FocusColor { get; }
    }
}
