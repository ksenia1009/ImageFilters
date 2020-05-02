using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double k = 40.0;
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intensity = 0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B;
            return Color.FromArgb(Clamp((int)(Intensity + 2 * k), 0, 255), Clamp((int)(Intensity + 0.5 * k), 0, 255), Clamp((int)(Intensity - 1 * k), 0, 255));
        }
    }
}
