using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Lab1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        private int width1;
        private int height1;
        private Stack<Bitmap> image1 = new Stack<Bitmap>();
        private Stack<Bitmap> image2 = new Stack<Bitmap>();

        public Form1()
        {
            InitializeComponent();
            width1 = 0;
            height1 = 0;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp; | All files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
            }
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                image1.Push(new Bitmap(pictureBox1.Image));
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чернобелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void увеличениеЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new IncreaseBrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(dialog.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                pictureBox1.Image.Save(dialog.FileName, format);
            }

        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new RemoveFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new WaveFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void motionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new CharraFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрПриюттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PruittaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (width1 != 0 && height1 != 0)
            {
                int dx = Width - width1;
                int dy = Height - height1;
                pictureBox1.Width = pictureBox1.Width + dx;
                pictureBox1.Height = pictureBox1.Height + dy;
                progressBar1.Location = new Point(progressBar1.Location.X, progressBar1.Location.Y + dy);
                progressBar1.Width = progressBar1.Width + dx;
                button1.Location = new Point(button1.Location.X + dx, button1.Location.Y + dy);
            }
            height1 = Height;
            width1 = Width;
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image1.Count > 0)
            {
                image2.Push(image);
                image = image1.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DilationFilter filter = new DilationFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErosionFilter filter = new ErosionFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningFilter filter = new OpeningFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosingFilter filter = new ClosingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopHatFilter filter = new TopHatFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйФильтрToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void фильтрСобеля2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new SobelFilter2());
        }

        private void виньеткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VinetkaFilter filter = new VinetkaFilter(pictureBox1.Image.Width, pictureBox1.Image.Height);
            backgroundWorker1.RunWorkerAsync(filter);
        }


    }
}
