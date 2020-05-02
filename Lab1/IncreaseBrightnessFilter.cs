using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class IncreaseBrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double k = 50.0;
            return Color.FromArgb(Clamp((int)(sourceColor.R + k), 0, 255), Clamp((int)(sourceColor.G + k), 0, 255), Clamp((int)(sourceColor.B + k), 0, 255));
        }
    }
}
