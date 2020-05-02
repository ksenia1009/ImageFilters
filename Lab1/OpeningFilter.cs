using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class OpeningFilter : Filters //раскрытие
    {
        private DilationFilter dilationFilter = new DilationFilter();
        private ErosionFilter erosionFilter = new ErosionFilter();

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y) 
        {
            return Color.White;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap res = erosionFilter.processImage(sourceImage, worker);
            Bitmap finalRes = dilationFilter.processImage(res, worker);

            return finalRes;
        }
    }
}
