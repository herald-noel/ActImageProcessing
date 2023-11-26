namespace ActImageProcessing
{
    internal class ImageProcess
    {
        private Bitmap loaded;
        private Bitmap processed;

        public ImageProcess(Bitmap loaded)
        {
            this.loaded = loaded;
            processed = new Bitmap(loaded.Width, loaded.Height);
        }

        public Bitmap? Loaded { get { return loaded; } }
        public Bitmap? Processed { get { return processed; } }

        // UTILS

        private int[] getHistogramData(ref Bitmap loaded, ref Bitmap processed)
        {
            Color sample;
            int[] histogramData = new int[256];

            for (int y = 0; y < loaded.Height; y++)
            {
                for (int x = 0; x < loaded.Width; x++)
                {
                    sample = processed.GetPixel(x, y);
                    histogramData[sample.R]++;
                }
            }
            return histogramData;
        }

        // ----------------------------------------

        public Bitmap Copy()
        {
            Color pixel;

            for (int y = 0; y < loaded.Height; y++)
            {
                for (int x = 0; x < loaded.Width; x++)
                {
                    pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, pixel);
                }
            }
            return processed;
        }

        public Bitmap Greyscale()
        {
            Color pixel;
            byte gray;

            for (int y = 0; y < loaded.Height; y++)
            {
                for (int x = 0; x < loaded.Width; x++)
                {
                    pixel = loaded.GetPixel(x, y);
                    gray = (byte)((pixel.R + pixel.G + pixel.B) / 3);
                    processed.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return processed;
        }

        public Bitmap ColorInversion()
        {
            Color pixel;

            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int y = 0; y < loaded.Height; y++)
            {
                for (int x = 0; x < loaded.Width - 1; x++)
                {
                    pixel = loaded.GetPixel(x, y);
                    processed.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }
            return processed;
        }

        public Bitmap Histogram()
        {
            Greyscale();

            // Get every pixel data
            int[] histogramData = getHistogramData(ref loaded, ref processed);
            // Color picturebox to white
            Bitmap data = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    data.SetPixel(x, y, Color.White);
                }
            }
            // Visualize the data
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histogramData[x] / 5, data.Height); y++)
                {
                    data.SetPixel(x, (data.Height - 1) - y, Color.Black);
                }
            }
            return data;
        }

        public Bitmap Sepia()
        {
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color originalPixel = loaded.GetPixel(x, y);

                    // Sepia Formula
                    int R = (int)(0.393 * originalPixel.R + 0.769 * originalPixel.G + 0.189 * originalPixel.B);
                    int G = (int)(0.349 * originalPixel.R + 0.686 * originalPixel.G + 0.168 * originalPixel.B);
                    int B = (int)(0.272 * originalPixel.R + 0.534 * originalPixel.G + 0.131 * originalPixel.B);

                    // Clamp values to be in the valid 0-255 range
                    int sepiaR = Math.Min(255, R);
                    int sepiaG = Math.Min(255, G);
                    int sepiaB = Math.Min(255, B);

                    processed.SetPixel(x, y, Color.FromArgb(sepiaR, sepiaG, sepiaB));
                }
            }
            return processed;
        }
    }
}
