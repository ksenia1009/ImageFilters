using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class GlassFilter : Filters
    {
        private double nrand;
        Random rand = new Random();
        public GlassFilter()
        {
            Random rand = new Random();
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            nrand = rand.NextDouble();
            int nx = Clamp((int)(x + (nrand - 0.5) * 10), 0, sourceImage.Width - 1);
            int ny = Clamp((int)(y + (nrand - 0.5) * 10), 0, sourceImage.Height - 1);
            if (nx >= sourceImage.Width || nx < 0 || ny >= sourceImage.Height || ny < 0)
                return Color.FromArgb(0, 0, 0);
            else return sourceImage.GetPixel(nx, ny);
        }
    }
}
