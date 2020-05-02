using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//фильтр Собеля, который сначала высчитывает интенсивность, потом применяем оператор собеля
namespace Lab1
{
    class SobelFilter2 : MatrixFilter
    {
        private float getIntensity(Color color)
        {
            return (float)(0.36 * color.R + 0.53 * color.G + 0.11 * color.B);
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float resultIntensityX = 0;
            float resultIntensityY = 0;
            kernel = new float[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultIntensityX += getIntensity(neighborColor) * kernel[k + radiusX, l + radiusY];
                }
            kernel = new float[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultIntensityY += getIntensity(neighborColor) * kernel[k + radiusX, l + radiusY];
                }

            return Color.FromArgb(Clamp((int)Math.Sqrt(resultIntensityY * resultIntensityY + resultIntensityX * resultIntensityX), 0, 255),
                Clamp((int)Math.Sqrt(resultIntensityY * resultIntensityY + resultIntensityX * resultIntensityX), 0, 255),
                Clamp((int)Math.Sqrt(resultIntensityY * resultIntensityY + resultIntensityX * resultIntensityX), 0, 255));

        }
    }
}
