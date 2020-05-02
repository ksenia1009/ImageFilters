using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Lab1
{
    class RemoveFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int nx = x + 100;
            int ny = y;
            if (nx >= sourceImage.Width)
                return Color.FromArgb(0, 0, 0);
            else return sourceImage.GetPixel(nx, ny);
        }
    }
}
