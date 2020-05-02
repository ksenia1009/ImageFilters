using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class ErosionFilter : Filters //сужение
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = 3;
            bool b = false;

            for (int k = -radius; k <= radius; k++)
            {
                for (int l = -radius; l <= radius; l++)
                {
                    int nX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int nY = Clamp(y + l, 0, sourceImage.Height - 1);

                    Color srcColor = sourceImage.GetPixel(nX, nY);

                    if (srcColor.R <= 10 && srcColor.G <= 10 && srcColor.B <= 10)
                    {
                        b = true;
                        break;
                    }

                }
            }

            if (b)
                return Color.Black;
            else
                return Color.White;
        }
    }
}
