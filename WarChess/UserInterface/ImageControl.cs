using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarChess.UserInterface
{
    public class ImageControl : Control
    {
        private readonly Image image;

        public ImageControl(Image image)
        {
            this.image = image;
            MinimumSize = image.Size;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(image, 0, 0);
        }
    }
}
