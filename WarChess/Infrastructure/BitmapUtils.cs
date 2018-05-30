using System;
using System.Drawing;

namespace WarChess.Infrastructure
{
    public static class BitmapUtils
    {
        public static Bitmap GetMonochromeBitmap(int width, int height, Color color)
        {
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            using (var brush = new SolidBrush(color))
            {
                graphics.FillRectangle(brush, 0, 0, width, height);
            }
            return bitmap;
        }

        public static Bitmap GetColoredBitmap(Bitmap bitmap, Color color)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (var x = 0; x < bitmap.Width; ++x)
            for (var y = 0; y < bitmap.Height; ++y)
            {
                var curColor = bitmap.GetPixel(x, y);
                var newColor = Color.FromArgb(curColor.A, color.R, color.G, color.B);
                newBitmap.SetPixel(x, y, newColor);
            }
            return newBitmap;
        }

        public static Bitmap GetOverlayedBitmap(Bitmap under, Bitmap above)
        {
            var width = Math.Max(under.Width, above.Width);
            var height = Math.Max(under.Height, above.Height);
            var finalBitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(finalBitmap))
            {
                graphics.DrawImage(under, 0, 0);
                graphics.DrawImage(above, 0, 0);
            }
            return finalBitmap;
        }

        public static Bitmap[,] GetArrayOf(int width, int height, Func<int, int, Bitmap> getBitmap)
        {
            var arr = new Bitmap[width, height];
            for (var row = 0; row < width; ++row)
            for (var column = 0; column < width; ++column)
                arr[row, column] = getBitmap(row, column);
            return arr;
        }

        public static Bitmap[,] GetEmptyArray(int width, int height, int bitmapWidth, int bitmapHeight)
            => GetArrayOf(width, height, (w, h) => GetMonochromeBitmap(w, h, Color.FromArgb(0)));
    }
}