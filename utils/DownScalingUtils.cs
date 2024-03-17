using DownSizingAPP.data;

namespace DownSizingAPP.utils
{
    internal class DownScalingUtils
    {
        public static Bitmap DownScale(Bitmap image, int scalingFactor)
        {
            double scalling = (double)scalingFactor / 100;
            double newWidth = (int)(image.Width * scalling);
            double newHeight = (int)(image.Height * scalling);
            ModifiedBitmap originalImageData = new ModifiedBitmap(image);
            Bitmap resizedBitmap = new Bitmap((int)newWidth, (int)newHeight);
            ModifiedBitmap resizedBitmapData = new ModifiedBitmap(resizedBitmap);
            if (newHeight < newHeight)
            {
                double swap = newHeight;
                newHeight = newWidth;
                newWidth = swap;
            }

            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    float originalX = x / (float)scalling;
                    float originalY = y / (float)scalling;

                    int x1 = (int)Math.Floor(originalX);
                    int x2 = Math.Min(x1 + 1, image.Width - 1);
                    int y1 = (int)Math.Floor(originalY);
                    int y2 = Math.Min(y1 + 1, image.Height - 1);

                    Color colorX1Y1 = originalImageData.GetPixelOfBitmap(x1, y1);
                    Color colorX1Y2 = originalImageData.GetPixelOfBitmap(x1, y2);
                    Color colorX2Y1 = originalImageData.GetPixelOfBitmap(x2, y1);
                    Color colorX2Y2 = originalImageData.GetPixelOfBitmap(x2, y2);

                    float tx = originalX - x1;
                    float ty = originalY - y1;

                    float red = (1 - tx) * (1 - ty) * colorX1Y1.R + tx * (1 - ty) * colorX2Y1.R +
                                (1 - tx) * ty * colorX1Y2.R + tx * ty * colorX2Y2.R;
                    float green = (1 - tx) * (1 - ty) * colorX1Y1.G + tx * (1 - ty) * colorX2Y1.G +
                                  (1 - tx) * ty * colorX1Y2.G + tx * ty * colorX2Y2.G;
                    float blue = (1 - tx) * (1 - ty) * colorX1Y1.B + tx * (1 - ty) * colorX2Y1.B +
                                 (1 - tx) * ty * colorX1Y2.B + tx * ty * colorX2Y2.B;

                    Color interpolatedColor = Color.FromArgb((int)red, (int)green, (int)blue);
                    resizedBitmapData.SetPixelOfBitmap(x, y, interpolatedColor);
                }
            }
            originalImageData.UnlockBitsOfBitmap();
            resizedBitmapData.UnlockBitsOfBitmap();
            return resizedBitmap;
        }

        public static Bitmap DownScaleInParallel(Bitmap image, int scalingFactor)
        {
            double scalling = (double)scalingFactor / 100;
            int originWidth = image.Width;
            int originHeight = image.Height;
            double newWidth = (int)(image.Width * scalling);
            double newHeight = (int)(image.Height * scalling);
            ModifiedBitmap originalImageData = new ModifiedBitmap(image);
            Bitmap resizedBitmap = new Bitmap((int)newWidth, (int)newHeight);
            ModifiedBitmap resizedBitmapData = new ModifiedBitmap(resizedBitmap);
            object lockObject = new object();

            if (newHeight < newHeight)
            {
                double swap = newHeight;
                newHeight = newWidth;
                newWidth = swap;
            }

            Parallel.For(0, (int)newHeight, y =>
            {
                for (int x = 0; x < newWidth; x++)
                {
                    float originalX = x / (float)scalling;
                    float originalY = y / (float)scalling;

                    int x1, x2, y1, y2;
                    Color colorX1Y1, colorX1Y2, colorX2Y1, colorX2Y2;

                    x1 = (int)Math.Floor(originalX);
                    x2 = Math.Min(x1 + 1, originWidth - 1);
                    y1 = (int)Math.Floor(originalY);
                    y2 = Math.Min(y1 + 1, originHeight - 1);

                    lock (lockObject)
                    {
                        colorX1Y1 = originalImageData.GetPixelOfBitmap(x1, y1);
                    }
                    lock (lockObject)
                    {
                        colorX1Y2 = originalImageData.GetPixelOfBitmap(x1, y2);
                    }
                    lock (lockObject)
                    {
                        colorX2Y1 = originalImageData.GetPixelOfBitmap(x2, y1);
                    }
                    lock (lockObject)
                    {
                        colorX2Y2 = originalImageData.GetPixelOfBitmap(x2, y2);
                    }

                    float tx = originalX - x1;
                    float ty = originalY - y1;

                    float red = (1 - tx) * (1 - ty) * colorX1Y1.R + tx * (1 - ty) * colorX2Y1.R +
                                (1 - tx) * ty * colorX1Y2.R + tx * ty * colorX2Y2.R;
                    float green = (1 - tx) * (1 - ty) * colorX1Y1.G + tx * (1 - ty) * colorX2Y1.G +
                                  (1 - tx) * ty * colorX1Y2.G + tx * ty * colorX2Y2.G;
                    float blue = (1 - tx) * (1 - ty) * colorX1Y1.B + tx * (1 - ty) * colorX2Y1.B +
                                 (1 - tx) * ty * colorX1Y2.B + tx * ty * colorX2Y2.B;

                    Color interpolatedColor = Color.FromArgb((int)red, (int)green, (int)blue);

                    lock (lockObject)
                    {
                        resizedBitmapData.SetPixelOfBitmap(x, y, interpolatedColor);

                    }
                }
            });

            originalImageData.UnlockBitsOfBitmap();
            resizedBitmapData.UnlockBitsOfBitmap();
            return resizedBitmap;
        }
    }
}
