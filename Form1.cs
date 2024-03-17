using System.Diagnostics;
using System.Drawing;
using DownSizingAPP.utils;

namespace DownSizingAPP
{
    public partial class Form1 : Form
    {
        private Bitmap myBitmapData;
        public Form1()
        {
            InitializeComponent();
            DownSizeBtn.Enabled = false;
            DownSizeParallelBtn.Enabled = false;
            ScalingInput.Enabled = false;
            ClearImgBtn.Enabled = false;

        }

        private void SelectImg_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = $"Setting the image for resizing...";
            LoadImage();
            StatusLabel.Text = "Image is ready to be resized.";
            DownSizeBtn.Enabled = true;
            DownSizeParallelBtn.Enabled = true;
            ScalingInput.Enabled = true;
            ClearImgBtn.Enabled = true;
            SelectImgBtn.Enabled = false;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void DownSizeBtn_Click(object sender, EventArgs e)
        {
            if (myBitmapData != null)
            {
                String scaling = ScalingInput.Text;
                int scale;
                if (scaling != null && int.TryParse(scaling, out scale))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    StatusLabel.Text = "Starting normal down sizing ...";
                    stopwatch.Start();
                    Bitmap resizedImage = DownScalingUtils.DownScale(myBitmapData, scale);
                    stopwatch.Stop();
                    resizeForm(resizedImage);

                    PictureBox imageControl = new PictureBox();
                    imageControl.Height = resizedImage.Height;
                    imageControl.Width = resizedImage.Width;
                   
                    Image.GetThumbnailImageAbort aallback =
                            new Image.GetThumbnailImageAbort(ThumbnailCallback);

                    Image resizedImageThumbnail = resizedImage.GetThumbnailImage(resizedImage.Width, resizedImage.Height,
                        aallback, IntPtr.Zero);
                    imageControl.Image = resizedImageThumbnail;


                    NormalDowmSizePictureBox.Size = new Size(imageControl.Width, imageControl.Height);
                    ParallelDownSizePictureBox.Location = new Point(NormalDowmSizePictureBox.Location.X + NormalDowmSizePictureBox.Size.Width + 15, NormalDowmSizePictureBox.Location.Y);
                    NormalDowmSizePictureBox.Controls.Add(imageControl);
                    TimeStandart.Text = stopwatch.ElapsedMilliseconds.ToString();
                    StatusLabel.Text = "Finish normal down size!";
                }
            }
        }


        private void DownSizeParallel_Click(object sender, EventArgs e)
        {
            if (myBitmapData != null)
            {
                String scaling = ScalingInput.Text;
                int scale;
                if (scaling != null && int.TryParse(scaling, out scale))
                {
                    StatusLabel.Text = "Starting parallel down sizing ...";
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Bitmap resizedImage = DownScalingUtils.DownScaleInParallel(myBitmapData, scale);
                    stopwatch.Stop();

                    resizeForm(resizedImage);
                    PictureBox imageControl = new PictureBox();
                    imageControl.Height = resizedImage.Height;
                    imageControl.Width = resizedImage.Width;


                    Image.GetThumbnailImageAbort myCallback =
                            new Image.GetThumbnailImageAbort(ThumbnailCallback);

                    Image myThumbnail = resizedImage.GetThumbnailImage(resizedImage.Width, resizedImage.Height,
                        myCallback, IntPtr.Zero);
                    imageControl.Image = myThumbnail;

                    ParallelDownSizePictureBox.Location = new Point(NormalDowmSizePictureBox.Location.X + NormalDowmSizePictureBox.Size.Width + 15, NormalDowmSizePictureBox.Location.Y);
                    ParallelDownSizePictureBox.Size = new Size(imageControl.Width, imageControl.Height);
                    ParallelDownSizePictureBox.Controls.Add(imageControl);
                    TimeParallel.Text = stopwatch.ElapsedMilliseconds.ToString();
                    StatusLabel.Text = "Finish parallel down sizing!";
                }
            }
        }

        private void ClearImg_Click(object sender, EventArgs e)
        {
            if (NormalDowmSizePictureBox.Controls.Count > 0)
            {
                NormalDowmSizePictureBox.Controls.Clear();
            }

            if (ParallelDownSizePictureBox.Controls.Count > 0)
            {
                ParallelDownSizePictureBox.Controls.Clear();
            }
            myBitmapData.Dispose();
            TimeParallel.Text = "0";
            TimeStandart.Text = "0";
            DownSizeBtn.Enabled = false;
            DownSizeParallelBtn.Enabled = false;
            ScalingInput.Enabled = false;
            ClearImgBtn.Enabled = false;
            SelectImgBtn.Enabled = true;
            StatusLabel.Text = "Image removed!";

            NormalDowmSizePictureBox.Size = new Size(400, 200);
            ParallelDownSizePictureBox.Location = new Point(NormalDowmSizePictureBox.Location.X + NormalDowmSizePictureBox.Size.Width + 15, NormalDowmSizePictureBox.Location.Y);
            Size = new Size(1000, 550);
        }

        private void resizeForm(Bitmap bitmap)
        {
            if(bitmap.Width > Width / 2 || bitmap.Height > Height / 2)
            {
                AutoScroll = true;
            }
        }

        private void LoadImage()
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Image Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "img",
                Filter = "img files (*.jpg)|*.jpg",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        Image.GetThumbnailImageAbort callback =
                              new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        myBitmapData = new Bitmap(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
