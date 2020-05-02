using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class WaveFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int nx = Clamp((int)(x + 20 * Math.Sin(2 * Math.PI * y / 60)), 0, sourceImage.Width - 1);
            int ny = y;
            if (nx >= sourceImage.Width || nx < 0 || ny >= sourceImage.Height || ny < 0)
                return Color.FromArgb(0, 0, 0);
            else return sourceImage.GetPixel(nx, ny);
        }
    }
}
