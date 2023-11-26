namespace ActImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap loaded;
        ImageProcess imgOperation;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    loaded = new Bitmap(ofd.FileName);
                    pictureBox1.Image = loaded;
                }
                imgOperation = new ImageProcess(loaded);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have not chosen an image.");
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox2.Image == null || pictureBox2 == null)
                {
                    throw new NullReferenceException();
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|All Files|*.*";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    // Get the image from the PictureBox
                    Image imageToSave = pictureBox2.Image;

                    // Save the image to the specified path
                    imageToSave.Save(saveFileDialog.FileName);

                    MessageBox.Show("Image saved successfully!");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no processed image.");
            }
        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = imgOperation.Copy();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please open a Bitmap/Png/Jpg files.");
            }
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                pictureBox2.Image = imgOperation.Greyscale();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please open a Bitmap/Png/Jpg files.");
            }
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                pictureBox2.Image = imgOperation.ColorInversion();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please open a Bitmap/Png/Jpg files.");
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                pictureBox2.Image = imgOperation.Histogram();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please open a Bitmap/Png/Jpg files.");
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                pictureBox2.Image = imgOperation.Sepia();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please open a Bitmap/Png/Jpg files.");
            }
        }

        private void subtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image_Subtraction IMAGE_SUBTRACTION = new();
            IMAGE_SUBTRACTION.Show();
        }
    }
}