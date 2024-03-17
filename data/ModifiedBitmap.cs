using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DownSizingAPP.data
{
    internal class ModifiedBitmap
    {
        private nint Iptr { get; set; }
        private BitmapData BitmapData { get; set; }
        private byte[] Pixels { get; set; }
        private int Depth { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }

        public Bitmap MyBitmap { get; set; }
        public ModifiedBitmap(Bitmap bitmap)
        {
            MyBitmap = bitmap;
            Width = MyBitmap.Width;
            Height = MyBitmap.Height;
            LockBitsOfBitmap(MyBitmap);
        }

        public ModifiedBitmap LockBitsOfBitmap(Bitmap bitmap)
        {
            int PixelCount = Width * Height;
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            Depth = Image.GetPixelFormatSize(bitmap.PixelFormat);
            if (Depth != 8 && Depth != 24 && Depth != 32)
            {
                throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
            }
            BitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite,
                                         bitmap.PixelFormat);
            int step = Depth / 8;
            Pixels = new byte[PixelCount * step];
            Iptr = BitmapData.Scan0;

            Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            return this;
        }

        public Color GetPixelOfBitmap(int x, int y)
        {
            Color clr = Color.Empty;
            int cCount = Depth / 8;

            int i = (y * Width + x) * cCount;

            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();
            clr = calculateColor(i);
            return clr;
        }

        public void SetPixelOfBitmap(int x, int y, Color color)
        {
            int cCount = Depth / 8;
            int i = (y * Width + x) * cCount;

            switch (Depth)
            {
                case 32:
                    {
                        Pixels[i] = color.B;
                        Pixels[i + 1] = color.G;
                        Pixels[i + 2] = color.R;
                        Pixels[i + 3] = color.A;
                        break;
                    }
                case 24:
                    {
                        Pixels[i] = color.B;
                        Pixels[i + 1] = color.G;
                        Pixels[i + 2] = color.R;
                        break;
                    }
                case 8:
                    {
                        Pixels[i] = color.B;
                        break;
                    }
            }
        }

        private Color calculateColor(int index)
        {
            switch (Depth)
            {
                case 32:
                    {
                        byte b = Pixels[index];
                        byte g = Pixels[index + 1];
                        byte r = Pixels[index + 2];
                        byte a = Pixels[index + 3]; // a
                        return Color.FromArgb(a, r, g, b);
                        break;
                    }
                case 24:
                    {
                        byte b = Pixels[index];
                        byte g = Pixels[index + 1];
                        byte r = Pixels[index + 2];
                        return Color.FromArgb(r, g, b);
                        break;
                    }
                case 8:
                    {
                        byte c = Pixels[index];
                        return Color.FromArgb(c, c, c);
                        break;
                    }
            }
            return Color.FromArgb(0, 0, 0);
        }

        public void UnlockBitsOfBitmap()
        {
            Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);
            MyBitmap.UnlockBits(BitmapData);
        }
    }
}
