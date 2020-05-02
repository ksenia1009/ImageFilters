using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class MedianFilter : Filters //медианный фильтр
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = 3;
            if (x < radius || x >= sourceImage.Width - radius - 1 || y < radius || y >= sourceImage.Height - radius - 1)
            {
                return sourceImage.GetPixel(x, y);
            }
            double[] intens = new double[(radius * 2 + 1) * (radius * 2 + 1)];
            Color[] pix = new Color[(radius * 2 + 1) * (radius * 2 + 1)];
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    intens[(i + radius) * (radius * 2 + 1) + j + radius] = 0.36 * sourceImage.GetPixel(x + i, y + j).R + 0.53 * sourceImage.GetPixel(x + i, y + j).G + 0.11 * sourceImage.GetPixel(x + i, y + j).B;
                    pix[(i + radius) * (radius * 2 + 1) + j + radius] = sourceImage.GetPixel(x + i, y + j);
                }
            }
            bool f = false;
            for (int i = 0; i < intens.Length; i++)
            {
                for (int j = 1; j < intens.Length; j++)
                {
                    if (intens[j] < intens[j - 1])
                    {
                        double intens1 = intens[j];
                        Color pix1 = pix[j];
                        intens[j] = intens[j - 1];
                        intens[j - 1] = intens1;
                        pix[j] = pix[j - 1];
                        pix[j - 1] = pix1;
                        f = true;
                    }
                }
                if (!f)
                {
                    break;
                }
            }
            return pix[pix.Length / 2];
        }
    }
}
