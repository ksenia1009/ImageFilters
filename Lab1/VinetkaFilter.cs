using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class VinetkaFilter : Filters
    {
        private double A1; //большая полуось вписанного эллипса
        private double B1; //малая полуось вписанного эллипса
        private double A2; //большая полуось внешнего эллипса
        private double B2; //малая полуось внешнего эллипса
        private double dA; //величина, на которую увеличивается большая полуось вписанного эллипса
        private double dB; //величина, на которую увеличивается малая полуось вписанного эллипса
        private double step = 10.0;
        private bool f;

        public VinetkaFilter(int Wimage, int Himage)
        {
            int large, small;
            if (Wimage > Himage)
            {
                large = Wimage;
                small = Himage;
                f = true;
            }
            else
            {
                small = Wimage;
                large = Himage;
                f = false;
            }
            A1 = large / 2;
            B1 = small / 2;
            A2 = Math.Sqrt(Wimage * Wimage + Himage * Himage);
            B2 = B1 * (A2 / A1);
            dA = 1.0;
            dB = 1.0;
        }
        private double InEllipse(int x, int y, double a, double b)
        {
            double value;
            if (f)
            {
                value = ((x - A1) * (x - A1)) / (a * a) + ((y - B1) * (y - B1)) / (b * b);
            }
            else
            {
                value = ((y - A1) * (y - A1)) / (a * a) + ((x - B1) * (x - B1)) / (b * b);
            }
            return value ;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            if (InEllipse(x, y, A1, B1) < 1)
            {
                return color;
            }
            else
            {
                double scale = 1;
                double curA = A1 + dA;
                double curB = B1 + dB;
                while (curA < A2 && curB < B2 && scale != 0)
                {
                    if (InEllipse(x, y, curA, curB) <= 1)
                    {
                        return Color.FromArgb(Clamp((int)(scale * sourceImage.GetPixel(x, y).R), 0, 255),
                            Clamp((int)(scale * sourceImage.GetPixel(x, y).G), 0, 255),
                            Clamp((int)(scale * sourceImage.GetPixel(x, y).B), 0, 255));
                    }
                    curA += dA;
                    curB += dB;
                    scale -= step / 450.0;
                }
            }
            return Color.Black;
        }
    }
}
