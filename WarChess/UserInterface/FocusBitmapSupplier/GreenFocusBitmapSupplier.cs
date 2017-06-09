using System.Drawing;

namespace WarChess.UserInterface.FocusBitmapSupplier
{
    public class GreenFocusBitmapSupplier : AbstractFocusBitmapSupplier
    {
        public override double FocusAreaPercent => 0.05;
        public override Color FocusColor => Color.Green;
    }
}
