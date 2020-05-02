using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class ClosingFilter : Filters //закрытие
    {
        private DilationFilter dilationFilter = new DilationFilter();
        private ErosionFilter erosionFilter = new ErosionFilter();

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return Color.White;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap res = dilationFilter.processImage(sourceImage, worker);
            Bitmap finalRes = erosionFilter.processImage(res, worker);

            return finalRes;
        }
    }
}
