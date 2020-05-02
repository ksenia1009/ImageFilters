using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class TopHatFilter : Filters
    {
        private ClosingFilter closingf = new ClosingFilter();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return Color.White;
        }
        public override Bitmap processImage(Bitmap sourceImage, System.ComponentModel.BackgroundWorker worker)
        {
            Bitmap copyim = sourceImage;
            Bitmap resultim = closingf.processImage(sourceImage, worker);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int resultR = Clamp(copyim.GetPixel(i, j).R - resultim.GetPixel(i, j).R, 0, 255);
                    int resultG = Clamp(copyim.GetPixel(i, j).G - resultim.GetPixel(i, j).G, 0, 255);
                    int resultB = Clamp(copyim.GetPixel(i, j).B - resultim.GetPixel(i, j).B, 0, 255);
                    Color resultColor = Color.FromArgb(resultR, resultG, resultB);
                    resultim.SetPixel(i, j, resultColor);
                }
            }
            return resultim;
        }
    }
}
