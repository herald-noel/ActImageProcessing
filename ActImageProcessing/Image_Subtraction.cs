using System.ComponentModel;

namespace ActImageProcessing
{
    public partial class Image_Subtraction : Form
    {
        Bitmap imageA, imageB, colorGreen;
        OpenFileDialog openFileDialog;

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
    }
}
