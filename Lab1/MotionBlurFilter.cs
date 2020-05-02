using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter()
        {
            kernel = new float[,] { { 0.2f, 0, 0, 0, 0 }, { 0, 0.2f, 0, 0, 0 }, { 0, 0, 0.2f, 0, 0 }, { 0, 0, 0, 0.2f, 0 }, { 0, 0, 0, 0, 0.2f } };
        }
    }
}
