using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class PruittaFilter : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float XresultR = 0;
            float XresultG = 0;
            float XresultB = 0;
            float YresultR = 0;
            float YresultG = 0;
            float YresultB = 0;

            kernel = new float[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    XresultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    XresultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    XresultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            kernel = new float[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    YresultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    YresultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    YresultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }

            return Color.FromArgb(Clamp((int)Math.Sqrt(YresultR * YresultR + XresultR * XresultR), 0, 255), Clamp((int)Math.Sqrt(YresultG * YresultG + XresultG * XresultG), 0, 255), Clamp((int)Math.Sqrt(YresultB * YresultB + XresultB * XresultB), 0, 255));
        }
    }
}
