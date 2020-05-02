using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class DilationFilter : Filters //расширение
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = 3;
            bool w = false;

            for (int k = -radius; k <= radius; k++)
            {
                for (int l = -radius; l <= radius; l++)
                {
                    int nX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int nY = Clamp(y + l, 0, sourceImage.Height - 1);

                    Color srcColor = sourceImage.GetPixel(nX, nY);

                    if (srcColor.R >= 250 && srcColor.G >= 250 && srcColor.B >= 250)
                    {
                        w = true;
                        break;
                    }

                }
            }

            if (w)
                return Color.White;
            else
                return Color.Black;

        }
    }
}
