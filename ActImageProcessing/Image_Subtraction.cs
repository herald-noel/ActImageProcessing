using System.ComponentModel;
using WebCamLib;

namespace ActImageProcessing
{
    public partial class Image_Subtraction : Form
    {
        Bitmap imageA, imageB, colorGreen;
        OpenFileDialog openFileDialog;

        Device[] device;

        public Image_Subtraction()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            imageB = new Bitmap(openFileDialog1.FileName);
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            imageA = new Bitmap(openFileDialog2.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = imageB;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            pictureBox2.Image = imageA;
        }

        private Bitmap Subract()
        {
            Bitmap resultImage = new Bitmap(imageB.Width, imageB.Height);

            Color myGreen = Color.FromArgb(0, 0, 255);
            int greyGreen = (myGreen.R + myGreen.G + myGreen.B) / 3;
            int threshold = 5;

            int imageBWidth = imageB.Width;
            int imageBHeight = imageB.Height;

            for (int x = 0; x < imageBWidth; x++)
            {
                for (int y = 0; y < imageBHeight; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backPixel = imageA.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractValue = Math.Abs(grey - greyGreen);

                    if (subtractValue < threshold)
                        resultImage.SetPixel(x, y, backPixel);
                    else
                        resultImage.SetPixel(x, y, pixel);
                }
            }
            return resultImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Subract();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            device = DeviceManager.GetAllDevices();
            device[0].ShowWindow(pictureBox1);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            device[0].Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            device[0].Sendmessage();
        }
    }
}
